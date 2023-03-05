using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Trade.Components;

namespace RSBot.Trade.Views
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnEnterGame", ReloadView);
            EventManager.SubscribeEvent("OnTalkToNpc", OnTalkToNpc);
        }

        private void OnTalkToNpc(uint uniqueId)
        {
            if (Game.Player.State.DialogState is not { IsInDialog: true })
                return;

            EventManager.FireEvent("AppendScriptCommand", $"buy-goods {Game.Player.State.DialogState.Npc.Record.CodeName}");
        }

        private void ReloadView()
        {
            PopulateRouteListComboBox();

            checkAttackThiefNpc.Checked = TradeConfig.AttackThiefNpcs;
            checkAttackThiefPlayers.Checked = TradeConfig.AttackThiefPlayers;
            checkCastBuffsWhileFighting.Checked = TradeConfig.CastBuffsWhileFighting;
            checkCastBuffsWhileWalking.Checked = TradeConfig.CastBuffsWhileWalking;
            checkRandomizeRoute.Checked = TradeConfig.RandomizeNextRoute;
            checkWaitForHunter.Checked = TradeConfig.WaitForHunter;
            checkCounterAttack.Checked = TradeConfig.CounterAttack;
            checkRunTownscript.Checked = TradeConfig.RunTownScript;
            checkBuyGoods.Checked = TradeConfig.BuyGoods;
            checkSellGoods.Checked = TradeConfig.SellGoods;

            //Make sure that the user didn't modify the config so both could equal true
            if (TradeConfig.UseRouteScripts && TradeConfig.TracePlayer) 
                TradeConfig.TracePlayer = false;

            if (!TradeConfig.UseRouteScripts && !TradeConfig.TracePlayer)
                TradeConfig.UseRouteScripts = true;

            radioTracePlayer.Checked = TradeConfig.TracePlayer;
            radioUseRouteList.Checked = TradeConfig.UseRouteScripts;

            numAmountGoods.Value = TradeConfig.BuyGoodsQuantity;
            txtTracePlayerName.Text = TradeConfig.TracePlayerName;
        }

        private void PopulateRouteListComboBox()
        {
            comboRouteList.Items.Clear();

            foreach (var scriptList in TradeConfig.RouteScripts)
                comboRouteList.Items.Add(scriptList.Key);

            if (comboRouteList.Items.Count > TradeConfig.SelectedRouteListIndex)
                comboRouteList.SelectedIndex = TradeConfig.SelectedRouteListIndex;
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
            if (comboRouteList.SelectedIndex == 0)
                return;


            if (MessageBox.Show(
                    $"Do you realy want to delete the route list {comboRouteList.SelectedItem}?") !=
                DialogResult.Yes)
                return;

            var selectedIndex = comboRouteList.SelectedIndex - 1; //- default
            if (TradeConfig.RouteScriptList.Count > selectedIndex) 
                TradeConfig.RouteScriptList.RemoveAt(selectedIndex);
        }

        private void buttonCreateList_Click(object sender, EventArgs e)
        {
            var dialog = new SDUI.Controls.InputDialog("New route list", "New route list", "Please enter the name for the new route list");
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var userInput = (string) dialog.Value;

            if(userInput.Contains(';'))
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
            var openFileDiag = new OpenFileDialog()
            {
                Title = "Select RSBot script file",
                AddExtension = true,
                CheckFileExists = true,
            };

            if (openFileDiag.ShowDialog() != DialogResult.OK)
                return;

            var selectedRouteList = (string)comboRouteList.SelectedItem;

            if (!TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
                return;

            if (TradeConfig.RouteScripts[selectedRouteList].Contains(openFileDiag.FileName))
                return;

            var routes = TradeConfig.RouteScripts;
            routes[(string) comboRouteList.SelectedItem].Add(openFileDiag.FileName);

            TradeConfig.RouteScripts = routes;

            RefreshRoutes();
        }

        private void RefreshRoutes()
        {
            lvRouteList.Items.Clear();
            var selectedRouteList = (string) comboRouteList.SelectedItem;

            if (!TradeConfig.RouteScripts.ContainsKey(selectedRouteList))
                return;

            foreach (var fileName in TradeConfig.RouteScripts[selectedRouteList])
            {
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

                var lvItem = new ListViewItem(Path.GetFileNameWithoutExtension(fileName));
                lvItem.SubItems.Add(originRegionName);
                lvItem.SubItems.Add(destinationRegionName);
                lvItem.SubItems.Add(walkScript.Count.ToString());

                lvRouteList.Items.Add(lvItem);
            }
        }

        private void checkBoxSetting_CheckedChanged(object sender, EventArgs e)
        {
            TradeConfig.WaitForHunter = checkWaitForHunter.Checked;
            TradeConfig.RandomizeNextRoute = checkRandomizeRoute.Checked;
            TradeConfig.RunTownScript = checkRunTownscript.Checked;
            TradeConfig.AttackThiefPlayers = checkAttackThiefPlayers.Checked;
            TradeConfig.AttackThiefNpcs = checkAttackThiefNpc.Checked;
            TradeConfig.CastBuffsWhileWalking = checkCastBuffsWhileWalking.Checked;
            TradeConfig.CastBuffsWhileFighting = checkCastBuffsWhileFighting.Checked;
            TradeConfig.CounterAttack = checkCounterAttack.Checked;
            TradeConfig.ProtectTransport = checkProtectTransport.Checked;
            TradeConfig.BuyGoods = checkBuyGoods.Checked;
            TradeConfig.SellGoods = checkSellGoods.Checked;
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

            if (selectedIndex > routes.Count)
                return;

            routes[selectedRouteList].RemoveAt(selectedIndex);

            TradeConfig.RouteScripts = routes;

            RefreshRoutes();
        }

        private void radioSetting_CheckedChanged(object sender, EventArgs e)
        {
            TradeConfig.UseRouteScripts = radioUseRouteList.Checked;
            TradeConfig.TracePlayer = radioTracePlayer.Checked;

            txtTracePlayerName.Enabled = radioTracePlayer.Checked;
        }

        private void txtTracePlayerName_TextChanged(object sender, EventArgs e)
        {
            TradeConfig.TracePlayerName = txtTracePlayerName.Text;
        }

        private void numAmountGoods_ValueChanged(object sender, EventArgs e)
        {
            TradeConfig.BuyGoodsQuantity = Convert.ToInt32(numAmountGoods.Value);
        }
    }
}
