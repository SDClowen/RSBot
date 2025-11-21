using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent;

internal class UpdateMountStateResponse : IPacketHandler
{
    #region Methods

    public void Invoke(Packet packet)
    {
        if (packet.ReadByte() != 0x01)
            return;

        var ownerUniqueId = packet.ReadUInt();
        var isMounted = packet.ReadBool();
        var cosUniqueId = packet.ReadUInt();

        if (ownerUniqueId == Game.Player.UniqueId)
        {
            if (!isMounted)
            {
                Game.Player.Vehicle = null;
                Game.Player.Transport = null;

                return;
            }

            if (cosUniqueId == Game.Player.Transport?.UniqueId)
                Game.Player.Vehicle = Game.Player.Transport;

            if (cosUniqueId == Game.Player.JobTransport?.UniqueId)
                Game.Player.Vehicle = Game.Player.JobTransport;

            // Vsro private servers uses the attack pet like pet2
            if (cosUniqueId == Game.Player.Growth?.UniqueId)
                Game.Player.Vehicle = Game.Player.Growth;

            if (cosUniqueId == Game.Player.Fellow?.UniqueId)
                Game.Player.Vehicle = Game.Player.Fellow;

            var bionicPosition = Game.Player.Vehicle.Bionic.Position;
            Game.Player.Vehicle.StopMoving(bionicPosition);
            Game.Player.StopMoving(bionicPosition);
        }

        //Assertion: only player's are supported to have active vehicles. Think it's the same in the client.
        if (!SpawnManager.TryGetEntity<SpawnedPlayer>(ownerUniqueId, out var owner))
            return;

        if (!SpawnManager.TryGetEntity<SpawnedCos>(cosUniqueId, out var cos))
            return;

        owner.OnTransport = isMounted;
        owner.TransportUniqueId = cosUniqueId;

        EventManager.FireEvent("OnEntityMountTransport", owner, cos, isMounted);
    }

    #endregion Methods

    #region Properties

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB0CB;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properties
}
