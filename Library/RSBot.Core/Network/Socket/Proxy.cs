using System;
using System.IO;
using RSBot.Core.Event;

namespace RSBot.Core.Network;

public class Proxy
{
    private enum ConnectionTarget
    {
        None = 0,
        Gateway = 1,
        Agent = 2,
    }

    private ConnectionTarget _connectionTarget;

    // Avoid log spam when the remote end drops quickly or connection attempts fail repeatedly.
    private DateTime _lastGatewayDisconnectLogUtc;
    private DateTime _lastAgentDisconnectLogUtc;

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
    ///     Gets a value indicating whether we are in the Gateway -> Agent switch phase.
    ///     In this phase, the Gateway connection is expected to drop and should not trigger relogin/shutdown logic.
    /// </summary>
    public bool IsSwitchingToAgentserver { get; private set; }

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

        _connectionTarget = ConnectionTarget.Gateway;

        Server.Connect(_gatewayIp, _gatewayPort);
    }

    /// <summary>
    ///     Connects to agentserver.
    /// </summary>
    private void ConnectToAgentserver()
    {
        Log.Notify($"Connecting to agentserver [{_agentIp}:{_agentPort}]...");
        CreateNewServerInstance();

        _connectionTarget = ConnectionTarget.Agent;

        Server.Connect(_agentIp, _agentPort);
    }

    /// <summary>
    ///     Initializes the new server instance.
    /// </summary>
    private void CreateNewServerInstance()
    {
        // We switch between gateway and agent by replacing the Server instance.
        // Important: detach handlers before disconnecting the old server; otherwise its delayed
        // disconnect can be misclassified as the new connection target and trigger relogin.
        var oldServer = Server;
        if (oldServer != null)
        {
            oldServer.Connected -= Server_OnConnected;
            oldServer.Disconnected -= Server_OnDisconnected;
            oldServer.PacketReceived -= Server_OnPacketReceived;

            if (oldServer.IsConnected)
                oldServer.Disconnect();
        }

        IsConnectedToGatewayserver = false;
        IsConnectedToAgentserver = false;
        _connectionTarget = ConnectionTarget.None;

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

        IsSwitchingToAgentserver = true;
        ConnectToAgentserver();
    }

    /// <summary>
    ///     Fired when the server disconnected
    /// </summary>
    private void Server_OnDisconnected()
    {
        if (IsConnectedToAgentserver || _connectionTarget == ConnectionTarget.Agent)
        {
            // Only log if we had an established connection or enough time passed (rate limit).
            if (IsConnectedToAgentserver || (DateTime.UtcNow - _lastAgentDisconnectLogUtc).TotalSeconds >= 3)
            {
                _lastAgentDisconnectLogUtc = DateTime.UtcNow;
                Log.Warn("Disconnected from game server!");
            }

            IsConnectedToAgentserver = false;
            IsSwitchingToAgentserver = false;

            Game.Ready = false;
            Game.Started = false;

            EventManager.FireEvent("OnAgentServerDisconnected");
        }
        else if (IsConnectedToGatewayserver || _connectionTarget == ConnectionTarget.Gateway)
        {
            // Capture state before we flip it; allows us to avoid logging disconnects that happen
            // before an actual connection was established.
            var wasConnectedToGateway = IsConnectedToGatewayserver;
            IsConnectedToGatewayserver = false;

            // Gateway disconnect is expected during the Gateway -> Agent switch.
            if (IsSwitchingToAgentserver)
                return;

            if (wasConnectedToGateway || (DateTime.UtcNow - _lastGatewayDisconnectLogUtc).TotalSeconds >= 3)
            {
                _lastGatewayDisconnectLogUtc = DateTime.UtcNow;
                Log.Debug("Disconnected from login server!");
            }

            EventManager.FireEvent("OnGatewayServerDisconnected");
        }
    }

    /// <summary>
    ///     Fired when the server conntected
    /// </summary>
    private void Server_OnConnected()
    {
        if (_connectionTarget == ConnectionTarget.Gateway)
        {
            IsConnectedToGatewayserver = true;
            IsConnectedToAgentserver = false;
            EventManager.FireEvent("OnGatewayServerConntected");
        }
        else if (_connectionTarget == ConnectionTarget.Agent)
        {
            IsConnectedToGatewayserver = false;
            IsConnectedToAgentserver = true;
            IsSwitchingToAgentserver = false;
            EventManager.FireEvent("OnAgentServerConnected");
        }
    }

    #endregion Server

    #endregion Event Listeners
}
