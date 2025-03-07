using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Mini control for displaying Cos (Companion) status in a compact form
/// </summary>
public partial class MiniCosControl : UserControl
{
    private bool _selected;

    /// <summary>
    /// Gets the HP progress bar
    /// </summary>
    public ProgressBar Hp => this.FindControl<ProgressBar>("progressHP");

    /// <summary>
    /// Gets or sets a value indicating whether this control is selected
    /// </summary>
    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            var border = this.FindControl<Border>("border");
            border.BorderBrush = value ? Brushes.DodgerBlue : null;
            border.BorderThickness = value ? new Thickness(2) : new Thickness(1);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MiniCosControl"/> class.
    /// </summary>
    public MiniCosControl()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        e.Handled = true;
    }
} 