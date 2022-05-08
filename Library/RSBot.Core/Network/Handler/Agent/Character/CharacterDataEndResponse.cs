using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Quests;

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

            packet = Core.Game.ChunkedPacket;
            packet.Lock();

            if (Core.Game.ClientType >= GameClientType.Thailand)
                packet.ReadUInt(); // serverTimestamp 

            var modelId = packet.ReadUInt();

            var character = new Player(modelId);
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
            character.Health = packet.ReadInt();
            character.Mana = packet.ReadInt();
            character.AutoInverstExperience = (AutoInverstType)packet.ReadByte();

            if (Core.Game.ClientType == GameClientType.Chinese)
                character.DailyPK = (byte)packet.ReadUShort();
            else
                character.DailyPK = packet.ReadByte();

            character.TotalPK = packet.ReadUShort();
            character.PKPenaltyPoint = packet.ReadUInt();

            if (Core.Game.ClientType >= GameClientType.Thailand)
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
                packet.ReadUInt();
                packet.ReadUShort();
                packet.ReadByte();

                if (Core.Game.ClientType == GameClientType.Turkey)
                    packet.ReadUInt();

                var cap = packet.ReadByte(); // server cap
                Log.Notify($"The game server cap is {cap}!");

                if (Core.Game.ClientType != GameClientType.Korean)
                    packet.ReadUShort();
            }

            var invsChar = InventoriesOfCharacter.FromPacket(packet);
            character.Inventory = invsChar.Inventory;
            character.Avatars = invsChar.Avatars;
            character.Job2 = invsChar.Job2;

            character.Skills = Skills.FromPacket(packet);
            character.Quest = Quest.FromPacket(packet);

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

            character.ParseBionicDetails(packet);
            
            character.Name = packet.ReadString();
            character.JobInformation = JobInfo.FromPacket(packet);
            character.State.PvpState = (PvpState)packet.ReadByte();
            character.OnTransport = packet.ReadBool(); //On transport?
            character.InCombat = packet.ReadBool();

            if (Core.Game.ClientType > GameClientType.Chinese)
                packet.ReadByte();

            if (character.OnTransport)
                character.TransportUniqueId = packet.ReadUInt();

            if (Core.Game.ClientType > GameClientType.Chinese)
                packet.ReadUInt(); //unkUint2 i think it is using for balloon event or buff for events

            if (Core.Game.ClientType > GameClientType.Vietnam)
                packet.ReadByte();

            packet.ReadByte(); //PVP dress for the CTF event //0 = Red Side, 1 = Blue Side, 0xFF = None
            //GuideFlag
            if (Core.Game.ClientType >= GameClientType.Thailand)
                packet.ReadULong();
            else
                packet.ReadUInt();

            if (Core.Game.ClientType == GameClientType.Chinese)
                packet.ReadByte();

            character.JID = packet.ReadUInt();
            character.IsGameMaster = packet.ReadBool();

            //Set instance..
            Core.Game.Player = character;
            Core.Game.ChunkedPacket = null;
            Core.Game.NearbyTeleporters = Core.Game.ReferenceManager.GetTeleporters(character.Movement.Source.RegionID);

            CollisionManager.Update(Core.Game.Player.Movement.Source.RegionID);

            EventManager.FireEvent("OnLoadCharacter");

            ClientManager.SetTitle($"{character.Name} - RSBot");

            if (!Core.Game.Clientless) 
                return;

            PacketManager.SendPacket(new Packet(0x3012), PacketDestination.Server);
        }
    }
}