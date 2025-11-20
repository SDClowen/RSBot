using System;
using System.IO;
using RSBot.Core.Event;

namespace RSBot.Core.Network;

public class Proxy
{
    /// <summary>
    ///     Gets a value indicating whether [client connected].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [client connected]; otherwise, <c>false</c>.
    /// </value>
    public bool ClientConnected { get; private set; }

    /// <summary>
    ///     Gets the port.
    /// </summary>
    /// <value>
    ///     The port.
    /// </value>
    public ushort Port { get; private set; }

    /// <summary>
    ///     Gets the client.
    /// </summary>
    /// <value>
    ///     The client.
    /// </value>
    public Client Client { get; private set; }

    /// <summary>
    ///     Gets the server.
    /// </summary>
    /// <value>
    ///     The server.
    /// </value>
    public Server Server { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether [connected to gatewayserver].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [connected to gatewayserver]; otherwise, <c>false</c>.
    /// </value>
    public bool IsConnectedToGatewayserver { get; private set; }

    /// <summary>
    ///     Gets a value indicating whether [connected to agentserver].
    /// </summary>
    /// <value>
    ///     <c>true</c> if [connected to agentserver]; otherwise, <c>false</c>.
    /// </value>
    public bool IsConnectedToAgentserver { get; private set; }

    /// <summary>
    ///     Gets the session.
    /// </summary>
    /// <value>
    ///     The session.
    /// </value>
    public uint Token { get; internal set; }

    /// <summary>
    ///     Starts the specified client port.
    /// </summary>
    /// <param name="clientPort">The client port.</param>
    /// <param name="gatewayIp">The gateway ip.</param>
    /// <param name="gatewayPort">The gateway port.</param>
    public void Start(ushort clientPort, string gatewayIp, ushort gatewayPort)
    {
        Port = clientPort;
        _gatewayIp = gatewayIp;
        _gatewayPort = gatewayPort;

        if (!Game.Clientless)
            CreateNewClientInstance(clientPort);
        else
            ConnectToGatewayserver();
    }

    /// <summary>
    ///     Shutdowns this instance.
    /// </summary>
    public void Shutdown()
    {
        Client?.Shutdown();
        Client = null;

        Server?.Disconnect();
        Server = null;

        _agentIp = null;
        _agentPort = 0;
        _gatewayIp = null;
        _gatewayPort = 0;
    }

    /// <summary>
    ///     Connects to gatewayserver.
    /// </summary>
    private void ConnectToGatewayserver()
    {
        Log.Notify($"Connecting to gateway server [{_gatewayIp}:{_gatewayPort}]...");

        CreateNewServerInstance();

        IsConnectedToAgentserver = false;
        IsConnectedToGatewayserver = true;

        Server.Connect(_gatewayIp, _gatewayPort);
    }

    /// <summary>
    ///     Connects to agentserver.
    /// </summary>
    private void ConnectToAgentserver()
    {
        Log.Notify($"Connecting to agentserver [{_agentIp}:{_agentPort}]...");
        CreateNewServerInstance();

        IsConnectedToGatewayserver = false;
        IsConnectedToAgentserver = true;

        Server.Connect(_agentIp, _agentPort);
    }

    /// <summary>
    ///     Initializes the new server instance.
    /// </summary>
    private void CreateNewServerInstance()
    {
        if (Server != null && Server.IsConnected)
            Server.Disconnect();

        IsConnectedToGatewayserver = false;
        IsConnectedToAgentserver = false;

        Server = new Server();
        Server.Connected += Server_OnConnected;
        Server.Disconnected += Server_OnDisconnected;
        Server.PacketReceived += Server_OnPacketReceived;
    }

    /// <summary>
    ///     Creates the new client instance.
    /// </summary>
    /// <param name="clientPort">The client port.</param>
    private void CreateNewClientInstance(ushort clientPort)
    {
        Client = new Client();
        Client.Connected += Client_OnConnected;
        Client.PacketReceived += Client_OnPacketReceived;
        Client.Disconnected += Client_OnDisconnected;
        Client.Listen(clientPort);
    }

    /// <summary>
    ///     Handle received packet
    /// </summary>
    /// <param name="packet">The packet</param>
    private void HandleReceivedPacket(Packet packet, PacketDestination destination)
    {
        //if(packet.Opcode != 0x2002)
        //   Log.Notify(packet.ToString());

        try
        {
            packet = PacketManager.CallHook(packet, destination);
        }
        catch (Exception e)
        {
            Log.Fatal(e);
        }
        finally
        {
            if (packet != null)
                try
                {
                    PacketManager.SendPacket(packet, destination);

                    packet.SeekRead(0, SeekOrigin.Begin);

                    PacketManager.CallHandler(packet, destination);
                    PacketManager.CallCallback(packet);
                }
                catch (Exception e)
                {
                    Log.Fatal(e);
                }
        }
    }

    #region Fields

    private string _agentIp;
    private ushort _agentPort;
    private string _gatewayIp;
    private ushort _gatewayPort;

    #endregion Fields

    #region Event Listeners

    #region Client

    /// <summary>
    ///     Fired when the client connected.
    /// </summary>
    private void Client_OnConnected()
    {
        Log.Notify("A new silkroad client connected.");

        EventManager.FireEvent("OnClientConnected");

        ClientConnected = true;

        if (!IsConnectedToGatewayserver && !IsConnectedToAgentserver)
            ConnectToGatewayserver();
    }

    /// <summary>
    ///     Fired when the client disconnected.
    /// </summary>
    private void Client_OnDisconnected()
    {
        ClientConnected = false;
    }

    /// <summary>
    ///     Fired when a client packet was received
    /// </summary>
    /// <param name="packet">The packet.</param>
    private void Client_OnPacketReceived(Packet packet)
    {
        if (IsConnectedToAgentserver && packet.Opcode == 0x6100)
            return;

        HandleReceivedPacket(packet, PacketDestination.Server);
        EventManager.FireEvent("OnClientPacketReceive", packet);
    }

    #endregion Client

    #region Server

    /// <summary>
    ///     Fired when a server packet was received
    /// </summary>
    /// <param name="packet">The packet.</param>
    private void Server_OnPacketReceived(Packet packet)
    {
        HandleReceivedPacket(packet, PacketDestination.Client);

        EventManager.FireEvent("OnServerPacketReceive", packet);
    }

    /// <summary>
    ///     Sets the agentserver address.
    /// </summary>
    /// <param name="ip">The ip.</param>
    /// <param name="port">The port.</param>
    internal void SetAgentserverAddress(string ip, ushort port)
    {
        _agentIp = ip;
        _agentPort = port;

        ConnectToAgentserver();
    }

    /// <summary>
    ///     Fired when the server disconnected
    /// </summary>
    private void Server_OnDisconnected()
    {
        if (IsConnectedToAgentserver)
        {
            Log.Warn("Disconnected from game server!");

            IsConnectedToAgentserver = false;

            Game.Ready = false;
            Game.Started = false;

            EventManager.FireEvent("OnAgentServerDisconnected");
        }
        else if (IsConnectedToGatewayserver)
        {
            Log.Debug("Disconnected from login server!");

            IsConnectedToGatewayserver = false;

            EventManager.FireEvent("OnGatewayServerDisconnected");
        }
    }

    /// <summary>
    ///     Fired when the server conntected
    /// </summary>
    private void Server_OnConnected()
    {
        if (IsConnectedToGatewayserver)
            EventManager.FireEvent("OnGatewayServerConntected");
        else if (IsConnectedToAgentserver)
            EventManager.FireEvent("OnAgentServerConnected");
    }

    #endregion Server

    #endregion Event Listeners
}
