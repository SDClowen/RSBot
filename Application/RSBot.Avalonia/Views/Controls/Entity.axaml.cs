using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.ViewModels;

namespace RSBot.Views.Controls;

/// <summary>
/// Represents a user control for displaying entity information including name, type and health
/// </summary>
public partial class Entity : UserControl
{
    /// <summary>
    /// Initializes a new instance of the Entity control
    /// </summary>
    public Entity()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the Entity control with a specific entity view model
    /// </summary>
    /// <param name="entityViewModel">The view model containing entity data to display</param>
    public Entity(EntityViewModel entityViewModel)
    {
        InitializeComponent();
        DataContext = entityViewModel;
    }
}