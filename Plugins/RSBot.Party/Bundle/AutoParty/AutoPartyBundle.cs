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
                LeaveIfMasterNot = PlayerConfig.Get<bool>("RSBot.Party.LeaveIfMasterNot"),
                LeaveIfMasterNotName = PlayerConfig.Get<string>("RSBot.Party.LeaveIfMasterNotName"),
                CenterPosition = new Position
                {
                    XCoordinate = PlayerConfig.Get<float>("RSBot.Area.X"),
                    YCoordinate = PlayerConfig.Get<float>("RSBot.Area.Y")
                }
            };

            if (!Game.Party.IsInParty)
                Game.Party.Settings = new PartySettings(Config.ExperienceAutoShare, Config.ItemAutoShare, Config.AllowInvitations);
        }

        public void OnTick()
        {
            var elapsed = Kernel.TickCount - _lastTick;
            if (elapsed > 5000)
            {
                CheckForPlayers();
                _lastTick = Kernel.TickCount;
            }
        }

        /// <summary>
        /// Checks for players that can be invited.
        /// </summary>
        public void CheckForPlayers()
        {
            if (Game.Party.IsInParty && 
                !Game.Party.IsLeader &&
                Config.LeaveIfMasterNot && 
                !string.IsNullOrWhiteSpace(Config.LeaveIfMasterNotName))
            {
                if (Config.LeaveIfMasterNotName != Game.Party.Leader.Name)
                    Game.Party.Leave();
            }

            if (!Game.Party.CanInvite) 
                return;

            var limit = 8;
            if (!Game.Party.Settings.ExperienceAutoShare && !Game.Party.Settings.ItemAutoShare)
                limit = 4;

            if (Game.Party.Members?.Count > limit)
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

                if(Config.InviteAll)
                {
                    Game.Party.Invite(player.UniqueId); 
                    continue;
                }

                if (Config.PlayerList.Contains(player.Name) && Config.InviteFromList)
                    Game.Party.Invite(player.UniqueId);
            }
        }
    }
}