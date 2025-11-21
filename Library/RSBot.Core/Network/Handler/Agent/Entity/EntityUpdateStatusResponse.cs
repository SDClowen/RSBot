using System;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdateStatusResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3057;

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
        var updateSource = packet.ReadUShort(); //UpdateSource
        var updateFlag = (EntityUpdateStatusFlag)packet.ReadByte();

        if (uniqueId == Game.Player.UniqueId)
            UpdatePlayerStatus(packet, updateFlag);
        else if (Game.Player.Growth?.UniqueId == uniqueId)
            UpdateGrowthStatus(packet, updateFlag);
        else if (Game.Player.Fellow?.UniqueId == uniqueId)
            UpdateFellowStatus(packet, updateFlag);
        else if (Game.Player.Transport?.UniqueId == uniqueId)
            UpdateTransportStatus(packet, updateFlag);
        else if (Game.Player.JobTransport?.UniqueId == uniqueId)
            UpdateJobTransportStatus(packet, updateFlag);
        else if (SpawnManager.TryGetEntity<SpawnedBionic>(uniqueId, out var entity))
            UpdateEntityStatus(packet, updateFlag, entity);
    }

    private static void UpdatePlayerStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
    {
        if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
        {
            Game.Player.Health = packet.ReadInt();
            EventManager.FireEvent("OnUpdateHP");
        }

        if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
        {
            Game.Player.Mana = packet.ReadInt();
            EventManager.FireEvent("OnUpdateMP");
        }

        if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
            EventManager.FireEvent("OnUpdateHPMP");

        if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
        {
            var effectPrevious = Game.Player.BadEffect;
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
                    Log.Warn($"You are under {effectValue} status.");

                if ((effectEnded & effectValue) == effectValue)
                    Log.Warn($"{effectValue} status has ended.");
            }

            Game.Player.BadEffect = effectCurrent;

            if (effectStarted != BadEffect.None)
                EventManager.FireEvent("OnPlayerBadEffect");

            if (effectEnded != BadEffect.None)
                EventManager.FireEvent("OnPlayerBadEffectEnd");
        }
    }

    private static void UpdateGrowthStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
    {
        if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
            Game.Player.Growth.Health = packet.ReadInt();

        if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
            packet.ReadUInt();

        if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
            EventManager.FireEvent("OnGrowthHealthUpdate");

        if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
        {
            var effectPrevious = Game.Player.Growth.BadEffect;
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

            Game.Player.Growth.BadEffect = effectCurrent;

            if (effectStarted != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffect", Game.Player.Growth);

            if (effectEnded != BadEffect.None)
                EventManager.FireEvent("OnCosGrowthEffectEnd", Game.Player.Growth);
        }
    }

    private static void UpdateFellowStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
    {
        if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
            Game.Player.Fellow.Health = packet.ReadInt();

        if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
            packet.ReadUInt();

        if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
            EventManager.FireEvent("OnFellowHealthUpdate");

        if (updateFlag == EntityUpdateStatusFlag.Fellow)
        {
            Game.Player.Fellow.Satiety = packet.ReadInt();
            EventManager.FireEvent("OnFellowSatietyUpdate");
            //packet.ReadInt(); // bad status??
        }

        if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
        {
            var effectPrevious = Game.Player.Fellow.BadEffect;
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
                    Log.Warn($"Your fellow pet are under {effectValue} status.");

                if ((effectEnded & effectValue) == effectValue)
                    Log.Warn($"Your fellow pet's bad status {effectValue} has ended.");
            }

            Game.Player.Fellow.BadEffect = effectCurrent;

            if (effectStarted != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffect", Game.Player.Fellow);

            if (effectEnded != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffectEnd", Game.Player.Fellow);
        }
    }

    private static void UpdateTransportStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
    {
        if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
            Game.Player.Transport.Health = packet.ReadInt();

        if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
            packet.ReadUInt();

        if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
            EventManager.FireEvent("OnUpdateTransportHealth");

        if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
        {
            var effectPrevious = Game.Player.Transport.BadEffect;
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

            Game.Player.Transport.BadEffect = effectCurrent;

            if (effectStarted != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffect", Game.Player.Transport);

            if (effectEnded != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffectEnd", Game.Player.Transport);
        }
    }

    private static void UpdateJobTransportStatus(Packet packet, EntityUpdateStatusFlag updateFlag)
    {
        if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
            Game.Player.JobTransport.Health = packet.ReadInt();

        if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
            packet.ReadUInt();

        if ((updateFlag & EntityUpdateStatusFlag.HPMP) != EntityUpdateStatusFlag.HPMP)
            EventManager.FireEvent("OnUpdateJobTransportHealth");

        if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect)
        {
            var effectPrevious = Game.Player.JobTransport.BadEffect;
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
                    Log.Warn($"Your job vehicle is under bad status {effectValue}.");

                if ((effectEnded & effectValue) == effectValue)
                    Log.Warn($"Your job vehicle's bad status {effectValue} has ended.");
            }

            Game.Player.JobTransport.BadEffect = effectCurrent;

            if (effectStarted != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffect", Game.Player.JobTransport);

            if (effectEnded != BadEffect.None)
                EventManager.FireEvent("OnCosBadEffectEnd", Game.Player.JobTransport);
        }
    }

    private static void UpdateEntityStatus(Packet packet, EntityUpdateStatusFlag updateFlag, SpawnedBionic bionic)
    {
        if ((updateFlag & EntityUpdateStatusFlag.HP) == EntityUpdateStatusFlag.HP)
        {
            var health = packet.ReadInt();
            bionic.Health = health;

            if (health <= 0 && Game.SelectedEntity?.UniqueId == bionic.UniqueId)
                Game.SelectedEntity = null;

            EventManager.FireEvent("OnUpdateEntityHp", bionic);
        }

        if ((updateFlag & EntityUpdateStatusFlag.MP) == EntityUpdateStatusFlag.MP)
            packet.ReadUInt();

        if ((updateFlag & EntityUpdateStatusFlag.BadEffect) == EntityUpdateStatusFlag.BadEffect) { }
    }
}
