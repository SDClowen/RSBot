using Avalonia.Controls;
using RSBot.ViewModels;

namespace RSBot.Views.Controls;

/// <summary>
/// Control for recording and managing bot scripts
/// </summary>
public partial class ScriptRecorder : Window
{
    public ScriptRecorder()
    {
        InitializeComponent();
        DataContext = new ScriptRecorderViewModel();
    }
} 