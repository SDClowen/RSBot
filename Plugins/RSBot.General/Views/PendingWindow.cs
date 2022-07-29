using RSBot.Core;
using RSBot.Core.Network;
using RSBot.General.Components;
using SDUI.Controls;
using System;
using System.Text;
using System.Windows.Forms;

namespace RSBot.General.Views
{
    public partial class PendingWindow : CleanForm
    {
        /// <summary>
        /// Started tick
        /// </summary>
        private int _startedTick;

        public PendingWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Text = "Pending";
        }

        internal void Update(Packet packet)
        {
            if (packet.ReadByte() != 1)
                return;

            var end = packet.ReadUShort();
            var timestamp = packet.ReadInt();
            var begin = packet.ReadUShort();

            labelPending.Text = $"{begin} / {end}";
            PrintTime(labelAvgWaitingTime, timestamp);
        }

        internal void Start(int count, int timestamp)
        {
            _startedTick = Kernel.TickCount;

            labelPending.Text = $"{count} / {count}";
            labelServerName.Text = labelServerName.Text.Replace("{SERVER}", Serverlist.Joining?.Name);

            PrintTime(labelAvgWaitingTime, timestamp);
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PrintTime(labelMyWaitingTime, Kernel.TickCount - _startedTick);
        }

        private void PrintTime(SDUI.Controls.Label label, int millisecond)
        {
            var text = new StringBuilder();

            var translatedHours = LanguageManager.GetLang("Xhours");
            var translatedMinutes = LanguageManager.GetLang("Xminutes");
            var translatedSeconds = LanguageManager.GetLang("Xseconds");

            var timespan = TimeSpan.FromMilliseconds(millisecond);
            if (timespan.Hours > 0)
                text.AppendFormat(translatedHours, timespan.Hours);

            if (timespan.Minutes > 0)
                text.AppendFormat(translatedMinutes, timespan.Minutes);

            if (timespan.Seconds > 0)
                text.AppendFormat(translatedSeconds, timespan.Seconds);

            label.Text = text.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            PacketManager.SendPacket(new Packet(0x610F, false, false, new byte[] { 0x1 }), PacketDestination.Server);
        }

        private void PendingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }
    }
}
