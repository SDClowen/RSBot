using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Skill;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionBuffAddResponse : IPacketHandler
{
    /// <summary>
    ///     Invokes the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var targetId = packet.ReadUInt();
        var skillId = packet.ReadUInt();
        var token = packet.ReadUInt();
        if (token == 0)
            return;

        var buff = new SkillInfo(skillId, token);
        if (targetId == Game.Player.UniqueId)
        {
            var playerBuff = Game.Player.Skills.GetSkillInfoById(buff.Id);
            if (playerBuff != null)
            {
                buff = playerBuff;
                playerBuff.Token = token;
            }

            Game.Player.State.ActiveBuffs.Add(buff);

            EventManager.FireEvent("OnAddBuff", buff);

            Log.Notify($"Buff [{buff.Record.GetRealName()}] added.");

            return;
        }

        if (SpawnManager.TryGetEntity<SpawnedBionic>(targetId, out var entity))
            entity.State.ActiveBuffs.Add(buff);
    }

    #region Properites

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0BD;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properites
}
