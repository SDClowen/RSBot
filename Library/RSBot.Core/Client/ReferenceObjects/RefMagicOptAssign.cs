using System.Collections.Generic;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefMagicOptAssign : IReference
{
    #region Methods

    public bool Load(ReferenceParser parser)
    {
        if (parser == null)
            return false;

        parser.TryParse(1, out Race);
        parser.TryParse(2, out TypeId3);
        parser.TryParse(3, out TypeId4);

        AvailableMagicOptions = new List<string>(80);
        for (var i = 4; i < parser.GetColumnCount(); i++)
            if (parser.TryParse(i, out string option))
                AvailableMagicOptions.Add(option);

        AvailableMagicOptions.RemoveAll(m => string.IsNullOrEmpty(m) || m == "xxx");

        return true;
    }

    #endregion Methods

    #region Fields

    public byte Race;
    public byte TypeId3;
    public byte TypeId4;
    public List<string> AvailableMagicOptions;

    #endregion Fields
}
