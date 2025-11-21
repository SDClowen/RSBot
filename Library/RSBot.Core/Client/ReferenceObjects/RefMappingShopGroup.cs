namespace RSBot.Core.Client.ReferenceObjects;

public class RefMappingShopGroup : IReference
{
    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        parser.TryParse(1, out Country);
        parser.TryParse(2, out Group);
        parser.TryParse(3, out Shop);

        return true;
    }

    #region Fields

    /// <summary>
    ///     Gets or sets the service.
    /// </summary>
    /// <value>
    ///     The service.
    /// </value>
    public byte Service;

    /// <summary>
    ///     Gets or sets the country.
    /// </summary>
    /// <value>
    ///     The country.
    /// </value>
    public int Country;

    /// <summary>
    ///     Gets or sets the group.
    /// </summary>
    /// <value>
    ///     The group.
    /// </value>
    public string Group;

    /// <summary>
    ///     Gets or sets the shop.
    /// </summary>
    /// <value>
    ///     The shop.
    /// </value>
    public string Shop;

    #endregion Fields
}
