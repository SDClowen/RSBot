namespace RSBot.FileSystem;

public static class PathUtil
{
    public static char PathSeparator = '\\';

    /// <summary>
    ///     Returns the parent path to the folder or file at the given path.
    /// </summary>
    /// <param name="path">The path to determine the parent path.</param>
    /// <returns>The parent path to the given path.</returns>
    public static string GetFolderName(string? path)
    {
        if (path == null)
            return string.Empty;

        path = Prepare(path);

        var paths = path.Split(PathSeparator);
        var pathsWithoutLast = paths[..^1];

        return string.Join(PathSeparator, pathsWithoutLast);
    }

    /// <summary>
    ///     Returns the file or folder name from the path.
    /// </summary>
    /// <param name="path">The path to get the file or folder name from.</param>
    /// <returns>The file name.</returns>
    public static string GetFileName(string path)
    {
        path = Prepare(path);

        return string.IsNullOrEmpty(path) ? string.Empty : path.Split(PathSeparator).Last();
    }

    /// <summary>
    ///     Appends the given folder or filename to the path.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="folderOrFileName"></param>
    /// <returns></returns>
    public static string Append(string path, string folderOrFileName)
    {
        if (!string.IsNullOrEmpty(path))
            path = Prepare(path);

        return path + PathSeparator + folderOrFileName;
    }

    /// <summary>
    ///     Returns a ready to use path string.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static string Prepare(string path)
    {
        if (path.StartsWith(PathSeparator))
            path = path.Substring(1, path.Length - 1);

        if (path.EndsWith(PathSeparator))
            path = path[..^1];

        return path;
    }
}
