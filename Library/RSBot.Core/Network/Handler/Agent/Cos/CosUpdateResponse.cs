using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent;

internal class CosUpdateResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x30C9;

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

        if (Game.Player.Growth?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    EventManager.FireEvent("OnTerminateCos", Game.Player.Growth);
                    Game.Player.Growth = null;
                    break;

                case 2: // update inventory

                    break;

                case 3:
                    var experience = packet.ReadLong();
                    var source = packet.ReadUInt();
                    if (source == Game.Player.Growth.UniqueId)
                        return;

                    Game.Player.Growth.Experience += experience;

                    var iLevel = Game.Player.Growth.Level;
                    while (Game.Player.Growth.Experience > Game.ReferenceManager.GetRefLevel(iLevel).Exp_C)
                    {
                        Game.Player.Growth.Experience -= Game.ReferenceManager.GetRefLevel(iLevel).Exp_C;
                        iLevel++;
                    }

                    if (Game.Player.Growth.Level < iLevel)
                    {
                        Game.Player.Growth.Level = iLevel;
                        EventManager.FireEvent("OnGrowthLevelUp");
                        Log.Notify(
                            $"Congratulations, your pet [{Game.Player.Growth.Name}] level has increased to [{Game.Player.Growth.Level}]"
                        );
                    }

                    EventManager.FireEvent("OnGrowthExperienceUpdate");
                    break;

                case 4:
                    Game.Player.Growth.CurrentHungerPoints = packet.ReadUShort();
                    EventManager.FireEvent("OnGrowthHungerUpdate");
                    break;

                case 5:
                    Game.Player.Growth.Name = packet.ReadString();
                    EventManager.FireEvent("OnGrowthNameChange");
                    break;

                case 7:

                    Game.Player.Growth.Id = packet.ReadUInt();
                    var record = Game.Player.Growth.Record;
                    if (record != null)
                        Game.Player.Growth.Health = Game.Player.Growth.MaxHealth = record.MaxHealth;

                    break;

                default:

                    Log.Debug("Pet update: " + type.ToString("X"));
                    break;
            }
        }
        else if (Game.Player.Fellow?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    EventManager.FireEvent("OnTerminateCos", Game.Player.Fellow);
                    Game.Player.Fellow = null;
                    EventManager.FireEvent("OnTerminateFellow");
                    break;

                case 2: // update inventory

                    break;

                case 3:
                    var experience = packet.ReadLong();
                    var source = packet.ReadUInt();
                    if (source == Game.Player.Fellow.UniqueId)
                        return;

                    Game.Player.Fellow.Experience += experience;

                    var iLevel = Game.Player.Fellow.Level;
                    while (Game.Player.Fellow.Experience > Game.ReferenceManager.GetRefLevel(iLevel).Exp_C_Pet2)
                    {
                        Game.Player.Fellow.Experience -= Game.ReferenceManager.GetRefLevel(iLevel).Exp_C_Pet2;
                        iLevel++;
                    }

                    if (Game.Player.Fellow.Level < iLevel)
                    {
                        Game.Player.Fellow.Level = iLevel;
                        Game.Player.Fellow.MaxHealth = Game.Player.Fellow.Health;
                        EventManager.FireEvent("OnFellowLevelUp");
                        Log.Notify(
                            $"Congratulations, your fellow pet [{Game.Player.Fellow.Name}] level has increased to [{Game.Player.Fellow.Level}]"
                        );
                    }

                    EventManager.FireEvent("OnFellowExperienceUpdate");
                    break;

                case 4:
                    Game.Player.Fellow.Satiety = packet.ReadUShort();
                    EventManager.FireEvent("OnFellowSatietyUpdate");
                    break;

                case 5:
                    Game.Player.Fellow.Name = packet.ReadString();
                    EventManager.FireEvent("OnFellowNameChange");
                    break;

                case 7:

                    Game.Player.Fellow.Id = packet.ReadUInt();
                    var record = Game.Player.Fellow.Record;
                    if (record != null)
                        Game.Player.Fellow.Health = Game.Player.Fellow.MaxHealth = record.MaxHealth;

                    break;

                case 8:
                    packet.ReadULong(); //gained pet exp
                    packet.ReadULong(); //gained skill exp
                    packet.ReadUInt(); //total stored SP
                    packet.ReadUInt(); //mob id
                    break;

                default:

                    Log.Debug("Pet update: " + type.ToString("X"));
                    break;
            }
        }
        else if (Game.Player.AbilityPet?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    EventManager.FireEvent("OnTerminateCos", Game.Player.AbilityPet);
                    Game.Player.AbilityPet = null;
                    EventManager.FireEvent("OnTerminateAbilityPet");
                    break;

                case 2:
                    Game.Player.AbilityPet.Inventory.Deserialize(packet);

                    EventManager.FireEvent("OnUpdateAbilityPetInventorySize");
                    break;

                case 5:
                    Game.Player.AbilityPet.Name = packet.ReadString();
                    EventManager.FireEvent("OnAbilityPetNameChange");
                    break;
            }
        }
        else if (Game.Player.Transport?.UniqueId == uniqueId)
        {
            EventManager.FireEvent("OnTerminateCos", Game.Player.Transport);
            Game.Player.Transport = null;
            EventManager.FireEvent("OnTerminateVehicle");
        }
        else if (Game.Player.JobTransport?.UniqueId == uniqueId)
        {
            switch (type)
            {
                case 1:
                    EventManager.FireEvent("OnTerminateCos", Game.Player.JobTransport);
                    Game.Player.JobTransport = null;
                    EventManager.FireEvent("OnTerminateJobTransport");
                    break;

                case 2:
                    Game.Player.JobTransport.Inventory.Deserialize(packet);

                    EventManager.FireEvent("OnUpdateJobTransportInventory");
                    break;
            }
        }
    }
}
