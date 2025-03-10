using Avalonia.Media.Imaging;
using ReactiveUI;
using RSBot.CommandCenter.Avalonia.Components;
using RSBot.Core;
using RSBot.Core.Components;
using System.Collections.ObjectModel;

namespace RSBot.CommandCenter.Avalonia.ViewModels;

/// <summary>
/// View model for the emoticon action element
/// </summary>
public class EmoticonActionElementViewModel : ReactiveObject
{
    private ActionComboBoxItem _selectedAction;
    private readonly EmoticonItem _emoticon;

    /// <summary>
    /// Gets the emoticon name
    /// </summary>
    public string Name => _emoticon.Label;

    /// <summary>
    /// Gets the emoticon icon image
    /// </summary>
    public Bitmap IconImage => _emoticon.GetIconImage();

    /// <summary>
    /// Gets the available actions
    /// </summary>
    public ObservableCollection<ActionComboBoxItem> Actions { get; }

    /// <summary>
    /// Gets or sets the selected action
    /// </summary>
    public ActionComboBoxItem SelectedAction
    {
        get => _selectedAction;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedAction, value);
            if (value != null)
                SaveSelectedAction(value.ActionName);
        }
    }

    /// <summary>
    /// Initializes a new instance of the EmoticonActionElementViewModel class
    /// </summary>
    /// <param name="emoticon">The emoticon item</param>
    /// <param name="selectedActionName">The initially selected action name</param>
    public EmoticonActionElementViewModel(EmoticonItem emoticon, string selectedActionName = null)
    {
        _emoticon = emoticon;
        Actions = new ObservableCollection<ActionComboBoxItem>();

        PopulateActions(selectedActionName);
    }

    /// <summary>
    /// Populates the actions collection
    /// </summary>
    private void PopulateActions(string selectedActionName)
    {
        Actions.Clear();

        foreach (var command in CommandManager.GetCommandDescriptions())
        {
            var item = new ActionComboBoxItem(command.Key, command.Value);
            Actions.Add(item);

            if (selectedActionName == command.Key)
                SelectedAction = item;
        }
    }

    /// <summary>
    /// Saves the selected action to the player config
    /// </summary>
    private void SaveSelectedAction(string actionName)
    {
        PlayerConfig.Set($"RSBot.CommandCenter.MappedEmotes.{_emoticon.Name}", actionName);
    }
}

/// <summary>
/// Represents an action item in the combo box
/// </summary>
/// <param name="ActionName">The name of the action</param>
/// <param name="ActionDescription">The description of the action</param>
public record ActionComboBoxItem(string ActionName, string ActionDescription); 