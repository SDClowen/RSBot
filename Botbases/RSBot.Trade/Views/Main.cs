using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Trade.Components;
using SDUI.Controls;

namespace RSBot.Trade.Views;

public partial class Main : DoubleBufferedControl
{
    private bool _loadingConfig;

    public Main()
    {
        InitializeComponent();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnTalkToNpc", OnTalkToNpc);
        EventManager.SubscribeEvent("OnJobScaleUpdate", OnUpdateJobInfo);
        EventManager.SubscribeEvent("OnJobExperienceUpdate", OnUpdateJobInfo);
        EventManager.SubscribeEvent("OnJobJoin", OnUpdateJobInfo);
        EventManager.SubscribeEvent("OnJobLeave", OnUpdateJobInfo);
        EventManager.SubscribeEvent("OnJobAliasUpdate", OnUpdateJobInfo);
    }

    private void OnUpdateJobInfo()
    {
        if (Game.Player.TradeInfo == null)
            return;

        if (Game.Player.JobInformation.Type == JobType.None)
        {
            lblJobExp.Text = "0";
            lblJobLevel.Text = "0";
            lblJobAlias.Text = "<none>";

            return;
        }

        lblTradeScale.Text = new string('■', Game.Player.TradeInfo.Scale);
        lblJobExp.Text = Game.Player.JobInformation.Experience.ToString();
        lblJobAlias.Text = Game.Player.JobInformation.Name;
        lblJobLevel.Text = Game.Player.JobInformation.Level.ToString();
    }

    private void OnTalkToNpc(uint uniqueId)
    {
        if (Game.Player.State.DialogState is not { IsInDialog: true, TalkOption: TalkOption.Trade })
            return;

        EventManager.FireEvent("AppendScriptCommand", $"buy-goods {Game.Player.State.DialogState.Npc.Record.CodeName}");
    }

    private void ReloadView()
    {
        PopulateRouteListComboBox();

        _loadingConfig = true;

        checkAttackThiefNpc.Checked = TradeConfig.AttackThiefNpcs;
        checkAttackThiefPlayers.Checked = TradeConfig.AttackThiefPlayers;
        checkCastBuffs.Checked = TradeConfig.CastBuffs;
        checkWaitForHunter.Checked = TradeConfig.WaitForHunter;
        checkCounterAttack.Checked = TradeConfig.CounterAttack;
        checkRunTownscript.Checked = TradeConfig.RunTownScript;
        checkBuyGoods.Checked = TradeConfig.BuyGoods;
        checkSellGoods.Checked = TradeConfig.SellGoods;
        checkProtectTransport.Checked = TradeConfig.ProtectTransport;
        checkMountTransport.Checked = TradeConfig.MountTransport;

        //Make sure that the user didn't modify the config so both could equal true
        if (TradeConfig.UseRouteScripts && TradeConfig.TracePlayer)
            TradeConfig.TracePlayer = false;

        if (!TradeConfig.UseRouteScripts && !TradeConfig.TracePlayer)
            TradeConfig.UseRouteScripts = true;

        radioTracePlayer.Checked = TradeConfig.TracePlayer;
        radioUseRouteList.Checked = TradeConfig.UseRouteScripts;

        numAmountGoods.Value = TradeConfig.BuyGoodsQuantity;
        numMaxDistance.Value = TradeConfig.MaxTransportDistance;
        txtTracePlayerName.Text = TradeConfig.TracePlayerName;

        _loadingConfig = false;
    }

    private void PopulateRouteListComboBox()
    {
        comboRouteList.Items.Clear();

        foreach (var scriptList in TradeConfig.RouteScripts)
            comboRouteList.Items.Add(scriptList.Key);

        if (comboRouteList.Items.Count > TradeConfig.SelectedRouteListIndex)
            comboRouteList.SelectedIndex = TradeConfig.SelectedRouteListIndex;
    }

