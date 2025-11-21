using System.ComponentModel;
using System.Windows.Forms;
using RSBot.General.Components;
using SDUI.Controls;

namespace RSBot.ServerInfo.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    public Main()
    {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();

        UpdateServerInfo();
    }

    private void UpdateServerInfo()
    {
        lvServerInfo.Items.Clear();

        if (Serverlist.Servers == null)
            return;

        foreach (var server in Serverlist.Servers)
        {
            var toInsert = new ListViewItem(new[] { server.Name, server.State });
            lvServerInfo.Items.Add(toInsert);
        }
    }
}
