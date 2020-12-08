using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.General.Models;

namespace RSBot.General.Components
{
    internal static class AutoLogin
    {
        /// <summary>
        /// Does the automatic login.
        /// </summary>
        public static void DoAutoLogin()
        {
            if (!GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
                return;

            if (Accounts.SavedAccounts.Count <= GlobalConfig.Get<int>("RSBot.General.AccountIndex")) return;
            var selectedAccount = Accounts.SavedAccounts[GlobalConfig.Get<int>("RSBot.General.AccountIndex")];

            var server = Serverlist.GetServerByName(selectedAccount.Servername);

            if (server == null && Serverlist.Servers != null && Serverlist.Servers.Count != 1)
                Log.Notify($"The server [{selectedAccount.Servername}] assigned to this account could not be found in the serverlist!");

            SendLoginRequest(selectedAccount, server);
        }

        /// <summary>
        /// Sends the login request.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="server">The server.</param>
        private static void SendLoginRequest(Account account, Models.Server server)
        {
            Log.Notify("Sending login credentials to the server...");

            if (account == null)
                return;

            var loginPacket = new Packet(0x6102, true);
            loginPacket.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
            loginPacket.WriteString(account.Username);
            loginPacket.WriteString(account.Password);

            loginPacket.WriteUShort(server?.Id ?? Serverlist.Servers[0].Id);

            loginPacket.Lock();

            PacketManager.SendPacket(loginPacket, PacketDestination.Server);
        }

        /// <summary>
        /// Sends the static captcha.
        /// </summary>
        public static void SendStaticCaptcha()
        {
            if (!GlobalConfig.Get<bool>("RSBot.General.EnableStaticCaptcha") || !GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin")) return;

            var captcha = GlobalConfig.Get<string>("RSBot.General.StaticCaptcha");
            Log.Notify($"Entering captcha ['{captcha}']...");
            var packet = new Packet(0x6323);
            packet.WriteString(captcha);
            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Enters the game.
        /// </summary>
        /// <param name="character">The character.</param>
        public static void EnterGame(string character)
        {
            if (!GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
                return;

            var packet = new Packet(0x7001);
            packet.WriteString(character);
            packet.Lock();
            PacketManager.SendPacket(packet, PacketDestination.Server);
            PlayerConfig.Load("User\\" + character);
            EventManager.FireEvent("OnEnterGame");
        }
    }
}