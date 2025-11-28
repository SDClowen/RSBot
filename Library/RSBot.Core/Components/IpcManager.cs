using System;
using System.Threading.Tasks;
using RSBot.Core.Event;
using RSBot.IPC;

namespace RSBot.Core.Components
{
    public class IpcManager
    {
        private static NamedPipeClient _pipeClient;
        private static string _pipeName;

        public static void Initialize(string pipeName)
        {
            if (string.IsNullOrEmpty(pipeName))
                return;

            _pipeName = pipeName;
            _pipeClient = new NamedPipeClient(_pipeName, Log.Debug);
            _pipeClient.Connected += OnConnected;
            _pipeClient.Disconnected += OnDisconnected;
            _pipeClient.MessageReceived += OnMessageReceived;

            _ = _pipeClient.ConnectAsync();
        }

        private static async void OnConnected()
        {
            Log.Debug("IPC: Connected to server.");

            var profileName = ProfileManager.SelectedProfile;
            if (!string.IsNullOrEmpty(profileName))
            {
                var command = new IpcCommand
                {
                    CommandType = CommandType.RegisterBot,
                    Profile = profileName,
                    RequestId = Guid.NewGuid().ToString(),
                };
                await _pipeClient.SendMessageAsync(command.ToJson());
                Log.Debug($"IPC: Sent registration for profile '{profileName}'.");
            }
        }

        private static void OnDisconnected()
        {
            Log.Debug("IPC: Disconnected from server. Reconnecting...");
            Task.Delay(5000).ContinueWith(t => _pipeClient.ConnectAsync());
        }

        private static async void OnMessageReceived(string message)
        {
            Log.Debug($"IPC: Message received: {message}");

            try
            {
                IpcCommand command = IpcCommand.FromJson(message);
                if (command != null)
                {
                    IpcResponse response = await HandleCommand(command);

                    if (response != null)
                    {
                        await _pipeClient.SendMessageAsync(response.ToJson());
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"IPC: Error processing message: {ex.Message}");
            }
        }

        private static async Task<IpcResponse> HandleCommand(IpcCommand command)
        {
            var response = new IpcResponse
            {
                RequestId = command.RequestId,
                Success = true,
                Message = "Command processed.",
            };

            switch (command.CommandType)
            {
                case CommandType.Stop:
                    Kernel.Bot.Stop();
                    response.Message = "Bot stopped.";
                    break;

                case CommandType.Start:
                    Kernel.Bot.Start();
                    response.Message = "Bot started.";
                    break;

                case CommandType.GetInfo:
                    response.Payload = new
                    {
                        Profile = ProfileManager.SelectedProfile,
                        Character = Game.Player?.Name,
                        Location = Game.Player?.Position.ToString(),
                        Uptime = Kernel.Bot.Uptime,
                        Botbase = Kernel.Bot.Botbase?.Name,
                        ClientVisible = !Game.Clientless,
                    }.ToString();
                    break;

                case CommandType.SetVisibility:
                    bool visible = bool.Parse(command.Payload);
                    EventManager.FireEvent("OnSetVisibility", visible);
                    response.Message = $"Window visibility set to {visible}.";
                    break;

                case CommandType.GoClientless:
                    EventManager.FireEvent("OnGoClientless");
                    response.Message = "Switched to clientless mode.";
                    break;

                case CommandType.SetClientVisibility:
                    bool clientVisible = bool.Parse(command.Payload);
                    ClientManager.SetVisible(clientVisible);
                    response.Message = $"Client window visibility set to {clientVisible}.";
                    break;

                case CommandType.LaunchClient:
                    var started = await ClientManager.Start();
                    response.Success = started;
                    response.Message = started ? "Client launched successfully." : "Failed to launch client.";
                    break;

                case CommandType.KillClient:
                    ClientManager.Kill();
                    response.Message = "Client killed.";
                    break;

                default:
                    response.Success = false;
                    response.Message = $"Unknown command type: {command.CommandType}";
                    break;
            }

            return response;
        }
    }
}
