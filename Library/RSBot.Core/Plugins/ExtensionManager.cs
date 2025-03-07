using RSBot.Core.Event;
using RSBot.Core.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RSBot.Core.Plugins;

public class ExtensionManager
{
    /// <summary>
    ///     Gets the extension directory for plugins.
    /// </summary>
    private static readonly string _directoryForPlugins = Path.Combine(Kernel.BasePath, "Data", "Plugins");

    /// <summary>
    ///     Gets the extension directory for botbases.
    /// </summary>
    private static readonly string _directoryForBotbases = Path.Combine(Kernel.BasePath, "Data", "Bots");

    /// <summary>
    ///     Gets the extensions.
    /// </summary>
    private static readonly List<IExtension> _extensions = [];

    /// <summary>
    ///    Gets the plugins.
    /// </summary>
    public static IEnumerable<IPlugin> Plugins => _extensions.OfType<IPlugin>().OrderBy(p => p.Index);

    /// <summary>
    /// Gets the botbases.
    /// </summary>
    public static IEnumerable<IBotbase> Bots => _extensions.OfType<IBotbase>();

    /// <summary>
    ///     Loads the assemblies.
    /// </summary>
    public static bool LoadAssemblies<T>() where T : IExtension
    {
        try
        {
            var name = typeof(T).Name;

            foreach (var extension in from file in 
                                          Directory.GetFiles(name == "IPlugin" ? _directoryForPlugins : _directoryForBotbases)
                     let fileInfo = new FileInfo(file)
                     where fileInfo.Extension == ".dll"
                     select GetExtensionsFromAssembly<T>(file)
                     into loadedExtensions
                     from extension in loadedExtensions
                     select extension)
            {
                _extensions.Add(extension);
                Log.Debug($"Loaded {name} [{extension.InternalName}]");
            }

            if(name == "IPlugin")
                EventManager.FireEvent("OnLoadPlugins");
            else
                EventManager.FireEvent("OnLoadBotbases");

            return true;
        }
        catch (Exception ex)
        {
            File.WriteAllText(Kernel.BasePath + "\\boot-error.log",
                $"The plugin manager encountered a problem: \n{ex.Message} at {ex.StackTrace}");
            return false;
        }
    }

    /// <summary>
    ///     Gets the extensions from assembly.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns></returns>
    private static List<T> GetExtensionsFromAssembly<T>(string file) 
        where T : IExtension
    {
        var result = new List<T>();

        var assembly = Assembly.LoadFrom(file);

        try
        {
            var assemblyTypes = assembly.GetTypes();

            foreach (var extension in (from type in assemblyTypes
                         where type.IsPublic && !type.IsAbstract && type.GetInterface(typeof(T).Name) != null
                         select Activator.CreateInstance(type)).OfType<T>())
                result.Add(extension);

            if (result.Count == 0)
                return result;

            var handlerType = typeof(IPacketHandler);
            var hookType = typeof(IPacketHook);

            var types = assemblyTypes
                .Where(p => handlerType.IsAssignableFrom(p) && !p.IsInterface);

            foreach (var handler in types)
                PacketManager.RegisterHandler((IPacketHandler)Activator.CreateInstance(handler));

            types = assemblyTypes
                .Where(p => hookType.IsAssignableFrom(p) && !p.IsInterface);

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