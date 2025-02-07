using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Job transport pet control that displays job transport information
/// </summary>
public partial class JobTransport : CosControlBase
{
    public JobTransport()
    {
        InitializeComponent();
        DataContext = new JobTransportViewModel(new());
    }

    public void Initialize()
    {
        if (DataContext is JobTransportViewModel viewModel)
            viewModel.Initialize();
    }

    public void Reset()
    {
        if (DataContext is JobTransportViewModel viewModel)
            viewModel.Reset();
    }
} 