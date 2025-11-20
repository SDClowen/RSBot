namespace RSBot.Core.Client.ReferenceObjects;

public class RefPackageItemScrap : IReference<string>
{
    public RefObjItem RefItem => Game.ReferenceManager.GetRefItem(RefItemCodeName);

    public string PrimaryKey => RefPackageItemCodeName;

    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        parser.TryParse(1, out Country);
        if (!parser.TryParse(2, out RefPackageItemCodeName))
            return false;

        parser.TryParse(3, out RefItemCodeName);
        parser.TryParse(4, out OptLevel);
        parser.TryParse(5, out Variance);
        parser.TryParse(6, out Data);

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

//Service	tinyint
//Country	int
//RefPackageItemCodeName	varchar(129)
//RefItemCodeName	varchar(129)
//OptLevel	tinyint
//Variance	bigint
//Data	int
//MagParamNum	tinyint
//MagParam1	bigint
//MagParam2	bigint
//MagParam3	bigint
//MagParam4	bigint
//MagParam5	bigint
//MagParam6	bigint
//MagParam7	bigint
//MagParam8	bigint
//MagParam9	bigint
//MagParam10	bigint
//MagParam11	bigint
//MagParam12	bigint
//Param1	int
//Param1_Desc128	varchar(129)
//Param2	int
//Param2_Desc128	varchar(129)
//Param3	int
//Param3_Desc128	varchar(129)
//Param4	int
//Param4_Desc128	varchar(129)
//[Index]	int
