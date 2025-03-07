namespace RSBot.Items.Avalonia.Models;

/// <summary>
/// Represents the item filter settings for the RSBot Items plugin.
/// Contains various boolean properties for filtering different types of weapons, armor, and other items.
/// </summary>
public class ItemFilters
{
    #region Weapon Filters

    /// <summary>
    /// Gets or sets whether to filter sword type weapons
    /// </summary>
    public bool WeaponSword { get; set; }

    /// <summary>
    /// Gets or sets whether to filter blade type weapons
    /// </summary>
    public bool WeaponBlade { get; set; }

    /// <summary>
    /// Gets or sets whether to filter spear type weapons
    /// </summary>
    public bool WeaponSpear { get; set; }

    /// <summary>
    /// Gets or sets whether to filter glave type weapons
    /// </summary>
    public bool WeaponGlave { get; set; }

    /// <summary>
    /// Gets or sets whether to filter bow type weapons
    /// </summary>
    public bool WeaponBow { get; set; }

    /// <summary>
    /// Gets or sets whether to filter one-handed sword type weapons
    /// </summary>
    public bool Weapon1HSword { get; set; }

    /// <summary>
    /// Gets or sets whether to filter two-handed sword type weapons
    /// </summary>
    public bool Weapon2HSword { get; set; }

    /// <summary>
    /// Gets or sets whether to filter staff type weapons
    /// </summary>
    public bool WeaponStaff { get; set; }

    /// <summary>
    /// Gets or sets whether to filter crossbow type weapons
    /// </summary>
    public bool WeaponXBow { get; set; }

    /// <summary>
    /// Gets or sets whether to filter dagger type weapons
    /// </summary>
    public bool WeaponDagger { get; set; }

    /// <summary>
    /// Gets or sets whether to filter harp type weapons
    /// </summary>
    public bool WeaponHarp { get; set; }

    /// <summary>
    /// Gets or sets whether to filter cold rod type weapons
    /// </summary>
    public bool WeaponCRod { get; set; }

    /// <summary>
    /// Gets or sets whether to filter warm rod type weapons
    /// </summary>
    public bool WeaponWRod { get; set; }

    /// <summary>
    /// Gets or sets whether to filter shield type weapons
    /// </summary>
    public bool WeaponShield { get; set; }

    /// <summary>
    /// Gets or sets whether to filter axe type weapons
    /// </summary>
    public bool WeaponAxe { get; set; }

    #endregion

    #region Armor Filters

    /// <summary>
    /// Gets or sets whether to filter heavy armor
    /// </summary>
    public bool ArmorHeavy { get; set; }

    /// <summary>
    /// Gets or sets whether to filter light armor
    /// </summary>
    public bool ArmorLight { get; set; }

    /// <summary>
    /// Gets or sets whether to filter cloth armor
    /// </summary>
    public bool ArmorClothes { get; set; }

    /// <summary>
    /// Gets or sets whether to filter protector armor
    /// </summary>
    public bool ArmorProtector { get; set; }

    /// <summary>
    /// Gets or sets whether to filter head armor
    /// </summary>
    public bool ArmorHead { get; set; }

    /// <summary>
    /// Gets or sets whether to filter shoulder armor
    /// </summary>
    public bool ArmorShoulder { get; set; }

    /// <summary>
    /// Gets or sets whether to filter chest armor
    /// </summary>
    public bool ArmorChest { get; set; }

    /// <summary>
    /// Gets or sets whether to filter leg armor
    /// </summary>
    public bool ArmorLegs { get; set; }

    /// <summary>
    /// Gets or sets whether to filter hand armor
    /// </summary>
    public bool ArmorHand { get; set; }

    #endregion

    #region Other Filters

    /// <summary>
    /// Gets or sets whether to filter coin items
    /// </summary>
    public bool OtherCoin { get; set; }

    /// <summary>
    /// Gets or sets whether to filter quest items
    /// </summary>
    public bool OtherQuest { get; set; }

    /// <summary>
    /// Gets or sets whether to filter ammunition items
    /// </summary>
    public bool OtherAmmo { get; set; }

    /// <summary>
    /// Gets or sets whether to filter alchemy items
    /// </summary>
    public bool OtherAlchemy { get; set; }

    /// <summary>
    /// Gets or sets whether to filter other items
    /// </summary>
    public bool OtherOther { get; set; }

    #endregion
} 