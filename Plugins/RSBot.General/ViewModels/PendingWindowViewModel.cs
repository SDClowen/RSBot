using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.ViewModels;

/// <summary>
/// View model for the pending window that displays queue information and log
/// </summary>
public class PendingWindowViewModel : ReactiveObject
{
    private readonly Window _owner;
    private string _position;
    private string _averageWaitingTime;
    private string _myWaitingTime;
    private int _queueNotifyIndex;
    private int _startedTick;
    private string _serverName;

    public string Position
    {
        get => _position;
        set => this.RaiseAndSetIfChanged(ref _position, value);
    }

    public string AverageWaitingTime
    {
        get => _averageWaitingTime;
        set => this.RaiseAndSetIfChanged(ref _averageWaitingTime, value);
    }

    public string MyWaitingTime
    {
        get => _myWaitingTime;
        set => this.RaiseAndSetIfChanged(ref _myWaitingTime, value);
    }

    public string ServerName
    {
        get => _serverName;
        set => this.RaiseAndSetIfChanged(ref _serverName, value);
    }

    public ReactiveCommand<Unit, Unit> CancelCommand { get; }
    public ReactiveCommand<Unit, Unit> HideCommand { get; }

    public PendingWindowViewModel(Window owner)
    {
        _owner = owner;
        CancelCommand = ReactiveCommand.Create(Cancel);
        HideCommand = ReactiveCommand.Create(this.Hide);

        EventManager.SubscribeEvent("OnClock", OnClock);
        ServerName = $"Server: {Serverlist.Joining?.Name}";
    }

    public void Update(Packet packet)
    {
        if (packet.ReadByte() != 1)
            return;

        var end = packet.ReadUShort();
        var timestamp = packet.ReadInt();
        var begin = packet.ReadUShort();

        Log.StatusLang("PendingQueue", Serverlist.Joining?.Name, begin, end);
        Position = $"{begin} / {end}";
        PrintTime(timestamp, time => AverageWaitingTime = time);
        LogPending(begin, end);

        if (GlobalConfig.Get("RSBot.General.EnableQuqueNotification", false))
        {
            var queue = GlobalConfig.Get("RSBot.General.QueueLeft", 30);
            if (begin <= queue && _queueNotifyIndex == 0)
            {
                // TODO: Implement notification in Avalonia
            }

            if (++_queueNotifyIndex > 3)
                _queueNotifyIndex = 0;
        }
    }

    public void Start(int count, int timestamp)
    {
        AutoLogin.Pending = true;
        _startedTick = Kernel.TickCount;

        Log.StatusLang("PendingQueue", Serverlist.Joining?.Name, count, count);

        Position = $"{count} / {count}";
        ServerName = $"Server: {Serverlist.Joining?.Name}";

        PrintTime(timestamp, time => AverageWaitingTime = time);
        LogPending(count, count);
    }

    private void OnClock()
    {
        if (!AutoLogin.Pending)
            return;

        PrintTime(Kernel.TickCount - _startedTick, time => MyWaitingTime = time);
    }

    private void PrintTime(int millisecond, Action<string> setter)
    {
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

        setter(text.ToString());
    }

    private void LogPending(int count, int count2)
    {
        if (GlobalConfig.Get<bool>("RSBot.General.PendingEnableQueueLogs"))
        {
            var logMessage = LanguageManager.GetLang("PendingQueue", Serverlist.Joining?.Name, count, count2);
            Log.Notify(logMessage);
        }
    }

    private void Cancel()
    {
        PacketManager.SendPacket(new Packet(0x610F, false, false, new byte[] { 0x1 }), PacketDestination.Server);
    }

    private void Hide()
    {
        _owner.Hide();
    }
} 