using RSBot.Core;
using RSBot.Core.Extensions;
using RSBot.Core.Network;
using RSBot.Party.Bundle.PartyMatching.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Party.Bundle.PartyMatching;

internal class PartyMatchingBundle
{
    /// <summary>
    ///     Gets or sets the configuration.
    /// </summary>
    /// <value>The configuration.</value>
    public MatchingConfig Config;

    /// <summary>
    ///     Gets or sets a value indicating whether this instance has matching entry.
    /// </summary>
    /// <value><c>true</c> if this instance has matching entry; otherwise, <c>false</c>.</value>
    public bool HasMatchingEntry;

    /// <summary>
    ///     Party matching Id
    /// </summary>
    public uint Id;

    public CancellationTokenSource DeletionCts;

    /// <summary>
    ///     Creates the specified settings.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public bool Change()
    {
        if (!HasMatchingEntry)
            return false;

        if (Game.Party.HasPendingRequest)
            Game.AcceptanceRequest?.Refuse();

        var flag = Game.Party.Settings.GetPartyType();

        var packet = new Packet(0x706A);
        packet.WriteUInt(Id);
        packet.WriteUInt(0);

        packet.WriteByte(flag);
        packet.WriteByte(Config.Purpose);
        packet.WriteByte(Config.LevelFrom);
        packet.WriteByte(Config.LevelTo);
        packet.WriteConditonalString(Config.Title);

        var callback =
            new AwaitCallback(
                response => response.ReadByte() == 1 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail, 0xB06A);

        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse(2000);

        return callback.IsCompleted;
    }

    /// <summary>
    ///     Creates the specified settings.
    /// </summary>
    /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    public bool Create()
    {
        if (HasMatchingEntry)
            return false;

        if (Game.Party.HasPendingRequest)
            Game.AcceptanceRequest?.Refuse();

        var flag = Game.Party.Settings.GetPartyType();

        var packet = new Packet(0x7069);
        packet.WriteUInt(0); //Party Id
        packet.WriteUInt(0);

        packet.WriteByte(flag);
        packet.WriteByte(Config.Purpose);
        packet.WriteByte(Config.LevelFrom);
        packet.WriteByte(Config.LevelTo);
        packet.WriteConditonalString(Config.Title);

        var callback =
            new AwaitCallback(
                response => response.ReadByte() == 1 ? AwaitCallbackResult.Success : AwaitCallbackResult.Fail, 0xB069);

        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse(2000);

        return callback.IsCompleted;
    }

    public async Task ScheduleDeletion(CancellationToken token)
    {
        try
        {
            await Task.Delay(20 * 60 * 1000, token);
            if (!token.IsCancellationRequested)
                Delete();
        }
        catch (TaskCanceledException)
        {
        }
    }

    public void CancelScheduledDeletion()
    {
        if (DeletionCts != null)
        {
            DeletionCts.Cancel();
            DeletionCts.Dispose();
            DeletionCts = null;
        }
    }

    public void Delete()
    {
        if (!HasMatchingEntry)
            return;

        if (Game.Party.HasPendingRequest)
            Game.AcceptanceRequest?.Refuse();

        var packet = new Packet(0x706B);
        packet.WriteUInt(Id);
        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Joins the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public bool Join(uint id)
    {
        var packet = new Packet(0x706D);
        packet.WriteUInt(id);

        var joiningResult = 0;
        var callback = new AwaitCallback(response =>
        {
            var result = response.ReadByte();
            if (result == 1)
            {
                // 0 => canceled
                // 1 => accepted
                // 2 => didnt answer
                joiningResult = response.ReadByte();
                return AwaitCallbackResult.Success;
            }

            return AwaitCallbackResult.Fail;
        }, 0xB06D);

        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse(10000);

        return callback.IsCompleted && joiningResult == 1;
    }

    /// <summary>
    ///     Requests the party list.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <returns></returns>
    public PartyList RequestPartyList(byte page = 0)
    {
        var packet = new Packet(0x706C);
        packet.WriteByte(page);

        var partyList = PartyList.FromPacket(null); //placeholder for the callback

        var callback = new AwaitCallback(response =>
        {
            partyList = PartyList.FromPacket(response);
            return AwaitCallbackResult.Success;
        }, 0xB06C);

        PacketManager.SendPacket(packet, PacketDestination.Server, callback);
        callback.AwaitResponse();

        return partyList;
    }
}