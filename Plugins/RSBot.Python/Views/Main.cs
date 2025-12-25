using Python.Runtime;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Python.Components.API.GUI;
using RSBot.Python.Components.API.ModuleLoader;
using RSBot.Python.Components.Loader;
using RSBot.Python.Plugins;
using SDUI.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RSBot.Python.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    private readonly PythonRuntimeManager _pyRuntime = new();
    private readonly PythonPluginManager _pyPlugins = new();
    private string projectDir = Directory.GetParent(Application.StartupPath).FullName;
    public Main()
    {
        InitializeComponent();
        ModuleLoader.InitAll(this);
        PythonRuntimeManager.GenerateStub(Directory.GetParent(Application.StartupPath).FullName);
        WireEvents();
        SubscribeEvents();
        InitPythonRuntime();
    }
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
        EventManager.SubscribeEvent("OnTeleportStart", OnTeleportStart);
        EventManager.SubscribeEvent("OnClientPacketReceive", OnClientPacketReceive);
        EventManager.SubscribeEvent("OnServerPacketReceive", OnServerPacketReceive);
    }
    private void WireEvents()
    {
        dgvPlugin.CurrentCellDirtyStateChanged += (s, e) =>
        {
            if (dgvPlugin.IsCurrentCellDirty)
                dgvPlugin.CommitEdit(DataGridViewDataErrorContexts.Commit);
        };
        dgvPlugin.CellValueChanged += (s, e) =>
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0) return;

            var row = dgvPlugin.Rows[e.RowIndex];
            bool isEnabled = Convert.ToBoolean(row.Cells[0].Value);
            string fileName = row.Cells[5].Value.ToString();
            string pluginName = row.Cells[1].Value.ToString();

            if (isEnabled)
            {
                AppendLog($"[Python-API] Activated plugin: {fileName}");
                RunPythonPlugin(fileName);
            }
            else
            {
                AppendLog($"[Python-API] Deactivated plugin: {fileName}");
                
                var gui = ModuleLoader.Get("gui") as WFAPI;
                gui?.ResetPlugin(pluginName);

                _pyPlugins.UnloadPlugin(fileName, AppendLog);
            }
        };
    }
    public void AppendLog(string text)
    {
        if (InvokeRequired)
        {
            Invoke(new System.Action(() => AppendLog(text)));
            return;
        }

        tbPluginLog.AppendText(Environment.NewLine + text);
        tbPluginLog.ScrollToCaret();
    }

    #region PythonRuntime
    private void InitPythonRuntime()
    {
        _pyRuntime.Initialize(projectDir, AppendLog);
        ReloadPluginGrid();
    }
    private void ReloadPluginGrid()
    {
        dgvPlugin.Rows.Clear();

        var plugins = _pyPlugins.ScanPlugins(projectDir, AppendLog);

        foreach (var info in plugins)
        {
            bool enabled = false;
            dgvPlugin.Rows.Add(enabled, info.Name, info.Description, info.Author, info.Version, info.FileName);
        }
    }
    private void RunPythonPlugin(string fileName)
    {
        string projectDir = Directory.GetParent(Application.StartupPath).FullName;
        _pyPlugins.RunPlugin(projectDir, fileName, AppendLog);
    }

    private void ResetPythonPlugins()
    {
        _pyPlugins.ResetPlugins();
    }

    #endregion
   
    private void btnReload_Click(object sender, EventArgs e)
    {
        var gui = ModuleLoader.Get("gui") as WFAPI;
        if (gui != null)
        {
            gui.ResetAll();
        }
        ResetPythonPlugins();
        ReloadPluginGrid();
        string pluginFolder = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "Plugins");

    }
    #region events
    private void OnTeleportStart()
    {
        _pyPlugins.CallPluginEvent("on_teleported", AppendLog, new PyInt(1));
    }
    private void OnTeleportComplete()
    {
        _pyPlugins.CallPluginEvent("on_teleported", AppendLog, new PyInt(2));
    }
    private void OnClientPacketReceive(Packet packet)
    {
        byte[] data = packet.GetBytes();
        string opcode = packet.HexCode;
        string data_hex = BitConverter.ToString(data).Replace("-", " ");
        _pyPlugins.CallPluginEvent("on_packet_from_client", AppendLog, opcode,data_hex);
    }
    private void OnServerPacketReceive(Packet packet)
    {
        byte[] data = packet.GetBytes();
        string opcode = packet.HexCode;
        string data_hex = BitConverter.ToString(data).Replace("-", " ");
        _pyPlugins.CallPluginEvent("on_packet_from_server", AppendLog, opcode,data_hex);
    }
    #endregion
    private void btnOpenFolder_Click(object sender, EventArgs e)
    {
      Process.Start("explorer.exe", Path.Combine(projectDir, "Data", "Python", "Plugins"));
    }
}
