using Python.Runtime;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Quests;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSBot.Python.Components.API.Core.Entity
{
    public class QuestAPI : IPythonPlugin
    {
        private Main _main;

        /// <summary>
        /// Unique module name of the plugin.
        /// </summary>
        public string ModuleName => "quest";

        /// <summary>
        /// Called once at startup to provide the main form to the plugin.
        /// </summary>
        /// <param name="main">Main form</param>
        public void Init(Main main)
        {
            _main = main;
        }
        private string GetStatusText(QuestStatus status)
        {
            switch (status)
            {
                case QuestStatus.Cancelled:
                    return "Cancelled";
                case QuestStatus.Completed:
                case QuestStatus.CompletedXTimes:
                    return "Completed";
                case QuestStatus.CompletedButNotSupplied:
                case QuestStatus.CompletedByUserButNotSupplied:
                    return "Ready for delivery";
                case QuestStatus.Initialized:
                case QuestStatus.StartedByUser:
                    return "In progress";
                case QuestStatus.Unavailable:
                    return "Unavailable";
                default:
                    return status.ToString();
            }
        }

        private PyList GetQuests()
        {
            using (Py.GIL())
            {
                var result = new PyList();
                if (Game.Player == null)
                {
                    return result;
                }
                foreach (var activeQuest in Game.Player.QuestLog.ActiveQuests)
                {
                    var pyQuest = new PyDict();
                    var quest = activeQuest.Value;
                    pyQuest.SetItem(new PyString("name"), new PyString(Game.ReferenceManager.GetTranslation(quest.Quest.NameString)));
                    pyQuest.SetItem(new PyString("id"), new PyInt(quest.Id));
                    pyQuest.SetItem(new PyString("level"), new PyInt(quest.Quest.Level));
                    pyQuest.SetItem(new PyString("status"), new PyString(GetStatusText(quest.Status)));
                    pyQuest.SetItem(new PyString("npc"), new PyString(Game.ReferenceManager.GetTranslation(quest.Quest.NoticeNPC)));
                    
                    if (quest.Npcs?.Length > 0)
                    {
                        foreach (var npcId in quest.Npcs)
                        {
                            var npc = Game.ReferenceManager.GetRefObjChar(npcId);
                            pyQuest.SetItem(new PyString("npc_name"), new PyInt(npc.NameStrID));
                            pyQuest.SetItem(new PyString("npc_id"), new PyInt(npc.ID));
                            pyQuest.SetItem(new PyString("npc_servername"), new PyString(npc.CodeName));                            
                        }
                    }
                    if (quest.Quest.Reward != null)
                    {
                        if (quest.Quest.Reward.Exp > 0)
                            pyQuest.SetItem(new PyString("reward_exp"), new PyInt(quest.Quest.Reward.Exp));

                        if (quest.Quest.Reward.SP > 0)
                            pyQuest.SetItem(new PyString("reward_sp"), new PyInt(quest.Quest.Reward.SP));

                        if (quest.Quest.Reward.Gold > 0)
                            pyQuest.SetItem(new PyString("reward_gold"), new PyInt(quest.Quest.Reward.Gold));
                    }

                    if (quest.Quest.RewardItems != null && quest.Quest.RewardItems.Any())
                    {
                        foreach (var rewardItem in quest.Quest.RewardItems)
                        {
                            if (rewardItem.Item != null)
                                pyQuest.SetItem(new PyString("reward_item"), new PyString(rewardItem.Item.GetRealName()));

                            if (rewardItem.OptionalItem != null)
                                pyQuest.SetItem(new PyString("reward_optional"), new PyString(rewardItem.OptionalItem.GetRealName()));
                        }
                    }

                    if (quest.Objectives?.Length > 0)
                        foreach (var objective in quest.Objectives)
                        {
                            var objectiveName = Game.ReferenceManager.GetTranslation(objective.NameStrId);
                            foreach (var task in objective.Tasks)
                            {
                                var actualTitle = objectiveName.Replace("%d", task.ToString());
                                pyQuest.SetItem(new PyString("objective"), new PyString(actualTitle));
                            }
                        }
                    result.Append(pyQuest);
                }

                return result;
            }
        }    
        public PyList get_quests()
        {
            return GetQuests();
        }
    }
}
