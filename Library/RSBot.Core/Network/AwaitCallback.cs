using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Network
{
    public class AwaitCallback
    {
        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>
        /// The <seealso cref="Predicate{Packet}"/>.
        /// </value>
        private Predicate<Packet> _predicate { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="AwaitCallback"/> is received.
        /// </summary>
        /// <value>
        ///   <c>true</c> if received; otherwise, <c>false</c>.
        /// </value>
        public volatile bool Received;

        /// <summary>
        /// Gets or sets the response opcode.
        /// </summary>
        /// <value>
        /// The response opcode.
        /// </value>
        public ushort ResponseOpcode { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AwaitCallback"/> is timeout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if timeout; otherwise, <c>false</c>.
        /// </value>
        public bool Timeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AwaitCallback" /> class.
        /// </summary>
        /// <param name="predicate">The <seealso cref="Predicate{Packet}"/>.</param>
        /// <param name="responseOpcode">The response opcode.</param>
        public AwaitCallback(Predicate<Packet> predicate, ushort responseOpcode)
        {
            _predicate = predicate;
            ResponseOpcode = responseOpcode;
        }

        /// <summary>
        /// Invokes the specified packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        internal void Invoke(Packet packet)
        {
            if (_predicate == null)
                Received = true;
            else
                Received = _predicate(packet);
        }

        /// <summary>
        /// Waits for response.
        /// </summary>
        /// <param name="timeOut">The timeout.</param>
        /// <returns></returns>
        public void AwaitResponse(int timeOut = 5000)
        {
            Task.Run(async () =>
            {
                while (!Received)
                {
                    await Task.Delay(10);
                    timeOut -= 10;

                    if (timeOut > 10)
                        continue;

                    Timeout = true;
                    Log.Debug("Callback timeout 0x" + ResponseOpcode.ToString("X"));

                    return;
                }
            })
            .Wait(timeOut);
        }
    }
}