using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Base control for Cos (Companion) entities providing common functionality
/// </summary>
public class CosControlBase : UserControl
{
    /// <summary>
    /// Gets the mini cos control associated with this control
    /// </summary>
    public MiniCosControl MiniCosControl { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CosControlBase"/> class.
    /// </summary>
    public CosControlBase()
    {
        InitializeComponent();

        MiniCosControl = new MiniCosControl();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    /// Initializes the control with default values
    /// </summary>
    public virtual void Initialize()
    {
    }

    /// <summary>
    /// Resets the control to its default state
    /// </summary>
    public virtual void Reset()
    {
        var progressHP = this.FindControl<ProgressBar>("progressHP");
        progressHP.Value = 0;
        progressHP.Maximum = 0;

        MiniCosControl.Hp.Value = 0;
        MiniCosControl.Hp.Maximum = 0;
    }
} 