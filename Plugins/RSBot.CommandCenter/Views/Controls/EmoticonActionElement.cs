using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.CommandCenter.Views.Controls;

[System.ComponentModel.ToolboxItem(false)]
internal partial class EmoticonActionElement : UserControl
{
    private record ActionComboBoxItem(string ActionName, string ActionDescription)
    {
        public override string ToString()
        {
            return ActionDescription;
        }
    }

    public Components.EmoticonItem Emoticon { get; }

    public string SelectedActionName { get; private set; }

    public EmoticonActionElement(Components.EmoticonItem item, string selectedActionName = null)
    {
        InitializeComponent();

        SelectedActionName = selectedActionName;
        Emoticon = item;
        picIcon.Image = item.GetIconImage();
        lblName.Text = item.Label;

        PopulateActions();
    }

    private void PopulateActions()
    {
        comboAction.BeginUpdate();
        comboAction.Items.Clear();

        foreach (var command in CommandManager.GetCommandDescriptions())
        {
            var index = comboAction.Items.Add(new ActionComboBoxItem(command.Key, command.Value));

            if (SelectedActionName == command.Key)
                comboAction.SelectedIndex = index;
        }

        comboAction.EndUpdate();
    }

    private void comboAction_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        if (comboAction.SelectedItem is not ActionComboBoxItem actionItem)
            return;

        SelectedActionName = actionItem.ActionName;

        PlayerConfig.Set($"RSBot.CommandCenter.MappedEmotes.{Emoticon.Name}", actionItem.ActionName);
    }
}