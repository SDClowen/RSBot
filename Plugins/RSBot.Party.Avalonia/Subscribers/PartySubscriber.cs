using System;
using System.Collections.Generic;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;
using RSBot.Party.Bundle.PartyMatching.Objects;

namespace RSBot.Party.Subscribers;

/// <summary>
/// Handles party-related events and updates the party management system
/// </summary>
internal class PartySubscriber
{
    /// <summary>
    /// Initializes the party subscriber and subscribes to events
    /// </summary>
    public static void Initialize()
    {
        SubscribeEvents();
        Log.Debug("[Party] Subscriber initialized");
    }

    /// <summary>
    /// Subscribes to party-related events
    /// </summary>
    private static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnPartyMatchingList", new Action<List<PartyEntry>>(OnPartyMatchingList));
        EventManager.SubscribeEvent("OnPartyMemberJoined", new Action<PartyMember>(OnPartyMemberJoined));
        EventManager.SubscribeEvent("OnPartyMemberLeft", new Action<PartyMember>(OnPartyMemberLeft));
        EventManager.SubscribeEvent("OnPartyMemberKicked", new Action<PartyMember>(OnPartyMemberKicked));
        EventManager.SubscribeEvent("OnPartyDismissed", OnPartyDismissed);
        EventManager.SubscribeEvent("OnPartyInvite", new Action<string>(OnPartyInvite));
        EventManager.SubscribeEvent("OnPartyInviteRefused", new Action<string>(OnPartyInviteRefused));
        EventManager.SubscribeEvent("OnPartyInviteAccepted", new Action<string>(OnPartyInviteAccepted));
    }

    /// <summary>
    /// Handles the party matching list update event
    /// </summary>
    private static void OnPartyMatchingList(List<PartyEntry> entries)
    {
        try
        {
            Bundle.Container.PartyMatching.UpdateList(entries);
            Log.Debug($"[Party] Updated party matching list with {entries.Count} entries");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to update party matching list: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the party member joined event
    /// </summary>
    private static void OnPartyMemberJoined(PartyMember member)
    {
        try
        {
            Log.Debug($"[Party] Member joined: {member.Name}");

            if (Bundle.Container.AutoParty.Config.ExperienceAutoShare)
                Game.Party.Settings.ExperienceAutoShare = true;

            if (Bundle.Container.AutoParty.Config.ItemAutoShare)
                Game.Party.Settings.ItemAutoShare = true;
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to handle member joined event: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the party member left event
    /// </summary>
    private static void OnPartyMemberLeft(PartyMember member)
    {
        try
        {
            Log.Debug($"[Party] Member left: {member.Name}");

            if (Game.Party.Members.Count == 1)
                Game.Party.Settings = new PartySettings(
                    Bundle.Container.AutoParty.Config.ExperienceAutoShare,
                    Bundle.Container.AutoParty.Config.ItemAutoShare,
                    Bundle.Container.AutoParty.Config.AllowInvitations);
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to handle member left event: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the party member kicked event
    /// </summary>
    private static void OnPartyMemberKicked(PartyMember member)
    {
        try
        {
            Log.Debug($"[Party] Member kicked: {member.Name}");

            if (Game.Party.Members.Count == 1)
                Game.Party.Settings = new PartySettings(
                    Bundle.Container.AutoParty.Config.ExperienceAutoShare,
                    Bundle.Container.AutoParty.Config.ItemAutoShare,
                    Bundle.Container.AutoParty.Config.AllowInvitations);
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to handle member kicked event: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the party dismissed event
    /// </summary>
    private static void OnPartyDismissed()
    {
        try
        {
            Log.Debug("[Party] Party dismissed");

            Game.Party.Settings = new PartySettings(
                Bundle.Container.AutoParty.Config.ExperienceAutoShare,
                Bundle.Container.AutoParty.Config.ItemAutoShare,
                Bundle.Container.AutoParty.Config.AllowInvitations);
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to handle party dismissed event: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the party invite event
    /// </summary>
    private static void OnPartyInvite(string inviter)
    {
        try
        {
            var config = Bundle.Container.AutoParty.Config;

            if (!config.AcceptAll && !config.AcceptFromList)
                return;

            if (!config.AcceptIfBotIsStopped && !Kernel.Bot.Running)
                return;

            if (config.OnlyAtTrainingPlace &&
                Game.Player.Movement.Source.DistanceTo(config.CenterPosition) > 50)
                return;

            if (config.AcceptAll || (config.AcceptFromList && config.PlayerList.Contains(inviter)))
                Game.Party.Accept();
            else
                Game.Party.Decline();

            Log.Debug($"[Party] Handled party invite from {inviter}");
        }
        catch (Exception ex)
        {
            Log.Error($"[Party] Failed to handle party invite event: {ex.Message}");
        }
    }

    /// <summary>
    /// Handles the party invite refused event
    /// </summary>
    private static void OnPartyInviteRefused(string player)
    {
        Log.Debug($"[Party] Invite refused by {player}");
    }

    /// <summary>
    /// Handles the party invite accepted event
    /// </summary>
    private static void OnPartyInviteAccepted(string player)
    {
        Log.Debug($"[Party] Invite accepted by {player}");
    }
} 