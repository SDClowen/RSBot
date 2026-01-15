using Python.Runtime;
using RSBot.Python.Components.API.Handler;
using RSBot.Python.Components.API.ModuleLoader;
using System;
using System.IO;
using System.Linq;


namespace RSBot.Python.Components.Loader
{
    public class PythonRuntimeManager
    {
        public bool IsInitialized { get; private set; }

        public void Initialize(string projectDir, Action<string> log)
        {
            if (IsInitialized) return;

            string pythonHome = Path.Combine(projectDir, "Data", "Python", "PyRuntime");
            string pythonDll = Directory.GetFiles(pythonHome, "python31*.dll").FirstOrDefault();
            string zipPath = Directory.GetFiles(pythonHome, "python31*.zip").FirstOrDefault();

            if (pythonDll == null)
            {
                log("[Python-API] Couldn´t find any Python-DLL!");
                return;
            }

            Runtime.PythonDLL = pythonDll;

            PythonEngine.PythonHome = pythonHome;
            PythonEngine.PythonPath = $"{pythonHome};{zipPath};{Path.Combine(pythonHome, "Lib")}";

            PythonEngine.Initialize();
            PythonEngine.BeginAllowThreads();

            using (Py.GIL())
            {
                try
                {
                    PythonEngine.Exec(@"
import clr, sys, types
clr.AddReference('RSBot.Python')
from RSBot.Python.Components.API.ModuleLoader import PythonPluginAccessor

RSBot = types.ModuleType('RSBot')
plugins = PythonPluginAccessor.all()

for name, plugin in plugins.items():
    for attr_name in dir(plugin):
        if attr_name.startswith('_'):
            continue
        attr = getattr(plugin, attr_name)
        if callable(attr):
            setattr(RSBot, attr_name, attr)

sys.modules['RSBot'] = RSBot

from RSBot.Python.Components.API.GUI import WFAPI
RSBot.GUI = WFAPI.GUI
");
                    IsInitialized = true;
                    log("[Python-API] Python initialised and created RSBot-Modul.");
                }
                catch (PythonException ex)
                {
                    var formatted = PythonErrorHandler.FormatException(ex);
                    log(formatted);
                    IsInitialized = false;
                }
            }
        }

        public static void GenerateStub(string path)
        {
            string stubPath = Path.Combine(path, "Data", "Python", "Plugins", "RSBot.pyi");
            PythonStubGenerator.Generate(stubPath);
        }
    }
}
