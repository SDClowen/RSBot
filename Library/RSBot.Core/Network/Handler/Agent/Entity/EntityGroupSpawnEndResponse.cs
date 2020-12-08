using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;
using System;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityGroupSpawnEndResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3018;

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
            packet = Core.Game.SpawnInfo.Packet;
            packet.Lock();

            for (var i = 0; i < Core.Game.SpawnInfo.Amount; i++)
            {
                try
                {
                    switch (Core.Game.SpawnInfo.Type)
                    {
                        case 0x01: //Spawn
                            var refObjId = packet.ReadUInt();

                            #region Skill area

                            if (refObjId == uint.MaxValue)
                            {
                                Core.Game.Spawns.SpellAreas.Add(SpawnedSpellArea.FromPacket(packet));
                                EventManager.FireEvent("OnSpawnSpellArea", Core.Game.Spawns.SpellAreas[Core.Game.Spawns.SpellAreas.Count - 1]);
                                return; //End of the packet
                            }

                            #endregion Skill area

                            var obj = Core.Game.ReferenceManager.GetRefObjCommon((uint)refObjId);

                            switch (obj.TypeID1)
                            {
                                #region Player

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

                                #region Item

                                case 3:
                                    Core.Game.Spawns.Items.Add(SpawnedItem.FromPacket(packet, refObjId));
                                    EventManager.FireEvent("OnSpawnItem", Core.Game.Spawns.GetItem(Core.Game.Spawns.Items[Core.Game.Spawns.Items.Count - 1].UniqueId));
                                    break;

                                #endregion Item

                                #region Teleporters

                                case 4:
                                    Core.Game.Spawns.Portals.Add(SpawnedPortal.FromPacket(packet, refObjId));
                                    EventManager.FireEvent("OnSpawnPortal", Core.Game.Spawns.GetPortal(Core.Game.Spawns.Portals[Core.Game.Spawns.Portals.Count - 1].UniqueId));
                                    break;

                                    #endregion Teleporters
                            }

                            break;

                        case 0x02: //Despawn
                            var uniqueId = packet.ReadUInt();
                            Core.Game.Spawns.Remove(uniqueId);
                            EventManager.FireEvent("OnDespawnEntity", uniqueId);
                            break;
                    }
                }
                catch (Exception)
                {
                    Log.Debug($"Spawn parse failed at index {i}!");
                    break;
                }
            }

            Core.Game.SpawnInfo = null; //release some resources!
        }
    }
}