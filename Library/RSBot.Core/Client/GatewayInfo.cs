using System;
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

        result.Port = Convert.ToUInt16(Game.MediaPk2.GetFile(Filename).ReadAllText().Trim());

        EventManager.FireEvent("OnLoadGateport", result);
        return result;
    }
}