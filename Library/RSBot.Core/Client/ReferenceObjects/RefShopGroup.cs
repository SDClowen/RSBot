using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefShopGroup : IReference<string>
{
    /// <summary>
    ///     Gets or sets the name of the code.
    /// </summary>
    /// <value>
    ///     The name of the code.
    /// </value>
    public string CodeName;

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
    ///     Gets or sets the name of the reference NPC code.
    /// </summary>
    /// <value>
    ///     The name of the reference NPC code.
    /// </value>
    public string RefNpcCodeName;

    /// <summary>
    ///     Gets or sets the service.
    /// </summary>
    /// <value>
    ///     The service.
    /// </value>
    public byte Service;

    public string PrimaryKey => CodeName;

    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        parser.TryParse(1, out Country);
        parser.TryParse(2, out Id);
        parser.TryParse(3, out CodeName);
        parser.TryParse(4, out RefNpcCodeName);

        return true;
    }

    /// <summary>
    ///     Gets the shops.
    /// </summary>
    /// <returns></returns>
    public List<RefShop> GetShops()
    {
        var mappedShops = Game.ReferenceManager.ShopGroupMapping.Where(m => m.Group == CodeName);

        return mappedShops
            .Select(mapping => Game.ReferenceManager.Shops.FirstOrDefault(s => s.Value.CodeName == mapping.Shop).Value)
            .ToList();
    }
}

//Service tinyint
//Country int
//ID  smallint
//CodeName128 varchar(129)
//RefNPCCodeName varchar(129)
//Param1 int
//Param1_Desc128  varchar(129)
//Param2 int
//Param2_Desc128  varchar(129)
//Param3 int
//Param3_Desc128  varchar(129)
//Param4 int
//Param4_Desc128  varchar(129)
