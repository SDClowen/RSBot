using System;

namespace RSBot.Core.Plugins;

/// <summary>
///     Event args for download progress updates.
/// </summary>
public class DownloadProgressEventArgs : EventArgs
{
    /// <summary>
    ///     Gets or sets the progress percentage (0-100).
    /// </summary>
    public int ProgressPercentage { get; set; }

    /// <summary>
    ///     Gets or sets the number of bytes received.
    /// </summary>
    public long BytesReceived { get; set; }

    /// <summary>
    ///     Gets or sets the total bytes to receive.
    /// </summary>
    public long TotalBytesToReceive { get; set; }

    /// <summary>
    ///     Gets or sets the file name being downloaded.
    /// </summary>
    public string FileName { get; set; }
}
