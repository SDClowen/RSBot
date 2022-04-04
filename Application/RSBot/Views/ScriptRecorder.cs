using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using System.Windows.Forms.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Views
{
    public partial class ScriptRecorder : CleanForm
    {
        #region Fields

        private bool _recording;
        private bool _running;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptRecorder"/> class.
        /// </summary>
        public ScriptRecorder()
        {
            InitializeComponent();
            SubscribeEvents();
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
        }

        /// <summary>
        /// Fired when the player moves
        /// </summary>
        private void OnPlayerMove()
        {
            if (!_recording) return;
            var stepString = new System.Text.StringBuilder();
            stepString.Append($"move {Game.Player.Movement.Destination.XOffset}");
            stepString.Append($" {Game.Player.Movement.Destination.YOffset}");
            stepString.Append($" {Game.Player.Movement.Destination.ZOffset}");
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
                btnStart.Text = @"Start";
                lblStatus.Text = @"Idle";
                _recording = false;
            }
            else
            {
                btnStart.Text = @"Stop";
                lblStatus.Text = @"Recording...";
                _recording = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClear_Click(object sender, System.EventArgs e)
        {
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
                Title = "Save recorded script",
                Filter = "RSBot Botbase Script|*.rbs",
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
        /// Handles the Click event of the btnRunNow control.
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

                btnRunNow.Text = "Run now";
                lblStatus.Text = string.Empty;
                _running = false;
            }
            else
            {
                if (ScriptManager.Running)
                    return;

                ScriptManager.Load(txtScript.Text.Split('\n'));
                Task.Run(() => { ScriptManager.RunScript(); });

                btnRunNow.Text = "Stop Running";
                lblStatus.Text = "Running...";
                _running = true;
            }
        }
    }
}