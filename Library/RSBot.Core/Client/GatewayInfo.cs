using RSBot.Core.Event;

namespace RSBot.Core.Client;

public class GatewayInfo
{
    #region Constants

    internal const string Filename = @"GATEPORT.TXT";

    #endregion Constants

    public ushort Port { get; set; }

    /// <summary>
    ///     Loads this instance.
    /// </summary>
    /// <returns></returns>
    internal static GatewayInfo Load()
    {
        var result = new GatewayInfo();
        if (Game.MediaPk2 == null)
        {
            Log.Notify("Could not load the GATEPORT.TXT file, because there is no active Archive.");
            return result;
        }

        if (!Game.MediaPk2.TryGetFile(Filename, out var file))
        {
            Log.Error("Could not load the GATEPORT.txt file, because the file was not found.");
            return result;
        }

        if (!ushort.TryParse(file.ReadAllText(), out var port))
        {
            Log.Error("Could not load the GATEPORT.txt file, because the data doesn't contain port information");
            return result;
        }

        result.Port = port;

        EventManager.FireEvent("OnLoadGateport", result);

        return result;
    }
}
