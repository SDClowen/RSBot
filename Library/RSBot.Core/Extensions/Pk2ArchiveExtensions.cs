using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using RSBot.Core.Client;
using RSBot.FileSystem;
using System;

namespace RSBot.Core.Extensions;

public static class Pk2Extensions
{
    /// <summary>
    ///     Gets the stream from a DDJ file in the Pk2 archive and converts the DDS Format to System.Image.
    /// </summary>
    /// <param name="file">The archive.</param>
    /// <returns></returns>
    public static WriteableBitmap ToImage(this IFile file)
    {
        try
        {
            var ddjBuffer = file.OpenRead().ReadAllBytes();
            var ddsBuffer = new byte[ddjBuffer.Length - 20];
            Array.ConstrainedCopy(ddjBuffer, 20, ddsBuffer, 0, ddjBuffer.Length - 20); //Cuts the first 20 bytes.
            return DDSImage.ToBitmap(ddsBuffer);
        }
        catch
        {
            return new WriteableBitmap(new PixelSize(256, 256), new Vector(96, 96), PixelFormat.Bgra8888, AlphaFormat.Premul);
        }
    }
}