using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace RSBot.Core.Network;

internal class NetworkUtilities
{
    /// <summary>
    ///     Get Free Port
    ///     Returns the first free port between a range
    /// </summary>
    /// <param name="start">Start index</param>
    /// <param name="end">End index</param>
    /// <param name="step">Step Distance</param>
    /// <returns>Free port</returns>
    public static ushort GetFreePort(ushort start, ushort end, ushort step = 1)
    {
        for (ushort port = start; port <= end; port += step)
        {
            try
            {
                using var listener = new TcpListener(IPAddress.Loopback, port);
                listener.Start();
                listener.Stop();
                return port;   // Successfully bound → free
            }
            catch (SocketException)
            {
                // Port already in use
            }
        }

        throw new Exception($"No free port in range {start}-{end}");
    }
}
