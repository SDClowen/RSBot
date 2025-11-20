using System.Collections.Generic;

namespace RSBot.Core.Client.ReferenceObjects;

public class RefQuest : IReference<uint>
{
    public uint PrimaryKey => ID;

    public bool Load(ReferenceParser parser)
    {
        //Skip disabled
        if (!parser.TryParse(0, out Service) || Service == 0)
            return false;

        //Skip invalid ID (PK)
        if (!parser.TryParse(1, out ID))
            return false;

        //Skip invalid CodeName
        if (!parser.TryParse(2, out CodeName))
            return false;

        parser.TryParse(3, out Level);
        parser.TryParse(4, out DescName);
        parser.TryParse(5, out NameString);
        parser.TryParse(6, out PayString);
        parser.TryParse(7, out ContentsString);
        parser.TryParse(8, out PayContents);
        parser.TryParse(9, out NoticeNPC);
        parser.TryParse(10, out NoticeCondition);

        return true;
    }

    public string GetTranslatedName()
    {
        return Game.ReferenceManager.GetTranslation(NameString);
    }

    #region Properties

    public RefQuestReward Reward => Game.ReferenceManager.GetQuestReward(ID);
    public IEnumerable<RefQuestRewardItem> RewardItems => Game.ReferenceManager.GetQuestRewardItems(ID);

    #endregion

    #region Fields

    public byte Service;
    public uint ID;
    public string CodeName;
    public byte Level;
    public string DescName;
    public string NameString;
    public string PayString;
    public string ContentsString;
    public string PayContents;
    public string NoticeNPC;
    public string NoticeCondition;

    #endregion Fields
}

//Service               1
//ID                    29
//CodeName              QSP_ALL_POTION_1
//[Level]               20
//DescName              재생의 물약 퀘스트
//NameString            SN_QSP_ALL_POTION_1
//PayString             SN_PAY_QSP_ALL_POTION_1
//ContentsString        xxx
//PayContents           SN_PAYCON_QSP_ALL_POTION_1
//NoticeNPC             SN_NN_QSP_ALL_POTION_1
//NoticeCondition       SN_NC_QSP_ALL_POTION_1
