using Avalonia.Controls;
using RSBot.CommandCenter.Avalonia.Components;
using RSBot.CommandCenter.Avalonia.ViewModels;

namespace RSBot.CommandCenter.Avalonia.Views.Controls;

/// <summary>
/// Control for managing emoticon actions
/// </summary>
public partial class EmoticonActionElement : UserControl
{
    /// <summary>
    /// Initializes a new instance of the EmoticonActionElement class
    /// </summary>
    /// <param name="item">The emoticon item</param>
    /// <param name="selectedActionName">The initially selected action name</param>
    public EmoticonActionElement(EmoticonItem item, string selectedActionName = null)
    {
        InitializeComponent();

        DataContext = new EmoticonActionElementViewModel(item, selectedActionName);
    }
} 