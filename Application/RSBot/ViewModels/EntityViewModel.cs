using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects.Spawn;
using System;

namespace RSBot.ViewModels;

/// <summary>
/// Represents the view model for entity information and statistics
/// </summary>
public class EntityViewModel : ReactiveObject
{
    #region Private Fields

    private string _entityName;
    private string _type;
    private int _healthMaximum;
    private int _health;

    #endregion

    /// <summary>
    /// Initializes a new instance of the EntityViewModel class
    /// </summary>
    public EntityViewModel()
    {
        SubscribeEvents();
        EntityName = LanguageManager.GetLang("LabelEntityName");
        Type = "None";
    }

    #region Public Properties

    /// <summary>
    /// Gets or sets the entity name
    /// </summary>
    public string EntityName
    {
        get => _entityName;
        set => this.RaiseAndSetIfChanged(ref _entityName, value);
    }

    /// <summary>
    /// Gets or sets the entity type
    /// </summary>
    public string Type
    {
        get => _type;
        set => this.RaiseAndSetIfChanged(ref _type, value);
    }

    /// <summary>
    /// Gets or sets the entity maximum health
    /// </summary>
    public int HealthMaximum
    {
        get => _healthMaximum;
        set => this.RaiseAndSetIfChanged(ref _healthMaximum, value);
    }

    /// <summary>
    /// Gets or sets the entity current health
    /// </summary>
    public int Health
    {
        get => _health;
        set => this.RaiseAndSetIfChanged(ref _health, value);
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Subscribes to all required events
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnSelectEntity", new Action<SpawnedBionic>(OnSelectEntity));
        EventManager.SubscribeEvent("OnDeselectEntity", OnDeselectEntity);
        EventManager.SubscribeEvent("OnUpdateEntityHp", new Action<SpawnedBionic>(OnUpdateEntityHp));
        EventManager.SubscribeEvent("OnKillSelectedEnemy", OnKillSelectedEnemy);
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
        EventManager.SubscribeEvent("OnInitialized", OnInitialized);
    }

    /// <summary>
    /// Handles the initialization event
    /// </summary>
    private void OnInitialized()
    {
        EntityName = LanguageManager.GetLang("LabelEntityName");
        Type = "None";
    }

    /// <summary>
    /// Handles the entity selection event
    /// </summary>
    /// <param name="entity">The selected entity</param>
    private void OnSelectEntity(SpawnedBionic entity)
    {
        Type = string.Empty;
        if (entity is SpawnedPlayer player)
            EntityName = player.Name;
        else
            EntityName = entity.Record.GetRealName();

        if (entity is SpawnedMonster monster)
        {
            try
            {
                HealthMaximum = monster.MaxHealth;
                Health = monster.Health;
            }
            catch
            {
                // Ignore exceptions during health update
            }

            Type = monster.Rarity.GetName();
        }
        else
        {
            Health = 100;
            HealthMaximum = 100;

            if (Game.Player.State.DialogState is { IsInDialog: true })
                Type = "<in conversation>";
        }
    }

    /// <summary>
    /// Handles the entity health update event
    /// </summary>
    /// <param name="entity">The entity whose health was updated</param>
    private void OnUpdateEntityHp(SpawnedBionic entity)
    {
        if (Game.SelectedEntity?.UniqueId != entity.UniqueId)
            return;

        if (!entity.HasHealth)
        {
            Health = 100;
            HealthMaximum = 100;
            return;
        }

        if (entity is SpawnedMonster monster)
        {
            HealthMaximum = monster.MaxHealth;
            Health = monster.Health;
        }
    }

    /// <summary>
    /// Handles the entity deselection event
    /// </summary>
    private void OnDeselectEntity()
    {
        Clear();
    }

    /// <summary>
    /// Handles the selected enemy kill event
    /// </summary>
    private void OnKillSelectedEnemy()
    {
        Clear();
    }

    /// <summary>
    /// Handles the agent server disconnected event
    /// </summary>
    private void OnAgentServerDisconnected()
    {
        Clear();
    }

    /// <summary>
    /// Clears all entity information
    /// </summary>
    private void Clear()
    {
        EntityName = LanguageManager.GetLang("LabelEntityName");
        Health = 0;
        HealthMaximum = 100;
        Type = "None";
    }

    #endregion
} 