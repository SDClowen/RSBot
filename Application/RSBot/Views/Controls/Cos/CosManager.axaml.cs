using Avalonia.Controls;
using RSBot.ViewModels.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Manager control for COS (Companion System) that handles displaying and switching between different COS controls
/// </summary>
public partial class CosManager : UserControl
{
    /// <summary>
    /// Initializes a new instance of the CosManager control
    /// </summary>
    public CosManager()
    {
        InitializeComponent();
        DataContext = new CosManagerViewModel();
    }
}