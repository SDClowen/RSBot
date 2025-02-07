using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Ability pet control that displays ability pet information
/// </summary>
public partial class Ability : CosControlBase
{
    public Ability()
    {
        InitializeComponent();
        DataContext = new AbilityViewModel(new());
    }

    public void Initialize()
    {
        if (DataContext is AbilityViewModel viewModel)
            viewModel.Initialize();
    }

    public void Reset()
    {
        if (DataContext is AbilityViewModel viewModel)
            viewModel.Reset();
    }
}