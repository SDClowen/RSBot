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

            if (Game.Player.AttackPet != null && Game.Player.AttackPet.UniqueId == uniqueId)
            {
                switch (type)
                {
                    case 1:
                        Game.Player.AttackPet = null;
                        EventManager.FireEvent("OnTerminateAttackPet");
                        break;

                    case 2:
                        Log.Debug("Unknown pet update type:2 Core::Network::Handler::PetUpdateResponse->Invoke() line.47");
                        break;

                    case 3:
                        var experience = packet.ReadLong();
                        var source = packet.ReadUInt();

                        if (source == Game.Player.AttackPet.UniqueId || Game.Player.AttackPet == null) 
                            return;

                        Game.Player.AttackPet.Experience += experience;

                        var iLevel = Game.Player.AttackPet.Level;
                        while (Game.Player.AttackPet.Experience > Game.ReferenceManager.GetRefLevel(iLevel).Exp_C)
                        {
                            Game.Player.AttackPet.Experience -= Game.ReferenceManager.GetRefLevel(iLevel).Exp_C;
                            iLevel++;
                        }

                        if (Game.Player.AttackPet.Level < iLevel)
                        {
                            Game.Player.AttackPet.Level = iLevel;
                            EventManager.FireEvent("OnPetLevelUp");
                            Log.Notify($"Congratulations, your pet [{Game.Player.AttackPet.Name}] level has increased to [{Game.Player.AttackPet.Level}]");
                        }

                        EventManager.FireEvent("OnPetExperienceUpdate");
                        break;

                    case 4:
                        Game.Player.AttackPet.CurrentHungerPoints = packet.ReadUShort();
                        EventManager.FireEvent("OnAttackPetHungerUpdate");
                        break;

                    case 5:
                        Game.Player.AttackPet.Name = packet.ReadString();
                        EventManager.FireEvent("OnAttackPetNameChange");
                        break;

                    default:

                        Log.Debug("Pet update: " + type.ToString("X"));
                        break;
                }
            }
            else if (Game.Player.AbilityPet != null && Game.Player.AbilityPet.UniqueId == uniqueId)
            {
                switch (type)
                {
                    case 1:
                        Game.Player.AbilityPet = null;
                        EventManager.FireEvent("OnTerminateAbilityPet");
                        break;

                    case 2:
                        Game.Player.AbilityPet.UpdateInventorySize(packet);
                        EventManager.FireEvent("OnUpdateAbilityPetInventorySize");
                        break;

                    case 5:
                        Game.Player.AbilityPet.Name = packet.ReadString();
                        EventManager.FireEvent("OnAbilityPetNameChange");
                        break;
                }
            }
            else if (Game.Player.Vehicle != null && Game.Player.Vehicle.UniqueId == uniqueId)
            {
                Game.Player.Vehicle = null;
                EventManager.FireEvent("OnTerminateVehicle");
            }
        }
    }
}