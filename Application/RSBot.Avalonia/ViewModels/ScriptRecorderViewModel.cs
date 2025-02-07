using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Input;

namespace RSBot.ViewModels;

/// <summary>
/// View model for the script recorder that manages recording and playback of bot actions
/// </summary>
public class ScriptRecorderViewModel : ReactiveObject
{
    private bool _isRecording;
    private ScriptAction _selectedAction;
    private int _selectedIndex = -1;

    public ScriptRecorderViewModel()
    {
        RecordedActions = new ObservableCollection<ScriptAction>();

        RecordCommand = ReactiveCommand.Create(ExecuteRecord);
        StopCommand = ReactiveCommand.Create(ExecuteStop);
        SaveCommand = ReactiveCommand.Create(ExecuteSave);
        ClearCommand = ReactiveCommand.Create(ExecuteClear);
        MoveUpCommand = ReactiveCommand.Create(ExecuteMoveUp);
        MoveDownCommand = ReactiveCommand.Create(ExecuteMoveDown);
        DeleteCommand = ReactiveCommand.Create(ExecuteDelete);

        SubscribeEvents();
    }

    public ObservableCollection<ScriptAction> RecordedActions { get; }

    public bool IsRecording
    {
        get => _isRecording;
        set => this.RaiseAndSetIfChanged(ref _isRecording, value);
    }

    public ScriptAction SelectedAction
    {
        get => _selectedAction;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedAction, value);
            _selectedIndex = RecordedActions.IndexOf(value);
            this.RaisePropertyChanged(nameof(CanMoveUp));
            this.RaisePropertyChanged(nameof(CanMoveDown));
            this.RaisePropertyChanged(nameof(CanDelete));
        }
    }

    public bool HasRecordedActions => RecordedActions.Any();
    public bool CanMoveUp => _selectedIndex > 0;
    public bool CanMoveDown => _selectedIndex >= 0 && _selectedIndex < RecordedActions.Count - 1;
    public bool CanDelete => SelectedAction != null;

    public ICommand RecordCommand { get; }
    public ICommand StopCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand ClearCommand { get; }
    public ICommand MoveUpCommand { get; }
    public ICommand MoveDownCommand { get; }
    public ICommand DeleteCommand { get; }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnPlayerMove", OnPlayerMove);
        EventManager.SubscribeEvent("OnPlayerAttack", OnPlayerAttack);
        EventManager.SubscribeEvent("OnPlayerUseSkill", OnPlayerUseSkill);
        EventManager.SubscribeEvent("OnPlayerUseItem", OnPlayerUseItem);
    }

    private void OnPlayerMove()
    {
        if (!IsRecording) return;

        var position = Game.Player.Position;
        AddAction($"Move to X:{position.X:F2} Y:{position.Y:F2}");
    }

    private void OnPlayerAttack()
    {
        if (!IsRecording) return;

        var target = Game.SelectedEntity;
        if (target != null)
            AddAction($"Attack {target.Id}");
    }

    private void OnPlayerUseSkill(uint skillId)
    {
        if (!IsRecording) return;

        var skill = Game.ReferenceManager.GetRefSkill(skillId);
        if (skill != null)
            AddAction($"Use skill {skill.GetRealName()}");
    }

    private void OnPlayerUseItem(uint itemId)
    {
        if (!IsRecording) return;

        var item = Game.ReferenceManager.GetRefItem(itemId);
        if (item != null)
            AddAction($"Use item {item.GetRealName()}");
    }

    private void AddAction(string description)
    {
        RecordedActions.Add(new ScriptAction { Description = description });
        this.RaisePropertyChanged(nameof(HasRecordedActions));
    }

    private void ExecuteRecord()
    {
        IsRecording = true;
    }

    private void ExecuteStop()
    {
        IsRecording = false;
    }

    private async void ExecuteSave()
    {
        var dialog = new SaveFileDialog
        {
            Title = "Save Script",
            DefaultExtension = ".rbs"
        };

        var result = await dialog.ShowAsync(null);
        if (!string.IsNullOrEmpty(result))
        {
            var scriptData = new ScriptData
            {
                Version = "1.0",
                CreatedAt = DateTime.Now,
                Actions = RecordedActions.ToList()
            };

            var json = JsonSerializer.Serialize(scriptData, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            
            await File.WriteAllTextAsync(result, json);
        }
    }

    private void ExecuteClear()
    {
        RecordedActions.Clear();
        this.RaisePropertyChanged(nameof(HasRecordedActions));
    }

    private void ExecuteMoveUp()
    {
        if (!CanMoveUp) return;

        var index = _selectedIndex;
        var item = RecordedActions[index];
        RecordedActions.RemoveAt(index);
        RecordedActions.Insert(index - 1, item);
        SelectedAction = item;
    }

    private void ExecuteMoveDown()
    {
        if (!CanMoveDown) return;

        var index = _selectedIndex;
        var item = RecordedActions[index];
        RecordedActions.RemoveAt(index);
        RecordedActions.Insert(index + 1, item);
        SelectedAction = item;
    }

    private void ExecuteDelete()
    {
        if (!CanDelete) return;

        var index = _selectedIndex;
        RecordedActions.RemoveAt(index);
        this.RaisePropertyChanged(nameof(HasRecordedActions));

        if (index < RecordedActions.Count)
            SelectedAction = RecordedActions[index];
        else if (RecordedActions.Any())
            SelectedAction = RecordedActions.Last();
        else
            SelectedAction = null;
    }
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