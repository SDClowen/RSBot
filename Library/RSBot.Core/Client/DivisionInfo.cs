using System.Collections.Generic;
using System.IO;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Event;
using RSBot.Core.Extensions;

namespace RSBot.Core.Client;

public class DivisionInfo
{
    #region Constants

    /// <summary>
    ///     The file name
    /// </summary>
    internal const string FileName = "DIVISIONINFO.TXT";

    #endregion Constants

    /// <summary>
    ///     Gets the divisions.
    /// </summary>
    /// <value>
    ///     The divisions.
    /// </value>
    public List<Division> Divisions { get; set; }

    /// <summary>
    ///     Gets the locale.
    /// </summary>
    /// <value>
    ///     The locale.
    /// </value>
    public byte Locale { get; set; }

    /// <summary>
    ///     Loads this instance.
    /// </summary>
    /// <returns></returns>
    internal static DivisionInfo Load()
    {
        var result = new DivisionInfo { Divisions = new List<Division>(), Locale = 0 };

        if (Game.MediaPk2 == null)
        {
            Log.Notify("Could not load the DIVISION.TXT file, because there is no active Archive.");
            return result;
        }

        if (!Game.MediaPk2.TryGetFile(FileName, out var file))
        {
            Log.Error($"{FileName} could not be found!");

            return result;
        }

        using (var reader = new BinaryReader(file!.OpenRead().GetStream()))
        {
            result.Locale = reader.ReadByte();

            var divisionCount = reader.ReadByte();
            for (var divisionIndex = 0; divisionIndex < divisionCount; divisionIndex++)
            {
                var division = new Division { Name = reader.ReadJoymaxString(), GatewayServers = new List<string>() };
                reader.ReadByte(); //Null terminator for NameStrID

                var gatewayCount = reader.ReadByte();

                for (var gatewayIndex = 0; gatewayIndex < gatewayCount; gatewayIndex++)
                {
                    var host = reader.ReadJoymaxString();
                    division.GatewayServers.Add(host);
                    reader.ReadByte(); //Null terminator for Host
                }

                result.Divisions.Add(division);
            }
        }

        EventManager.FireEvent("OnLoadDivisionInfo", result);

        return result;
    }
}
