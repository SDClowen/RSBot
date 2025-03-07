using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Base control for COS (Companion System) related controls that provides common functionality
/// </summary>
public partial class CosControlBase : UserControl
{
    private MiniCosControl _miniCosControl;

    /// <summary>
    /// Gets the mini COS control associated with this control
    /// </summary>
    public MiniCosControl MiniCosControl => _miniCosControl ??= new MiniCosControl();

    /// <summary>
    /// Initializes a new instance of the CosControlBase class
    /// </summary>
    public CosControlBase()
    {
        InitializeComponent();
        DataContext = new CosControlBaseViewModel(new MiniCosControlViewModel());
    }

    /// <summary>
    /// Initializes the control and its associated view model
    /// </summary>
    public virtual void Initialize()
    {
        if (DataContext is CosControlBaseViewModel viewModel)
            viewModel.Initialize();
    }

    /// <summary>
    /// Resets the control and its associated view model to their default states
    /// </summary>
    public virtual void Reset()
    {
        if (DataContext is CosControlBaseViewModel viewModel)
            viewModel.Reset();
    }
} 