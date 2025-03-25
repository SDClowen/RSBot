using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using RSBot.Skills.ViewModels;
using System;
using Avalonia.Markup.Xaml;

namespace RSBot.Skills.Views;

/// <summary>
/// Main view for the Skills plugin that handles skill management and configuration
/// </summary>
public partial class Main : UserControl
{
    /// <summary>
    /// Gets the view model associated with this view
    /// </summary>
    private MainViewModel ViewModel => (MainViewModel)DataContext!;

    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class
    /// </summary>
    public Main()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        SubscribeEvents();
    }

    /// <summary>
    /// Subscribes to the necessary game events
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnLoadCharacter", OnLoadCharacter);
        EventManager.SubscribeEvent("OnSkillLearned", new Action<SkillInfo>(OnSkillLearned));
        EventManager.SubscribeEvent("OnSkillUpgraded", new Action<SkillInfo, SkillInfo>(OnSkillUpgraded));
        EventManager.SubscribeEvent("OnWithdrawSkill", new Action<SkillInfo, SkillInfo>(OnWithdrawSkill));
        EventManager.SubscribeEvent("OnLearnSkillMastery", new Action<MasteryInfo>(OnLearnSkillMastery));
        EventManager.SubscribeEvent("OnAddBuff", new Action<SkillInfo>(OnAddBuff));
        EventManager.SubscribeEvent("OnRemoveBuff", new Action<SkillInfo>(OnRemoveBuff));
        EventManager.SubscribeEvent("OnResurrectionRequest", OnResurrectionRequest);
        EventManager.SubscribeEvent("OnExpSpUpdate", OnSpUpdated);
        EventManager.SubscribeEvent("OnAddItemPerk", new Action<uint, uint>(OnAddItemPerk));
        EventManager.SubscribeEvent("OnRemoveItemPerk", new Action<uint, ItemPerk>(OnRemoveItemPerk));
    }

    /// <summary>
    /// Handles the OnLoadCharacter event
    /// </summary>
    private void OnLoadCharacter()
    {
        ViewModel?.LoadCharacterData();
    }

    /// <summary>
    /// Handles the OnSkillLearned event
    /// </summary>
    private void OnSkillLearned(SkillInfo learnedSkill)
    {
        ViewModel?.OnSkillLearned(learnedSkill);
    }

    /// <summary>
    /// Handles the OnSkillUpgraded event
    /// </summary>
    private void OnSkillUpgraded(SkillInfo oldSkill, SkillInfo newSkill)
    {
        ViewModel?.OnSkillUpgraded(oldSkill, newSkill);
    }

    /// <summary>
    /// Handles the OnWithdrawSkill event
    /// </summary>
    private void OnWithdrawSkill(SkillInfo oldSkill, SkillInfo newSkill)
    {
        ViewModel?.OnWithdrawSkill(oldSkill, newSkill);
    }

    /// <summary>
    /// Handles the OnLearnSkillMastery event
    /// </summary>
    private void OnLearnSkillMastery(MasteryInfo info)
    {
        ViewModel?.OnLearnSkillMastery(info);
    }

    /// <summary>
    /// Handles the OnAddBuff event
    /// </summary>
    private void OnAddBuff(SkillInfo buffInfo)
    {
        ViewModel?.OnAddBuff(buffInfo);
    }

    /// <summary>
    /// Handles the OnRemoveBuff event
    /// </summary>
    private void OnRemoveBuff(SkillInfo removingBuff)
    {
        ViewModel?.OnRemoveBuff(removingBuff);
    }

    /// <summary>
    /// Handles the OnResurrectionRequest event
    /// </summary>
    private void OnResurrectionRequest()
    {
        ViewModel?.OnResurrectionRequest();
    }

    /// <summary>
    /// Handles the OnSpUpdated event
    /// </summary>
    private void OnSpUpdated()
    {
        ViewModel?.OnSpUpdated();
    }

    /// <summary>
    /// Handles the OnAddItemPerk event
    /// </summary>
    private void OnAddItemPerk(uint targetId, uint token)
    {
        ViewModel?.OnAddItemPerk(targetId, token);
    }

    /// <summary>
    /// Handles the OnRemoveItemPerk event
    /// </summary>
    private void OnRemoveItemPerk(uint targetId, ItemPerk removedPerk)
    {
        ViewModel?.OnRemoveItemPerk(targetId, removedPerk);
    }
} 