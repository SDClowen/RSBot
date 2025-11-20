using System.Linq;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Teleport;

internal class TeleportRequest : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x705A;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Server;

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var teleporterUniqueId = packet.ReadUInt();
        var teleportType = (TeleportType)packet.ReadByte();
        if (teleportType == TeleportType.Guide || teleportType == TeleportType.RUNTIME_PORTAL)
        {
            var operation = packet.ReadByte();
            return;
        }

        var destination = packet.ReadUInt();

        if (!SpawnManager.TryGetEntity<SpawnedBionic>(teleporterUniqueId, out var portal))
            return;

        Game.Player.Teleportation = new Teleportation
        {
            Destination = Game.ReferenceManager.TeleportData.FirstOrDefault(t => t.ID == destination),
        };

        EventManager.FireEvent("OnRequestTeleport", destination, portal.Record.CodeName);
    }
}
