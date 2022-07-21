using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Network.SecurityAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace RSBot.Core.Network
{
    public class Server
    {
        public delegate void OnConnectedEventHandler();
        public event OnConnectedEventHandler OnConnected;

        public delegate void OnDisconnectedEventHandler();
        public event OnDisconnectedEventHandler OnDisconnected;

        public delegate void OnPacketReceivedEventHandler(Packet packet);
        public event OnPacketReceivedEventHandler OnPacketReceived;

        public delegate void PacketSentEventHandler(Packet packet);
        public event PacketSentEventHandler OnPacketSent;

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        private Socket _socket;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this socket is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected => _socket != null && _socket.Connected;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing { get; set; }

        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>
        /// The ip.
        /// </value>
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public ushort Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable packet processor].
        /// </summary>
        /// <value>
        /// <c>true</c> if [enable packet processor]; otherwise, <c>false</c>.
        /// </value>
        public bool EnablePacketDispatcher { get; set; }

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
        private Thread _netMessageDispatcherThread;

        /// <summary>
        /// Get the allocated buffer.
        /// </summary>
        /// <value>
        /// The allocated buffer.
        /// </value>
        private byte[] _buffer { get; } = new byte[4096];

        /// <summary>
        /// Connects the specified ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public void Connect(string ip, ushort port)
        {
            IP = ip;
            Port = port;

            if (_socket != null)
                Disconnect();

            try
            {
                _protocol = new SecurityProtocol();
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    _socket.Connect(ip, port, 3000);
                }
                catch (SocketException)
                {
                    Log.Error($"Could not establish a connection to {ip}:{port}.");
                    Disconnect();
                    return;
                }

                if (_netMessageDispatcherThread == null)
                {
                    _netMessageDispatcherThread = new Thread(ProcessPacketsThreaded)
                    {
                        Name = "Proxy.Network.Server.PacketProcessor",
                        IsBackground = true
                    };
                    _netMessageDispatcherThread.Start();
                }

                EnablePacketDispatcher = true;

                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);

                OnConnected?.Invoke();

                EventManager.FireEvent("OnServerConnected");
                Log.Debug("Server connection established!");
            }
            catch
            {
            }
        }

        /// <summary>
        /// Processes the packets threaded.
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
            catch
            {
            }
        }

        /// <summary>
        /// Processes the packets.
        /// </summary>
        private void ProcessQueuedPackets()
        {
            try
            {
                if (IsClosing || !EnablePacketDispatcher)
                    return;

                var receiveds = _protocol.TransferIncoming();
                if (receiveds != null)
                {
                    foreach (var packet in receiveds)
                    {
                        if (packet.Opcode == 0x5000 || packet.Opcode == 0x9000)
                            continue;

                        OnPacketReceived?.Invoke(packet);
                    }
                }

                foreach (var buffer in _protocol.TransferOutgoing())
                {
                    if (_socket == null || IsClosing || !EnablePacketDispatcher || !_socket.Connected)
                        return;

                    _socket.Send(buffer);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Waits for data.
        /// </summary>
        /// <param name="result">The result.</param>
        private void OnBeginReceiveCallback(IAsyncResult ar)
        {
            if (IsClosing || !EnablePacketDispatcher)
                return;

            int receivedSize = 0;

            try
            {
                receivedSize = _socket.EndReceive(ar, out var error);
                if (receivedSize == 0 || error != SocketError.Success)
                {
                    OnDisconnected?.Invoke();
                    return;
                }

                _protocol.Recv(_buffer, 0, receivedSize);
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionReset) //Client OnDisconnected > Mostly occurs during GW->AS switch
                {
                    OnDisconnected?.Invoke();
                }
            }
            catch (HandshakeSecurityException)
            {
                Log.Notify("[Fatal]: Could not handshake the client, restarting client process now...");
                Game.Start();
            }
            finally
            {
                try
                {
                    if (receivedSize != 0 && _socket != null && _socket.Connected)
                        _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);
                }
                catch
                {
                    OnDisconnected?.Invoke();
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
            _protocol.Send(packet);
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        public void Disconnect()
        {
            EnablePacketDispatcher = false;
            IsClosing = true;

            try
            {
                if (_socket == null)
                    return;

                if (_socket.Connected)
                {
                    _socket.Shutdown(SocketShutdown.Both);
                    _socket.Close();
                }
            }
            catch
            {
            }
            finally
            {
                _socket = null;
                OnDisconnected?.Invoke();
            }

            IsClosing = false;
        }
    }
}