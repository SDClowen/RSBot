using System;
using RSBot.Core.Components;
using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityGroupSpawnEndResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3018;

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
        packet = Game.SpawnInfo.Packet;
        packet.Lock();

        for (var i = 0; i < Game.SpawnInfo.Amount; i++)
            try
            {
                switch (Game.SpawnInfo.Type)
                {
                    case 0x01: //Spawn

                        SpawnManager.Parse(packet, true);

                        break;

                    case 0x02: //Despawn
                        var uniqueId = packet.ReadUInt();
                        SpawnManager.TryRemove(uniqueId, out var removedEntity);
                        EventManager.FireEvent("OnDespawnEntity", removedEntity);
                        break;
                }
            }
            catch (Exception)
            {
                Log.Debug($"Spawn parse failed at index {i}!");
                break;
            }

        Game.SpawnInfo = null; //release some resources!
    }
}
