using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Cos;

namespace RSBot.Core.Network.Handler.Agent;

internal class CosDataResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30C8;

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
        var objectId = packet.ReadUInt();

        var objChar = Game.ReferenceManager.GetRefObjChar(objectId);
        if (objChar.TypeID2 == 2 && objChar.TypeID3 == 3)
        {
            var hp = packet.ReadInt();
            var maxHp = packet.ReadInt();
            maxHp = maxHp != 0 && maxHp != 200 ? maxHp : objChar.MaxHealth;

            switch (objChar.TypeID4)
            {
                case 1:

                    Game.Player.Transport = new Transport
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };

                    Game.Player.StopMoving();
                    Game.Player.SetSpeed(objChar.Speed1, objChar.Speed2);

                    EventManager.FireEvent("OnSummonTransport");
                    EventManager.FireEvent("OnSummonCos", Game.Player.Transport);

                    break;
                case 2:

                    Game.Player.JobTransport = new JobTransport
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                        Inventory = new InventoryItemCollection(packet),
                        OwnerUniqueId = packet.ReadUInt(),
                    };

                    EventManager.FireEvent("OnSummonJobTransport");
                    EventManager.FireEvent("OnSummonCos", Game.Player.JobTransport);

                    Game.Player.StopMoving();
                    Game.Player.SetSpeed(objChar.Speed1, objChar.Speed2);

                    break;
                case 3:

                    Game.Player.Growth = new Growth
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };
                    Game.Player.Growth.Deserialize(packet);

                    EventManager.FireEvent("OnSummonGrowth");
                    EventManager.FireEvent("OnSummonCos", Game.Player.Growth);

                    break;
                case 4:

                    Game.Player.AbilityPet = new Ability
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };

                    Game.Player.AbilityPet.Deserialize(packet);
                    EventManager.FireEvent("OnSummonCos", Game.Player.AbilityPet);
                    EventManager.FireEvent("OnSummonAbility");

                    break;
                case 9:

                    Game.Player.Fellow = new Fellow
                    {
                        Id = objectId,
                        UniqueId = uniqueId,
                        Health = hp,
                        MaxHealth = maxHp,
                    };

                    Game.Player.Fellow.Deserialize(packet);
                    EventManager.FireEvent("OnSummonCos", Game.Player.Fellow);

                    break;
            }
        }
    }
}
