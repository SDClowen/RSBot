﻿using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Scripting;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Views.Dialog;
using SDUI.Controls;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Views
{
    public partial class ScriptRecorder : CleanForm
    {
        private class CommandComboBoxItem
        {
            public IScriptCommand Command { get; }

            public CommandComboBoxItem(IScriptCommand command)
            {
                Command = command;
            }

            public override string ToString() => Command.Name;
        }

        private bool _recording;
        private bool _running;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptRecorder"/> class.
        /// </summary>
        public ScriptRecorder()
        {
            InitializeComponent();
            SubscribeEvents();
            PopulateCommandList();
        }

        /// <summary>
        /// Populates the command list.
        /// </summary>
        private void PopulateCommandList()
        {
            foreach (var command in ScriptManager.CommandHandlers)
                comboCommand.Items.Add(new CommandComboBoxItem(command));
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnPlayerMove", OnPlayerMove);
            EventManager.SubscribeEvent("OnRequestTeleport", new Action<uint, string>(OnRequestTeleport));
            EventManager.SubscribeEvent("OnTerminateVehicle", OnTerminateVehicle);
            EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
            EventManager.SubscribeEvent("OnScriptStartExecuteCommand", new Action<IScriptCommand, int>(OnScriptStartExecuteCommand));
            EventManager.SubscribeEvent("OnNpcRepairRequest", new Action<uint, byte, byte>(OnNpcRepairRequest));
            EventManager.SubscribeEvent("OnStorageOpenRequest", new Action<uint>(StorageOpenRequest));
            EventManager.SubscribeEvent("OnTalkRequest", new Action<uint, TalkOption>(OnTalkRequest));
            EventManager.SubscribeEvent("OnFinishScript", OnFinishScript);

            //Use EventManager.FireEvent("AppendScriptCommand", "<name> <parameters>"); to add your own commands to the output
            EventManager.SubscribeEvent("AppendScriptCommand", new Action<string>(AppendScriptCommand));
        }

        /// <summary>
        /// Appends the script command fired from a plugin.
        /// </summary>
        /// <param name="command">The command.</param>
        private void AppendScriptCommand(string command)
        {
            txtScript.AppendText(command + Environment.NewLine);
        }

        /// <summary>
        /// Highlights the line at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="color">The color.</param>
        private void HighlightLine(int index, Color color)
        {
            txtScript.SelectAll();
            txtScript.SelectionBackColor = txtScript.BackColor;
            var lines = txtScript.Lines;
            if (index < 0 || index >= lines.Length)
                return;
            var start = txtScript.GetFirstCharIndexFromLine(index);  // Get the 1st char index of the appended text
            var length = lines[index].Length;
            txtScript.Select(start, length);                 // Select from there to the end
            txtScript.SelectionBackColor = color;
        }

        #region Events

        private void OnFinishScript()
        {
            if (_running)
            {
                btnRun.Text = "▶";
                labelStatus.Text = LanguageManager.GetLang("Idle");
                _running = false;
            }
            else
            {
                labelStatus.Text = LanguageManager.GetLang("StopRunning");

                btnRun.Text = "⏹";
                _running = true;
            }
        }

        private void OnTalkRequest(uint entityId, TalkOption option)
        {
            if (!_recording) return;

            if (option != TalkOption.Store)
                return;

            var entity = SpawnManager.GetEntity<SpawnedBionic>(entityId);

            if (entity != null)
                txtScript.AppendText($"buy {entity.Record.CodeName}\n");
        }

        private void StorageOpenRequest(uint entityId)
        {
            if (!_recording) return;

            var entity = SpawnManager.GetEntity<SpawnedBionic>(entityId);

            if (entity != null)
                txtScript.AppendText($"store {entity.Record.CodeName}\n");
        }

        private void OnNpcRepairRequest(uint entityId, byte type, byte slot)
        {
            if (!_recording) return;

            var entity = SpawnManager.GetEntity<SpawnedBionic>(entityId);

            if (entity != null)
                txtScript.AppendText($"repair {entity.Record.CodeName}\n");
        }

        private void OnScriptStartExecuteCommand(IScriptCommand command, int lineNumber)
        {
            if (!ScriptManager.Running) return;

            if (txtScript.Text.Split('\n').Length >= lineNumber)
                HighlightLine(lineNumber != 0 ? lineNumber + 1 : 0, Color.CornflowerBlue);
        }

        /// <summary>
        /// Fired when the player moves
        /// </summary>
        private void OnPlayerMove()
        {
            if (!_recording) return;
            var stepString = new System.Text.StringBuilder();
            stepString.Append($"move {Math.Round(Game.Player.Movement.Destination.RXOffset, MidpointRounding.AwayFromZero)}");
            stepString.Append($" {Math.Round(Game.Player.Movement.Destination.RYOffset, MidpointRounding.AwayFromZero)}");
            stepString.Append($" {Math.Round(Game.Player.Movement.Destination.ZOffset, MidpointRounding.AwayFromZero)}");
            stepString.Append($" {Game.Player.Movement.Destination.XSector}");
            stepString.Append($" {Game.Player.Movement.Destination.YSector}");
            stepString.AppendLine();
            txtScript.AppendText(stepString.ToString());
        }

        /// <summary>
        /// Fired when the client requests to teleport
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <param name="npcCodeName">Name of the NPC code.</param>
        private void OnRequestTeleport(uint destination, string npcCodeName)
        {
            if (!_recording) return;

            txtScript.AppendText($"teleport {npcCodeName} {destination}\n");
        }

        /// <summary>
        /// Fired when the vehicle was terminated
        /// </summary>
        private void OnTerminateVehicle()
        {
            if (!_recording) return;

            txtScript.AppendText("dismount\n");
        }

        private void OnTeleportComplete()
        {
            if (!_recording) return;

            txtScript.AppendText("wait 5000\n");
        }

        /// <summary>
        /// Handles the Click event of the btnStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, System.EventArgs e)
        {
            if (ScriptManager.Running)
                return;

            if (_recording)
            {
                btnStartStop.Text = LanguageManager.GetLang("Start");
                labelStatus.Text = LanguageManager.GetLang("Idle");
                btnStartStop.Color = Color.FromArgb(33, 150, 243);

                _recording = false;
                btnRun.Enabled = true;
            }
            else
            {
                btnStartStop.Text = LanguageManager.GetLang("Stop");
                labelStatus.Text = LanguageManager.GetLang("Recording");
                btnStartStop.Color = Color.DarkRed;
                _recording = true;

                btnRun.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show(@"Do you really want to clear the script?", @"Are you sure?",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            txtScript.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtScript.Text))
                return;

            var diag = new SaveFileDialog
            {
                Title = LanguageManager.GetLang("SaveRecordedScript"),
                Filter = "RSBot Botbase File|*.rbs",
                InitialDirectory = Environment.CurrentDirectory + "\\Scripts"
            };

            if (diag.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(diag.FileName, txtScript.Text);
        }

        /// <summary>
        /// Handles the FormClosed event of the ScriptRecorder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void ScriptRecorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            _recording = false;
            _running = false;
        }

        /// <summary>
        /// Handles the Click event of the btnRun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnRunNow_Click(object sender, System.EventArgs e)
        {
            if (_recording || string.IsNullOrWhiteSpace(txtScript.Text))
                return;

            if (_running)
            {
                ScriptManager.Stop();

                labelStatus.Text = LanguageManager.GetLang("Idle");
                btnRun.Text = "▶";
                txtScript.ReadOnly = false;

                _running = false;
            }
            else
            {
                if (ScriptManager.Running)
                    return;

                ScriptManager.Load(txtScript.Text.Split('\n'));
                Task.Run(ScriptManager.RunScript);

                labelStatus.Text = LanguageManager.GetLang("Running");
                btnRun.Text = "X";
                txtScript.ReadOnly = true;

                _running = true;
            }
        }

        private void ScriptRecorder_Load(object sender, EventArgs e)
        {
            LanguageManager.Translate(this, Kernel.Language);
        }

        private void btnAddCommand_Click(object sender, EventArgs e)
        {
            if (!(comboCommand.SelectedItem is CommandComboBoxItem selectedItem)) return;

            if (selectedItem.Command.Arguments == null || selectedItem.Command.Arguments.Count == 0)
            {
                txtScript.AppendText(selectedItem.Command.Name + Environment.NewLine);

                return;
            }

            var diag = new CommandDialog(selectedItem.Command);
            if (diag.ShowDialog() == DialogResult.OK)
                txtScript.AppendText(diag.CommandText + Environment.NewLine);
        }

        #endregion Events
    }
}