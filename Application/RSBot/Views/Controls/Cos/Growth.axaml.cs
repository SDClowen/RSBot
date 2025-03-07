using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Growth pet control that displays growth information and statistics
/// </summary>
public partial class Growth : CosControlBase
{
    public Growth()
    {
        InitializeComponent();
        DataContext = new GrowthViewModel(new());
    }

    public void Initialize()
    {
        if (DataContext is GrowthViewModel viewModel)
            viewModel.Initialize();
    }

    public void Reset()
    {
        if (DataContext is GrowthViewModel viewModel)
            viewModel.Reset();
    }
} 