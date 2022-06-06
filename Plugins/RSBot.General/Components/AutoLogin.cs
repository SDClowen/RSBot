using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Network.SecurityAPI;
using RSBot.General.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSBot.General.PacketHandler;

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
            {
                _busy = false;

                await Task.Delay(5000);
                ClientlessManager.RequestServerList();
                return;
            }

            var selectedAccount = Accounts.SavedAccounts.Find(p => p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername"));
            if (selectedAccount == null)
            {
                _busy = false;
                Log.WarnLang("NoHaveAccountForAutoLogin");
                await Task.Delay(5000);
                ClientlessManager.RequestServerList();
                return;
            }

            var server = Serverlist.GetServerByName(selectedAccount.Servername);
            if (server == null && Serverlist.Servers != null)
            {
                Log.NotifyLang("ServerNotFound", selectedAccount.Servername);

                server = Serverlist.Servers.First();

                Log.NotifyLang("SelectedFirstServer", server.Name);
            }

            // is server check [Lazy :)]
            if (!server.Status)
            {
                _busy = false;

                Log.NotifyLang("ServerCheck");

                await Task.Delay(5000);
                ClientlessManager.RequestServerList();

                return;
            }

            await Task.Delay(10_000);
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
            Log.NotifyLang("LoginCredentials", server.Name);

            ushort opcode = 0x6102;
            if (Game.ClientType >= GameClientType.Global)
                opcode = 0x610A;

            var loginPacket = new Packet(opcode, true);
            loginPacket.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
            loginPacket.WriteString(account.Username);
            loginPacket.WriteString(account.Password);

            if (Game.ClientType == GameClientType.Turkey)
                loginPacket.WriteByteArray(new byte[6]); // mac

            loginPacket.WriteUShort(server.Id);

            if (opcode == 0x610A)
                loginPacket.WriteByte(account.Channel);

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

            Log.NotifyLang("EnteringCaptcha", captcha);

            var packet = new Packet(0x6323);
            packet.WriteString(captcha);

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
            PacketManager.SendPacket(packet, PacketDestination.Server);

            PlayerConfig.Load(character);

            EventManager.FireEvent("OnEnterGame");
        }
    }
}