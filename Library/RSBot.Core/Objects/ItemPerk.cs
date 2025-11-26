using System.ComponentModel.DataAnnotations;
using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Objects;

public class ItemPerk
{
    #region Properties

    [Required]
    public uint ItemId { get; init; }

    [Required]
    public uint Token { get; init; }

    public uint Value { get; set; }

    public uint RemainingTime { get; set; }

    public RefObjItem? Item => Game.ReferenceManager.GetRefItem(ItemId);

    #endregion Properties
}
