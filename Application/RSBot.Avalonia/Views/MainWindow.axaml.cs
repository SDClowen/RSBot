using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using RSBot.Extensions;
using RSBot.ViewModels;
using System.Windows.Input;
using ReactiveUI;
using RSBot.Core.Components;

namespace RSBot.Views;

/// <summary>
/// Main window of the application that hosts all controls and views
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the MainWindow class
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        LanguageManager.Translate(this);
        DataContext = new MainWindowViewModel(this);

        this.Opened += (_, __) =>
        {
            this.EnableMica();
            this.EnableDarkMode();


        };

        this.PointerPressed += OnPointerPressed;
    }

    /// <summary>
    /// Handles the pointer pressed event to enable window dragging
    /// </summary>
    /// <param name="sender">The event sender</param>
    /// <param name="e">The event arguments</param>
    private void OnPointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            BeginMoveDrag(e);
    }
}