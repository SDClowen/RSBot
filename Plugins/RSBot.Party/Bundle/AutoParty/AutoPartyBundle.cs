using RSBot.Core;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;
using System.Linq;
using System.Threading;

namespace RSBot.Party.Bundle.AutoParty
{
    internal class AutoPartyBundle
    {
        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public AutoPartyConfig Config { get; set; }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            Config = new AutoPartyConfig
            {
                PlayerList = PlayerConfig.GetArray<string>("RSBot.Party.AutoPartyList"),
                InviteAll = PlayerConfig.Get<bool>("RSBot.Party.InviteAll"),
                AcceptAll = PlayerConfig.Get<bool>("RSBot.Party.AcceptAll"),
                AcceptFromList = PlayerConfig.Get<bool>("RSBot.Party.AcceptList"),
                InviteFromList = PlayerConfig.Get<bool>("RSBot.Party.InviteList"),
                OnlyAtTrainingPlace = PlayerConfig.Get<bool>("RSBot.Party.AtTrainingPlace"),
                ExperienceAutoShare = PlayerConfig.Get<bool>("RSBot.Party.EXPAutoShare"),
                ItemAutoShare = PlayerConfig.Get<bool>("RSBot.Party.ItemAutoShare"),
                AllowInvitations = PlayerConfig.Get<bool>("RSBot.Party.AllowInvitations"),
                AcceptIfBotIsStopped = PlayerConfig.Get<bool>("RSBot.Party.AcceptIfBotStopped"),
                CenterPosition = new Position
                {
                    XSector = PlayerConfig.Get<byte>("RSBot.Area.XSec"),
                    YSector = PlayerConfig.Get<byte>("RSBot.Area.YSec"),
                    XCoordinate = PlayerConfig.Get<float>("RSBot.Area.X"),
                    YCoordinate = PlayerConfig.Get<float>("RSBot.Area.Y")
                }
            };

            if (!Game.Party.IsInParty)
                Game.Party.Settings = new PartySettings(Config.ExperienceAutoShare, Config.ItemAutoShare, Config.AllowInvitations);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            while (Kernel.Bot.Running || Kernel.Bot.IsStarting)
            {
                CheckForPlayers();

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Checks for players that can be invited.
        /// </summary>
        public void CheckForPlayers()
        {
            if (!Game.Party.CanInvite) return;
            if (Config.OnlyAtTrainingPlace &&
                Game.Player.Tracker.Position.DistanceTo(Config.CenterPosition) > 50) return;

            foreach (var player in Game.Spawns.GetPlayers())
            {
                if (Game.Party.IsInParty && Game.Party.GetMemberByName(player.Name) != null) continue;

                if (Config.InviteAll || Config.PlayerList.Contains(player.Name) && Config.InviteFromList)
                    Game.Party.Invite(player.Bionic.UniqueId);
            }
        }
    }
}