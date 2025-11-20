using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using SDUI.Controls;

namespace RSBot.Chat.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    public Main()
    {
        CheckForIllegalCrossThreadCalls = false;
        InitializeComponent();

        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
    }

    /// <summary>
    ///     Sends the chat message.
    /// </summary>
    /// <param name="sender">The sender.</param>
    private void SendChatMessage(Control sender)
    {
        if (!Enum.TryParse<ChatType>(sender.Tag.ToString(), out var chatType))
            return;

        if (chatType == ChatType.Global)
            Bundle.Chat.SendGlobalChatPacket(sender.Text);
        else
            Bundle.Chat.SendChatPacket(chatType, sender.Text, txtRecievePrivate.Text);

        if (chatType == ChatType.Private)
            PlayerConfig.Set("RSBot.Chat.LastWhisper", txtRecievePrivate.Text);
    }

    /// <summary>
    ///     Appends the message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="sender">The sender.</param>
    /// <param name="type">The type.</param>
    public void AppendMessage(string message, string sender, ChatType type)
    {
        message = $"({sender}): {message}";

        switch (type)
        {
            case ChatType.Academy:
                txtAcademy.Write(message);
                break;

            case ChatType.All:
                txtAll.Write(message);
                break;

            case ChatType.AllGM:
                txtAll.Write(message);
                break;

            case ChatType.Global:
                txtGlobal.Write(message);
                break;

            case ChatType.Guild:
                txtGuild.Write(message);
                break;

            case ChatType.Notice:
                txtGlobal.Write(message);
                break;

            case ChatType.Npc:
                txtAll.Write(message);
                break;

            case ChatType.Party:
                txtParty.Write(message);
                break;

            case ChatType.Private:
                txtPrivate.Write(message);
                break;

            case ChatType.Union:
                txtUnion.Write(message);
                break;

            case ChatType.Stall:
                txtStall.Write(message);
                break;
        }
    }

    /// <summary>
    ///     The first event that will be fired after the player enters the game
    /// </summary>
    private void OnEnterGame()
    {
        txtRecievePrivate.Text = PlayerConfig.Get<string>("RSBot.Chat.LastWhisper");
    }

    /// <summary>
    ///     Messages the preview key down.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="PreviewKeyDownEventArgs" /> instance containing the event data.</param>
    private void MessagePreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;
        SendChatMessage((Control)sender);
        ((Control)sender).ResetText();
    }
}
