using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefShopTab : IReference<string>
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
        parser.TryParse(4, out RefTabGroupCodeName);
        parser.TryParse(5, out StrID128_Tab);

        return true;
    }

    /// <summary>
    ///     Gets the goods.
    /// </summary>
    /// <returns></returns>
    public List<RefShopGood> GetGoods()
    {
        return Game.ReferenceManager.ShopGoods.Where(g => g.RefTabCodeName == CodeName).ToList();
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

    /// <summary>
    ///     Gets or sets the name of the reference tab group code.
    /// </summary>
    /// <value>
    ///     The name of the reference tab group code.
    /// </value>
    public string RefTabGroupCodeName;

    /// <summary>
    ///     Gets or sets the string i D128_ tab.
    /// </summary>
    /// <value>
    ///     The string i D128_ tab.
    /// </value>
    public string StrID128_Tab;

    #endregion Fields
}

//Service tinyint
//Country int
//ID  int
//CodeName128 varchar(129)
//RefTabGroupCodeName varchar(129)
//StrID128_Tab varchar(129)
