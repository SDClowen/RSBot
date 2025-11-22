using Python.Runtime;
using RSBot.Python.API;
using RSBot.Python.API.GUI;
using RSBot.Python.API.Handler;
using RSBot.Python.API.ModuleLoader;
using SDUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Python.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    private Thread pythonThread;
    private PeriodicTimer _pluginTimer;
    private CancellationTokenSource _cts;
    private List<PyObject> _loadedPlugins = new List<PyObject>();
    public Main()
    {
        InitializeComponent();
        ModuleLoader.InitAll(this);
        string stubPath = Path.Combine(Directory.GetParent(Application.StartupPath).FullName, "Data", "Python", "Plugins", "RSBot.pyi");
        PythonStubGenerator.Generate(stubPath);
        WireEvents();
        InitPythonRuntime();
    }
    public void AppendLog(string text)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => AppendLog(text)));
            return;
        }

        tbPluginLog.AppendText(text + Environment.NewLine);
    }

    private void WireEvents()
    {
        dgvPlugin.CellValueChanged += (s, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)  return;

            var row = dgvPlugin.Rows[e.RowIndex];
            bool isEnabled = Convert.ToBoolean(row.Cells[0].Value);
            string fileName = row.Cells[5].Value.ToString(); // Versteckte Spalte mit Dateinamen
            if (isEnabled)
            {
                AppendLog($"Aktiviere Plugin: {fileName}");
                RunPythonPlugin(fileName);
            }
            else
            {
                AppendLog($"Deaktiviere Plugin: {fileName}");
                //ResetPythonPlugins();
            }
        };
    }
    private void LoadPythonPlugins()
    {
        try
        {
            // Projektverzeichnis (z. B. bin/Debug/... → gehe 2 Ebenen hoch)
            string projectDir = Directory.GetParent(Application.StartupPath).FullName;


            // Plugin-Ordner
            string pluginDir = Path.Combine(projectDir, "Data", "Python", "Plugins");

            if (!Directory.Exists(pluginDir))
            {
                Directory.CreateDirectory(pluginDir);
            }

            // Alle .py-Dateien im Plugin-Ordner laden
            string[] pythonFiles = Directory.GetFiles(pluginDir, "*.py", SearchOption.TopDirectoryOnly);

            dgvPlugin.Rows.Clear();

            foreach (string file in pythonFiles)
            {
                // --- Metadaten statisch aus dem Datei-Text holen (KEIN Python-Exec!)
                PythonPluginInfo info = PluginMetaReader.ReadPythonPluginInfo(file);

                // --- Enabled Status über Dateiname bestimmen
                bool enabled = false;

                // --- Zeile hinzufügen
                // ACHTUNG: Reihenfolge muss exakt zu deinen Spalten passen
                dgvPlugin.Rows.Add(
                    enabled,
                    info.Name,
                    info.Description,
                    info.Author,
                    info.Version,
                    info.FileName   // <- nur wenn du eine versteckte ID-Spalte hast
                );
            }

            AppendLog($"Es wurden {pythonFiles.Length} Python-Plugins gefunden.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Fehler beim Laden der Plugins:\n" + ex.Message);
        }
    }

    private void InitPythonRuntime()
    {
        // 1. Pfade setzen (gleich wie bisher)
        string projectDir = Directory.GetParent(Application.StartupPath).FullName;
        string pythonHome = Path.Combine(projectDir,"Data","Python", "PyRuntime");
        string pythonDll = Directory.GetFiles(pythonHome, "python31*.dll").FirstOrDefault();

        if (pythonDll == null)
        {
            AppendLog("Keine Python-DLL gefunden!");
            return;
        }

        Runtime.PythonDLL = pythonDll;
        PythonEngine.PythonHome = pythonHome;
        PythonEngine.PythonPath = pythonHome + ";" + Path.Combine(pythonHome, "Lib");

        PythonEngine.Initialize();
        PythonEngine.BeginAllowThreads();

        // 2. API-Namespace nach Python exportieren
        using (Py.GIL())
        {
            try
            {
                PythonEngine.Exec(@"
import clr
import sys
import types

# C# Assembly laden
clr.AddReference('RSBot.Python')

# Richtige Accessor-Klasse importieren!
from RSBot.Python.API.ModuleLoader import PythonPluginAccessor

# Neues Modul erstellen
RSBot = types.ModuleType('RSBot')

# Plugin-Instanzen abrufen
plugins = PythonPluginAccessor.all()


# Export aller öffentlichen Methoden aller Plugins
for name, plugin in plugins.items():

    # Durch alle Attribute der Plugin-Klasse gehen
    for attr_name in dir(plugin):

        # interne/private Methoden überspringen
        if attr_name.startswith('_'):
            continue

        # Attribut abrufen
        attr = getattr(plugin, attr_name)

        # nur Funktionen exportieren
        if callable(attr):
            setattr(RSBot, attr_name, attr)

# Modul offiziell registrieren
sys.modules['RSBot'] = RSBot

from RSBot.Python.API.GUI import WFAPI
RSBot.GUI = WFAPI.GUI
");
                AppendLog("Python initialisiert und RSBot-Modul erstellt.");
            }
            catch (PythonException ex)
            {
                var formatted = PythonErrorHandler.FormatException(ex);
                AppendLog(formatted);          // ins Log
            }
            LoadPythonPlugins();

        }
    }
    private void RunPythonPlugin(string fileName)
    {
        Task.Run(() =>
        {
            try
            {
                string projectDir = Directory.GetParent(Application.StartupPath).FullName;
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
                AppendLog($"[Fehler] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
            }
        });
    }
    private void ResetPythonPlugins()
    {
        if (_loadedPlugins.Count == 0)
            return;
        using (Py.GIL())
        {
            _loadedPlugins.Clear();
        }
    }

    private void btnReload_Click(object sender, EventArgs e)
    {
        var gui = ModuleLoader.Get("gui") as WFAPI;
        if (gui != null)
        {
            gui.ResetAll();
        }
        //ResetPythonPlugins();
        LoadPythonPlugins();
        string pluginFolder = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "Plugins");

    }
}