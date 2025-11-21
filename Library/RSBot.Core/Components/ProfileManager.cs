using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

namespace RSBot.Core.Components;

public class ProfileManager
{
    /// <summary>
    ///     The profile config
    /// </summary>
    private static readonly Config _config;

    /// <summary>
    ///     Get active profiles
    /// </summary>
    private static readonly ObservableCollection<string> _profiles;

    /// <summary>
    ///     Initialize static ctor
    /// </summary>
    static ProfileManager()
    {
        _config = new Config(GetProfileConfigFileName());
        _profiles = new ObservableCollection<string>(_config.GetArray<string>("RSBot.Profiles", '|'));
        _profiles.CollectionChanged += Profiles_CollectionChanged;
    }

    /// <summary>
    ///     Get active profiles
    /// </summary>
    public static string[] Profiles => _profiles.ToArray();

    /// <summary>
    ///     If the selected profile loaded via program args <c>true</c>; otherwise <c>false</c>.
    /// </summary>
    public static bool IsProfileLoadedByArgs { get; set; }

    /// <summary>
    ///     The selected character
    /// </summary>
    public static string SelectedCharacter { get; set; }

    /// <summary>
    ///     The selected profile
    /// </summary>
    public static string SelectedProfile => _config.Get("RSBot.SelectedProfile", "Default");

    /// <summary>
    ///     Show the profile dialog <c>true</c>; otherwise <c>false</c>
    /// </summary>
    public static bool ShowProfileDialog
    {
        get => _config.Get("RSBot.ShowProfileDialog", false);
        set
        {
            _config.Set("RSBot.ShowProfileDialog", value);
            _config.Save();
        }
    }

    /// <summary>
    ///     There have any value in the collection <c>true</c>; otherwise <c>false</c>
    /// </summary>
    public static bool Any()
    {
        return _profiles.Any();
    }

    /// <summary>
    ///     Called after Profiles are changed
    /// </summary>
    private static void Profiles_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        _config.SetArray("RSBot.Profiles", _profiles, "|");
        _config.Save();
    }

    /// <summary>
    ///     Set selected profile
    /// </summary>
    /// <param name="profile">The profile</param>
    public static bool SetSelectedProfile(string profile)
    {
        if (!_profiles.Any(p => p == profile))
            return false;

        _config.Set("RSBot.SelectedProfile", profile);
        _config.Save();

        return true;
    }

    /// <summary>
    ///     Is profile exists <c>true</c>; otherwise <c>false</c>
    /// </summary>
    /// <param name="profile">The profile</param>
    public static bool ProfileExists(string profile)
    {
        return _profiles.Any(p => p.Equals(profile, StringComparison.InvariantCultureIgnoreCase));
    }

    /// <summary>
    ///     Create new profile
    /// </summary>
    /// <param name="profile">The profile</param>
    /// <param name="useAsBase">Use as base <c>true</c>; otherwise <c>false</c></param>
    /// <returns>Is created <c>true</c>; otherwise <c>false</c></returns>
    public static bool Add(string profile, bool useAsBase = false)
    {
        if (profile.Equals("Profiles", StringComparison.InvariantCultureIgnoreCase))
            return false;

        if (profile == SelectedProfile)
            return true;

        _profiles.Add(profile);

        if (useAsBase)
            CopyOldProfileData(profile);

        var newProfileDirectory = GetProfileDirectory(profile);
        if (!Directory.Exists(newProfileDirectory))
            Directory.CreateDirectory(newProfileDirectory);

        SetSelectedProfile(profile);

        return false;
    }

    /// <summary>
    ///     Remove the profile
    /// </summary>
    /// <param name="profile">The profile</param>
    /// <returns>Is removed <c>true</c>; otherwise <c>false</c></returns>
    public static bool Remove(string profile)
    {
        return _profiles.Remove(profile);
    }

    /// <summary>
    ///     Copies the old profile data to the new profile.
    /// </summary>
    /// <param name="profile">Name of the profile.</param>
    private static void CopyOldProfileData(string profile)
    {
        try
        {
            var oldProfileFilePath = GetProfileFile(SelectedProfile);
            var newProfileFilePath = GetProfileFile(profile);
            var oldAutoLoginFile = Path.Combine(GetProfileDirectory(SelectedProfile), "autologin.data");
            var newAutoLoginFile = Path.Combine(GetProfileDirectory(profile), "autologin.data");

            if (File.Exists(oldProfileFilePath))
                File.Copy(oldProfileFilePath, newProfileFilePath);

            if (File.Exists(oldAutoLoginFile))
                File.Copy(oldAutoLoginFile, newAutoLoginFile);
        }
        catch (Exception ex)
        {
            Log.Warn($"Could not copy old profile data to the new profile: {ex.Message}");
        }
    }

    /// <summary>
    ///     Get profile config file name
    /// </summary>
    /// <returns></returns>
    public static string GetProfileConfigFileName()
    {
        return Path.Combine(Kernel.BasePath, "User", "Profiles.rs");
    }

    public static string GetProfileFile(string profileName)
    {
        return Path.Combine(Kernel.BasePath, "User", $"{profileName}.rs");
    }

    public static string GetProfileDirectory(string profileName)
    {
        return Path.Combine(Kernel.BasePath, "User", profileName);
    }
}
