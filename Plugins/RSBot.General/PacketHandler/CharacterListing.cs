using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.General.Components;

namespace RSBot.General.PacketHandler;

internal class CharacterListing : IPacketHandler
{
    /// <summary>
    ///     Gets or sets the opcode.
    /// </summary>
    /// <value>
    ///     The opcode.
    /// </value>
    public ushort Opcode => 0xB007;

    /// <summary>
    ///     Gets or sets the destination.
    /// </summary>
    /// <value>
    ///     The destination.
    /// </value>
    public PacketDestination Destination => PacketDestination.Client;

    /// <summary>
    ///     Handles the packet.
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

        Log.StatusLang("WaitingUserForSelectCharacter");

        var charCount = packet.ReadByte();

        var lobbyCharacters = new (byte level, string name)[charCount];

        for (var i = 0; i < charCount; i++)
        {
            packet.ReadInt(); //Model

            var name = packet.ReadString();

            if (Game.ClientType >= GameClientType.Chinese)
                packet.ReadString(); // what is this?

            packet.ReadByte(); //Scale
            var level = packet.ReadByte();
            packet.ReadULong(); //EXP
            packet.ReadUShort(); //Strength
            packet.ReadUShort(); //Intelligence
            packet.ReadUShort(); //Stat point(s)

            if (Game.ClientType >= GameClientType.Chinese_Old)
                packet.ReadInt(); // skill point

            packet.ReadInt(); //Health
            packet.ReadInt(); //Mana

            if (Game.ClientType >= GameClientType.Chinese_Old)
                packet.ReadUShort(); // Region

            //Check if the character is being deleted
            var characterDeletionFlag = packet.ReadBool();
            if (characterDeletionFlag)
                packet.ReadInt(); //Time till deletion

            if (Game.ClientType >= GameClientType.Chinese)
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
                lobbyCharacters[i] = (level, name);

            Log.NotifyLang("PlayerDetected", name, level);
        }

        var username = GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername");
        var selectedAccount = Accounts.SavedAccounts?.Find(p => p.Username == username);
        if (selectedAccount == null)
            return;

        selectedAccount.Characters = lobbyCharacters.Select(p => p.name).ToList();

        EventManager.FireEvent("OnCharacterListReceived");

        if (
            !string.IsNullOrWhiteSpace(ProfileManager.SelectedCharacter)
            && lobbyCharacters.Any(p => p.name == ProfileManager.SelectedCharacter)
        )
        {
            selectedAccount.SelectedCharacter = ProfileManager.SelectedCharacter;
        }
        else if (
            string.IsNullOrWhiteSpace(selectedAccount.SelectedCharacter)
            || !lobbyCharacters.Any(p => p.name == selectedAccount.SelectedCharacter)
        )
        {
            if (charCount == 0)
            {
                Log.Warn("There are no characters on this account!");
                return;
            }

            if (GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectFirst"))
            {
                selectedAccount.SelectedCharacter = lobbyCharacters.FirstOrDefault().name;
            }
            else if (GlobalConfig.Get<bool>("RSBot.General.CharacterAutoSelectHigher"))
            {
                selectedAccount.SelectedCharacter = lobbyCharacters.MaxBy(p => p.level).name;
            }
            else
            {
                Log.StatusLang("SelectYourCharacterManually");
                return;
            }
        }

        Accounts.Save();
        AutoLogin.EnterGame(selectedAccount.SelectedCharacter);
    }
}
