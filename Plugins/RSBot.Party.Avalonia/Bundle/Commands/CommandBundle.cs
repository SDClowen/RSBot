using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Party.Bundle.Commands;

/// <summary>
/// Manages party-related commands and their execution
/// </summary>
internal class CommandBundle
{
    private readonly Dictionary<string, Action<string>> _commands;

    /// <summary>
    /// Gets or sets the configuration for commands
    /// </summary>
    public CommandConfig Config { get; set; }

    /// <summary>
    /// Initializes a new instance of the CommandBundle class
    /// </summary>
    public CommandBundle()
    {
        _commands = new Dictionary<string, Action<string>>
        {
            { "!pt", HandlePartyCommand },
            { "!party", HandlePartyCommand },
            { "!follow", HandleFollowCommand },
            { "!unfollow", HandleUnfollowCommand },
            { "!recall", HandleRecallCommand },
            { "!return", HandleReturnCommand },
            { "!buff", HandleBuffCommand },
            { "!buffall", HandleBuffAllCommand },
            { "!buffme", HandleBuffMeCommand },
            { "!buffparty", HandleBuffPartyCommand },
            { "!buffpet", HandleBuffPetCommand },
            { "!buffallpets", HandleBuffAllPetsCommand },
            { "!buffpartypets", HandleBuffPartyPetsCommand },
            { "!buffmypet", HandleBuffMyPetCommand }
        };

        EventManager.SubscribeEvent("OnPartyChat", new Action<string, string>(OnPartyChat));
        EventManager.SubscribeEvent("OnWhisper", new Action<string, string>(OnWhisper));
    }

    /// <summary>
    /// Refreshes the configuration from settings
    /// </summary>
    public void Refresh()
    {
        Config = new CommandConfig
        {
            EnableCommands = PlayerConfig.Get<bool>("RSBot.Party.Commands.Enable"),
            EnableWhisperCommands = PlayerConfig.Get<bool>("RSBot.Party.Commands.EnableWhisper"),
            EnablePartyCommands = PlayerConfig.Get<bool>("RSBot.Party.Commands.EnableParty"),
            AllowedPlayers = PlayerConfig.GetArray<string>("RSBot.Party.Commands.AllowedPlayers"),
            AllowedPartyCommands = PlayerConfig.GetArray<string>("RSBot.Party.Commands.AllowedPartyCommands"),
            AllowedWhisperCommands = PlayerConfig.GetArray<string>("RSBot.Party.Commands.AllowedWhisperCommands")
        };
    }

    /// <summary>
    /// Handles party chat messages
    /// </summary>
    private void OnPartyChat(string sender, string message)
    {
        if (!Config.EnableCommands || !Config.EnablePartyCommands)
            return;

        var command = message.Split(' ')[0].ToLower();
        if (!_commands.ContainsKey(command))
            return;

        if (!Config.AllowedPartyCommands.Contains(command))
            return;

        if (!Config.AllowedPlayers.Contains(sender))
            return;

        _commands[command](message);
    }

    /// <summary>
    /// Handles whisper messages
    /// </summary>
    private void OnWhisper(string sender, string message)
    {
        if (!Config.EnableCommands || !Config.EnableWhisperCommands)
            return;

        var command = message.Split(' ')[0].ToLower();
        if (!_commands.ContainsKey(command))
            return;

        if (!Config.AllowedWhisperCommands.Contains(command))
            return;

        if (!Config.AllowedPlayers.Contains(sender))
            return;

        _commands[command](message);
    }

