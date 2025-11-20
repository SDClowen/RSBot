using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Action;

internal class ActionTalkResponse : IPacketHandler
{
    #region Methods

    /// <summary>
    ///     Handles the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    public void Invoke(Packet packet)
    {
        var result = packet.ReadByte();

        if (Game.Player.State.DialogState == null || result != 1)
            return;

        var talkOption = (TalkOption)packet.ReadByte();

        Game.Player.State.DialogState.Npc = SpawnManager.GetEntity<SpawnedNpc>(
            Game.Player.State.DialogState.RequestedNpcId
        );
        Game.Player.State.DialogState.TalkOption = talkOption;

        if (talkOption == TalkOption.Trade)
            Game.Player.State.DialogState.IsSpecialityTime = packet.ReadBool();

        Game.SelectedEntity = Game.Player.State.DialogState.Npc;

        EventManager.FireEvent("OnSelectEntity", Game.SelectedEntity);
        EventManager.FireEvent("OnTalkToNpc", Game.Player.State.DialogState.RequestedNpcId);
    }

    #endregion Methods

    #region Properties

    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB046;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    #endregion Properties
}
