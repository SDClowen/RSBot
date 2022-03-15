using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    internal class EntityUpdateStatusResponse : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3057;

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
            var updateSource = packet.ReadUShort(); //UpdateSource
            var updateFlag = (EntityUpdateStatusFlag)packet.ReadByte();

            if (uniqueId == Core.Game.Player.UniqueId)
                UpdatePlayerStatus(packet, updateFlag);
            else if (Core.Game.Player.AttackPet != null && uniqueId == Core.Game.Player.AttackPet.UniqueId)
                UpdatePetStatus(packet, updateFlag);
            else if (Core.Game.Player.Vehicle != null && uniqueId == Core.Game.Player.Vehicle.UniqueId)
                UpdateVehicleStatus(packet, updateFlag);
            else if (SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var entity))
                UpdateEntityStatus(packet, updateFlag, entity);
        }

        private static void UpdatePlayerStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
        {
            if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
            {
                Core.Game.Player.Health = packet.ReadUInt();
                EventManager.FireEvent("OnUpdateHP");
            }

            if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
            {
                Core.Game.Player.Mana = packet.ReadUInt();
                EventManager.FireEvent("OnUpdateMP");
            }

            if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
                EventManager.FireEvent("OnUpdateHPMP");

            if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
            {
                var effectPrevious = Core.Game.Player.BadEffect;
                var effectCurrent = (BadEffect)packet.ReadUInt();
                var effectStarted = ~effectPrevious & effectCurrent;
                var effectEnded = effectPrevious & ~effectCurrent;

                foreach (BadEffect effectValue in Enum.GetValues(typeof(BadEffect)))
                {
                    if(effectValue == BadEffect.None)
                        continue;

                    byte effectLevel;

                    if ((effectCurrent & effectValue) > BadEffect.Zombie)
                        effectLevel = packet.ReadByte(); //EffectLevel

                    if ((effectStarted & effectValue) == effectValue)
                        Log.Warn($"You are under {effectValue} status.");

                    if ((effectEnded & effectValue) == effectValue)
                        Log.Warn($"{effectValue} status has ended.");
                }

                Core.Game.Player.BadEffect = effectCurrent;

                if (effectStarted != BadEffect.None)
                    EventManager.FireEvent("OnPlayerBadEffect");

                if (effectEnded != BadEffect.None)
                    EventManager.FireEvent("OnPlayerBadEffectEnd");
            }
        }

        private static void UpdatePetStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
        {
            if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
                Core.Game.Player.AttackPet.Health = packet.ReadUInt();

            if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
                packet.ReadUInt();

            if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
                EventManager.FireEvent("OnUpdatePetHPMP");

            if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
            {
                var effectPrevious = Core.Game.Player.AttackPet.BadEffect;
                var effectCurrent = (BadEffect)packet.ReadUInt();
                var effectStarted = ~effectPrevious & effectCurrent;
                var effectEnded = effectPrevious & ~effectCurrent;

                foreach (BadEffect effectValue in Enum.GetValues(typeof(BadEffect)))
                {
                    if (effectValue == BadEffect.None)
                        continue;

                    byte effectLevel;

                    if ((effectCurrent & effectValue) > BadEffect.Zombie)
                        effectLevel = packet.ReadByte(); //EffectLevel

                    if ((effectStarted & effectValue) == effectValue)
                        Log.Warn($"Your pet are under {effectValue} status.");

                    if ((effectEnded & effectValue) == effectValue)
                        Log.Warn($"Your pet's bad status {effectValue} has ended.");
                        
                }

                Core.Game.Player.AttackPet.BadEffect = effectCurrent;

                if (effectStarted != BadEffect.None)
                    EventManager.FireEvent("OnPetBadEffect");

                if (effectEnded != BadEffect.None)
                    EventManager.FireEvent("OnPetBadEffectEnd");
            }
        }

        private static void UpdateVehicleStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
        {
            if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
                Core.Game.Player.Vehicle.Health = packet.ReadUInt();

            if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
                packet.ReadUInt();

            if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
                EventManager.FireEvent("OnUpdateVehicleHPMP");

            if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
            {
                var effectPrevious = Core.Game.Player.Vehicle.BadEffect;
                var effectCurrent = (BadEffect)packet.ReadUInt();
                var effectStarted = ~effectPrevious & effectCurrent;
                var effectEnded = effectPrevious & ~effectCurrent;

                foreach (BadEffect effectValue in Enum.GetValues(typeof(BadEffect)))
                {
                    if (effectValue == BadEffect.None)
                        continue;

                    byte effectLevel;

                    if ((effectCurrent & effectValue) > BadEffect.Zombie)
                        effectLevel = packet.ReadByte(); //EffectLevel

                    if ((effectStarted & effectValue) == effectValue)
                        Log.Warn($"Your vehicle is under bad status {effectValue}.");

                    if ((effectEnded & effectValue) == effectValue)
                        Log.Warn($"Your vehicle's bad status {effectValue} has ended.");
                }

                Core.Game.Player.Vehicle.BadEffect = effectCurrent;

                if (effectStarted != BadEffect.None)
                    EventManager.FireEvent("OnVehicleBadEffect");

                if (effectEnded != BadEffect.None)
                    EventManager.FireEvent("OnVehicleBadEffectEnd");
            }
        }

        private static void UpdateEntityStatus(Packet packet, EntityUpdateStatusFlag updateFlag, SpawnedBionic bionic)
        {
            if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
            {
                var health = packet.ReadInt();
                bionic.Health = health;

                Log.Debug("HP updated: " + health);

                if (health <= 0)
                {
                    EventManager.FireEvent("OnKillSelectedEnemy");
                    Core.Game.SelectedEntity = null;
                }

                if(Core.Game.SelectedEntity?.UniqueId == bionic.UniqueId)
                    EventManager.FireEvent("OnUpdateSelectedEntityHP", bionic);
            }

            if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
                packet.ReadUInt();

            if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
            {
                
            }
        }
    }
}