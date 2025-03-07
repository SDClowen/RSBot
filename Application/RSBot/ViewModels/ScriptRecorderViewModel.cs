using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Scripting;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RSBot.ViewModels;

/// <summary>
/// View model for the script recorder that manages recording and playback of bot actions
/// </summary>
public class ScriptRecorderViewModel : ReactiveObject
{
    #region Private Fields

    private readonly int _ownerId;
    private bool _isRecording;
    private bool _isRunning;
    private string _scriptText = string.Empty;
    private string _status = "Idle";
    private bool _canRun;
    private int _selectedCommandIndex;
    private IBrush _highlightBrush;

    #endregion Private Fields

    #region Constructor

    public ScriptRecorderViewModel(int ownerId = 0, bool startRecording = false)
    {
        _ownerId = ownerId;
        _canRun = true;
        _highlightBrush = new SolidColorBrush(Colors.CornflowerBlue);

        InitializeCommands();
        SubscribeEvents();
        PopulateCommandList();

        if (startRecording)
            StartRecording();

        this.WhenAnyValue(x => x.ScriptText)
            .Subscribe(_ => 
            {
                this.RaisePropertyChanged(nameof(CanSave));
                this.RaisePropertyChanged(nameof(CanClear));
            });
    }

    #endregion Constructor

    #region Properties

    public bool IsRecording
    {
        get => _isRecording;
        set => this.RaiseAndSetIfChanged(ref _isRecording, value);
    }

    public bool IsRunning
    {
        get => _isRunning;
        set => this.RaiseAndSetIfChanged(ref _isRunning, value);
    }

    public string ScriptText
    {
        get => _scriptText;
        set => this.RaiseAndSetIfChanged(ref _scriptText, value);
    }

    public string Status
    {
        get => _status;
        set => this.RaiseAndSetIfChanged(ref _status, value);
    }

    public bool CanRun
    {
        get => _canRun && !string.IsNullOrWhiteSpace(ScriptText) && !IsRecording;
        set => this.RaiseAndSetIfChanged(ref _canRun, value);
    }

    public bool CanSave => !string.IsNullOrWhiteSpace(ScriptText);
    public bool CanClear => !string.IsNullOrWhiteSpace(ScriptText);

