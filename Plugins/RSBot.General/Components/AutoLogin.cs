using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Network.SecurityAPI;
using RSBot.General.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.General.Components
{
    internal static class AutoLogin
    {
        /// <summary>
        /// Is the auto login handling <c>true</c> otherwise; <c>false</c>
        /// </summary>
        private static bool _busy = false;

        /// <summary>
        /// Does the automatic login.
        /// </summary>
        public static async void Handle()
        {
            if (_busy)
                return;

            _busy = true;

            if (!GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
                return;

            var selectedAccount = Accounts.SavedAccounts.Find(p => p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername"));
            if (selectedAccount == null)
            {
                _busy = false;
                Log.Warn("No have any selected account for autologin. RSBot waiting for manual login from you! Do not forget select a account for auto login next time ;)");
                return;
            }

            var server = Serverlist.GetServerByName(selectedAccount.Servername);
            if (server == null && Serverlist.Servers != null)
            {
                Log.Notify($"The server [{selectedAccount.Servername}] assigned to this account could not be found in the serverlist!");

                server = Serverlist.Servers.First();
                Log.Notify($"Selected default server: [{server.Name}]");
            }

            // is server check [Lazy :)]
            if (!server.Status)
            {
                _busy = false;

                Log.Notify("The selected server is under maintainance. Retrying to login in few seconds...");

                // Only need while clientless, otherwise the client already sending every 5 seconds instead of bot.
                if (Game.Clientless)
                {
                    await Task.Delay(5000);
                    PacketManager.SendPacket(new Packet(0x6101, true), PacketDestination.Server);
                }

                return;
            }

            await Task.Delay(5000);
            SendLoginRequest(selectedAccount, server);
        }

        /// <summary>
        /// Sends the secondary password if have.
        /// </summary>
        internal static void SendSecondaryPassword()
        {
            if (Accounts.Joined == null)
                return;

            if (!GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
                return;

            var secondaryPassword = Accounts.Joined.SecondaryPassword;

            if (string.IsNullOrWhiteSpace(secondaryPassword))
                return;

            var blowfish = new Blowfish();
            byte[] key = { 0x0F, 0x07, 0x3D, 0x20, 0x56, 0x62, 0xC9, 0xEB };
            blowfish.Initialize(key);

            var encodedBuffer = blowfish.Encode(Encoding.ASCII.GetBytes(secondaryPassword));

            var packet = new Packet(0x6117, true);
            packet.WriteByte(4);
            packet.WriteUShort(secondaryPassword.Length);
            packet.WriteByteArray(encodedBuffer);
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }

        /// <summary>
        /// Sends the login request.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="server">The server.</param>
        private static void SendLoginRequest(Account account, Models.Server server)
        {
            Log.Notify("Sending login credentials to the server...");

            ushort opcode = 0x6102;
            if (Game.ClientType >= GameClientType.Global)
                opcode = 0x610A;

            var loginPacket = new Packet(opcode, true);
            loginPacket.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
            loginPacket.WriteString(account.Username);
            loginPacket.WriteString(account.Password);

            if (opcode == 0x610A)
                loginPacket.WriteByteArray(new byte[6]); // mac

            loginPacket.WriteUShort(server.Id);

            if (opcode == 0x610A)
                loginPacket.WriteByte(1); // unknown!

            loginPacket.Lock();

            PacketManager.SendPacket(loginPacket, PacketDestination.Server);

            Accounts.Joined = account;
            Serverlist.Joining = server;

            _busy = false;
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