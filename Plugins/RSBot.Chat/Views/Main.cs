using RSBot.Chat.Objects;
using RSBot.Core;
using RSBot.Core.Event;
using System.Windows.Forms;

namespace RSBot.Chat.Views
{
    using Theme.Extensions;

    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        public Main()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            SubscribeEvents();
        }

        /// <summary>
        /// Subscribes the events.
        /// </summary>
        private void SubscribeEvents()
        {
            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
        }

        /// <summary>
        /// Sends the chat message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void SendChatMessage(Control sender)
        {
            switch (sender.Name)
            {
                case "txtSendAll":
                    Bundle.Chat.SendChatPacket(ChatType.All, sender.Text);
                    break;

                case "txtSendParty":
                    Bundle.Chat.SendChatPacket(ChatType.Party, sender.Text);
                    break;

                case "txtSendPrivate":
                    Bundle.Chat.SendChatPacket(ChatType.Private, sender.Text, txtRecievePrivate.Text);
                    PlayerConfig.Set("RSBot.Chat.LastWhisper", txtRecievePrivate.Text);
                    break;

                case "txtSendGuild":
                    Bundle.Chat.SendChatPacket(ChatType.Guild, sender.Text);
                    break;

                case "txtSendAcademy":
                    Bundle.Chat.SendChatPacket(ChatType.Academy, sender.Text);
                    break;

                case "txtSendUnion":
                    Bundle.Chat.SendChatPacket(ChatType.Union, sender.Text);
                    break;

                default:
                    Log.Warn("Unknown chat type.");
                    break;
            }
        }

        /// <summary>
        /// Appends the message.
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
            }
        }

        /// <summary>
        /// The first event that will be fired after the player enters the game
        /// </summary>
        private void OnEnterGame()
        {
            txtRecievePrivate.Text = PlayerConfig.Get<string>("RSBot.Chat.LastWhisper");
        }

        /// <summary>
        /// Messages the preview key down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PreviewKeyDownEventArgs"/> instance containing the event data.</param>
        private void MessagePreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            SendChatMessage((Control)sender);
            ((Control)sender).ResetText();
        }
    }
}