    private void RefreshRoutes()
    {
        lvRouteList.Items.Clear();
        var selectedRouteList = (string)comboRouteList.SelectedItem ?? "";

        if (!TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
            return;

        foreach (var fileName in TradeConfig.RouteScripts[selectedRouteList])
        {
            if (!File.Exists(fileName))
                continue;

            ScriptManager.Load(fileName);
            var walkScript = ScriptManager.GetWalkScript();

            if (walkScript.Count == 0)
            {
                Log.Warn($"There is no walk script in the route [{fileName}]!");

                continue;
            }

            var origin = walkScript.First();
            var destination = walkScript.Last();
            var originRegionName = Game.ReferenceManager.GetTranslation(origin.Region.ToString());
            var destinationRegionName = Game.ReferenceManager.GetTranslation(destination.Region.ToString());

            var lvItem = new ListViewItem(Path.GetFileNameWithoutExtension(fileName)) { Tag = fileName };
            lvItem.SubItems.Add(originRegionName);
            lvItem.SubItems.Add(destinationRegionName);
            lvItem.SubItems.Add(walkScript.Count.ToString());

            lvRouteList.Items.Add(lvItem);
        }
    }

    private void comboRouteList_SelectedIndexChanged(object sender, EventArgs e)
    {
        buttonDeleteList.Enabled = comboRouteList.SelectedIndex != 0;

        TradeConfig.SelectedRouteListIndex = comboRouteList.SelectedIndex;
        RefreshRoutes();
    }

    private void buttonDeleteList_Click(object sender, EventArgs e)
    {
        //Can not delete Default
        if (comboRouteList.SelectedIndex <= 0)
            return;

        if (MessageBox.Show(
                $"Do you realy want to delete the route list {comboRouteList.SelectedItem}?", "Delete list",
                MessageBoxButtons.YesNo) !=
            DialogResult.Yes)
            return;

        var selectedIndex = comboRouteList.SelectedIndex - 1; //- default
        var scripts = TradeConfig.RouteScriptList;
        if (scripts.Count > selectedIndex)
            scripts.RemoveAt(selectedIndex);

        TradeConfig.RouteScriptList = scripts;

        PopulateRouteListComboBox();
        RefreshRoutes();
    }

    private void buttonCreateList_Click(object sender, EventArgs e)
    {
        var dialog = new InputDialog("New route list", "New route list",
            "Please enter the name for the new route list");
        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        var userInput = (string)dialog.Value;

        if (userInput.Contains(';'))
        {
            MessageBox.Show("The character ';' is invalid in route list names", "Invalid character",
                MessageBoxButtons.OK);

            return;
        }

        //ToDO: Refactor the config handling completely to JSON so it's possible to have whitespaces and such in names -> Or create a key value pair 
        if (userInput.Contains(' '))
        {
            MessageBox.Show("The name can not have a whitespace character", "Invalid character",
                MessageBoxButtons.OK);

            return;
        }

        userInput = userInput.Trim();
        if (TradeConfig.RouteScriptList.Contains(userInput))
        {
            MessageBox.Show("The name can not have a whitespace character", "Invalid character",
                MessageBoxButtons.OK);

            return;
        }

        var routeScripts = TradeConfig.RouteScriptList;
        routeScripts.Add(userInput);

        TradeConfig.RouteScriptList = routeScripts;
        ReloadView();

        comboRouteList.SelectedIndex = comboRouteList.Items.Count - 1;
    }

    private void menuChooseScript_Click(object sender, EventArgs e)
    {
        var openFileDiag = new OpenFileDialog
        {
            Title = "Select RSBot script file(s)",
            AddExtension = true,
            CheckFileExists = true,
            Multiselect = true
        };

        if (openFileDiag.ShowDialog() != DialogResult.OK)
            return;

        var selectedRouteList = (string)comboRouteList.SelectedItem;

        if (!TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
            return;

        var newRouteList = TradeConfig.RouteScripts;
        var routes = newRouteList[selectedRouteList];

        foreach (var fileName in openFileDiag.FileNames)
        {
            if (routes.Contains(fileName))
                continue;

            routes.Add(fileName);
        }

        newRouteList[selectedRouteList] = routes;
        TradeConfig.RouteScripts = newRouteList;

        RefreshRoutes();
    }

    private void checkBoxSetting_CheckedChanged(object sender, EventArgs e)
    {
        if (_loadingConfig)
            return;

        TradeConfig.WaitForHunter = checkWaitForHunter.Checked;
        TradeConfig.RunTownScript = checkRunTownscript.Checked;
        TradeConfig.AttackThiefPlayers = checkAttackThiefPlayers.Checked;
        TradeConfig.AttackThiefNpcs = checkAttackThiefNpc.Checked;
        TradeConfig.CastBuffs = checkCastBuffs.Checked;
        TradeConfig.CounterAttack = checkCounterAttack.Checked;
        TradeConfig.ProtectTransport = checkProtectTransport.Checked;
        TradeConfig.BuyGoods = checkBuyGoods.Checked;
        TradeConfig.SellGoods = checkSellGoods.Checked;
        TradeConfig.MountTransport = checkMountTransport.Checked;
    }

    private void menuRemoveScript_Click(object sender, EventArgs e)
    {
        if (lvRouteList.SelectedItems.Count == 0)
            return;

        var selectedRouteList = (string)comboRouteList.SelectedItem;
        if (!TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
            return;

        var routes = TradeConfig.RouteScripts;
        var selectedIndex = lvRouteList.SelectedItems[0].Index;

        if (selectedIndex > routes[selectedRouteList].Count)
            return;

        routes[selectedRouteList].RemoveAt(selectedIndex);

        TradeConfig.RouteScripts = routes;

        RefreshRoutes();
    }

    private void radioSetting_CheckedChanged(object sender, EventArgs e)
    {
        if (_loadingConfig)
            return;

        TradeConfig.UseRouteScripts = radioUseRouteList.Checked;
        TradeConfig.TracePlayer = radioTracePlayer.Checked;

        txtTracePlayerName.Enabled = radioTracePlayer.Checked;
    }

    private void txtTracePlayerName_TextChanged(object sender, EventArgs e)
    {
        if (_loadingConfig)
            return;

        TradeConfig.TracePlayerName = txtTracePlayerName.Text;
    }

    private void numSetting_ValueChanged(object sender, EventArgs e)
    {
        if (_loadingConfig)
            return;

        TradeConfig.BuyGoodsQuantity = Convert.ToInt32(numAmountGoods.Value);
        TradeConfig.MaxTransportDistance = Convert.ToInt32(numMaxDistance.Value);
    }

    private void linkRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        ShowScriptRecorder();
    }

    private void ShowScriptRecorder()
    {
        if (!ScriptManager.Running)
            EventManager.FireEvent("OnShowScriptRecorder", 2000, true);
        else
            MessageBox.Show("Can not record a new script while a script is running! Stop the bot and try again.",
                "Script manager busy",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void menuRecordScript_Click(object sender, EventArgs e)
    {
        ShowScriptRecorder();
    }

    /// <summary>
    ///     Occurs before Main form is displayed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_Load(object sender, EventArgs e)
    {
        ReloadView();
    }
}