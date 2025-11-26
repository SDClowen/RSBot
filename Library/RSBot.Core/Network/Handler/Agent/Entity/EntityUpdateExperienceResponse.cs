using System;
using RSBot.Core.Event;

namespace RSBot.Core.Network.Handler.Agent.Entity;

internal class EntityUpdateExperienceResponse : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0x3056;

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
        packet.ReadUInt(); //Mobs unique ID!

        long experienceAmount;

        if (Game.ClientType >= GameClientType.Thailand)
            experienceAmount = packet.ReadLong();
        else
            experienceAmount = packet.ReadUInt();

        Game.Player.Experience += experienceAmount;

        var iLevel = Game.Player.Level;
        var oldLevel = Game.Player.Level;

        while (Game.Player.Experience > Game.ReferenceManager.GetRefLevel(iLevel).Exp_C)
        {
            Game.Player.Experience -= Game.ReferenceManager.GetRefLevel(iLevel).Exp_C;
            iLevel++;
        }

        if (Game.Player.Level < iLevel)
        {
            Game.Player.StatPoints += Convert.ToUInt16((iLevel - oldLevel) * 3);
            Game.Player.Level = iLevel;

            Log.Notify($"Congratulations, your level has increased to lv.{Game.Player.Level}");

            EventManager.FireEvent("OnLevelUp", oldLevel);
        }

        EventManager.FireEvent("OnExpSpUpdate");
    }
}
