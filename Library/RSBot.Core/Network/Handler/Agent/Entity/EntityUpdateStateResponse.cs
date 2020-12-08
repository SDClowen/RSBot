using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityUpdateStateResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x30BF;

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
            var uniqueId = packet.ReadUInt();

            var type = packet.ReadByte();
            var state = packet.ReadByte();

            switch (type)
            {
                case 0:
                    if (uniqueId == Core.Game.Player.UniqueId)
                        Core.Game.Player.State.LifeState = (LifeState)state;
                    else
                    {
                        var bionic = Core.Game.Spawns.GetBionic(uniqueId);
                        if (bionic == null)
                            return;

                        bionic.State.LifeState = (LifeState)state;
                        if (uniqueId == Core.Game.SelectedEntity?.UniqueId && bionic.State.LifeState == LifeState.Dead)
                            Core.Game.SelectedEntity = null;
                    }

                    EventManager.FireEvent("OnUpdateEntityLifeState", uniqueId);
                    break;

                case 1:
                    if (uniqueId == Core.Game.Player.UniqueId || (Core.Game.Player.Vehicle != null && uniqueId == Core.Game.Player.Vehicle.UniqueId))
                        Core.Game.Player.Tracker.State = (MotionState)state;
                    else
                    {
                        var bionic = Core.Game.Spawns.GetBionic(uniqueId);
                        if (bionic != null)
                            bionic.Tracker.State = (MotionState)state;
                    }

                    EventManager.FireEvent("OnUpdateEntityMotionState", uniqueId);
                    break;

                case 4:
                    if (uniqueId == Core.Game.Player.UniqueId)
                        Core.Game.Player.State.BodyState = (BodyState)state;
                    else
                    {
                        var bionic = Core.Game.Spawns.GetBionic(uniqueId);
                        if (bionic != null)
                            bionic.State.BodyState = (BodyState)state;
                    }
                    EventManager.FireEvent("OnUpdateEntityBodyState", uniqueId);
                    break;

                case 7:
                    if (uniqueId == Core.Game.Player.UniqueId)
                        Core.Game.Player.State.PvpState = (PvpState)state;
                    else
                    {
                        var bionic = Core.Game.Spawns.GetBionic(uniqueId);
                        if (bionic != null)
                            bionic.State.PvpState = (PvpState)state;
                    }

                    EventManager.FireEvent("OnUpdateEntityPvpState", uniqueId);
                    break;

                case 8:
                    if (uniqueId == Core.Game.Player.UniqueId)
                        Core.Game.Player.State.BattleState = (BattleState)state;
                    else
                    {
                        var bionic = Core.Game.Spawns.GetBionic(uniqueId);

                        if (bionic != null)
                            bionic.State.BattleState = (BattleState)state;
                    }

                    EventManager.FireEvent("OnUpdateEntityBattleState", uniqueId);
                    break;

                case 11:
                    if (uniqueId == Core.Game.Player.UniqueId)
                    {
                        Core.Game.Player.State.ScrollState = (ScrollState)state;
                        if (Core.Game.Player.State.ScrollState == ScrollState.Cancel && Kernel.Bot.Running)
                            Kernel.Bot.Stop();
                    }
                    else
                    {
                        var bionic = Core.Game.Spawns.GetBionic(uniqueId);

                        if (bionic != null)
                            bionic.State.ScrollState = (ScrollState)state;
                    }

                    EventManager.FireEvent("OnUpdateEntityScrollState", uniqueId);
                    break;

                default:
                    Log.Error("EntityUpdate: Unknown update type " + type);
                    break;
            }
        }
    }
}