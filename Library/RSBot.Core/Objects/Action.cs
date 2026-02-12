using System;
using System.Diagnostics;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects;

public class Action
{
    /// <summary>
    ///     Gets or sets the action identifier.
    /// </summary>
    /// <value>
    ///     The action identifier.
    /// </value>
    public byte Code { get; set; }

    /// <summary>
    ///     Gets or sets the skill identifier.
    /// </summary>
    /// w
    /// <value>
    ///     The skill identifier.
    /// </value>
    public uint SkillId { get; set; }

    /// <summary>
    ///     Gets or sets the executor identifier.
    /// </summary>
    /// <value>
    ///     The executor identifier.
    /// </value>
    public uint ExecutorId { get; set; }

    /// <summary>
    ///     Gets or sets the identifier.
    /// </summary>
    /// <value>
    ///     The identifier.
    /// </value>
    public uint Id { get; set; }

    /// <summary>
    ///     Gets or sets the target identifier.
    /// </summary>
    /// <value>
    ///     The target identifier.
    /// </value>
    public uint TargetId { get; set; }

    /// <summary>
    ///     Gets or sets the target identifier.
    /// </summary>
    /// <value>
    ///     The target identifier.
    /// </value>
    public uint UnknownId { get; set; }

    /// <summary>
    ///     Gets or sets the flag.
    /// </summary>
    /// <value>
    ///     The flag.
    /// </value>
    public ActionStateFlag Flag { get; set; }

    /// <summary>
    ///     Gets a value indicating whether [player is executor].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [player is executor]; otherwise, <c>false</c>.
    /// </value>
    public bool PlayerIsExecutor => Game.Player.UniqueId == ExecutorId;

    /// <summary>
    ///     Gets a value indicating whether [player is target].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [player is target]; otherwise, <c>false</c>.
    /// </value>
    public bool PlayerIsTarget => Game.Player.UniqueId == TargetId;

    public void ReadPacket(Packet packet)
    {
        if (Flag.HasFlag(ActionStateFlag.Attack))
        {
            var hitCount = packet.ReadByte();
            var affectedObjectCount = packet.ReadByte();

            for (var i = 0; i < affectedObjectCount; i++)
            {
                var uniqueId = packet.ReadUInt();
                if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var entity))
                    continue;

                for (var j = 0; j < hitCount; j++)
                {
                    var state = (ActionHitStateFlag)packet.ReadByte();
                    if (state == ActionHitStateFlag.Abort)
                        break;

                    if (entity != null)
                    {
                        entity.State.HitState = state;
                        if (state.HasFlag(ActionHitStateFlag.Dead))
                            entity.State.LifeState = LifeState.Dead;
                    }

                    if (state != ActionHitStateFlag.Block)
                    {
                        var critStatus = packet.ReadByte(); // 0x01: normal 0x02 critical

                        var damage = BitConverter.ToInt32(
                            new byte[] { packet.ReadByte(), packet.ReadByte(), packet.ReadByte(), 0 },
                            0
                        );

                        //if(entity.Health < damage)
                        //damage = entity.Health;

                        var unknownState = packet.ReadInt();
                        Debug.WriteLine("UnknownState:" + unknownState);

                        //packet.ReadUShort();
                        //packet.ReadByte();

                        EventManager.FireEvent("OnEntityHit", Id, ExecutorId, uniqueId, damage, critStatus == 0x02);
                    }

                    // dont worry it will return true for knockdown states
                    if (state.HasFlag(ActionHitStateFlag.KnockBack))
                    {
                        var position = Position.FromPacketInt(packet);
                        if (entity == null)
                            continue;

                        entity.SetSource(position);
                    }
                }
            }
        }

        if (Flag.HasFlag(ActionStateFlag.Teleport))
        {
            var position = Position.FromPacketInt(packet);
            if (PlayerIsExecutor)
            {
                Game.Player.SetSource(position);
            }
            else
            {
                if (!TryGetExecutor<SpawnedBionic>(out var executor))
                    return;

                executor.SetSource(position);
            }
        }
    }

    /// <summary>
    ///     Gets the executor.
    /// </summary>
    public bool TryGetExecutor<T>(out T entity)
        where T : SpawnedBionic
    {
        return SpawnManager.TryGetEntity(ExecutorId, out entity);
    }

    /// <summary>
    ///     Gets the target.
    /// </summary>
    /// <returns></returns>
    public bool TryGetTarget<T>(out T entity)
        where T : SpawnedBionic
    {
        return SpawnManager.TryGetEntity(TargetId, out entity);
    }
}
