using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdateMoveSpeedResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30D0;

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
        var walkSpeed = packet.ReadFloat();
        var runSpeed = packet.ReadFloat();

        if (uniqueId == Game.Player.UniqueId || Game.Player.Vehicle?.UniqueId == uniqueId)
        {
            Game.Player.SetSpeed(walkSpeed, runSpeed);

            EventManager.FireEvent("OnUpdatePlayerSpeed");
        }
        else
        {
            if (!SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var bionic))
                return;

            bionic.SetSpeed(walkSpeed, runSpeed);

            EventManager.FireEvent("OnUpdateEntitySpeed", uniqueId);
        }
    }
}
