using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.ViewModels;

namespace RSBot.Views.Controls;

/// <summary>
/// Represents a user control for displaying character information including name, level, HP, MP and experience
/// </summary>
public partial class Character : UserControl
{
    /// <summary>
    /// Initializes a new instance of the Character control
    /// </summary>
    public Character()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the Character control with a specific character view model
    /// </summary>
    /// <param name="characterViewModel">The view model containing character data to display</param>
    public Character(CharacterViewModel characterViewModel)
    {
        InitializeComponent();
        DataContext = characterViewModel;
    }
} 