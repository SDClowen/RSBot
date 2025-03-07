using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Fellow pet control that displays fellow information and statistics
/// </summary>
public partial class Fellow : CosControlBase
{
    public Fellow()
    {
        InitializeComponent();
        DataContext = new FellowViewModel(new());
    }

    public void Initialize()
    {
        if (DataContext is FellowViewModel viewModel)
            viewModel.Initialize();
    }

    public void Reset()
    {
        if (DataContext is FellowViewModel viewModel)
            viewModel.Reset();
    }
}