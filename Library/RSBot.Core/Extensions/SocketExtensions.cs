﻿using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.Core.Extensions
{
    public class SocketProxyException : Exception
    {
        public SocketProxyException(string message) : base(message)
        {
        }
    }

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

        public static async Task<bool> ConnectViaProxy(this Socket socket, ProxyConfig config)
        {
            Log.Notify($"Trying to connect to proxy server [{config.ProxyIp}:{config.ProxyPort} / Version: {config.Version}]...");
            await socket.ConnectAsync(config.ProxyIp, config.ProxyPort);
            if (!socket.Connected)
                return false;

            Log.Notify($"Successfully connected to proxy server...");

            var portBuffer = new byte[2]
            {
                Convert.ToByte(config.ProxyPort / 256),
                Convert.ToByte(config.ProxyPort % 256)
            }; 
            
            var proxyIpBuffer = Encoding.ASCII.GetBytes(config.ProxyIp);
            var userNameBuffer = Encoding.ASCII.GetBytes(config.UserName);
            var passwordBuffer = Encoding.ASCII.GetBytes(config.Password);

            var targetAddress = Dns.GetHostAddresses(config.Ip)[0];

            if (config.Version == 5)
            {
                await socket.SendAsync(new byte[4] { 5, 2, 0, 2 }, SocketFlags.None);

                var response = new byte[2];
                var receiveSize = await socket.ReceiveAsync(response, SocketFlags.None);
                if (receiveSize != 2)
                    throw new SocketProxyException($"Failed to select an authentication method, the server sent {receiveSize} bytes.");

                if (response[1] == 0xff)
                {
                    socket.Close();
                    throw new SocketProxyException("The proxy destination does not accept the supported proxy client authentication methods.");
                }

                if (response[1] == 0x02 && string.IsNullOrWhiteSpace(config.UserName))
                {
                    socket.Close();
                    throw new SocketProxyException("The proxy destination requires a username and password for authentication.");
                }

                var authBuffer = new byte[userNameBuffer.Length + passwordBuffer.Length + 3];
                authBuffer[0] = 1;
                authBuffer[1] = (byte)userNameBuffer.Length;
                userNameBuffer.CopyTo(authBuffer, 2);
                authBuffer[2 + userNameBuffer.Length] = (byte)passwordBuffer.Length;
                passwordBuffer.CopyTo(authBuffer, 3 + userNameBuffer.Length);
                await socket.SendAsync(authBuffer, SocketFlags.None);

                response = new byte[2];

                receiveSize = await socket.ReceiveAsync(response, SocketFlags.None);
                if (receiveSize != 2)
                    throw new SocketProxyException($"Failed to perform authentication, the server sent {receiveSize} bytes.");

                if (response[1] != 0)
                {
                    socket.Close();
                    throw new SocketProxyException("Proxy authentication failed.");
                }

                byte addressType = GetAddressType(config.ProxyIp);
                byte[] hostBuffer = GetHostAddressBytes(addressType, config.ProxyIp);

                // +----+-----+-------+------+----------+----------+
                // |VER | CMD |  RSV  | ATYP | DST.ADDR | DST.PORT |
                // +----+-----+-------+------+----------+----------+
                // | 1  |  1  | X'00' |  1   | Variable |    2     |
                // +----+-----+-------+------+----------+----------+
                
                var buffer = new byte[6 + hostBuffer.Length];
                buffer[0] = 5;
                buffer[1] = 1;
                buffer[2] = 0;
                buffer[3] = addressType;
                hostBuffer.CopyTo(buffer, 4);
                portBuffer.CopyTo(buffer, 4 + hostBuffer.Length);
                await socket.SendAsync(buffer, SocketFlags.None);

                response = new byte[0xFF];
                await socket.ReceiveAsync(response, SocketFlags.None);

                if (response[1] != 0)
                {
                    HandleProxyCommandError(response, config.ProxyIp, config.ProxyPort);
                    return false;
                }

                return true;
            }

            // +----+----+----+----+----+----+----+----+----+----+....+----+
            // | VN | CD | DSTPORT |      DSTIP        | USERID       |NULL|
            // +----+----+----+----+----+----+----+----+----+----+....+----+
            //    1    1      2              4           variable       1
            var request = new byte[9 + config.UserName.Length];
            request[0] = 4;
            request[1] = 1;
            portBuffer.CopyTo(request, 2);
            targetAddress.GetAddressBytes().CopyTo(request, 4);
            userNameBuffer.CopyTo(request, 8);
            request[8 + config.UserName.Length] = 0x00;

            await socket.SendAsync(request, SocketFlags.None);

            var receiveBuffer = new byte[8];
            var result = socket.BeginReceive(receiveBuffer, 0, 8, SocketFlags.None, null, null);
            if (result.AsyncWaitHandle.WaitOne(config.TimeOut, true))
            {
                var received = socket.EndReceive(result);
                if (received == 8 && receiveBuffer[0] == 0x5A)
                    return true;
            }

            return false;
        }

        private static void HandleProxyCommandError(byte[] response, string destinationHost, int destinationPort)
        {
            var replyCode = response[1];
            var proxyErrorText = replyCode switch
            {
                1 => "a general socks destination failure occurred",
                2 => "the connection is not allowed by proxy destination rule set",
                3 => "the network was unreachable",
                4 => "the host was unreachable",
                5 => "the connection was refused by the remote network",
                6 => "the time to live (TTL) has expired",
                7 => "the command issued by the proxy client is not supported by the proxy destination",
                8 => "the address type specified is not supported",
                _ => string.Format(CultureInfo.InvariantCulture,
                        "an unknown SOCKS reply with the code value '{0}' was received",
                        replyCode.ToString(CultureInfo.InvariantCulture)),
            };
            string exceptionMsg = string.Format(CultureInfo.InvariantCulture,
                "proxy error: {0} for destination host {1} port number {2}.",
                proxyErrorText, destinationHost, destinationPort);

            throw new SocketProxyException(exceptionMsg);
        }

        private static byte GetAddressType(string host)
        {
            if (!IPAddress.TryParse(host, out var ipAddr))
                return 3;

            return ipAddr.AddressFamily switch
            {
                AddressFamily.InterNetwork => 1,
                AddressFamily.InterNetworkV6 => 4,
                _ => throw new SocketProxyException(
                                        string.Format("The host addess {0} of type '{1}' is not a supported address type.\n" +
                                        "The supported types are InterNetwork and InterNetworkV6.", host,
                                        Enum.GetName(typeof(AddressFamily), ipAddr.AddressFamily))),
            };
        }

        private static byte[] GetHostAddressBytes(byte addressType, string host)
        {
            switch (addressType)
            {
                case 1:
                case 4:
                    return IPAddress.Parse(host).GetAddressBytes();
                case 3:
                    var bytes = new byte[host.Length + 1];
                    bytes[0] = Convert.ToByte(host.Length);
                    Encoding.ASCII.GetBytes(host).CopyTo(bytes, 1);
                    return bytes;
                default:
                    return null;
            }
        }
        
        /// <summary>
         /// Converts a string representing a host name or address to its <see cref="IPAddress"/> representation, 
         /// optionally opting to return a IpV6 address (defaults to IpV4)
         /// </summary>
         /// <param name="hostNameOrAddress">Host name or address to convert into an <see cref="IPAddress"/></param>
         /// <param name="favorIpV6">When <code>true</code> will return an IpV6 address whenever available, otherwise 
         /// returns an IpV4 address instead.</param>
         /// <returns>The <see cref="IPAddress"/> represented by <paramref name="hostNameOrAddress"/> in either IpV4 or
         /// IpV6 (when available) format depending on <paramref name="favorIpV6"/></returns>
        public static IPAddress ToIPAddress(this string hostNameOrAddress, bool favorIpV6 = false)
        {
            var favoredFamily = favorIpV6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork;
            var addrs = Dns.GetHostAddresses(hostNameOrAddress);
            return addrs.FirstOrDefault(addr => addr.AddressFamily == favoredFamily)
                   ??
                   addrs.FirstOrDefault();
        }
    }
}
