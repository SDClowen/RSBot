using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using System.Linq;

namespace RSBot.General.PacketHandler
{
    internal class CharacterListing : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0xB007;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var type = packet.ReadByte();
            var result = packet.ReadByte();

            if (type != 2)
                return;

            if (result != 1)
                return;

            BotWindow.SetStatusTextLang("WaitingUserForSelectCharacter");

            var charCount = packet.ReadByte();

            var lobbyCharacters = new string[charCount];

            for (var i = 0; i < charCount; i++)
            {
                packet.ReadInt(); //Model
                var name = packet.ReadString();

                if (Game.ClientType > GameClientType.Chinese)
                    packet.ReadString(); // what is this?

                packet.ReadByte(); //Scale
                var level = packet.ReadByte();
                packet.ReadULong(); //EXP
                packet.ReadUShort(); //Strength
                packet.ReadUShort(); //Intelligence
                packet.ReadUShort(); //Stat point(s)

                if (Game.ClientType >= GameClientType.Chinese)
                    packet.ReadInt(); // skill point

                packet.ReadInt(); //Health
                packet.ReadInt(); //Mana

                if (Game.ClientType >= GameClientType.Chinese)
                    packet.ReadUShort(); // Region

                //Check if the character is being deleted
                var characterDeletionFlag = packet.ReadBool();
                if (characterDeletionFlag)
                    packet.ReadInt(); //Time till deletion

                if (Game.ClientType > GameClientType.Chinese)
                    packet.ReadUInt(); // last logged out timestamp

                packet.ReadByte(); //Has guild?
                var grantNameFlag = packet.ReadByte();
                if (grantNameFlag == 0x01)
                    packet.ReadString();

                packet.ReadByte(); //Academy

                //Read items
                var itemCount = packet.ReadByte();
                for (var iItem = 0; iItem < itemCount; iItem++)
                {
                    packet.ReadInt(); //Item identifier
                    packet.ReadByte(); //Item plus value (enhancement)
                }

                if (Game.ClientType >= GameClientType.Thailand)
                {
                    //Read avatars
                    var avatarCount = packet.ReadByte();
                    for (var iAvatar = 0; iAvatar < avatarCount; iAvatar++)
                    {
                        packet.ReadInt(); //Avatar identifier
                        packet.ReadByte(); //Avatar plus value (enhancement)
                    }
                }

                if (!characterDeletionFlag)
                    lobbyCharacters[i] = name;

                Log.NotifyLang("PlayerDetected", name, level);
            }

            var username = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");
            var selectedAccount = Components.Accounts.SavedAccounts.Find(p => p.Username == username);
            if (selectedAccount == null)
                return;

            if (selectedAccount.Characters.Count == 0)
            {
                selectedAccount.Characters.AddRange(lobbyCharacters);
                Components.Accounts.Save();
            }

            EventManager.FireEvent("OnCharacterListReceived");

            if (string.IsNullOrWhiteSpace(selectedAccount.SelectedCharacter))
            {
                BotWindow.SetStatusTextLang("SelectYourCharacterManually");
                return;
            }

            if (lobbyCharacters.Contains(selectedAccount.SelectedCharacter))
                Components.AutoLogin.EnterGame(selectedAccount.SelectedCharacter);
        }
    }
}