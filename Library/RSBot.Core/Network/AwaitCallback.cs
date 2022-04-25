﻿using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Network
{
    /// <summary>
    /// The result of <see cref="AwaitCallback"/>-processing the received packet 
    /// </summary>
    public enum AwaitCallbackResult
    {
        /// <summary>
        /// If your condition not equals with received packet.
        /// </summary>
        ConditionFailed = 0,

        /// <summary>
        /// If your condition successfully equal with received packet.
        /// </summary>
        Successed,

        /// <summary>
        /// If your received packet responsed with error code, or could not read required data from received.
        /// </summary>
        Failed,
    }
    
    /// <summary>
    /// Predicate delegate for <see cref="AwaitCallback"/> received packet
    /// </summary>
    /// <param name="packet">The received <see cref="Packet"/></param>
    /// <returns><see cref="AwaitCallbackResult"/></returns>
    public delegate AwaitCallbackResult AwaitCallbackPredicate(Packet packet);

    /// <summary>
    /// <see cref="AwaitCallback"/> is a callback with wait for response method.
    /// </summary>
    public class AwaitCallback
    {
        /// <summary>
        /// Default value of timeout[millisecond].
        /// </summary>
        private const int TIMEOUT_DEFAULT = 5_000;
        /// <summary>
        /// Step value of timeout[millisecond].
        /// </summary>
        private const int TIMEOUT_STEP = 10;
        /// <summary>
        /// Lock object.
        /// </summary>
        private readonly object _lock = new object();
        
        /// <summary>
        /// Predicate for received packet
        /// </summary>
        private readonly AwaitCallbackPredicate Predicate;
        /// <summary>
        /// Gets the response opcode.
        /// </summary>
        /// <value>
        /// The response opcode.
        /// </value>
        public ushort ResponseOpcode { get; }

        /// <summary>
        /// The value indicating whether the <see cref="AwaitCallback"/> is invoked.
        /// </summary>
        /// <value>
        /// <c>true</c> if invoked; otherwise <c>false</c>.
        /// </value>
        private bool _invoked;
        /// <summary>
        /// The value indicating whether the <see cref="AwaitCallback"/> is timeout.
        /// </summary>
        /// <value>
        /// <c>true</c> if timeout; otherwise <c>false</c>.
        /// </value>
        private bool _timeout;
        /// <summary>
        /// The value indicating whether the <see cref="AwaitCallback"/> is successed.
        /// </summary>
        /// <value>
        /// <c>true</c> if successed; otherwise <c>false</c>.
        /// </value>
        private bool _successed;
        /// <summary>
        /// The value indicating whether the <see cref="AwaitCallback"/> is waited for response.
        /// </summary>
        /// <value>
        /// <c>true</c> if waited; otherwise <c>false</c>.
        /// </value>
        private bool _waited;

        /// <summary>
        /// Gets the value indicating whether the <see cref="AwaitCallback"/> is completed.
        /// </summary>
        /// <value>
        /// <c>true</c> if completed(not timeout and invoked and successed); otherwise <c>false</c>.
        /// </value>
        public bool IsCompleted
        {
            get
            {
                var temp = false;
                lock (_lock) 
                { 
                    temp = !_timeout && _invoked && _successed; 
                }

                return temp;
            }
        }
        /// <summary>
        /// Gets the value indicating whether the <see cref="AwaitCallback"/> is closed.
        /// </summary>
        /// <value>
        /// <c>true</c> if closed(timeout or invoked); otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed
        {
            get
            {
                var temp = false;
                lock (_lock) { temp = _timeout || _invoked; }

                return temp;
            }
        }

        /// <summary>
        /// Constructor of the <see cref="AwaitCallback"/> class.
        /// </summary>
        /// <param name="predicate">The <see cref="AwaitCallbackPredicate"/>.</param>
        /// <param name="responseOpcode">The response opcode.</param>
        public AwaitCallback(AwaitCallbackPredicate predicate, ushort responseOpcode)
        {
            Predicate = predicate;
            ResponseOpcode = responseOpcode;
            
            _invoked = _timeout =_successed = _waited = false;
        }

        /// <summary>
        /// Invokes this <see cref="AwaitCallback"/> instance.
        /// </summary>
        /// <param name="packet">The received <see cref="Packet"/>.</param>
        internal void Invoke(Packet packet)
        {
            lock (_lock)
            {
                _invoked = true;

                if (Predicate == null)
                    _successed = true;
                else
                {
                    var result = AwaitCallbackResult.Failed;

                    try { 
                        result = Predicate(packet); 
                    } 
                    catch { }

                    switch (result)
                    {
                        case AwaitCallbackResult.Successed:
                            _successed = true;
                            break;
                        case AwaitCallbackResult.ConditionFailed:
                        case AwaitCallbackResult.Failed:
                            _successed = false;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Waits for the first response.<br/>
        /// If you call it one more time, then it does nothing.
        /// </summary>
        /// <param name="milliseconds">The timeout in milliseconds, default value is <see cref="TIMEOUT_DEFAULT"/>.</param>
        /// <returns></returns>
        public void AwaitResponse(int milliseconds = TIMEOUT_DEFAULT)
        {
            if (_waited)
                return;

            _waited = true;

            if (milliseconds < TIMEOUT_STEP)
                milliseconds = TIMEOUT_STEP;

            Task.Factory.StartNew(() =>
            {
                var invoked = false;
                do
                {
                    Thread.Sleep(TIMEOUT_STEP);
                    milliseconds -= TIMEOUT_STEP;

                    lock (_lock) 
                    { 
                        invoked = _invoked;
                    }
                } while (!invoked && milliseconds > 0);

                lock (_lock)
                {
                    _timeout = !_invoked;

                    if (_timeout)
                        Log.Error($"Callback timeout, ResponseOpcode: 0x{ResponseOpcode:X}");
                }

            }).Wait();
        }
    }
}