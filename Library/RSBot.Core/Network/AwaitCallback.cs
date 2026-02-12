using System;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Network;

/// <summary>
///     The result of <see cref="AwaitCallback" />-processing the received packet
/// </summary>
public enum AwaitCallbackResult
{
    /// <summary>
    ///     If your condition not equals with received packet.
    /// </summary>
    ConditionFailed = 0,

    /// <summary>
    ///     If your condition successfully equal with received packet.
    /// </summary>
    Success,

    /// <summary>
    ///     If your received packet responsed with error code, or could not read required data from received.
    /// </summary>
    Fail,
}

/// <summary>
///     Predicate delegate for <see cref="AwaitCallback" /> received packet
/// </summary>
/// <param name="packet">The received <see cref="Packet" /></param>
/// <returns>
///     <see cref="AwaitCallbackResult" />
/// </returns>
public delegate AwaitCallbackResult AwaitCallbackPredicate(Packet packet);

/// <summary>
///     <see cref="AwaitCallback" /> is a callback with wait for response method.
/// </summary>
public class AwaitCallback
{
    /// <summary>
    ///     Default value of timeout[millisecond].
    /// </summary>
    private const int TIMEOUT_DEFAULT = 5_000;

    /// <summary>
    ///     Completion source used to signal when the callback is invoked.
    /// </summary>
    private readonly TaskCompletionSource<bool> _completionSource =
        new(TaskCreationOptions.RunContinuationsAsynchronously);

    /// <summary>
    ///     Predicate for received packet
    /// </summary>
    private readonly AwaitCallbackPredicate _predicate;

    /// <summary>
    ///     The value indicating whether the <see cref="AwaitCallback" /> is invoked.
    /// </summary>
    private volatile bool _invoked;

    /// <summary>
    ///     The value indicating whether the <see cref="AwaitCallback" /> is successed.
    /// </summary>
    private volatile bool _succeeded;

    /// <summary>
    ///     The value indicating whether the <see cref="AwaitCallback" /> is timeout.
    /// </summary>
    private volatile bool _timeout;

    /// <summary>
    ///     The value indicating whether the <see cref="AwaitCallback" /> is waited for response.
    ///     Uses int for <see cref="Interlocked.CompareExchange(ref int, int, int)" />.
    /// </summary>
    private int _waited;

    /// <summary>
    ///     Constructor of the <see cref="AwaitCallback" /> class.
    /// </summary>
    /// <param name="predicate">The <see cref="AwaitCallbackPredicate" />.</param>
    /// <param name="responseOpcode">The response opcode.</param>
    public AwaitCallback(AwaitCallbackPredicate predicate, ushort responseOpcode)
    {
        _predicate = predicate;
        ResponseOpcode = responseOpcode;
    }

    /// <summary>
    ///     Gets the response opcode.
    /// </summary>
    /// <value>
    ///     The response opcode.
    /// </value>
    public ushort ResponseOpcode { get; }

    /// <summary>
    ///     Gets the value indicating whether the <see cref="AwaitCallback" /> is completed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if completed(not timeout and invoked and successed); otherwise <c>false</c>.
    /// </value>
    public bool IsCompleted => !_timeout && _invoked && _succeeded;

    /// <summary>
    ///     Gets the value indicating whether the <see cref="AwaitCallback" /> is closed.
    /// </summary>
    /// <value>
    ///     <c>true</c> if closed(timeout or invoked); otherwise, <c>false</c>.
    /// </value>
    public bool IsClosed => _timeout || _invoked;

    /// <summary>
    ///     Invokes this <see cref="AwaitCallback" /> instance.
    /// </summary>
    /// <param name="packet">The received <see cref="Packet" />.</param>
    internal void Invoke(Packet packet)
    {
        if (_predicate == null)
        {
            _succeeded = true;
            _invoked = true;
            _completionSource.TrySetResult(true);
            return;
        }

        var result = AwaitCallbackResult.Fail;

        try
        {
            result = _predicate(packet);
        }
        catch (Exception ex)
        {
            Log.Debug($"Callback predicate threw an exception: {ex.Message}\n{ex.StackTrace}");
        }

        switch (result)
        {
            case AwaitCallbackResult.Success:
                _succeeded = true;
                _invoked = true;
                _completionSource.TrySetResult(true);
                break;

            case AwaitCallbackResult.ConditionFailed:
                break;

            case AwaitCallbackResult.Fail:
                _succeeded = false;
                _invoked = true;
                _completionSource.TrySetResult(false);
                break;
        }
    }

    /// <summary>
    ///     Waits for the first response.<br />
    ///     If you call it one more time, then it does nothing.
    /// </summary>
    /// <param name="milliseconds">The timeout in milliseconds, default value is <see cref="TIMEOUT_DEFAULT" />.</param>
    /// <returns></returns>
    public void AwaitResponse(int milliseconds = TIMEOUT_DEFAULT)
    {
        if (Interlocked.CompareExchange(ref _waited, 1, 0) != 0)
            return;

        if (milliseconds < 1)
            milliseconds = 1;

        var task = _completionSource.Task;

        if (SynchronizationContext.Current != null)
        {
            // UI thread: pump messages to keep interface responsive
            var deadline = Environment.TickCount64 + milliseconds;
            while (!task.IsCompleted && Environment.TickCount64 < deadline)
            {
                System.Windows.Forms.Application.DoEvents();
                if (!task.IsCompleted)
                    Thread.Sleep(1);
            }
        }
        else
        {
            // Background thread: efficient blocking wait
            task.Wait(milliseconds);
        }

        if (!task.IsCompleted)
        {
            _timeout = true;
            Log.Debug($"Callback timeout, ResponseOpcode: 0x{ResponseOpcode:X}");
        }
    }

    public async Task AwaitResponseAsync(
        int milliseconds = TIMEOUT_DEFAULT,
        CancellationToken cancellationToken = default
    )
    {
        if (Interlocked.CompareExchange(ref _waited, 1, 0) != 0)
            return;

        if (milliseconds < 1)
            milliseconds = 1;

        try
        {
            using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeoutCts.CancelAfter(milliseconds);
            await _completionSource.Task.WaitAsync(timeoutCts.Token);
        }
        catch (OperationCanceledException)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                _timeout = true;
                Log.Debug($"Callback timeout, ResponseOpcode: 0x{ResponseOpcode:X}");
            }
        }
    }
}
