using Avalonia.Controls;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Skills.ViewModels.Dialog;

namespace RSBot.Skills.Views.Dialog;

/// <summary>
/// Dialog window that displays buff properties
/// </summary>
public partial class BuffProperties : Window
{
    /// <summary>
    /// Gets the view model associated with this window
    /// </summary>
    private BuffPropertiesViewModel ViewModel => DataContext as BuffPropertiesViewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="BuffProperties"/> class for a skill buff
    /// </summary>
    /// <param name="skillInfo">The skill buff to display properties for</param>
    public BuffProperties(SkillInfo skillInfo)
    {
        InitializeComponent();
        DataContext = new BuffPropertiesViewModel(skillInfo);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BuffProperties"/> class for an item perk
    /// </summary>
    /// <param name="itemPerk">The item perk to display properties for</param>
    public BuffProperties(ItemPerk itemPerk)
    {
        InitializeComponent();
        DataContext = new BuffPropertiesViewModel(itemPerk);
    }
} 