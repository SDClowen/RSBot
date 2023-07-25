using System.ComponentModel;
using System.Windows.Forms;
using RSBot.Core.Event;
using RSBot.General.Components;

namespace RSBot.ServerInfo.Views;

[ToolboxItem(false)]
public partial class Main : UserControl
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

        if (Serverlist.Servers == null) return;

        foreach (var server in Serverlist.Servers)
        {
            ListViewItem toInsert = new ListViewItem(new[]
            {
                server.Name,
                server.State
            });
            lvServerInfo.Items.Add(toInsert);
        }
    }
}