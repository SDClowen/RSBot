using System.Net.Sockets;

namespace RSBot.Core.Extensions
{
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
    }
}
