using System.Linq;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdateStateResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30BF;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var uniqueId = packet.ReadUInt();

        var type = packet.ReadByte();
        var state = packet.ReadByte();

        if (!SpawnManager.TryGetEntityIncludingMe(uniqueId, out var entity))
            return;

        switch (type)
        {
            case 0:

                entity.State.LifeState = (LifeState)state;
                if ( /*uniqueId == Game.SelectedEntity?.UniqueId || */
                    Game.Player.GetAttackers().Any(e => e.UniqueId == uniqueId)
                    && entity.State.LifeState == LifeState.Dead
                )
                    EventManager.FireEvent("OnKillEnemy");

                if (uniqueId == Game.SelectedEntity?.UniqueId && entity.State.LifeState == LifeState.Dead)
                {
                    EventManager.FireEvent("OnKillSelectedEnemy");
                    Game.SelectedEntity = null;
                }

                EventManager.FireEvent("OnUpdateEntityLifeState", uniqueId);

                if (uniqueId == Game.Player.UniqueId && entity.State.LifeState == LifeState.Dead)
                    EventManager.FireEvent("OnPlayerDied");

                break;

            case 1:

                var motionState = (MotionState)state;
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

                entity.State.BodyState = (BodyState)state;

                EventManager.FireEvent("OnUpdateEntityBodyState", uniqueId);
                break;

            case 7:

                entity.State.PvpState = (PvpState)state;
                EventManager.FireEvent("OnUpdateEntityPvpState", uniqueId);

                break;

            case 8:

                entity.State.BattleState = (BattleState)state;

                EventManager.FireEvent("OnUpdateEntityBattleState", uniqueId);

                break;

            case 11:

                var scrollState = (ScrollState)state;
                entity.State.ScrollState = scrollState;

                //Do not stop bot on scroll cancel, it will stop bot on death while teleporting.
                //if (uniqueId == Game.Player.UniqueId)
                //    if (scrollState == ScrollState.Cancel && Kernel.Bot.Running)
                //        Kernel.Bot.Stop();

                EventManager.FireEvent("OnUpdateEntityScrollState", uniqueId);

                break;

            default:
                Log.Error("EntityUpdate: Unknown update type " + type);
                break;
        }
    }
}
