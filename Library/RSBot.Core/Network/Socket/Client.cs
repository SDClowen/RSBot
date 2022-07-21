using RSBot.Core.Network.SecurityAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Network
{
    public class Client
    {
        public delegate void ConnectedEventHandler();
        public event ConnectedEventHandler OnConnected;

        public delegate void DisconnectedEventHandler();
        public event DisconnectedEventHandler OnDisconnected;

        public delegate void PacketReceivedEventHandler(Packet packet);
        public event PacketReceivedEventHandler OnPacketReceived;
        
        public delegate void PacketSentEventHandler(Packet packet);
        public event PacketSentEventHandler OnPacketSent;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing;

        /// <summary>
        /// The enable packet processor
        /// </summary>
        /// <value>
        /// <c>true</c> if the packet processor enabled; otherwise, <c>false</c>.
        /// </value>
        public bool EnablePacketDispatcher;

        /// <summary>
        /// Gets or sets the listener.
        /// </summary>
        /// <value>
        /// The listener.
        /// </value>
        public Socket _listener;

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public Socket _socket;

        /// <summary>
        /// Gets or sets the security protocol.
        /// </summary>
        /// <value>
        /// The protocol.
        /// </value>
        private SecurityProtocol _protocol;

        /// <summary>
        /// Gets or sets the packet dispatcher thread.
        /// </summary>
        /// <value>
        /// The dispatcher thread.
        /// </value>
        private Thread _dispatcherThread;

        /// <summary>
        /// Get the allocated buffer.
        /// </summary>
        /// <value>
        /// The allocated buffer.
        /// </value>
        private byte[] _buffer { get; } = new byte[4096];

        /// <summary>
        /// Listens the specified port.
        /// </summary>
        /// <param name="port">The port.</param>
        public void Listen(ushort port)
        {
            try
            {
                _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //Thread Management
                _dispatcherThread = new Thread(PacketDispatcherCallback)
                {
                    Name = "Proxy.Network.Client.PacketProcessor",
                    IsBackground = true
                };

                _dispatcherThread.Start();

                _listener.Bind(new IPEndPoint(IPAddress.Loopback, port));
                _listener.Listen(1);
                _listener.BeginAccept(OnClientConnect, null);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Listens this instance.
        /// </summary>
        private void Listen()
        {
            try
            {
                EnablePacketDispatcher = false;

                _socket?.Shutdown(SocketShutdown.Both);
                _socket?.Close();

                _listener.BeginAccept(OnClientConnect, null);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public void Shutdown()
        {
            try
            {
                EnablePacketDispatcher = false;
                IsClosing = true;

                _dispatcherThread?.Join();

                //Close Socket
                if (_socket != null)
                {
                    if (_socket.Connected)
                        _socket.Shutdown(SocketShutdown.Both);

                    _socket.Close();
                    _socket = null;
                }

                //Close listener
                if (_listener != null)
                {
                    _listener.Close();
                    _listener = null;
                }

                _protocol = null;
                _dispatcherThread = null;
            }
            catch
            {
            }
        }

        /// <summary>
        /// Called when [client connect].
        /// </summary>
        /// <param name="ar">The ar.</param>
        private void OnClientConnect(IAsyncResult ar)
        {
            try
            {
                if (IsClosing)
                    return;

                EnablePacketDispatcher = true;
                _socket = _listener.EndAccept(ar);

                _protocol = new SecurityProtocol();
                _protocol.GenerateSecurity(true, true, true);

                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);
                
                OnConnected?.Invoke();
            }
            catch (Exception)
            {
                OnDisconnected?.Invoke();
                Listen();
            }
        }

        /// <summary>
        /// Waits for data.
        /// </summary>
        /// <param name="ar">The ar.</param>
        private void OnBeginReceiveCallback(IAsyncResult ar)
        {
            if (IsClosing || !EnablePacketDispatcher)
                return;

            int receivedSize = 0;

            try
            {
                receivedSize = _socket.EndReceive(ar, out var error);
                if(receivedSize == 0 || error != SocketError.Success)
                {
                    OnDisconnected?.Invoke();
                    Listen();
                    return;
                }

                _protocol.Recv(_buffer, 0, receivedSize);
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionReset) //Client OnDisconnected > Mostly occurs during GW->AS switch
                {
                    OnDisconnected?.Invoke();

                    Listen();
                }
            }
            catch (HandshakeSecurityException ex)
            {
                Log.Error("[Fatal]: Could not handshake the client, restarting client process now...");
                Game.Start();
            }
            finally
            {
                try
                {
                    if(receivedSize != 0 && _socket != null && _socket.Connected)
                        _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Sends the specified packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Send(Packet packet)
        {
            OnPacketSent?.Invoke(packet);

            _protocol?.Send(packet);
        }

        /// <summary>
        /// Threadeds the packet processing.
        /// </summary>
        private void PacketDispatcherCallback()
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

                PacketDispatcherCallback();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Processes the client packets.
        /// </summary>
        private void ProcessQueuedPackets()
        {
            try
            {
                if (IsClosing || !EnablePacketDispatcher || _protocol == null)
                    return;

                var receiveds = _protocol.TransferIncoming();
                if (receiveds != null)
                {
                    foreach (var packet in receiveds)
                    {
                        if (packet.Opcode == 0x5000 || packet.Opcode == 0x9000 || packet.Opcode == 0x2001)
                            continue;

                        OnPacketReceived?.Invoke(packet);
                    }
                }

                foreach (var buffer in _protocol.TransferOutgoing())
                {
                    //if (_socket == null || IsClosing || !EnablePacketProcessor || !_socket.Connected)
                    //return;

                    _socket.Send(buffer);
                }
            }
            catch
            {
            }
        }
    }
}