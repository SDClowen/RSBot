using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Quests;
using SDUI;
using SDUI.Controls;

namespace RSBot.Quest.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Main" /> class.
    /// </summary>
    public Main()
    {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();

        SubscribeEvents();
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        treeQuests.BackColor = ColorScheme.BackColor;
        treeQuests.ForeColor = ColorScheme.ForeColor;
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", RefreshQuestList);
        EventManager.SubscribeEvent("OnUpdateQuests", RefreshQuestList);
    }

    private void RefreshQuestList()
    {
        try
        {
            if (!treeQuests.Created)
                return;

            treeQuests.Invoke(() =>
            {
                treeQuests.Nodes.Clear();
                foreach (var activeQuest in Game.Player.QuestLog.ActiveQuests)
                {
                    var node = CreateNode(activeQuest.Value);
                    node.Tag = activeQuest.Key;

                    node.ContextMenuStrip = contextQuest;

                    treeQuests.Nodes.Add(node);
                }

                if (!checkShowCompleted.Checked)
                    return;

                var completedNode = new TreeNode("Completed");
                foreach (var questId in Game.Player.QuestLog.CompletedQuests)
                {
                    var quest = Game.ReferenceManager.GetRefQuest(questId);

                    var node = new TreeNode($"{quest.GetTranslatedName()} (lv. {quest.Level})");
                    completedNode.Nodes.Add(node);
                }

                treeQuests.Nodes.Add(completedNode);
            });
        }
        catch (Exception e)
        {
            // ignored
        }
    }

    private TreeNode CreateNode(ActiveQuest quest)
    {
        if (quest.Quest == null)
            return new TreeNode($"Unknown quest [{quest.Id}]");

        var name = Game.ReferenceManager.GetTranslation(quest.Quest.NameString);

        var node = new TreeNode(name);
        node.Nodes.Add($"Id: {quest.Id}");
        node.Nodes.Add($"Level: {quest.Quest.Level}");
        node.Nodes.Add($"Status: {GetStatusText(quest.Status)}");

        node.Tag = quest.Id;

        if (quest.Npcs?.Length > 0)
        {
            var npcNode = new TreeNode("NPCs");
            foreach (var npcId in quest.Npcs)
            {
                var npc = Game.ReferenceManager.GetRefObjChar(npcId);
                var npcName = Game.ReferenceManager.GetTranslation(npc.NameStrID);
                npcNode.Nodes.Add(npcName);
            }

            node.Nodes.Add(npcNode);
        }

        var rewardNode = new TreeNode("Rewards");

        if (quest.Quest.Reward != null)
        {
            if (quest.Quest.Reward.Exp > 0)
                rewardNode.Nodes.Add($"Exp: {quest.Quest.Reward.Exp}");

            if (quest.Quest.Reward.Gold > 0)
                rewardNode.Nodes.Add($"Gold: {quest.Quest.Reward.Gold}");

            if (quest.Quest.Reward.SP > 0)
                rewardNode.Nodes.Add($"Skill points: {quest.Quest.Reward.Gold}");

            if (quest.Quest.Reward.SP > 0)
                rewardNode.Nodes.Add($"Skill Exp: {quest.Quest.Reward.Gold}");

            if (quest.Quest.Reward.InventorySlots > 0)
                rewardNode.Nodes.Add($"Inv. slots: {quest.Quest.Reward.Gold}");

            if (quest.Quest.Reward.Hwan > 0)
                rewardNode.Nodes.Add($"Hwan: {quest.Quest.Reward.Gold}");
        }

        if (quest.Quest.RewardItems != null && quest.Quest.RewardItems.Any())
        {
            var itemsNode = new TreeNode("Items");

            foreach (var rewardItem in quest.Quest.RewardItems)
            {
                if (rewardItem.Item != null)
                    itemsNode.Nodes.Add($"{rewardItem.Item.GetRealName()}");

                if (rewardItem.OptionalItem != null)
                    itemsNode.Nodes.Add($"{rewardItem.OptionalItem.GetRealName()}");
            }

            rewardNode.Nodes.Add(itemsNode);
        }

        node.Nodes.Add(rewardNode);

        if (quest.Objectives?.Length > 0)
            foreach (var objective in quest.Objectives)
            {
                var objectiveName = Game.ReferenceManager.GetTranslation(objective.NameStrId);
                var objectiveSubNode = new TreeNode(objectiveName);
                if (objective.InProgress)
                    objectiveSubNode.Nodes.Add("Status: In progress");
                else
                    objectiveSubNode.Nodes.Add("Status: Complete");

                foreach (var task in objective.Tasks)
                {
                    var actualTitle = objectiveName.Replace("%d", task.ToString());

                    objectiveSubNode.Nodes.Add($"Progress: {task}");
                    objectiveSubNode.Text = actualTitle;
                }

                node.Nodes.Add(objectiveSubNode);
            }

        return node;
    }

    private string GetStatusText(QuestStatus status)
    {
        switch (status)
        {
            case QuestStatus.Cancelled:
                return "Cancelled";
            case QuestStatus.Completed:
            case QuestStatus.CompletedXTimes:
                return "Completed";
            case QuestStatus.CompletedButNotSupplied:
            case QuestStatus.CompletedByUserButNotSupplied:
                return "Ready for delivery";
            case QuestStatus.Initialized:
            case QuestStatus.StartedByUser:
                return "In progress";
            case QuestStatus.Unavailable:
                return "Unavailable";
            default:
                return status.ToString();
        }
    }

    private void checkShowCompleted_CheckedChanged(object sender, EventArgs e)
    {
        RefreshQuestList();
    }

    private void Main_Load(object sender, EventArgs e)
    {
        RefreshQuestList();
    }

    private void watchQuestToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!uint.TryParse(treeQuests.SelectedNode?.Tag.ToString(), out var questId))
            return;

        if (View.SidebarElement.HasQuest(questId))
            View.SidebarElement.RemoveQuest(questId);
        else
            View.SidebarElement.AddQuest(questId);
    }

    private void treeQuests_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        treeQuests.SelectedNode = e.Node;
    }

    private void abandonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!uint.TryParse(treeQuests.SelectedNode?.Tag.ToString(), out var questId))
            return;

        if (!Game.Player.QuestLog.ActiveQuests.TryGetValue(questId, out var activeQuest))
            return;

        if (
            MessageBox.Show(
                $"Do you really want to abandon the quest [{activeQuest.Quest.GetTranslatedName()}]?",
                "Abandon quest",
                MessageBoxButtons.YesNo
            ) == DialogResult.Yes
        )
            Game.Player.QuestLog.AbandonQuest(questId);
    }
}
