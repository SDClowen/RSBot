using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System.Diagnostics;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionSkillCastResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB070;

    /// <summary>
    ///     Invokes the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var result = packet.ReadByte();
        if (result != 0x01)
        {
            var errorCode = packet.ReadByte();

            switch (errorCode)
            {
                case 0x0C:
                    // Same other skills are already running
                    break;

                case 0x0E:
                    Game.Player.EquipAmmunition();
                    break;

                case 0x05:
                    Log.Debug("Skill cooldown error. Still have time!");
                    break;

                case 0x06: // invalid target
                    break;

                case 0x10: // obstacle
                    EventManager.FireEvent("OnTargetBehindObstacle");
                    break;

                default:
                    Log.Error($"Invalid skill error code: 0x{errorCode:X2}");
                    break;
            }

            return;
        }

        var actionCode = packet.ReadByte();

        if (Game.ClientType > GameClientType.Thailand)
            packet.ReadByte(); // always 0x30

        var action = new Objects.Action
        {
            Code = actionCode,
            SkillId = packet.ReadUInt(),
            ExecutorId = packet.ReadUInt(),
            Id = packet.ReadUInt(),
        };

        if (Game.ClientType > GameClientType.Chinese && Game.ClientType != GameClientType.Japanese)
            action.UnknownId = packet.ReadUInt();

        action.TargetId = packet.ReadUInt();
        if (
            Game.ClientType == GameClientType.Turkey
            || Game.ClientType == GameClientType.Global
            || Game.ClientType == GameClientType.VTC_Game
            || Game.ClientType == GameClientType.RuSro
            || Game.ClientType == GameClientType.Korean
            || Game.ClientType == GameClientType.Japanese
            || Game.ClientType == GameClientType.Taiwan
        )
        {
            packet.ReadByte();
            action.Flag = (ActionStateFlag)packet.ReadByte();
        }
        else if (Game.ClientType == GameClientType.Rigid)
        {
            action.Flag = (ActionStateFlag)packet.ReadByte();
            var flag = packet.ReadByte();
            Debug.WriteLine("Flag:" + flag);
        }
        else
        {
            action.Flag = (ActionStateFlag)packet.ReadByte();
        }

        /*if (Game.ClientType >= GameClientType.Chinese)
            packet.ReadByte();

        action.Flag = (ActionStateFlag)packet.ReadByte();*/
        action.ReadPacket(packet);

        if (action.PlayerIsExecutor)
        {
            //Game.Player.StopMoving();

            var skillInfo = Game.Player.Skills.GetSkillInfoById(action.SkillId);
            if (skillInfo == null)
                skillInfo = SkillManager.Buffs.Find(p => p.Id == action.SkillId);

            skillInfo?.Update();

            EventManager.FireEvent("OnCastSkill", action.SkillId);

            return;
        }

        if (!action.TryGetExecutor<SpawnedBionic>(out var executor))
            return;

        executor.TargetId = action.TargetId;
        //executor.StopMoving();

        if (!action.PlayerIsTarget)
            return;

        EventManager.FireEvent("OnEnemySkillOnPlayer");

        executor.StartAttackingTimer();
    }
}
