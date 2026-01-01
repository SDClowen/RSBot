using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;

namespace RSBot.Python.Components.API.ModuleLoader
{
    /// <summary>
    /// Finds and loads all plugin classes that implement the IPythonPlugin interface.
    /// Saves them in a dictionary for later access.
    /// </summary>
    public static class ModuleLoader
    {
        private static readonly Dictionary<string, IPythonPlugin> _plugins = new();

        /// <summary>
        /// Finds all plugin classes, initializes them, and stores them.
        /// This method is called once at the start of the application.
        /// </summary>
        public static void InitAll(Main form)
        {
            var pluginType = typeof(IPythonPlugin);

            var pluginInstances = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())                  
                .Where(t => pluginType.IsAssignableFrom(t)      
                            && !t.IsInterface                   
                            && !t.IsAbstract)
                .Select(t => (IPythonPlugin)Activator.CreateInstance(t)!);
            foreach (var plugin in pluginInstances)
            {
                plugin.Init(form);                         
                _plugins[plugin.ModuleName] = plugin;
                form.AppendLog($"[Python-API] Plugin loaded: {plugin.ModuleName}");
            }
        }

        /// <summary>
        /// Returns a plugin by its name.
        /// Example: Get("core") → CoreAPI instance
        /// </summary>
        public static IPythonPlugin Get(string moduleName)
        {
            _plugins.TryGetValue(moduleName, out var plugin);
            return plugin;
        }

        /// <summary>
        /// Returns all plugins (e.g., for Python or debugging).
        /// </summary>
        public static Dictionary<string, object> GetAll()
        {
            return _plugins.ToDictionary(
                x => x.Key,
                x => (object)x.Value
            );
        }
    }
}
