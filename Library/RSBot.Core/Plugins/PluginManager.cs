using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using RSBot.Core.Event;
using RSBot.Core.Network;

namespace RSBot.Core.Plugins;

public class PluginManager
{
    /// <summary>
    ///     Gets the extension directory.
    /// </summary>
    /// <value>
    ///     The extension directory.
    /// </value>
    public string InitialDirectory => Path.Combine(Kernel.BasePath, "Data", "Plugins");

    /// <summary>
    ///     Gets the extensions.
    /// </summary>
    /// <value>
    ///     The extensions.
    /// </value>
    public Dictionary<string, IPlugin> Extensions { get; private set; }

    /// <summary>
    ///     Loads the assemblies.
    /// </summary>
    public bool LoadAssemblies()
    {
        if (Extensions != null)
            return false;

        Extensions = new Dictionary<string, IPlugin>();

        try
        {
            foreach (
                var extension in from file in Directory.GetFiles(InitialDirectory)
                let fileInfo = new FileInfo(file)
                where fileInfo.Extension == ".dll"
                select GetExtensionsFromAssembly(file) into loadedExtensions
                from extension in loadedExtensions
                select extension
            )
            {
                Extensions.Add(extension.Key, extension.Value);
                Log.Debug($"Loaded plugin [{extension.Value.InternalName}]");
            }

            //order by index, not alphabeticaly
            Extensions = Extensions.OrderBy(entry => entry.Value.Index).ToDictionary(x => x.Key, x => x.Value);

            EventManager.FireEvent("OnLoadPlugins");

            return true;
        }
        catch (Exception ex)
        {
            File.WriteAllText(
                Kernel.BasePath + "\\boot-error.log",
                $"The plugin manager encountered a problem: \n{ex.Message} at {ex.StackTrace}"
            );
            return false;
        }
    }

    /// <summary>
    ///     Gets the extensions from assembly.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns></returns>
    private static Dictionary<string, IPlugin> GetExtensionsFromAssembly(string file)
    {
        var result = new Dictionary<string, IPlugin>();

        var assembly = Assembly.LoadFrom(file);

        try
        {
            var assemblyTypes = assembly.GetTypes();

            foreach (
                var extension in (
                    from type in assemblyTypes
                    where type.IsPublic && !type.IsAbstract && type.GetInterface("IPlugin") != null
                    select Activator.CreateInstance(type)
                ).OfType<IPlugin>()
            )
                result.Add(extension.InternalName, extension);

            if (result.Count == 0)
                return result;

            var handlerType = typeof(IPacketHandler);
            var hookType = typeof(IPacketHook);

            var types = assemblyTypes.Where(p => handlerType.IsAssignableFrom(p) && !p.IsInterface).ToArray();

            foreach (var handler in types)
                PacketManager.RegisterHandler((IPacketHandler)Activator.CreateInstance(handler));

            types = assemblyTypes.Where(p => hookType.IsAssignableFrom(p) && !p.IsInterface).ToArray();

            foreach (var hook in types)
                PacketManager.RegisterHook((IPacketHook)Activator.CreateInstance(hook));
        }
        catch
        {
            /* ignore, it's an invalid extension */
        }

        return result;
    }
}
