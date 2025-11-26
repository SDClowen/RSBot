using System;
using System.Net;
using System.Net.Sockets;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Network.Protocol;

namespace RSBot.Core.Network;

public class Server : NetBase
{
    /// <summary>
    ///     Gets or sets the ip.
    /// </summary>
    /// <value>
    ///     The ip.
    /// </value>
    public string IP { get; set; }

    /// <summary>
    ///     Gets or sets the port.
    /// </summary>
    /// <value>
    ///     The port.
    /// </value>
    public ushort Port { get; set; }

    /// <summary>
    ///     Connects the specified ip.
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
                var bindIp = GlobalConfig.Get("RSBot.Network.BindIp", "0.0.0.0");
                if (!string.IsNullOrWhiteSpace(bindIp) && bindIp != "0.0.0.0")
                    _socket.Bind(new IPEndPoint(IPAddress.Parse(bindIp), port));

                if (ProxyConfig.TryGetProxy(ip, port, out var proxyConfig))
                {
                    if (!_socket.ConnectViaProxy(proxyConfig).Result)
                    {
                        Log.Warn("Proxy receiving has timeout!");
                        Disconnect();
                        return;
                    }
                }
                else
                {
                    _socket.Connect(ip, port, 3000);
                }
            }
            catch (AggregateException s)
            {
                Log.Error(s.Message);
                Disconnect();
                return;
            }
            catch (SocketProxyException s)
            {
                Log.Error(s.Message);
                Disconnect();
                return;
            }
            catch (SocketException s)
            {
                Log.Error($"Could not establish a connection to {ip}:{port}.");
                Log.Error(s.Message);
                Disconnect();
                return;
            }

            StartNetWorker();

            EnablePacketDispatcher = true;

            _socket?.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);

            OnConnected();

            EventManager.FireEvent("OnServerConnected");
            Log.Debug("Server connection established!");
        }
        catch { }
    }

    /// <summary>
    ///     Waits for data.
    /// </summary>
    /// <param name="result">The result.</param>
    private void OnBeginReceiveCallback(IAsyncResult ar)
    {
        if (IsClosing || !EnablePacketDispatcher)
            return;

        var receivedSize = 0;

        try
        {
            receivedSize = _socket.EndReceive(ar, out var error);
            if (receivedSize == 0 || error != SocketError.Success)
            {
                OnDisconnected();
                return;
            }

            _protocol.Recv(_buffer, 0, receivedSize);
        }
        catch (SocketException se)
        {
            if (se.SocketErrorCode == SocketError.ConnectionReset) //Client OnDisconnected > Mostly occurs during GW->AS switch
                OnDisconnected();
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
                OnDisconnected();
            }
        }
    }

    /// <summary>
    ///     Sends the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Send(Packet packet)
    {
        OnPacketSent(packet);
        _protocol.Send(packet);
    }

    /// <summary>
    ///     Disconnects this instance.
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
        catch { }
        finally
        {
            _socket = null;
            OnDisconnected();
        }

        IsClosing = false;
    }
}
