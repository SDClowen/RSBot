using System;
using System.Net.Sockets;
using System.Threading;
using RSBot.Core.Network.Protocol;

namespace RSBot.Core.Network;

public class NetBase(bool isClient = false)
{
    /// <summary>
    ///     Gets or sets the packet dispatcher thread.
    /// </summary>
    /// <value>
    ///     The dispatcher thread.
    /// </value>
    protected Thread _dispatcherThread;

    /// <summary>
    ///     Get the allocated buffer.
    /// </summary>
    /// <value>
    ///     The allocated buffer.
    /// </value>
    protected byte[] _buffer { get; } = new byte[4096];

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is closing.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is closing; otherwise, <c>false</c>.
    /// </value>
    private bool _isClient { get; set; } = isClient;

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is closing.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is closing; otherwise, <c>false</c>.
    /// </value>
    public bool IsClosing { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether [enable packet processor].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [enable packet processor]; otherwise, <c>false</c>.
    /// </value>
    public bool EnablePacketDispatcher { get; set; }

    /// <summary>
    ///     Gets or sets the security protocol.
    /// </summary>
    /// <value>
    ///     The protocol.
    /// </value>
    protected SecurityProtocol _protocol;

    /// <summary>
    ///     Gets or sets the socket.
    /// </summary>
    /// <value>
    ///     The socket.
    /// </value>
    protected Socket _socket;

    /// <summary>
    ///     Gets or sets a value indicating whether this instance is connected.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this socket is connected; otherwise, <c>false</c>.
    /// </value>
    public bool IsConnected => _socket != null && _socket.Connected;

    /// <summary>
    /// Call the event when packet received
    /// </summary>
    public delegate void ConnectedEventHandler();

    public delegate void DisconnectedEventHandler();

    public delegate void PacketReceivedEventHandler(Packet packet);

    public delegate void PacketSentEventHandler(Packet packet);
    public event ConnectedEventHandler Connected;
    public event DisconnectedEventHandler Disconnected;
    public event PacketReceivedEventHandler PacketReceived;
    public event PacketSentEventHandler PacketSent;

    public virtual void OnConnected()
    {
        Connected?.Invoke();
    }

    public virtual void OnDisconnected()
    {
        Disconnected?.Invoke();
    }

    public virtual void OnPacketReceived(Packet packet)
    {
        PacketReceived?.Invoke(packet);
    }

    public virtual void OnPacketSent(Packet packet)
    {
        PacketSent?.Invoke(packet);
    }

    protected void StartNetWorker()
    {
        if (_dispatcherThread == null)
        {
            _dispatcherThread = new Thread(ProcessPacketsThreaded)
            {
                Name = "Network.PacketProcessor",
                IsBackground = true,
            };
            _dispatcherThread.Start();
        }
    }

    /// <summary>
    ///     Processes the packets threaded.
    /// </summary>
    private void ProcessPacketsThreaded()
    {
        try
        {
            while (!EnablePacketDispatcher && !IsClosing)
                Thread.Sleep(1);

            while (EnablePacketDispatcher && !IsClosing)
            {
                ProcessQueuedPackets();
                Thread.Sleep(1);
            }

            if (IsClosing)
                return;

            ProcessPacketsThreaded();
        }
        catch { }
    }

    /// <summary>
    ///     Processes the packets.
    /// </summary>
    private void ProcessQueuedPackets()
    {
        try
        {
            if (IsClosing || !EnablePacketDispatcher)
                return;

            var packets = _protocol.TransferIncoming();
            if (packets != null)
            {
                foreach (var packet in packets)
                {
                    if (packet.Opcode == 0x5000 || packet.Opcode == 0x9000)
                        continue;

                    if (_isClient && packet.Opcode == 0x2001)
                        continue;

                    try
                    {
                        OnPacketReceived(packet);
                    }
                    catch (Exception) { }
                }
            }

            var buffers = _protocol?.TransferOutgoing();
            if (buffers == null)
                return;

            foreach (var buffer in buffers)
            {
                if (_socket == null || IsClosing || !EnablePacketDispatcher || !_socket.Connected)
                    return;

                _socket.Send(buffer);
            }
        }
        catch { }
    }

    /// <summary>
    ///     Sends the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Send(Packet packet)
    {
        OnPacketSent(packet);

        _protocol?.Send(packet);
    }
}
