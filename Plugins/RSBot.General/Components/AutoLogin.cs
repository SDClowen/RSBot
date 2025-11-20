using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Core.Network.Protocol;
using RSBot.General.Models;
using Server = RSBot.General.Models.Server;

namespace RSBot.General.Components;

internal static class AutoLogin
{
    /// <summary>
    ///     Is the auto login pending <c>true</c> otherwise; <c>false</c>
    /// </summary>
    public static bool Pending;

    public static CancellationTokenSource? Cts { get; private set; }

    /// <summary>
    ///     Is the auto login handling <c>true</c> otherwise; <c>false</c>
    /// </summary>
    private static bool _busy;

    /// <summary>
    ///     Does the automatic login.
    /// </summary>
    public static async void Handle()
    {
        if (Pending)
            return;

        if (_busy)
            return;

        Log.StatusLang("WaitingUser");

        _busy = true;

        if (!GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin"))
        {
            _busy = false;

            await Task.Delay(5000);
            ClientlessManager.RequestServerList();
            return;
        }

        var selectedAccount = Accounts.SavedAccounts?.Find(p =>
            p.Username == GlobalConfig.Get<string>("RSBot.General.AutoLoginAccountUsername")
        );
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

        //Wait for the configured delay before sending the login request
        //It is possible to cancel in case of manual login to the server
        if (GlobalConfig.Get("RSBot.General.EnableLoginDelay", false))
        {
            var delay = GlobalConfig.Get("RSBot.General.LoginDelay", 10) * 1000;
            Cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(delay, Cts.Token);
            }
            catch (TaskCanceledException)
            {
                _busy = false;
                Log.Debug("Manual login has been detected. AutoLogin is cancelled this time!");
                return;
            }
            finally
            {
                Cts.Dispose();
                Cts = null;
            }
        }

        SendLoginRequest(selectedAccount, server);
    }

    /// <summary>
    ///     Sends the secondary password if have.
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

        Blowfish blowfish = new();
        byte[] key = { 0x0F, 0x07, 0x3D, 0x20, 0x56, 0x62, 0xC9, 0xEB };

        if (Game.ClientType == GameClientType.Rigid)
            key = key.Reverse().ToArray();

        blowfish.Initialize(key);

        var encodedBuffer = blowfish.Encode(Encoding.ASCII.GetBytes(secondaryPassword));

        var packet = new Packet(0x6117, true);
        packet.WriteByte(4);
        packet.WriteUShort(secondaryPassword.Length);
        packet.WriteBytes(encodedBuffer);
        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Sends the login request.
    /// </summary>
    /// <param name="account">The account.</param>
    /// <param name="server">The server.</param>
    private static void SendLoginRequest(Account account, Server server)
    {
        Log.NotifyLang("LoginCredentials", server.Name);

        ushort opcode = 0x6102;
        if (Game.ClientType >= GameClientType.Chinese)
            opcode = 0x610A;

        var loginPacket = new Packet(opcode, true);
        loginPacket.WriteByte(Game.ReferenceManager.DivisionInfo.Locale);
        if (Game.ClientType == GameClientType.RuSro)
        {
            loginPacket.WriteString(GlobalConfig.Get<string>("RSBot.RuSro.login"));
            loginPacket.WriteString(GlobalConfig.Get<string>("RSBot.RuSro.password"));
        }
        else if (Game.ClientType == GameClientType.Japanese)
        {
            loginPacket.WriteString(string.Empty);
            loginPacket.WriteString(GlobalConfig.Get<string>("RSBot.JSRO.token"));
        }
        else
        {
            loginPacket.WriteString(account.Username);
            loginPacket.WriteString(account.Password);
        }

        Game.MacAddress = GenerateMacAddress();

        if (
            Game.ClientType == GameClientType.Turkey
            || Game.ClientType == GameClientType.VTC_Game
            || Game.ClientType == GameClientType.RuSro
            || Game.ClientType == GameClientType.Korean
            || Game.ClientType == GameClientType.Japanese
            || Game.ClientType == GameClientType.Taiwan
        )
            loginPacket.WriteBytes(Game.MacAddress);

        loginPacket.WriteUShort(server.Id);

        if (opcode == 0x610A)
            loginPacket.WriteByte(account.Channel);

        PacketManager.SendPacket(loginPacket, PacketDestination.Server);

        Accounts.Joined = account;
        Serverlist.Joining = server;

        _busy = false;
    }

    /// <summary>
    ///     Generates valid MAC address.
    /// </summary>
    /// <returns></returns>
    private static byte[] GenerateMacAddress()
    {
        Random rand = new Random();
        byte firstByte = (byte)(rand.Next(0, 256) & 0xFE);

        byte[] macBytes = new byte[6];
        macBytes[0] = firstByte;
        for (int i = 1; i < 6; i++)
        {
            macBytes[i] = (byte)rand.Next(0, 256);
        }

        return macBytes;
    }

    /// <summary>
    ///     Sends the static captcha.
    /// </summary>
    public static void SendStaticCaptcha()
    {
        if (
            !GlobalConfig.Get<bool>("RSBot.General.EnableStaticCaptcha")
            || !GlobalConfig.Get<bool>("RSBot.General.EnableAutomatedLogin")
        )
            return;

        var captcha = GlobalConfig.Get<string>("RSBot.General.StaticCaptcha");
        captcha ??= string.Empty;

        Log.NotifyLang("EnteringCaptcha", captcha);

        var packet = new Packet(0x6323);
        packet.WriteString(captcha);

        PacketManager.SendPacket(packet, PacketDestination.Server);
    }

    /// <summary>
    ///     Enters the game.
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