    public int SelectedCommandIndex
    {
        get => _selectedCommandIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedCommandIndex, value);
    }

    public ObservableCollection<IScriptCommand> Commands { get; } = new();

    #endregion Properties

    #region Commands

    public ReactiveCommand<Unit, Unit> StartStopCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> RunCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> ClearCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> SaveCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> AddCommandCommand { get; private set; }

    #endregion Commands

    #region Private Methods

    private void InitializeCommands()
    {
        StartStopCommand = ReactiveCommand.Create(ExecuteStartStop);
        RunCommand = ReactiveCommand.Create(ExecuteRun);
        ClearCommand = ReactiveCommand.Create(ExecuteClear);
        SaveCommand = ReactiveCommand.Create(ExecuteSave);
        AddCommandCommand = ReactiveCommand.Create(ExecuteAddCommand);
    }

    private void PopulateCommandList()
    {
        foreach (var command in ScriptManager.CommandHandlers)
            Commands.Add(command);
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnPlayerMove", OnPlayerMove);
        EventManager.SubscribeEvent("OnVehicleMove", OnPlayerMove);
        EventManager.SubscribeEvent("OnRequestTeleport", new Action<uint, string>(OnRequestTeleport));
        EventManager.SubscribeEvent("OnTerminateVehicle", OnTerminateVehicle);
        EventManager.SubscribeEvent("OnTeleportComplete", OnTeleportComplete);
        EventManager.SubscribeEvent("OnScriptStartExecuteCommand", new Action<IScriptCommand, int>(OnScriptStartExecuteCommand));
        EventManager.SubscribeEvent("OnNpcRepairRequest", new Action<uint, byte, byte>(OnNpcRepairRequest));
        EventManager.SubscribeEvent("OnStorageOpenRequest", new Action<uint>(StorageOpenRequest));
        EventManager.SubscribeEvent("OnTalkRequest", new Action<uint, TalkOption>(OnTalkRequest));
        EventManager.SubscribeEvent("OnFinishScript", new Action<bool>(OnFinishScript));
        EventManager.SubscribeEvent("OnCastSkill", new Action<uint>(OnCastSkill));
        EventManager.SubscribeEvent("AppendScriptCommand", new Action<string>(AppendScriptCommand));
    }

    private void StartRecording()
    {
        Status = LanguageManager.GetLang("Recording");
        IsRecording = true;
        CanRun = false;
    }

    private void StopRecording()
    {
        Status = LanguageManager.GetLang("Idle");
        IsRecording = false;
        CanRun = true;
    }

    #region Command Executions

    private void ExecuteStartStop()
    {
        if (ScriptManager.Running)
            return;

        if (IsRecording)
            StopRecording();
        else
            StartRecording();
    }

    private void ExecuteRun()
    {
        if (IsRecording || string.IsNullOrWhiteSpace(ScriptText))
            return;

        if (IsRunning)
        {
            ScriptManager.Stop();
            Status = LanguageManager.GetLang("Idle");
            IsRunning = false;
        }
        else
        {
            if (ScriptManager.Running)
                return;

            ScriptManager.Load(ScriptText.Split('\n'));
            Task.Run(() => ScriptManager.RunScript(false, true));

            Status = LanguageManager.GetLang("Running");
            IsRunning = true;
        }
    }

    private void ExecuteClear()
    {
        ScriptText = string.Empty;
    }

    private async void ExecuteSave()
    {
        if (string.IsNullOrWhiteSpace(ScriptText))
            return;

        var dialog = new SaveFileDialog
        {
            Title = LanguageManager.GetLang("SaveRecordedScript"),
            InitialFileName = "script.rbs",
            DefaultExtension = "rbs"
        };

        var file = await dialog.ShowAsync(null);
        if (!string.IsNullOrEmpty(file))
        {
            EventManager.FireEvent("OnSaveScript", _ownerId, file);
            await File.WriteAllTextAsync(file, ScriptText);
        }
    }

    private void ExecuteAddCommand()
    {
        if (SelectedCommandIndex < 0 || SelectedCommandIndex >= Commands.Count)
            return;

        var selectedCommand = Commands[SelectedCommandIndex];
        if (selectedCommand.Arguments == null || selectedCommand.Arguments.Count == 0)
        {
            AppendScriptCommand(selectedCommand.Name);
            return;
        }

        // Command dialog will be handled by the view
        EventManager.FireEvent("ShowCommandDialog", selectedCommand);
    }

    #endregion Command Executions

    #region Event Handlers

    private void OnFinishScript(bool error = false)
    {
        Status = LanguageManager.GetLang(IsRunning ? "StopRunning" : "Idle");
        IsRunning = !IsRunning;
    }

    private void OnCastSkill(uint skillId)
    {
        if (!IsRecording) return;
        AppendScriptCommand($"cast {Game.ReferenceManager.GetRefSkill(skillId).Basic_Code}");
    }

    private void AppendScriptCommand(string command)
    {
        if (!IsRecording) return;
        ScriptText += command + Environment.NewLine;
    }

    private void OnTalkRequest(uint entityId, TalkOption option)
    {
        if (!IsRecording) return;

        if (!SpawnManager.TryGetEntity<SpawnedBionic>(entityId, out var entity))
            return;

        switch (option)
        {
            case TalkOption.Store:
                AppendScriptCommand($"buy {entity.Record.CodeName}");
                break;

            case TalkOption.Trader:
                AppendScriptCommand($"open-trade {entity.Record.CodeName}");
                break;
        }
    }

    private void StorageOpenRequest(uint entityId)
    {
        if (!IsRecording) return;

        if (!SpawnManager.TryGetEntity<SpawnedBionic>(entityId, out var entity))
            return;

        AppendScriptCommand($"store {entity.Record.CodeName}");
    }

    private void OnNpcRepairRequest(uint entityId, byte type, byte slot)
    {
        if (!IsRecording) return;

        if (!SpawnManager.TryGetEntity<SpawnedBionic>(entityId, out var entity))
            return;

        AppendScriptCommand($"repair {entity.Record.CodeName}");
    }

    private void OnScriptStartExecuteCommand(IScriptCommand command, int lineNumber)
    {
        if (!ScriptManager.Running)
            return;

        EventManager.FireEvent("HighlightScriptLine", lineNumber, _highlightBrush);
    }

    private void OnPlayerMove()
    {
        if (!IsRecording)
            return;

        SpawnedEntity entity = Game.Player;
        if (Game.Player.HasActiveVehicle)
            entity = Game.Player.Vehicle.Bionic;

        if (!entity.Movement.HasDestination)
            return;

        var destination = entity.Movement.Destination;

        StringBuilder stepString = new();
        stepString.Append($"move {destination.XOffset:0}");
        stepString.Append($" {destination.YOffset:0}");
        stepString.Append($" {destination.ZOffset:0}");
        stepString.Append($" {destination.Region.X}");
        stepString.Append($" {destination.Region.Y}");
        stepString.AppendLine();

        ScriptText += stepString.ToString();
    }

    private void OnRequestTeleport(uint destination, string npcCodeName)
    {
        if (!IsRecording)
            return;

        AppendScriptCommand($"teleport {npcCodeName} {destination}");
    }

    private void OnTerminateVehicle()
    {
        if (!IsRecording)
            return;

        AppendScriptCommand("dismount");
    }

    private void OnTeleportComplete()
    {
        if (!IsRecording) return;
        AppendScriptCommand("wait 5000");
    }

    #endregion Event Handlers

    #endregion Private Methods
}

public class ScriptAction
{
    public string Description { get; set; }
    public string Type { get; set; }
    public object Parameters { get; set; }
}

public class ScriptData
{
    public string Version { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ScriptAction> Actions { get; set; }
} 