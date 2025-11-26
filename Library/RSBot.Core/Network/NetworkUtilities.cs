using System.Linq;
using System.Net.NetworkInformation;

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
    public static ushort GetFreePort(ushort start, ushort end, ushort step)
    {
        var properties = IPGlobalProperties.GetIPGlobalProperties();
        var tcpEndPoints = properties.GetActiveTcpListeners();

        var usedPorts = tcpEndPoints.Select(p => p.Port).ToList();
        ushort result = 0;

        for (var port = start; port < end; port += step)
        {
            if (usedPorts.Contains(port))
                continue;
            result = port;
            break;
        }

        return result;
    }
}
