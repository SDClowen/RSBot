using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Cos
{
    internal class UpdateResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x30C9;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var uniqueId = packet.ReadUInt();
            var type = packet.ReadByte();

            if (Core.Game.Player.AttackPet != null && Core.Game.Player.AttackPet.UniqueId == uniqueId)
            {
                switch (type)
                {
                    case 1:
                        Core.Game.Player.AttackPet = null;
                        EventManager.FireEvent("OnTerminateAttackPet");
                        break;

                    case 2:
                        Log.Debug("Unknown pet update type:2 Core::Network::Handler::PetUpdateResponse->Invoke() line.47");
                        break;

                    case 3:
                        var experience = packet.ReadULong();
                        var source = packet.ReadUInt();

                        if (source == Core.Game.Player.AttackPet.UniqueId || Core.Game.Player.AttackPet == null) return;

                        Core.Game.Player.AttackPet.Experience += experience;

                        var iLevel = Core.Game.Player.AttackPet.Level;
                        while (Core.Game.Player.AttackPet.Experience > (ulong)Core.Game.ReferenceManager.GetRefLevel(iLevel).Exp_C)
                        {
                            Core.Game.Player.AttackPet.Experience -= (ulong)Core.Game.ReferenceManager.GetRefLevel(iLevel).Exp_C;
                            iLevel++;
                        }

                        if (Core.Game.Player.AttackPet.Level < iLevel)
                        {
                            Core.Game.Player.AttackPet.Level = iLevel;
                            EventManager.FireEvent("OnPetLevelUp");
                            Log.Notify($"Congratulations, your pet [{Core.Game.Player.AttackPet.Name}] level has increased to [{Core.Game.Player.AttackPet.Level}]");
                        }

                        EventManager.FireEvent("OnPetExperienceUpdate");
                        break;

                    case 4:
                        Core.Game.Player.AttackPet.CurrentHungerPoints = packet.ReadUShort();
                        EventManager.FireEvent("OnAttackPetHungerUpdate");
                        break;

                    case 5:
                        Core.Game.Player.AttackPet.Name = packet.ReadString();
                        EventManager.FireEvent("OnAttackPetNameChange");
                        break;

                    default:

                        Log.Debug("Pet update: " + type.ToString("X"));
                        break;
                }
            }
            else if (Core.Game.Player.AbilityPet != null && Core.Game.Player.AbilityPet.UniqueId == uniqueId)
            {
                switch (type)
                {
                    case 1:
                        Core.Game.Player.AbilityPet = null;
                        EventManager.FireEvent("OnTerminateAbilityPet");
                        break;

                    case 2:
                        Core.Game.Player.AbilityPet.Slots = packet.ReadByte();
                        Core.Game.Player.AbilityPet.ParseInventory(packet);
                        EventManager.FireEvent("OnUpdateAbilityPetInventorySize");
                        break;

                    case 5:
                        Core.Game.Player.AbilityPet.Name = packet.ReadString();
                        EventManager.FireEvent("OnAbilityPetNameChange");
                        break;
                }
            }
            else if (Core.Game.Player.Vehicle != null && Core.Game.Player.Vehicle.UniqueId == uniqueId)
            {
                Core.Game.Player.Vehicle = null;
                EventManager.FireEvent("OnTerminateVehicle");
            }
        }
    }
}