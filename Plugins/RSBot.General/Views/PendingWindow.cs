using RSBot.Core.Network;
using RSBot.General.Components;
using RSBot.Theme.Controls;
using System;
using System.Text;
using System.Windows.Forms;

namespace RSBot.General.Views
{
    public partial class PendingWindow : Form
    {
        /// <summary>
        /// Started tick
        /// </summary>
        private int _startedTick;

        public PendingWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
            _startedTick = Environment.TickCount;

            labelPending.Text = $"{count} / {count}";
            labelServerName.Text = labelServerName.Text.Replace("{SERVER}", Serverlist.Joining?.Name);

            PrintTime(labelAvgWaitingTime, timestamp);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PrintTime(labelMyWaitingTime, Environment.TickCount - _startedTick);
        }

        private void PrintTime(Label label, int millisecond)
        {
            var text = new StringBuilder();

            var timespan = TimeSpan.FromMilliseconds(millisecond);
            if (timespan.Hours > 0)
                text.AppendFormat("{0} hours ", timespan.Hours);

            if (timespan.Minutes > 0)
                text.AppendFormat("{0} minutes ", timespan.Minutes);

            if (timespan.Seconds > 0)
                text.AppendFormat("{0} seconds", timespan.Seconds);

            label.Text = text.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            PacketManager.SendPacket(new Packet(0x610F, false, false, new byte[] { 0x1 }), PacketDestination.Server);
        }
    }
}
