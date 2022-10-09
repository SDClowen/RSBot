using RSBot.Core.Network;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace RSBot.Core.Extensions
{
    public struct ProxyConfig
    {
        public string Ip;
        public int Port;
        public string ProxyIp;
        public int ProxyPort;
        public string UserName;
        public string Password;
        public byte Version;
        public int TimeOut;

        public static bool TryGetProxy(string ip, int port, out ProxyConfig config)
        {
            config = new ProxyConfig
            {
                Ip = ip,
                Port = port,
                TimeOut = 5000
            };

            var values = GlobalConfig.GetArray<string>("RSBot.Network.Proxy", '|', StringSplitOptions.TrimEntries);
            if (values.Length != 6)
                return false;

            if (!bool.TryParse(values[0], out var active) || !active)
                return false;

            config.ProxyIp = values[1];
            config.UserName = values[3];
            config.Password = values[4];

            if (!int.TryParse(values[2], out config.ProxyPort))
                return false;

            if (!byte.TryParse(values[5], out config.Version))
                return false;

            return true;
        }
    }

    public static class SocketExtensions
    {

        /// <summary>
        /// Connects the specified socket.
        /// </summary>
        /// <param name="socket">The socket.</param>
        /// <param name="endpoint">The IP endpoint.</param>
        /// <param name="timeout">The timeout.</param>
        public static void Connect(this Socket socket, string host, int port, int timeout)
        {
            var result = socket.BeginConnect(host, port, null, null);
            if (result.AsyncWaitHandle.WaitOne(timeout, true))
                socket.EndConnect(result);
            else
                throw new SocketException(10060); // Connection timed out.
        }

        public static async Task<bool> ConnectProxy(this Socket socket, ProxyConfig config)
        {
            Log.Notify($"Trying to connect to proxy server [{config.ProxyIp}:{config.ProxyPort}]...");
            socket.Connect(config.ProxyIp, config.ProxyPort);
            if (!socket.Connected)
                return false;

            Log.Notify($"Successfully connected to proxy server...");

            var targetAddress = Dns.GetHostAddresses(config.Ip)[0];

            var requestPacket = new Packet(0x0);
            requestPacket.WriteByte(config.Version);
            requestPacket.WriteByte(1);
            requestPacket.WriteUShort(config.Port);
            requestPacket.WriteByteArray(targetAddress.GetAddressBytes());
            requestPacket.WriteStringUTF8(config.UserName);
            requestPacket.WriteByte(0);

            await socket.SendAsync(requestPacket.GetBytes(), SocketFlags.None);

            var buffer = new byte[8];
            var result = socket.BeginReceive(buffer, 0, 8, SocketFlags.None, null, null);
            if (result.AsyncWaitHandle.WaitOne(config.TimeOut, true))
            {
                var received = socket.EndReceive(result);
                if (received == 8 && buffer[0] == 0x5A)
                    return true;
            }

            return false;
        }
    }
}
