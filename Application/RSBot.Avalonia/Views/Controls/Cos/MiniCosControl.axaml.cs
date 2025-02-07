using Avalonia.Controls;
using Avalonia.Input;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Mini COS control that displays a small preview with health bar
/// </summary>
public partial class MiniCosControl : UserControl
{
    public MiniCosControl()
    {
        InitializeComponent();
        DataContext = new MiniCosControlViewModel();

        this.PointerPressed += (s, e) =>
        {
            if (DataContext is MiniCosControlViewModel viewModel)
                viewModel.Selected = !viewModel.Selected;
        };
    }

    public void Reset()
    {
        if (DataContext is MiniCosControlViewModel viewModel)
            viewModel.Reset();
    }
} 