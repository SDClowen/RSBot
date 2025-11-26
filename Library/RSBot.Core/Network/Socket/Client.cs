using System;
using System.Net;
using System.Net.Sockets;
using RSBot.Core.Network.Protocol;

namespace RSBot.Core.Network;

public class Client() : NetBase(isClient: true)
{
    /// <summary>
    ///     Gets or sets the listener.
    /// </summary>
    /// <value>
    ///     The listener.
    /// </value>
    public Socket _listener;

    /// <summary>
    ///     Listens the specified port.
    /// </summary>
    /// <param name="port">The port.</param>
    public void Listen(ushort port)
    {
        try
        {
            _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            StartNetWorker();

            _listener.Bind(new IPEndPoint(IPAddress.Loopback, port));
            _listener.Listen(1);
            _listener.BeginAccept(OnClientConnect, null);
        }
        catch { }
    }

    /// <summary>
    ///     Listens this instance.
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
        catch { }
    }

    /// <summary>
    ///     Shutdowns this instance.
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
        catch { }
    }

    /// <summary>
    ///     Called when [client connect].
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

            OnConnected();
        }
        catch (Exception)
        {
            OnDisconnected();
            Listen();
        }
    }

    /// <summary>
    ///     Waits for data.
    /// </summary>
    /// <param name="ar">The ar.</param>
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
                Listen();
                return;
            }

            _protocol.Recv(_buffer, 0, receivedSize);
        }
        catch (SocketException se)
        {
            if (se.SocketErrorCode == SocketError.ConnectionReset) //Client OnDisconnected > Mostly occurs during GW->AS switch
            {
                OnDisconnected();

                Listen();
            }
        }
        catch (HandshakeSecurityException ex)
        {
            Log.Error("[Fatal]: Could not handshake the client, restarting client process now...");

            Kernel.Proxy?.Shutdown();
        }
        finally
        {
            try
            {
                if (receivedSize != 0 && _socket != null && _socket.Connected)
                    _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, OnBeginReceiveCallback, null);
            }
            catch { }
        }
    }
}
