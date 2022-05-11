using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;

namespace RSBot.Core.Network.Handler.Agent.Party
{
    internal class PartyUpdateResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3864;

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
            var type = (PartyUpdateType)packet.ReadByte();

            switch (type)
            {
                case PartyUpdateType.Dismissed:
                    Game.Party.Clear();
                    EventManager.FireEvent("OnPartyDismiss");
                    break;

                case PartyUpdateType.Joined:
                    Game.Party.Members?.Add(PartyMember.FromPacket(packet));
                    EventManager.FireEvent("OnPartyMemberJoin", Game.Party.Members?[Game.Party.Members.Count - 1]);
                    break;

                case PartyUpdateType.Leave:
                    var memberLeft = Game.Party.GetMemberById(packet.ReadUInt());
                    Game.Party.Members.Remove(memberLeft);
                    /*
                        0x03 => ????
                     */
                    if (packet.ReadByte() == 0x04)
                        EventManager.FireEvent("OnPartyMemberBanned", memberLeft);
                    else if (memberLeft.Name == Game.Player.Name)
                    {
                        EventManager.FireEvent("OnPartyDismiss");
                        Game.Party.Clear();
                    }
                    else
                        EventManager.FireEvent("OnPartyMemberLeave", memberLeft);

                    break;

                case PartyUpdateType.Member:
                    var memberId = packet.ReadUInt();
                    var member = Game.Party.GetMemberById(memberId);
                    var memberUpdateType = (PartyMemberUpdateType)packet.ReadByte();

                    switch (memberUpdateType)
                    {
                        case PartyMemberUpdateType.NameRefObjID:
                            member.Name = packet.ReadString();
                            member.ObjectId = packet.ReadUInt();
                            break;

                        case PartyMemberUpdateType.HPMP:
                            member.HealthMana = packet.ReadByte(); //0-A|0-A -> 0%-100%|0%-100%
                            break;

                        case PartyMemberUpdateType.Mastery:
                            member.MasteryId1 = packet.ReadUInt();
                            member.MasteryId2 = packet.ReadUInt();
                            break;

                        case PartyMemberUpdateType.Level:
                            member.Level = packet.ReadByte();
                            break;

                        case PartyMemberUpdateType.Position:
                            member.Position = new Position
                            {
                                XSector = packet.ReadByte(),
                                YSector = packet.ReadByte(),
                            };
                            if (!member.Position.IsInDungeon)
                            {
                                member.Position.XOffset = packet.ReadShort();
                                member.Position.ZOffset = packet.ReadShort();
                                member.Position.YOffset = packet.ReadShort();
                            }
                            else
                            {
                                member.Position.XOffset = packet.ReadInt();
                                member.Position.ZOffset = packet.ReadInt();
                                member.Position.YOffset = packet.ReadInt();
                            }

                            packet.ReadInt(); // layer & world id

                            break;

                        case PartyMemberUpdateType.Guild:
                            member.Guild = packet.ReadString();
                            break;
                    }

                    EventManager.FireEvent("OnPartyMemberUpdate", member);
                    break;

                case PartyUpdateType.Leader:
                    Game.Party.Leader = Game.Party.GetMemberById(packet.ReadUInt());
                    EventManager.FireEvent("OnPartyLeaderChange");
                    break;

                default:
                    Log.Debug($"Unknow party type:{type}");
                    break;
            }
        }
    }
}