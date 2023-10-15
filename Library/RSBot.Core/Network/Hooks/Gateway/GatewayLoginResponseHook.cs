﻿namespace RSBot.Core.Network.Hooks;

internal class GatewayLoginResponseHook : IPacketHook
{
    /// <summary>
    ///     Gets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xA102;

    /// <summary>
    ///     Gets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Replaces the packet and returns a new packet.
    /// </summary>
    /// <param name="packet"></param>
    /// <returns></returns>
    public Packet ReplacePacket(Packet packet)
    {
        var result = packet.ReadByte();
        if (result == 0x01)
        {
            Kernel.Proxy.Token = packet.ReadUInt();
            Kernel.Proxy.SetAgentserverAddress(packet.ReadString(), packet.ReadUShort());

            if (Game.Clientless)
                return null;
        }
        else
        {
            return packet;
        }

        var resultPacket = new Packet(packet.Opcode, packet.Encrypted, packet.Massive);
        resultPacket.WriteByte(result);
        resultPacket.WriteUInt(Kernel.Proxy.Token);
        resultPacket.WriteString("127.0.0.1");
        resultPacket.WriteUShort(Kernel.Proxy.Port);

        if (packet.ReaderRemain > 0)
            resultPacket.WriteByteArray(packet.ReadByteArray(packet.ReaderRemain));
        /*
        //unknown value
        if (Game.ClientType == GameClientType.Japanese_Old)
            resultPacket.WriteInt(packet.ReadInt());

        if (Game.ClientType >= GameClientType.Global)
        {
            var unk1 = packet.ReadByte();
            resultPacket.WriteByte(unk1);

            if (unk1 == 2 && packet.ReaderRemain > 0)
                resultPacket.WriteString(packet.ReadString());
        }
        */
        return resultPacket;
    }
}