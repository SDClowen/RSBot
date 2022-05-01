namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefLevel : IReference<byte>
    {
        #region Fields

        public byte Level;
        public long Exp_C;
        public int Exp_M;

        #endregion Fields

        public byte PrimaryKey => Level;

        public bool Load(ReferenceParser parser)
        {
            if (!parser.TryParse(0, out Level))
                return false;

            parser.TryParse(1, out Exp_C);
            parser.TryParse(2, out Exp_M);

            return true;
        }
    }
}

//Lvl tinyint
//Exp_C bigint
//Exp_M int
//Cost_M  int
//Cost_ST int
//GUST_Mob_Exp    int
//JobExp_Trader   int
//JobExp_Robber   int
//JobExp_Hunter   int