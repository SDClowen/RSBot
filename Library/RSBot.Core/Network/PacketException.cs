using System;

namespace RSBot.Core.Network;

public class PacketException : SystemException
{
    public PacketException(Packet packet, Exception innerException)
    {
        this.packet = packet;
        Message = "PacketError:" + innerException.Message;
    }

    public PacketException(Packet packet, string message)
    {
        this.packet = packet;
        Message = "PacketError:" + message;
    }

    public Packet packet { get; }

    public override string Message { get; }
}
