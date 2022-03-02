using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;
using RSBot.Core.Objects.Spawn;
using System;
using System.Linq;

namespace RSBot.Party.Bundle.AutoParty
{
    internal class AutoPartyBundle
    {
        /// <summary>
        /// Last tick for checking party members
        /// </summary>
        private int _lastTick;

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public AutoPartyConfig Config { get; set; }
        
        /// <summary>
        /// Initialize this instance
        /// </summary>
        public AutoPartyBundle()
        {
            EventManager.SubscribeEvent("OnTick", OnTick);
        }

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

        public void OnTick()
        {
            if (!Kernel.Bot.Running)
                return;

            var elapsed = Environment.TickCount - _lastTick;
            if (elapsed > 1000)
            {
                CheckForPlayers();
                _lastTick = Environment.TickCount;
            }
        }

        /// <summary>
        /// Checks for players that can be invited.
        /// </summary>
        public void CheckForPlayers()
        {
            if (!Game.Party.CanInvite) 
                return;

            if (Config.OnlyAtTrainingPlace &&
                Game.Player.Movement.Source.DistanceTo(Config.CenterPosition) > 50) 
                return;

            if (!SpawnManager.TryGetEntities<SpawnedPlayer>(out var players))
                return;

            foreach (var player in players)
            {
                if (Game.Party.IsInParty && Game.Party.GetMemberByName(player.Name) != null) 
                    continue;

                if (Config.InviteAll || Config.PlayerList.Contains(player.Name) && Config.InviteFromList)
                    Game.Party.Invite(player.UniqueId);
            }
        }
    }
}