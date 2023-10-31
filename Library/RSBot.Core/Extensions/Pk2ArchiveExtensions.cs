using System;
using System.Drawing;
using RSBot.Core.Client;
using RSBot.FileSystem;

namespace RSBot.Core.Extensions;

public static class Pk2Extensions
{
    /// <summary>
    ///     Gets the stream from a DDJ file in the Pk2 archive and converts the DDS Format to System.Image.
    /// </summary>
    /// <param name="file">The archive.</param>
    /// <returns></returns>
    public static Image ToImage(this IFile file)
    {
        var ddjBuffer = file.OpenRead().ReadAllBytes();

        try
        {
            var ddsBuffer = new byte[ddjBuffer.Length - 20];
            Array.ConstrainedCopy(ddjBuffer, 20, ddsBuffer, 0, ddjBuffer.Length - 20); //Cuts the first 20 bytes.
            return DDSImage.ToBitmap(ddsBuffer);
        }
        catch
        {
            return new Bitmap(16, 16);
        }
    }

    /// <summary>
    ///     Gets the given file ignoring the file name's case.
    ///     This may reduce performance but adds additional compatibility to dirty PK2 files.
    /// </summary>
    /// <param name="fileSystem"></param>
    /// <param name="path"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    public static bool TryGetFileIgnoreCase(this IFileSystem fileSystem, string path, out IFile file)
    {
        //Original
        if (fileSystem.TryGetFile(path, out file))
            return true;

        //ToLower
        var fileName = PathUtil.GetFileName(path).ToLower();
        var folderName = PathUtil.GetFolderName(path);
        var newPath = PathUtil.Append(folderName, fileName);

        if (fileSystem.TryGetFile(newPath, out file))
            return true;

        //ToUpper
        newPath = PathUtil.Append(folderName, fileName.ToUpper());
        if (fileSystem.TryGetFile(newPath, out file))
            return true;
        
        //No file found
        Log.Warn($"File not found: {newPath}");

        return false;

    }
}