using System.IO;
using System.Text;
using RSBot.Core.Event;
using RSBot.Core.Network.Protocol;

namespace RSBot.Core.Client;

public class VersionInfo
{
    #region Constants

    /// <summary>
    ///     The filename
    /// </summary>
    internal const string Filename = @"SV.T";

    #endregion Constants

    /// <summary>
    ///     Gets the version.
    /// </summary>
    /// <value>
    ///     The version.
    /// </value>
    public int Version { get; set; }

    /// <summary>
    ///     Loads this instance.
    /// </summary>
    /// <returns></returns>
    internal static VersionInfo Load()
    {
        var result = new VersionInfo();
        if (Game.MediaPk2 == null)
        {
            Log.Notify("Could not load the SV.T file, because there is no active Archive.");
            return result;
        }

        if (!Game.MediaPk2.TryGetFile(Filename, out var file))
        {
            Log.Error("Could not load the SV.T file, because the file could not be found.");
            return result;
        }

        using (var reader = new BinaryReader(file!.OpenRead().GetStream()))
        {
            var versionBufferLength = reader.ReadInt32();
            var versionBuffer = reader.ReadBytes(versionBufferLength);

            var blowfish = new Blowfish();
            blowfish.Initialize(Encoding.ASCII.GetBytes("SILKROADVERSION"), 0, 8);

            var decodedVersionBuffer = blowfish.Decode(versionBuffer);
            result.Version = int.Parse(Encoding.ASCII.GetString(decodedVersionBuffer, 0, 4));
        }

        EventManager.FireEvent("OnLoadVersionInfo", result);
        return result;
    }
}
