using RSBot.Core.Event;
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

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public Socket Socket { get; set; }

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
        public bool EnablePacketProcessor { get; set; }

        #region Fields

        private SecurityManager _securityManager;
        private TransferBuffer _receiveTransferBuffer;
        private List<Packet> _receivedPackets;
        private List<KeyValuePair<TransferBuffer, Packet>> _sendTransferBuffers;
        private Thread _packetProcessor;

        #endregion Fields

        /// <summary>
        /// Connects the specified ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public void Connect(string ip, ushort port)
        {
            IP = ip;
            Port = port;

            if (Socket != null)
                Disconnect();

            _receiveTransferBuffer = new TransferBuffer(8192, 0, 0);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (_packetProcessor == null)
            {
                _packetProcessor = new Thread(ProcessPacketsThreaded)
                {
                    Name = "Proxy.Network.Server.PacketProcessor",
                    IsBackground = true
                };
                _packetProcessor.Start();
            }

            _securityManager = new SecurityManager();

            try
            {
                Socket?.Connect(ip, port);
            }
            catch (SocketException)
            {
                Log.Error($"Could not establish a connection to {ip}:{port}.");
            }

            if (Socket == null)
            {
                Log.Error("Network error: Server socket cannot be null");
                return;
            }

            if (!Socket.Connected)
                return;

            EnablePacketProcessor = true;

            Socket.BeginReceive(_receiveTransferBuffer.Buffer, 0, 8192, SocketFlags.None,
                WaitForData, Socket);

            OnConnected?.Invoke();

            EventManager.FireEvent("OnServerConnected");
            Log.Debug("Server connection established!");
        }

        /// <summary>
        /// Processes the packets threaded.
        /// </summary>
        private void ProcessPacketsThreaded()
        {
            while (!EnablePacketProcessor && !IsClosing)
                Thread.Sleep(1);

            while (EnablePacketProcessor && !IsClosing)
            {
                ProcessPackets();
                Thread.Sleep(1);
            }

            if (IsClosing) return;

            ProcessPacketsThreaded();
        }

        /// <summary>
        /// Processes the packets.
        /// </summary>
        private void ProcessPackets()
        {
            if (IsClosing || !EnablePacketProcessor) return;

            _receivedPackets = _securityManager.TransferIncoming();

            if (_receivedPackets != null)
            {
                foreach (var packet in _receivedPackets.Where(packet => packet.Opcode != 0x5000 && packet.Opcode != 0x9000)) //Ignore handshakes
                    OnPacketReceived?.Invoke(packet);
            }

            _sendTransferBuffers = _securityManager.TransferOutgoing();

            if (_sendTransferBuffers == null) return;

            foreach (var buffer in _sendTransferBuffers)
                Send(buffer.Key.Buffer);
        }

        /// <summary>
        /// Waits for data.
        /// </summary>
        /// <param name="result">The result.</param>
        private void WaitForData(IAsyncResult result)
        {
            if (IsClosing || !EnablePacketProcessor) return;

            var worker = result.AsyncState as Socket;

            if (worker == null) return;

            int dataLength;

            try
            {
                dataLength = worker.EndReceive(result);
            }
            catch (SocketException)
            {
                OnDisconnected?.Invoke();
                return;
            }

            if (dataLength > 0)
            {
                _receiveTransferBuffer.Size = dataLength;
                _securityManager.Recv(_receiveTransferBuffer);
            }
            else
            {
                Disconnect();
                return;
            }

            if (worker.Connected)
                worker.BeginReceive(_receiveTransferBuffer.Buffer, 0, 8192, SocketFlags.None, WaitForData, worker);
            else
                Log.Notify("Connection to the server has been lost! - Please restart the game client!");
        }

        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Send(byte[] data)
        {
            if (Socket == null || IsClosing || !EnablePacketProcessor || !Socket.Connected) return;

            Socket.Send(data);
        }

        /// <summary>
        /// Sends the specified packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Send(Packet packet)
        {
            if (!packet.Locked)
                packet.Lock();

            _securityManager.Send(packet);
        }

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        public void Disconnect()
        {
            EnablePacketProcessor = false;
            IsClosing = true;

            if (Socket != null)
            {
                if (Socket.Connected)
                {
                    Socket.Shutdown(SocketShutdown.Both);
                    OnDisconnected?.Invoke();
                }

                Socket.Close();
                Socket = null;
            }

            IsClosing = false;
        }
    }
}