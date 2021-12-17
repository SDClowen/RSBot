using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Collections.Generic;

namespace RSBot.Core.Network.Handler.Agent.Character
{
    internal class CharacterDataEndResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x34A6;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            SpawnManager.Clear();

            packet = Core.Game.CharacterPacket;
            packet.Lock();
            var character = new Player();

            packet.ReadUInt(); //Server timestamp

            character.ModelId = packet.ReadUInt();
            character.Scale = packet.ReadByte();
            character.Level = packet.ReadByte();
            character.MaxLevel = packet.ReadByte();
            character.Experience = packet.ReadLong();
            character.SkillExperience = packet.ReadUInt();
            character.Gold = packet.ReadULong();
            character.SkillPoints = packet.ReadUInt();
            character.StatPoints = packet.ReadUShort();
            character.BerzerkPoints = packet.ReadByte();
            character.ExperienceChunk = packet.ReadUInt();
            character.Health = packet.ReadUInt();
            character.Mana = packet.ReadUInt();
            character.AutoInverstExperience = (AutoInverstType)packet.ReadByte();

            if (Core.Game.ClientType == GameClientType.ChineseR)
                character.DailyPK = (byte)packet.ReadUShort();
            else
                character.DailyPK = packet.ReadByte();

            character.TotalPK = packet.ReadUShort();
            character.PKPenaltyPoint = packet.ReadUInt();
            character.BerzerkLevel = packet.ReadByte();

            if(Core.Game.ClientType > GameClientType.Thailand)
                character.PvpFlag = (PvpFlag)packet.ReadByte();

            if (Core.Game.ClientType >= GameClientType.Global)
            {
                packet.ReadByte();
                packet.ReadUInt();
                packet.ReadUShort();
                packet.ReadUShort();
                packet.ReadUShort();
                packet.ReadULong();
                packet.ReadUShort();
                packet.ReadByte();
                packet.ReadByte();
                packet.ReadUShort();
            }

            character.Inventory = Objects.Inventory.FromPacket(packet);

            character.Skills = Skills.FromPacket(packet);

            #region Read Quests

            var completedQuestCount = packet.ReadUShort();
            for (var i = 0; i < completedQuestCount; i++)
                packet.ReadUInt(); //QuestID

            var activeQuestCount = packet.ReadByte();
            for (var iQuest = 0; iQuest < activeQuestCount; iQuest++)
            {
                packet.ReadUInt(); //QuestID
                packet.ReadByte(); //achievementAmount
                packet.ReadByte(); //Requiered share pt
                var type = packet.ReadByte();

                if (type == 28 || type == 92)
                    packet.ReadUInt(); //Remaining time

                packet.ReadByte(); //State

                if (type != 8)
                {
                    var objectiveAmount = packet.ReadByte();
                    for (var iObjective = 0; iObjective < objectiveAmount; iObjective++)
                    {
                        packet.ReadByte(); //ObjectiveID
                        packet.ReadByte(); //State
                        packet.ReadString(); //CharacterName
                        var taskCount = packet.ReadByte();

                        for (var iTask = 0; iTask < taskCount; iTask++)
                            packet.ReadUInt(); //Value
                    }
                }

                if (type != 88 && type != 92) continue;

                var npcAmount = packet.ReadByte();
                for (var iNpc = 0; iNpc < npcAmount; iNpc++)
                    packet.ReadUInt(); //NPC ObjectId
            }

            #endregion Read Quests

            packet.ReadByte(); // Unknown

            if (Core.Game.ClientType > GameClientType.Thailand)
            {
                var collectionBookStartedThemeCount = packet.ReadUInt();
                for (var i = 0; i < collectionBookStartedThemeCount; i++)
                {
                    packet.ReadUInt(); //index
                    packet.ReadUInt(); //Starttime
                    packet.ReadUInt(); //pages
                }
            }

            character.UniqueId = packet.ReadUInt();
            character.Tracker = new PositionTracker(Movement.FromPacket(packet));
            character.State = State.FromPacket(packet);
            character.Name = packet.ReadString();
            character.JobInformation = JobInfo.FromPacket(packet);
            character.State.PvpState = (PvpState)packet.ReadByte();
            character.OnTransport = packet.ReadBool(); //On transport?
            character.InCombat = packet.ReadBool();

            if (Core.Game.ClientType > GameClientType.ChineseR)
                packet.ReadByte();

            if (character.OnTransport)
                character.TransportUniqueId = packet.ReadUInt();

            if (Core.Game.ClientType > GameClientType.ChineseR)
                packet.ReadUInt(); //unkUint2 i think it is using for balloon event or buff for events

            if (Core.Game.ClientType == GameClientType.ChineseR)
                packet.ReadByte();

            packet.ReadByte(); //PVP dress for the CTF event //0 = Red Side, 1 = Blue Side, 0xFF = None
            packet.ReadULong(); //GuideFlag

            if (Core.Game.ClientType == GameClientType.ChineseR)
                packet.ReadByte();

            character.JID = packet.ReadUInt();
            character.IsGameMaster = packet.ReadBool();

            //Set instance..
            Core.Game.Player = character;
            character.Tracker.SetSpeed(character.State.WalkSpeed, character.State.RunSpeed);
            Core.Game.CharacterPacket = null;

            Core.Game.NearbyTeleporters = Core.Game.ReferenceManager.GetTeleporters(character.Tracker.Position.RegionID);
            CollisionManager.Update(Core.Game.Player.Tracker.Position.RegionID);

            EventManager.FireEvent("OnLoadCharacter");
            EventManager.FireEvent("OnUpdateHPMP");

            Kernel.ChangeClientProcessTitle($"{character.Name} - RSBot");

            if (!Core.Game.Clientless) 
                return;

            var response = new Packet(0x3012);
            response.Lock();
            PacketManager.SendPacket(response, PacketDestination.Server);
        }
    }
}