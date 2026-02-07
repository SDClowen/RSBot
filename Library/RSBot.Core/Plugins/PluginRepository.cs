using System;
using System.Collections.Generic;

namespace RSBot.Core.Plugins;

/// <summary>
///     Represents a plugin repository containing available plugins.
/// </summary>
public class PluginRepository
{
    /// <summary>
    ///     Gets or sets the repository name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the repository URL.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    ///     Gets or sets the list of available plugins.
    /// </summary>
    public List<PluginInfo> Plugins { get; set; } = new List<PluginInfo>();
}

/// <summary>
///     Represents information about a downloadable plugin.
/// </summary>
public class PluginInfo
{
    /// <summary>
    ///     Gets or sets the plugin display name.
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or sets the plugin internal name.
    /// </summary>
    public string InternalName { get; set; }

    /// <summary>
    ///     Gets or sets the plugin description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     Gets or sets the plugin version.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    ///     Gets or sets the plugin author.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    ///     Gets or sets the download URL.
    /// </summary>
    public string DownloadUrl { get; set; }

    /// <summary>
    ///     Gets or sets the plugin file size in bytes.
    /// </summary>
    public long FileSize { get; set; }

    /// <summary>
    ///     Gets or sets the SHA256 hash for verification.
    /// </summary>
    public string Hash { get; set; }

    /// <summary>
    ///     Gets or sets the icon URL.
    /// </summary>
    public string IconUrl { get; set; }

    /// <summary>
    ///     Gets or sets the plugin category.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    ///     Gets or sets the required RSBot version.
    /// </summary>
    public string RequiredVersion { get; set; }

    /// <summary>
    ///     Gets or sets whether this is a premium plugin.
    /// </summary>
    public bool IsPremium { get; set; }

    /// <summary>
    ///     Gets or sets the plugin rating (0-5).
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    ///     Gets or sets the number of downloads.
    /// </summary>
    public int Downloads { get; set; }

    /// <summary>
    ///     Gets or sets the last update date.
    /// </summary>
    public DateTime LastUpdated { get; set; }

    /// <summary>
    ///     Gets or sets the plugin tags.
    /// </summary>
    public List<string> Tags { get; set; } = new List<string>();

    /// <summary>
    ///     Gets or sets the screenshots URLs.
    /// </summary>
    public List<string> Screenshots { get; set; } = new List<string>();
}
