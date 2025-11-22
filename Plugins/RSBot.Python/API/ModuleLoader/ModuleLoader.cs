using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Python;
using RSBot.Python.API;
using RSBot.Python.Views;

namespace RSBot.Python.API.ModuleLoader
{
    /// <summary>
    /// Der ModuleLoader ist dafür zuständig, automatisch alle Klassen zu finden,
    /// die das Interface IPythonPlugin implementieren.
    /// Er erstellt dann Instanzen dieser Klassen, ruft Init() auf
    /// und speichert sie in einem Dictionary für späteren Zugriff.
    /// </summary>
    public static class ModuleLoader
    {
        // Hier speichern wir später alle Plugins, zugreifbar über ihren Namen.
        private static readonly Dictionary<string, IPythonPlugin> _plugins = new();

        /// <summary>
        /// Findet alle Plugin-Klassen, initialisiert sie und speichert sie.
        /// Diese Methode wird einmal beim Start der Anwendung aufgerufen.
        /// </summary>
        /// <param name="form">Die Hauptform (Form1), die an jedes Plugin übergeben wird.</param>
        public static void InitAll(Main form)
        {
            // Typ des Interfaces holen (IPythonPlugin)
            var pluginType = typeof(IPythonPlugin);

            // Alle Typen in allen geladenen Assemblies durchsuchen
            var pluginInstances = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())                  // Alle Typen jeder Assembly
                .Where(t => pluginType.IsAssignableFrom(t)      // Typ implementiert IPythonPlugin
                            && !t.IsInterface                   // Kein Interface
                            && !t.IsAbstract)                   // Keine abstrakte Klasse
                .Select(t => (IPythonPlugin)Activator.CreateInstance(t)!);
            // Activator.CreateInstance erstellt ein Objekt zur Laufzeit

            // Jetzt initialisieren wir alle gefundenen Plugins
            foreach (var plugin in pluginInstances)
            {
                plugin.Init(form);                              // Form1 an das Plugin übergeben
                _plugins[plugin.ModuleName] = plugin;           // Unter plugin.ModuleName speichern
                form.AppendLog($"Plugin geladen: {plugin.ModuleName}");
            }
        }

        /// <summary>
        /// Gibt ein Plugin anhand seines Namens zurück.
        /// Beispiel: Get("core") → CoreAPI-Instanz
        /// </summary>
        public static IPythonPlugin? Get(string moduleName)
        {
            _plugins.TryGetValue(moduleName, out var plugin);
            return plugin;
        }

        /// <summary>
        /// Gibt alle Plugins zurück (z. B. für Python oder Debugging).
        /// </summary>
        public static Dictionary<string, object> GetAll()
        {
            return _plugins.ToDictionary(
                x => x.Key,
                x => (object)x.Value  // wichtig: konkrete Klasse zurückgeben
            );
        }
    }
}
