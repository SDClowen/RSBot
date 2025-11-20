namespace RSBot.Core.Client.ReferenceObjects;

public class RefPackageItem
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RefPackageItem" /> class.
    /// </summary>
    /// <param name="data">The data.</param>
    public RefPackageItem(string[] data)
    {
        if (data == null)
            return;
        Service = byte.Parse(data[0]);
        Country = int.Parse(data[1]);
        RefPackageItemCodeName = data[2];
        RefItemCodeName = data[3];
        OptLevel = byte.Parse(data[4]);
        Variance = long.Parse(data[5]);
        Data = int.Parse(data[6]);
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
    ///     Gets or sets the name of the reference package item code.
    /// </summary>
    /// <value>
    ///     The name of the reference package item code.
    /// </value>
    public string RefPackageItemCodeName;

    /// <summary>
    ///     Gets or sets the name of the reference item code.
    /// </summary>
    /// <value>
    ///     The name of the reference item code.
    /// </value>
    public string RefItemCodeName;

    /// <summary>
    ///     Gets or sets the opt level.
    /// </summary>
    /// <value>
    ///     The opt level.
    /// </value>
    public byte OptLevel;

    /// <summary>
    ///     Gets or sets the variance.
    /// </summary>
    /// <value>
    ///     The variance.
    /// </value>
    public long Variance;

    /// <summary>
    ///     Gets or sets the data.
    /// </summary>
    /// <value>
    ///     The data.
    /// </value>
    public int Data; //Actually durability!
    #endregion Fields
}
