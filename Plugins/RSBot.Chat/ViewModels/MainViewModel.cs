using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Reactive;
using System.Threading.Tasks;


namespace RSBot.Chat.ViewModels;

/// <summary>
/// View model for the main chat window that manages all chat tabs and message routing
/// </summary>
public class MainViewModel : ReactiveObject
{
    private string _receiverText;

    #region Chat Tabs

    public ChatTabViewModel AllChat { get; }
    public ChatTabViewModel PrivateChat { get; }
    public ChatTabViewModel PartyChat { get; }
    public ChatTabViewModel GuildChat { get; }
    public ChatTabViewModel UnionChat { get; }
    public ChatTabViewModel AcademyChat { get; }
    public ChatTabViewModel GlobalChat { get; }
    public ChatTabViewModel StallChat { get; }
    public ChatTabViewModel UniqueChat { get; }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the receiver's name for private messages
    /// </summary>
    public string ReceiverText
    {
        get => _receiverText;
        set => this.RaiseAndSetIfChanged(ref _receiverText, value);
    }

    #endregion

    #region Commands

    /// <summary>
    /// Gets the command for sending messages to all chat
    /// </summary>
    public ReactiveCommand<Unit, Unit> SendAllCommand { get; private set; }

    /// <summary>
    /// Gets the command for sending private messages
    /// </summary>
    public ReactiveCommand<Unit, Unit> SendPrivateCommand { get; private set; }

    /// <summary>
    /// Gets the command for sending messages to party chat
    /// </summary>
    public ReactiveCommand<Unit, Unit> SendPartyCommand { get; private set; }

    /// <summary>
    /// Gets the command for sending messages to guild chat
    /// </summary>
    public ReactiveCommand<Unit, Unit> SendGuildCommand { get; private set; }

    /// <summary>
    /// Gets the command for sending messages to union chat
    /// </summary>
    public ReactiveCommand<Unit, Unit> SendUnionCommand { get; private set; }

    /// <summary>
    /// Gets the command for sending messages to academy chat
    /// </summary>
    public ReactiveCommand<Unit, Unit> SendAcademyCommand { get; private set; }

    /// <summary>
    /// Gets the command for clearing chat history
    /// </summary>
    public ReactiveCommand<ChatType, Unit> ClearChatCommand { get; private set; }

    #endregion

    /// <summary>
    /// Initializes a new instance of the MainViewModel class
    /// </summary>
    /// <param name="chatService">The chat service instance</param>
    public MainViewModel()
    {
        // Initialize chat tabs
        AllChat = new ChatTabViewModel();
        PrivateChat = new ChatTabViewModel();
        PartyChat = new ChatTabViewModel();
        GuildChat = new ChatTabViewModel();
        UnionChat = new ChatTabViewModel();
        AcademyChat = new ChatTabViewModel();
        GlobalChat = new ChatTabViewModel();
        StallChat = new ChatTabViewModel();
        UniqueChat = new ChatTabViewModel();

        InitializeCommands();
        SubscribeToEvents();
    }

    /// <summary>
    /// Initializes the commands for sending messages
    /// </summary>
    private void InitializeCommands()
    {
        SendAllCommand = ReactiveCommand.CreateFromTask(async () => await SendMessage(ChatType.All, AllChat.SendText));
        SendPrivateCommand = ReactiveCommand.CreateFromTask(async () => await SendMessage(ChatType.Private, PrivateChat.SendText, ReceiverText));
        SendPartyCommand = ReactiveCommand.CreateFromTask(async () => await SendMessage(ChatType.Party, PartyChat.SendText));
        SendGuildCommand = ReactiveCommand.CreateFromTask(async () => await SendMessage(ChatType.Guild, GuildChat.SendText));
        SendUnionCommand = ReactiveCommand.CreateFromTask(async () => await SendMessage(ChatType.Union, UnionChat.SendText));
        SendAcademyCommand = ReactiveCommand.CreateFromTask(async () => await SendMessage(ChatType.Academy, AcademyChat.SendText));
        ClearChatCommand = ReactiveCommand.Create<ChatType>(ClearChat);
    }

    /// <summary>
    /// Subscribes to necessary events
    /// </summary>
    private void SubscribeToEvents()
    {
        EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);
        EventManager.SubscribeEvent("OnChatMessage", OnChatMessage);
    }

    /// <summary>
    /// Sends a message and clears the input field
    /// </summary>
    private async Task SendMessage(ChatType type, string message, string receiver = null)
    {
        if (string.IsNullOrEmpty(message))
            return;

        Bundle.Chat.SendChatPacket(type, message, receiver);

        var chatTab = GetChatTab(type);
        if (chatTab != null)
            chatTab.SendText = string.Empty;

        if (type == ChatType.Private)
            await SaveLastWhisperer(receiver);
    }

    /// <summary>
    /// Handles the game enter event
    /// </summary>
    private async void OnEnterGame()
    {
        ReceiverText = await GetLastWhisperer();
    }

    /// <summary>
    /// Handles incoming chat messages
    /// </summary>
    internal void OnChatMessage(string message, ChatType type)
    {
        var chatTab = GetChatTab(type);
        chatTab?.AddMessage(message);
    }

    /// <summary>
    /// Clears the chat history for the specified chat type
    /// </summary>
    private void ClearChat(ChatType type)
    {
        var chatTab = GetChatTab(type);
        chatTab?.Clear();
    }

    /// <summary>
    /// Gets the chat tab for the specified chat type
    /// </summary>
    private ChatTabViewModel GetChatTab(ChatType type)
    {
        return type switch
        {
            ChatType.All => AllChat,
            ChatType.Private => PrivateChat,
            ChatType.Party => PartyChat,
            ChatType.Guild => GuildChat,
            ChatType.Union => UnionChat,
            ChatType.Academy => AcademyChat,
            ChatType.Global => GlobalChat,
            ChatType.Stall => StallChat,
            ChatType.Unique => UniqueChat,
            _ => null
        };
    }

    /// <summary>
    /// Saves the name of the last whisper sender
    /// </summary>
    /// <param name="name">The name of the last whisper sender</param>
    public Task SaveLastWhisperer(string name)
    {
        PlayerConfig.Set("RSBot.Chat.LastWhisper", name);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Gets the name of the last whisper sender
    /// </summary>
    /// <returns>The name of the last whisper sender</returns>
    public Task<string> GetLastWhisperer()
    {
        return Task.FromResult(PlayerConfig.Get<string>("RSBot.Chat.LastWhisper"));
    }
} 