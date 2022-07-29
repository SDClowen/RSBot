using RSBot.Core.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RSBot.Core.Plugins
{
    public class BotbaseManager
    {
        /// <summary>
        /// Gets the extension directory.
        /// </summary>
        /// <value>
        /// The extension directory.
        /// </value>
        public string DirectoryPath => Path.Combine(Environment.CurrentDirectory, "Data", "Bots");

        /// <summary>
        /// Gets the extensions.
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public Dictionary<string, IBotbase> Bots { get; private set; }

        /// <summary>
        /// Loads the assemblies.
        /// </summary>
        public bool LoadAssemblies()
        {
            if (Bots != null) return false;

            try
            {
                Bots = new Dictionary<string, IBotbase>();

                foreach (var extension in from file in Directory.GetFiles(DirectoryPath)
                                          let fileInfo = new FileInfo(file)
                                          where fileInfo.Extension == ".dll"
                                          select GetExtensionsFromAssembly(file)
                    into loadedExtensions
                                          from extension in loadedExtensions
                                          select extension)
                {
                    Bots.Add(extension.Key, extension.Value);
                    Log.Debug($"Loaded botbase [{extension.Value.Info.Name}]");
                }

                EventManager.FireEvent("OnLoadBotbases");

                return true;
            }
            catch (Exception ex)
            {
                File.WriteAllText(Environment.CurrentDirectory + "\\boot-error.log", $"The botbase manager encountered a problem: \n{ex.Message} at {ex.StackTrace}");
                return false;
            }
        }

        /// <summary>
        /// Gets the extensions from assembly.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        private static Dictionary<string, IBotbase> GetExtensionsFromAssembly(string file)
        {
            var result = new Dictionary<string, IBotbase>();

            var assembly = Assembly.LoadFrom(file);

            try
            {
                var types = assembly.GetTypes();

                foreach (var extension in (from type in types where type.IsPublic && !type.IsAbstract && type.GetInterface("IBotbase") != null select Activator.CreateInstance(type)).OfType<IBotbase>())
                {
                    result.Add(extension.Info.Name, extension);
                }
            }
            catch { /* ignore, it's an invalid botbase */ }

            return result;
        }
    }
}