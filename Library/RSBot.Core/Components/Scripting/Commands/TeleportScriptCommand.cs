using System.Collections.Generic;
using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Components.Scripting.Commands;

internal class TeleportScriptCommand : IScriptCommand
{
    #region Properties

    public string Name => "teleport";

    public bool IsBusy { get; private set; }

    public Dictionary<string, string> Arguments =>
        new() { { "Codename", "The code name of the NPC" }, { "Destination", "The id of the destination" } };

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Executes this instance.
    /// </summary>
    /// <param name="arguments"></param>
    /// <returns>
    ///     A value indicating if the command has been executed successfully.
    /// </returns>
    public bool Execute(string[] arguments = null)
    {
        if (arguments == null || arguments.Length == 0)
        {
            Log.Warn("[Script] Invalid store command: Position information missing.");

            return false;
        }

        try
        {
            IsBusy = true;

            Log.Notify("[Script] Teleporting...");
            return ExecuteTeleport(arguments);
        }
        finally
        {
            IsBusy = false;
        }
    }

    /// <summary>
    ///     Executes the teleport.
    /// </summary>
    /// <param name="arguments">The arguments.</param>
    private static bool ExecuteTeleport(IReadOnlyList<string> arguments)
    {
        if (arguments.Count < 2)
            return false;

        var npcCodeName = arguments[0];
        if (!uint.TryParse(arguments[1], out var destination))
            return false;

        if (!SpawnManager.TryGetEntity<SpawnedBionic>(p => p.Record.CodeName == npcCodeName, out var entity))
        {
            Log.Debug("[Script] Could not find teleporter NPC " + npcCodeName);
            return false;
        }

        if (!entity.TrySelect())
            return false;

        var packet = new Packet(0x705A);
        packet.WriteUInt(entity.UniqueId);
        packet.WriteByte(0x02);
        packet.WriteUInt(destination);

        var gameReadyOpcode = (ushort)(Game.ClientType == GameClientType.Rigid ? 0x3077 : 0x3012);
        var callback = new AwaitCallback(null, gameReadyOpcode); // Game Ready
        PacketManager.SendPacket(packet, PacketDestination.Server, callback);

        callback.AwaitResponse(30_000); //For some really slow PCs

        return true;
    }

    public void Stop()
    {
        IsBusy = false;
    }

    #endregion Methods
}
