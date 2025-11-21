namespace RSBot.Training.Bundle.Loot;

internal class LootConfig
{
    /// <summary>
    ///     Gets or sets a value indicating whether [use ability pet].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [use ability pet]; otherwise, <c>false</c>.
    /// </value>
    public bool UseAbilityPet { get; set; }

    /// <summary>
    ///     Gets a value , <c>true</c> Turn off the pickup if the player botting, otherwise <c>false</c>
    /// </summary>
    public bool DontPickupWhileBotting { get; set; }

    /// <summary>
    ///     Gets a value , <c>true</c> Turn off the pickup if the player in berzerk mode, otherwise <c>false</c>
    /// </summary>
    public bool DontPickupInBerzerk { get; set; }
}
