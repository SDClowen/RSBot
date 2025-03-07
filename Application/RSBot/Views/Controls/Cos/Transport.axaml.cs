using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Transport pet control that displays transport information
/// </summary>
public partial class Transport : CosControlBase
{
    public Transport()
    {
        InitializeComponent();
        DataContext = new TransportViewModel(new());
    }

    public void Initialize()
    {
        if (DataContext is TransportViewModel viewModel)
            viewModel.Initialize();
    }

    public void Reset()
    {
        if (DataContext is TransportViewModel viewModel)
            viewModel.Reset();
    }
} 