    /// <summary>
    /// Handles party-related commands
    /// </summary>
    private void HandlePartyCommand(string message)
    {
        var args = message.Split(' ');
        if (args.Length < 2)
            return;

        var action = args[1].ToLower();
        switch (action)
        {
            case "invite":
                if (args.Length < 3)
                    return;

                var playerName = args[2];
                var player = SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == playerName);
                if (player != null)
                    Game.Party.Invite(player.UniqueId);
                break;

            case "leave":
                Game.Party.Leave();
                break;

            case "kick":
                if (args.Length < 3)
                    return;

                var memberName = args[2];
                var member = Game.Party.GetMemberByName(memberName);
                if (member != null)
                    Game.Party.Kick(member.Id);
                break;
        }
    }

    /// <summary>
    /// Handles follow command
    /// </summary>
    private void HandleFollowCommand(string message)
    {
        var args = message.Split(' ');
        var target = args.Length > 1 ? args[1] : Game.Party.Leader?.Name;

        if (string.IsNullOrEmpty(target))
            return;

        var entity = SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == target);
        if (entity == null)
            return;

        Game.Player.StartFollowing(entity);
    }

    /// <summary>
    /// Handles unfollow command
    /// </summary>
    private void HandleUnfollowCommand(string message)
    {
        Game.Player.StopFollowing();
    }

    /// <summary>
    /// Handles recall command
    /// </summary>
    private void HandleRecallCommand(string message)
    {
        Game.Player.UseRecallScroll();
    }

    /// <summary>
    /// Handles return command
    /// </summary>
    private void HandleReturnCommand(string message)
    {
        Game.Player.UseReturnScroll();
    }

    /// <summary>
    /// Handles buff command
    /// </summary>
    private void HandleBuffCommand(string message)
    {
        var args = message.Split(' ');
        if (args.Length < 2)
            return;

        var target = args[1];
        var entity = SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == target);
        if (entity == null)
            return;

        Game.Player.CastBuffs(entity);
    }

    /// <summary>
    /// Handles buff all command
    /// </summary>
    private void HandleBuffAllCommand(string message)
    {
        if (!SpawnManager.TryGetEntities<SpawnedPlayer>(out var players))
            return;

        foreach (var player in players)
            Game.Player.CastBuffs(player);
    }

    /// <summary>
    /// Handles buff me command
    /// </summary>
    private void HandleBuffMeCommand(string message)
    {
        Game.Player.CastBuffs(Game.Player.Movement.Source);
    }

    /// <summary>
    /// Handles buff party command
    /// </summary>
    private void HandleBuffPartyCommand(string message)
    {
        if (!Game.Party.IsInParty)
            return;

        foreach (var member in Game.Party.Members)
        {
            var entity = SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == member.Name);
            if (entity != null)
                Game.Player.CastBuffs(entity);
        }
    }

    /// <summary>
    /// Handles buff pet command
    /// </summary>
    private void HandleBuffPetCommand(string message)
    {
        var args = message.Split(' ');
        if (args.Length < 2)
            return;

        var target = args[1];
        var player = SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == target);
        if (player?.JobTransport == null)
            return;

        Game.Player.CastBuffs(player.JobTransport);
    }

    /// <summary>
    /// Handles buff all pets command
    /// </summary>
    private void HandleBuffAllPetsCommand(string message)
    {
        if (!SpawnManager.TryGetEntities<SpawnedPlayer>(out var players))
            return;

        foreach (var player in players.Where(p => p.JobTransport != null))
            Game.Player.CastBuffs(player.JobTransport);
    }

    /// <summary>
    /// Handles buff party pets command
    /// </summary>
    private void HandleBuffPartyPetsCommand(string message)
    {
        if (!Game.Party.IsInParty)
            return;

        foreach (var member in Game.Party.Members)
        {
            var entity = SpawnManager.GetEntity<SpawnedPlayer>(p => p.Name == member.Name);
            if (entity?.JobTransport != null)
                Game.Player.CastBuffs(entity.JobTransport);
        }
    }

    /// <summary>
    /// Handles buff my pet command
    /// </summary>
    private void HandleBuffMyPetCommand(string message)
    {
        if (Game.Player.JobTransport != null)
            Game.Player.CastBuffs(Game.Player.JobTransport);
    }
} 