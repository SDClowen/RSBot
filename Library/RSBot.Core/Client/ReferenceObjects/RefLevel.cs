namespace RSBot.Core.Client.ReferenceObjects;

public class RefLevel : IReference<byte>
{
    public byte PrimaryKey => Level;

    public bool Load(ReferenceParser parser)
    {
        if (!parser.TryParse(0, out Level))
            return false;

        parser.TryParse(1, out Exp_C);
        parser.TryParse(2, out Exp_M);

        if (Game.ClientType >= GameClientType.Chinese_Old)
        {
            parser.TryParse(9, out Exp_C_Pet2);
            parser.TryParse(10, out StoredSp_Pet2);
        }

        return true;
    }

    #region Fields

    public byte Level;
    public long Exp_C;

    public int Exp_M;

    /*public int Cost_M;
    public int Cost_ST;
    public int GUST_Mob_Exp;
    public int JobExp_Trader;
    public int JobExp_Robber;
    public int JobExp_Hunter;*/
    public long Exp_C_Pet2;
    public int StoredSp_Pet2;

    #endregion Fields
}
