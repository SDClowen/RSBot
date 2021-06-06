using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;

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
            if (packet.ReadByte() == 0x02)
            {
                if (packet.ReadByte() == 0x01)
                {
                    BotWindow.SetStatusText("Waiting for the user to select a character...");
                    var charCount = packet.ReadByte();
                    Models.Account selectedAccount = null;
                    if (Components.Accounts.SavedAccounts.Count >
                        GlobalConfig.Get<int>("RSBot.General.AccountIndex"))
                    {
                        selectedAccount =
                           Components.Accounts.SavedAccounts[GlobalConfig.Get<int>("RSBot.General.AccountIndex")];

                        if (selectedAccount != null)
                            selectedAccount.Characters = new string[charCount];
                    }

                    for (var i = 0; i < charCount; i++)
                    {
                        packet.ReadInt(); //Model
                        var name = packet.ReadString();
                        packet.ReadByte(); //Volume/Height
                        var level = packet.ReadByte();
                        packet.ReadULong(); //EXP
                        packet.ReadUShort(); //Strength
                        packet.ReadUShort(); //Intelligence
                        packet.ReadUShort(); //Stat point(s)
                        packet.ReadInt(); //Health
                        packet.ReadInt(); //Mana

                        //Check if the character is being deleted
                        var characterDeletionFlag = packet.ReadByte();
                        if (characterDeletionFlag == 0x01)
                            packet.ReadInt(); //Time till deletion

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

                        //Read avatars
                        var avatarCount = packet.ReadByte();
                        for (var iAvatar = 0; iAvatar < avatarCount; iAvatar++)
                        {
                            packet.ReadInt(); //Avatar identifier
                            packet.ReadByte(); //Avatar plus value (enhancement)
                        }

                        if (selectedAccount != null)
                            selectedAccount.Characters[i] = name;
                    
                        Log.Notify($"Player detected: {name} (lv. {level})");
                    }

                    EventManager.FireEvent("OnCharacterListReceived");

                    if (selectedAccount == null) return;

                    Components.Accounts.Save();

                    var character = GlobalConfig.Get<string>("RSBot.General.AutoLoginCharacter");
                    if (charCount == 0 || string.IsNullOrWhiteSpace(character))
                    {
                        BotWindow.SetStatusText("Select your character manually only for this time.");
                        return;
                    }

                    Components.AutoLogin.EnterGame(character);
                }
                else
                    Log.Notify("Could not correctly decode the character listing!");
            }
            else
                Log.Notify("Could not correctly decode the character listing!");
        }
    }
}