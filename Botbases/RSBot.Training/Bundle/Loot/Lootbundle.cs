using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Training.Bundle.Loot;

internal class LootBundle : IBundle
{
    /// <summary>
    ///     Gets the configuration.
    /// </summary>
    /// <value>
    ///     The configuration.
    /// </value>
    public LootConfig Config { get; private set; }

    /// <summary>
    ///     Invokes this instance.
    /// </summary>
    public void Invoke()
    {
        if (Bundles.Loot.Config.DontPickupWhileBotting)
            return;

        //If we use the ability pet, we can attack during the work of the Pickup manager
        if (Config.UseAbilityPet && Game.Player.HasActiveAbilityPet && !PickupManager.RunningAbilityPetPickup)
            PickupManager.RunAbilityPet(Container.Bot.Area.Position, Container.Bot.Area.Radius);

        if ((Bundles.Loot.Config.DontPickupInBerzerk && Game.Player.Berzerking) || ScriptManager.Running)
            return;

        //Don't pickup if a mob is selected
        if (Game.SelectedEntity is SpawnedMonster monster && monster.State.LifeState == LifeState.Alive)
            return;

        PickupManager.RunPlayer(Game.Player.Position, Container.Bot.Area.Position, Container.Bot.Area.Radius);
    }

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    public void Refresh()
    {
        Config = new LootConfig
        {
            UseAbilityPet = PlayerConfig.Get("RSBot.Items.Pickup.EnableAbilityPet", true),
            DontPickupWhileBotting = PlayerConfig.Get("RSBot.Items.Pickup.DontPickupWhileBotting", false),
            DontPickupInBerzerk = PlayerConfig.Get("RSBot.Items.Pickup.DontPickupInBerzerk", true),
        };
    }

    public void Stop()
    {
        PickupManager.Stop();
    }
}
