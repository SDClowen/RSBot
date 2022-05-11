using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

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
                    if (uniqueId == Game.Player.UniqueId)
                        Game.Player.State.LifeState = (LifeState)state;
                    else
                    {
                        if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                            return;

                        bionic.State.LifeState = (LifeState)state;
                        if (uniqueId == Game.SelectedEntity?.UniqueId && bionic.State.LifeState == LifeState.Dead)
                        {
                            EventManager.FireEvent("OnKillSelectedEnemy");
                            Game.SelectedEntity = null;
                        }
                    }

                    EventManager.FireEvent("OnUpdateEntityLifeState", uniqueId);
                    break;

                case 1:

                    var motionState = (MotionState)state;
                    SpawnedEntity entity;

                    if (SpawnManager.TryGetEntity<SpawnedEntity>(uniqueId, out entity))
                    {

                    }
                    else if (uniqueId == Game.Player.UniqueId)
                    {
                        entity = Game.Player;
                    }
                    else if (Game.Player.Vehicle != null && uniqueId == Game.Player.Vehicle.UniqueId)
                    {
                        entity = Game.Player.Vehicle;
                    }

                    if (entity == null)
                        return;

                    entity.State.MotionState = motionState;
                    switch (motionState)
                    {
                        case MotionState.Walking:

                            entity.Movement.Type = MovementType.Walking;

                            break;
                        case MotionState.Running:

                            entity.Movement.Type = MovementType.Running;

                            break;
                    }

                    EventManager.FireEvent("OnUpdateEntityMotionState", uniqueId);

                    break;

                case 4:
                    if (uniqueId == Game.Player.UniqueId)
                        Game.Player.State.BodyState = (BodyState)state;
                    else
                    {
                        if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                            return;

                        bionic.State.BodyState = (BodyState)state;
                    }
                    EventManager.FireEvent("OnUpdateEntityBodyState", uniqueId);
                    break;

                case 7:
                    if (uniqueId == Game.Player.UniqueId)
                        Game.Player.State.PvpState = (PvpState)state;
                    else
                    {
                        if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                            return;

                        bionic.State.PvpState = (PvpState)state;
                    }

                    EventManager.FireEvent("OnUpdateEntityPvpState", uniqueId);
                    break;

                case 8:
                    if (uniqueId == Game.Player.UniqueId)
                        Game.Player.State.BattleState = (BattleState)state;
                    else
                    {
                        if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                            return;

                        bionic.State.BattleState = (BattleState)state;
                    }

                    EventManager.FireEvent("OnUpdateEntityBattleState", uniqueId);
                    break;

                case 11:
                    if (uniqueId == Game.Player.UniqueId)
                    {
                        Game.Player.State.ScrollState = (ScrollState)state;
                        if (Game.Player.State.ScrollState == ScrollState.Cancel && Kernel.Bot.Running)
                            Kernel.Bot.Stop();
                    }
                    else
                    {
                        if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                            return;

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