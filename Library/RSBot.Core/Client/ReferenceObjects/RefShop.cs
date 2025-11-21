using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefShop : IReference<string>
{
    public string PrimaryKey => CodeName;

    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        parser.TryParse(1, out Country);
        parser.TryParse(2, out Id);
        parser.TryParse(3, out CodeName);

        return true;
    }

    /// <summary>
    ///     Gets the tabs.
    /// </summary>
    /// <returns></returns>
    public List<RefShopTab> GetTabs()
    {
        var mapping = Game.ReferenceManager.ShopTabMapping.Where(m => m.Shop == CodeName);

        return (
            from map in mapping
            from tab in Game.ReferenceManager.ShopTabs.Where(s => s.Value.RefTabGroupCodeName == map.Tab)
            select tab.Value
        ).ToList();
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
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public int Id;

    /// <summary>
    ///     Gets or sets the name of the code.
    /// </summary>
    /// <value>
    ///     The name of the code.
    /// </value>
    public string CodeName;

    #endregion Fields
}

//Service tinyint
//Country int
//ID  int
//CodeName128 varchar(129)
//Param1 int
//Param1_Desc128  varchar(129)
//Param2 int
//Param2_Desc128  varchar(129)
//Param3 int
//Param3_Desc128  varchar(129)
//Param4 int
//Param4_Desc128  varchar(129)
