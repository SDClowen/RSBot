using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json;
using RSBot.IPC;

namespace RSBot.Server
{
    internal class Program
    {
        private static NamedPipeServer _serverPipe;
        private static readonly ConcurrentDictionary<string, string> _botClientConnections = new ConcurrentDictionary<string, string>(); // Profile -> ClientPipeId
        private static readonly ConcurrentDictionary<string, string> _cliRequestMap = new ConcurrentDictionary<string, string>(); // RequestId -> CliClientPipeId

        public class Options
        {
            [Option("pipename", Required = false, HelpText = "The name of the pipe to listen on.", Default = "RSBotIpcServer")]
            public string PipeName { get; set; }
        }

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       RunServer(o.PipeName);
                   });
        }

        static void RunServer(string pipeName)
        {
            Console.WriteLine("RSBot IPC Server Starting...");

            _serverPipe = new NamedPipeServer(pipeName);
            _serverPipe.ClientConnected += OnClientConnected;
            _serverPipe.ClientDisconnected += OnClientDisconnected;
            _serverPipe.MessageReceived += OnMessageReceived;

            _serverPipe.Start();

            Console.WriteLine($"IPC Server listening on pipe: {pipeName}");
            Console.WriteLine("Press any key to stop the server.");
            Console.ReadKey();

            _serverPipe.Stop();
            Console.WriteLine("RSBot IPC Server Stopped.");
        }

        private static void OnClientConnected(string clientPipeId)
        {
            Console.WriteLine($"Client connected: {clientPipeId}");
        }

        private static void OnClientDisconnected(string clientPipeId)
        {
            Console.WriteLine($"Client disconnected: {clientPipeId}");

            // Remove from bot client connections
            var botEntry = _botClientConnections.FirstOrDefault(x => x.Value == clientPipeId);
            if (botEntry.Key != null)
            {
                _botClientConnections.TryRemove(botEntry.Key, out _);
                Console.WriteLine($"Bot client '{botEntry.Key}' removed.");
            }

            // Also check if the disconnected client has pending requests in the map
            var requestsToRemove = _cliRequestMap.Where(kvp => kvp.Value == clientPipeId).Select(kvp => kvp.Key).ToList();
            foreach (var requestId in requestsToRemove)
            {
                _cliRequestMap.TryRemove(requestId, out _);
                Console.WriteLine($"Removed pending request '{requestId}' for disconnected client.");
            }
        }

        private static async void OnMessageReceived(string clientPipeId, string message)
        {
            Console.WriteLine($"Message received from {clientPipeId}: {message}");

            // Try to parse as IpcCommand first
            try
            {
                IpcCommand command = IpcCommand.FromJson(message);
                if (command != null)
                {
                    if (command.CommandType == CommandType.RegisterBot)
                    {
                        // This is a registration command from a bot client
                        string profileName = command.Profile;
                        if (!string.IsNullOrEmpty(profileName))
                        {
                            _botClientConnections[profileName] = clientPipeId;
                            Console.WriteLine($"Bot client for profile '{profileName}' registered with pipe ID {clientPipeId}.");
                        }
                    }
                    else
                    {
                        // This is a command from a CLI client
                        if (!string.IsNullOrEmpty(command.RequestId))
                        {
                            _cliRequestMap[command.RequestId] = clientPipeId;
                        }

                        Console.WriteLine($"Received command '{command.CommandType}' for profile '{command.Profile}' from CLI client {clientPipeId}");

                        if (_botClientConnections.TryGetValue(command.Profile, out string botClientPipeId))
                        {
                            Console.WriteLine($"Routing command to bot client {botClientPipeId} for profile '{command.Profile}'");
                            await _serverPipe.SendMessageToClientAsync(botClientPipeId, message);
                        }
                        else
                        {
                            // Bot client not found, send error response back to CLI client
                            IpcResponse errorResponse = new IpcResponse
                            {
                                RequestId = command.RequestId,
                                Success = false,
                                Message = $"Bot client for profile '{command.Profile}' not found.",
                                Payload = ""
                            };
                            await _serverPipe.SendMessageToClientAsync(clientPipeId, errorResponse.ToJson());
                            _cliRequestMap.TryRemove(command.RequestId, out _); // Clean up the request map
                        }
                    }
                    return;
                }
            }
            catch (JsonException) { /* Not an IpcCommand, proceed to check if it's an IpcResponse */ }

            // Try to parse as IpcResponse
            try
            {
                IpcResponse response = IpcResponse.FromJson(message);
                if (response != null && !string.IsNullOrEmpty(response.RequestId))
                {
                    // This is a response from a bot client
                    Console.WriteLine($"Received response for request '{response.RequestId}' from bot client {clientPipeId}");

                    if (_cliRequestMap.TryRemove(response.RequestId, out string cliClientPipeId))
                    {
                        Console.WriteLine($"Routing response back to CLI client {cliClientPipeId}");
                        await _serverPipe.SendMessageToClientAsync(cliClientPipeId, message);
                    }
                    else
                    {
                        Console.WriteLine($"Could not find originating CLI client for request ID '{response.RequestId}'.");
                    }
                }
            }
            catch (JsonException)
            {
                Console.WriteLine($"Received unparseable message from {clientPipeId}: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message from {clientPipeId}: {ex.Message}");
            }
        }
    }
}
