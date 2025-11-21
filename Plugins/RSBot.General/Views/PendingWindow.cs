using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.General.Components;
using SDUI.Controls;
using Label = SDUI.Controls.Label;

namespace RSBot.General.Views;

public partial class PendingWindow : UIWindowBase
{
    /// <summary>
    ///     The Queue Notify Index
    /// </summary>
    private int _queueNotifyIndex;

    /// <summary>
    ///     The Started tick
    /// </summary>
    private int _startedTick;

    /// <summary>
    ///     CancellationTokenSource for clientless queue task
    /// </summary>
    private CancellationTokenSource _clientlessQueueTaskTokenSource;

    public PendingWindow()
    {
        InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;
        Text = "Pending";

        EventManager.SubscribeEvent("OnClock", OnClock);
    }

    public void ShowAtTop(IWin32Window owner)
    {
        var form = (owner as UserControl).ParentForm;

        var point = new Point(form.Left + form.Width / 2 - Width / 2, form.Top); //  + form.Height / 2 - Height / 2

        Location = point;
        Show(owner);
    }

    internal void Update(Packet packet)
    {
        if (packet.ReadByte() != 1)
            return;

        var end = packet.ReadUShort();
        var timestamp = packet.ReadInt();
        var begin = packet.ReadUShort();

        Log.StatusLang("PendingQueue", Serverlist.Joining?.Name, begin, end);
        labelPending.Text = $"{begin} / {end}";
        PrintTime(labelAvgWaitingTime, timestamp);
        LogPending(begin, end);

        if (GlobalConfig.Get("RSBot.General.EnableQuqueNotification", false))
        {
            var queue = GlobalConfig.Get("RSBot.General.QueueLeft", 30);
            if (begin <= queue && _queueNotifyIndex == 0)
            {
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "Pending Queue Notification";
                notifyIcon.BalloonTipText = $"{begin} / {end}";
                notifyIcon.ShowBalloonTip(2000);
            }

            if (++_queueNotifyIndex > 3)
                _queueNotifyIndex = 0;
        }
    }

    internal void Start(int count, int timestamp)
    {
        AutoLogin.Pending = true;
        _startedTick = Kernel.TickCount;

        Log.StatusLang("PendingQueue", Serverlist.Joining?.Name, count, count);

        labelPending.Text = $"{count} / {count}";
        labelServerName.Text = labelServerName.Text.Replace("{SERVER}", Serverlist.Joining?.Name);

        PrintTime(labelAvgWaitingTime, timestamp);
        LogPending(count, count);

        StartClientlessQueueTask();
    }

    private void StartClientlessQueueTask()
    {
        StopClientlessQueueTask();

        if (!Game.Clientless)
            return;

        _clientlessQueueTaskTokenSource = new CancellationTokenSource();
        var token = _clientlessQueueTaskTokenSource.Token;

        Task.Run(
            async () =>
            {
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        ClientlessManager.RequestServerList();

                        await Task.Delay(5000, token);
                    }
                }
                catch (TaskCanceledException)
                {
                    // Task stopped
                }
                catch (Exception ex)
                {
                    Log.Error($"ClientlessQueueTask error: {ex}");
                }
            },
            token
        );
    }

    internal void StopClientlessQueueTask()
    {
        if (_clientlessQueueTaskTokenSource != null)
        {
            _clientlessQueueTaskTokenSource.Cancel();
            _clientlessQueueTaskTokenSource.Dispose();
            _clientlessQueueTaskTokenSource = null;
        }
    }

    private void OnClock()
    {
        if (!AutoLogin.Pending || !Visible)
            return;

        PrintTime(labelMyWaitingTime, Kernel.TickCount - _startedTick);
    }

    private void PrintTime(Label label, int millisecond)
    {
        //label.RunInUIThread(() =>
        //{
        var text = new StringBuilder();

        var translatedHours = LanguageManager.GetLang("Xhours");
        var translatedMinutes = LanguageManager.GetLang("Xminutes");
        var translatedSeconds = LanguageManager.GetLang("Xseconds");

        var timespan = TimeSpan.FromMilliseconds(millisecond);
        if (timespan.Hours > 0)
            text.AppendFormat(translatedHours + " ", timespan.Hours);

        if (timespan.Minutes > 0)
            text.AppendFormat(translatedMinutes + " ", timespan.Minutes);

        if (timespan.Seconds > 0)
            text.AppendFormat(translatedSeconds, timespan.Seconds);

        label.Text = text.ToString();
        //});
    }

    private void LogPending(int count, int count2)
    {
        if (GlobalConfig.Get<bool>("RSBot.General.PendingEnableQueueLogs"))
            Log.NotifyLang("PendingQueue", Serverlist.Joining?.Name, count, count2);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        PacketManager.SendPacket(new Packet(0x610F, false, false, new byte[] { 0x1 }), PacketDestination.Server);
    }

    private void buttonHide_Click(object sender, EventArgs e)
    {
        Hide();
    }
}
