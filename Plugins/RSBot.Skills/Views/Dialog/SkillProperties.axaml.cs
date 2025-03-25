using Avalonia.Controls;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Skills.ViewModels.Dialog;

namespace RSBot.Skills.Views.Dialog;

/// <summary>
/// Dialog window that displays skill properties
/// </summary>
public partial class SkillProperties : Window
{
    /// <summary>
    /// Gets the view model associated with this window
    /// </summary>
    private SkillPropertiesViewModel ViewModel => DataContext as SkillPropertiesViewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="SkillProperties"/> class
    /// </summary>
    /// <param name="skill">The skill to display properties for</param>
    public SkillProperties(RefSkill skill)
    {
        InitializeComponent();
        DataContext = new SkillPropertiesViewModel(skill);
    }
} 