namespace RSBot.Core.Client.ReferenceObjects
{
    public class RefText : IReference<string>
    {
        private const int LANG_OFFSET = 2;
        private const int LANG_COUNT = 14;

        //private readonly string[] _data = new string[LANG_COUNT];

        #region IRefrerence

        public string PrimaryKey => ID;

        #endregion IRefrerence

        private byte Service;
        public string ID;
        public string Data;

        // languageFlag
        // 0 - Korean
        // 1 - Chinese
        // 2 - Taiwan
        // 3 - Japan
        // 4 - English
        // 5 - Vietnam
        // 7 - Turkey
        // 8 - Thailand
        // 9 - Russia
        // 10 - Spain
        // 11 - Arabic

        //public string Lang0 => _data[OFFSET + 0];
        //public string Lang1 => _data[OFFSET + 1];
        //public string Lang2 => _data[OFFSET + 2];
        //public string Lang3 => _data[OFFSET + 3];
        //public string Lang4 => _data[OFFSET + 4];
        //public string Lang5 => _data[OFFSET + 5];
        //public string Lang6 => _data[OFFSET + 6];
        //public string Lang7 => _data[OFFSET + 7];
        //public string Lang8 => _data[OFFSET + 8];

        //public string this[int index] => _data[index];

        public bool Load(ReferenceParser parser)
        {
            if (!parser.TryParseByte(0, out Service) || Service == 0)
                return false;

            if (!parser.TryParseString(1, out ID))
                return false;


            var languageTab = 5;
            var maxTabs = parser.GetColumnCount();

            if (languageTab > maxTabs)
            {
                languageTab = 2;
            }

          
            //Try parse with the already set language tab
            parser.TryParseString(languageTab, out Data);

            while (isEmptyString(Data) && languageTab <= maxTabs)
            { 
                parser.TryParseString(languageTab, out Data);

                languageTab++;
            }


            ////for (int i = 0; i < LANG_COUNT; i++) 
            ////    parser.TryParseString(LANG_OFFSET + i, out _data[i], "0");
            //parser.TryParseString(LANG_OFFSET + Game.ReferenceManager.LanguageTab, out Data, "MISSING TRANS");

            //if (Data.Length == 0)
            //{
            //    parser.TryParseString(Game.ReferenceManager.LanguageTab, out Data, "MISSING TRANS");

            //}

            //Skip huge strings? (4 mb)
            //if (Data.Length > 256 || Data.EndsWith("_DESC"))
            //    return false;

            return true;
        }

        private bool isEmptyString(string data)
        {
            if (data == null)
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(data))
            {
                return true;
            }

            if (data == "0")
            {
                return true;
            }


            if (data.StartsWith("?"))
            {
                return true;
            }

            return false;
        }
    }
}