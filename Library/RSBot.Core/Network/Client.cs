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
        public delegate void PacketReceivedEventHandler(Packet packet);

        public event PacketReceivedEventHandler OnPacketReceived;

        public delegate void ConnectedEventHandler();

        public event ConnectedEventHandler Connected;

        public delegate void DisconnectedEventHandler();

        public event DisconnectedEventHandler OnDisconnected;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing { get; set; }

        /// <summary>
        /// The enable packet processor
        /// </summary>
        public bool EnablePacketProcessor;

        /// <summary>
        /// Gets or sets the listener.
        /// </summary>
        /// <value>
        /// The listener.
        /// </value>
        public Socket Listener { get; set; }

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public Socket Socket { get; set; }

        #region Fields

        private SecurityManager _securityManager;
        private TransferBuffer _transferBuffer;
        private List<Packet> _receivedPackets;
        private List<KeyValuePair<TransferBuffer, Packet>> _sendBuffers;
        private Thread _packetProcessor;

        #endregion Fields

        /// <summary>
        /// Listens the specified port.
        /// </summary>
        /// <param name="port">The port.</param>
        public void Listen(ushort port)
        {
            _securityManager = new SecurityManager();
            _securityManager.GenerateSecurity(true, true, true);

            _transferBuffer = new TransferBuffer(8192, 0, 0);
            Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Thread Management
            _packetProcessor = new Thread(ThreadedPacketProcessing)
            {
                Name = "Proxy.Network.Client.PacketProcessor",
                IsBackground = true
            };

            _packetProcessor.Start();

            if (Listener.IsBound == false)
            {
                Listener.Bind(new IPEndPoint(IPAddress.Loopback, port));
                Listener.Listen(1);
            }
            Listener.BeginAccept(AcceptClient, null);
        }

        /// <summary>
        /// Listens this instance.
        /// </summary>
        private void Listen()
        {
            EnablePacketProcessor = false;

            if (Socket != null)
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
            }

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Listener.BeginAccept(AcceptClient, null);
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        public void Shutdown()
        {
            EnablePacketProcessor = false;
            IsClosing = true;

            //Close Socket
            if (Socket != null)
            {
                if (Socket.Connected)
                    Socket.Shutdown(SocketShutdown.Both);

                Socket.Close();
                Socket = null;
            }

            //Close listener
            if (Listener != null)
            {
                Listener.Close();
                Listener = null;
            }

            _securityManager = null;

            _transferBuffer = null;
            _receivedPackets = null;
            _sendBuffers = null;
            _packetProcessor = null;
        }

        /// <summary>
        /// Called when [client connect].
        /// </summary>
        /// <param name="ar">The ar.</param>
        private void AcceptClient(IAsyncResult ar)
        {
            if (IsClosing) return;

            EnablePacketProcessor = true;
            Socket = Listener.EndAccept(ar);
            Socket.BeginReceive(_transferBuffer.Buffer, 0, 8192, SocketFlags.None, WaitForData, Socket);

            _securityManager = new SecurityManager();
            _securityManager.GenerateSecurity(false, false, false);

            //RaiseEvent if event is linked
            Connected?.Invoke();
        }

        /// <summary>
        /// Waits for data.
        /// </summary>
        /// <param name="ar">The ar.</param>
        private void WaitForData(IAsyncResult ar)
        {
            if (IsClosing || !EnablePacketProcessor) return;
            Socket worker = null;
            try
            {
                worker = (Socket)ar.AsyncState;
                var dataLength = worker.EndReceive(ar);
                if (dataLength > 0)
                {
                    _transferBuffer.Size = dataLength;
                    _securityManager.Recv(_transferBuffer);
                }
                else
                {
                    OnDisconnected?.Invoke();
                    Listen();
                }
            }
            catch (SocketException se)
            {
                if (se.SocketErrorCode == SocketError.ConnectionReset) //Client OnDisconnected > Mostly occurs during GW->AS switch
                {
                    OnDisconnected?.Invoke();

                    Listen();

                    //Mark worker as null to stop reciveing.
                    worker = null;
                }
            }
            catch (HandshakeSecurityException)
            {
                Log.Notify("[Fatal]: Could not handshake the client, restarting client process now...");
                Game.Start();
            }

            if (worker != null && Socket != null && Socket.Connected)
                worker.BeginReceive(_transferBuffer.Buffer, _transferBuffer.Offset, _transferBuffer.Size,
                    SocketFlags.None,
                    WaitForData, worker);
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
        /// Threadeds the packet processing.
        /// </summary>
        private void ThreadedPacketProcessing()
        {
            //Wait until we should process packets
            while (!EnablePacketProcessor && !IsClosing)
                Thread.Sleep(1);

            while (EnablePacketProcessor && !IsClosing)
            {
                ProcessClientPackets();
                Thread.Sleep(1);
            }

            if (IsClosing)
                return; //Jump out.

            ThreadedPacketProcessing();
        }

        /// <summary>
        /// Processes the client packets.
        /// </summary>
        private void ProcessClientPackets()
        {
            if (IsClosing || !EnablePacketProcessor) return;

            _receivedPackets = _securityManager.TransferIncoming();

            if (_receivedPackets != null)
                foreach (var packet in _receivedPackets.Where(packet => packet.Opcode != 0x5000 && packet.Opcode != 0x9000 && packet.Opcode != 0x2001))
                    Task.Run(() => OnPacketReceived?.Invoke(packet));

            _sendBuffers = _securityManager.TransferOutgoing();
            if (_sendBuffers == null) return;
            foreach (var buffer in _sendBuffers)
                Send(buffer.Key.Buffer);
        }
    }
}