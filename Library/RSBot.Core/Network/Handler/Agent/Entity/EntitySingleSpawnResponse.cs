using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntitySingleSpawnResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3015;

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
            var refObjId = packet.ReadUInt();

            #region Skill area

            if (refObjId == uint.MaxValue)
            {
                Core.Game.Spawns.SpellAreas.Add(SpawnedSpellArea.FromPacket(packet));
                return; //End of the packet
            }

            #endregion Skill area

            var obj = Core.Game.ReferenceManager.GetRefObjCommon((uint)refObjId);

            #region Player

            switch (obj.TypeID1)
            {
                case 1:
                    var bionic = new SpawnedBionic
                    {
                        ObjId = obj.ID
                    };

                    if (obj.TypeID2 == 1) //Player
                        Core.Game.Spawns.Players.Add(SpawnedPlayer.FromPacket(packet, bionic));
                    else if (obj.TypeID2 == 2 && obj.TypeID3 == 5)
                    {
                        //NPC_FORTRESS_STRUCT
                        Core.Game.Spawns.FortressStructures.Add(SpawnedFortressStructure.FromPacket(packet,
                            bionic));

                        EventManager.FireEvent("OnSpawnFortressStructure", Core.Game.Spawns.GetFortressStructure(bionic.UniqueId));
                    }

                    bionic.ParseDetails(packet);

                    break;

                #endregion Player

                case 3:
                    var item = SpawnedItem.FromPacket(packet, refObjId);
                    Core.Game.Spawns.Items.Add(item);

                    EventManager.FireEvent("OnSpawnItem", Core.Game.Spawns.GetItem(Core.Game.Spawns.Items[Core.Game.Spawns.Items.Count - 1].UniqueId));
                    break;

                case 4:
                    Core.Game.Spawns.Portals.Add(SpawnedPortal.FromPacket(packet, refObjId));
                    EventManager.FireEvent("OnSpawnPortal", Core.Game.Spawns.GetPortal(Core.Game.Spawns.Portals[Core.Game.Spawns.Portals.Count - 1].UniqueId));
                    break;
            }

            if (obj.TypeID1 == 1 || obj.TypeID1 == 4)
                packet.ReadByte(); //1 = Normal, 3 = Spawning, 4 = Running
            else if (obj.TypeID1 == 3)
            {
                packet.ReadByte(); //DropSource
                packet.ReadUInt(); //DropUID
            }
        }
    }
}