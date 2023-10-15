using System;

namespace RSBot.Core.Network;

public class PacketException : SystemException
{
    private Packet m_packet;

    public Packet packet
    {
        get { return m_packet; }
    }

    private string m_message;

    public override string Message
    {
        get { return m_message; }
    }

    public PacketException(Packet packet, Exception innerException)
    {
        this.m_packet = packet;
        this.m_message = "PacketError:" + innerException.Message;
    }

    public PacketException(Packet packet, string message)
    {
        this.m_packet = packet;
        this.m_message = "PacketError:" + message;
    }
}