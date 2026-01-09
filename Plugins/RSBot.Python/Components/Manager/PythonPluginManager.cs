using PeNet.Header.Resource;
using Python.Runtime;
using RSBot.Python.Components.API.Handler;
using RSBot.Python.Components.API.ModuleLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RSBot.Python.Plugins
{
    public class PythonPluginManager
    {
        private readonly List<PyObject> _loadedPlugins = new();

        public IReadOnlyList<PyObject> LoadedPlugins => _loadedPlugins;

        public List<PythonPluginInfo> ScanPlugins(string projectDir, Action<string> log)
        {
            string pluginDir = Path.Combine(projectDir, "Data", "Python", "Plugins");
            if (!Directory.Exists(pluginDir))
            {
                Directory.CreateDirectory(pluginDir);
            }

            string[] pythonFiles = Directory.GetFiles(pluginDir, "*.py", SearchOption.TopDirectoryOnly);

            var result = new List<PythonPluginInfo>();

            foreach (string file in pythonFiles)
            {
                var info = PluginMetaReader.ReadPythonPluginInfo(file);
                result.Add(info);
            } 

            log($"[Python-API] Found {pythonFiles.Length} Plugins.");
            return result;
        }

        public void RunPlugin(string projectDir, string fileName, Action<string> log)
        {
            Task.Run(() =>
            {
                try
                {
                    string pluginsDir = Path.Combine(projectDir, "Data", "Python", "Plugins");
                    string pluginPath = Path.Combine(pluginsDir, fileName);

                    using (Py.GIL())
                    {
                        dynamic importlib = Py.Import("importlib.util");
                        string moduleName = "plugin_" + Path.GetFileNameWithoutExtension(fileName);

                        dynamic spec = importlib.spec_from_file_location(moduleName, pluginPath);
                        dynamic module = importlib.module_from_spec(spec);
                        spec.loader.exec_module(module);

                        _loadedPlugins.Add(module);
                    }
                }
                catch (Exception ex)
                {
                    log($"[Python-API][Error] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                }
            });
        }
        public void UnloadPlugin(string fileName, Action<string> log)
        {
            using (Py.GIL())
            {
                try
                {
                    string moduleName = "plugin_" + Path.GetFileNameWithoutExtension(fileName);

                    dynamic sys = Py.Import("sys");
                    if (sys.modules.__contains__(moduleName))
                        sys.modules.pop(moduleName, null);

                    _loadedPlugins.RemoveAll(p =>
                    {
                        try
                        {
                            return p.GetAttr("__name__").ToString() == moduleName;
                        }
                        catch { return false; }
                    });

                    dynamic gc = Py.Import("gc");
                    gc.collect();

                    log($"[Python-API] Plugin unloaded: {fileName}");
                }
                catch (Exception ex)
                {
                    log($"[Python-API][Unload Error] {fileName}: {ex.Message}");
                }
            }
        }

        public void ResetPlugins()
        {
            if (_loadedPlugins.Count == 0) return;

            using (Py.GIL())
            {
                foreach (var m in _loadedPlugins)
                    m.Dispose();

                _loadedPlugins.Clear();
            }
        }
        public void CallPluginEvent(string e, Action<string> log, params object[] args)
        {
            using (Py.GIL())
            {
                var pyArgs = args?
                    .Select(a => a == null ? PyObject.None : a.ToPython())
                    .ToArray()
                    ?? Array.Empty<PyObject>();

                foreach (PyObject plugin in _loadedPlugins)
                {
                    try
                    {
                        if (!plugin.HasAttr(e))
                            continue;

                        using PyObject func = plugin.GetAttr(e);
                        func.Invoke(pyArgs);
                    }
                    catch (Exception ex)
                    {
                        log($"[Python-API][Plugin-Event Error] {e}: {ex.Message}");
                    }
                }

                foreach (var a in pyArgs)
                    a.Dispose();
            }
        }

    }
}
