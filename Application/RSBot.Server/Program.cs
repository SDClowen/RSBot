using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using Newtonsoft.Json;
using RSBot.IPC;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RSBot.Server
{
    internal class Program
    {
        public class TimestampedTextWriter : TextWriter
        {
            private readonly TextWriter _innerWriter;

            public TimestampedTextWriter(TextWriter innerWriter)
            {
                _innerWriter = innerWriter;
            }

            public override Encoding Encoding => _innerWriter.Encoding;

            public override void Write(char value)
            {
                _innerWriter.Write(value);
            }

            public override void Write(string value)
            {
                _innerWriter.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {value}");
            }

            public override void WriteLine(string value)
            {
                _innerWriter.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {value}");
            }
        }

        private static NamedPipeServer _serverPipe;
        private static readonly ConcurrentDictionary<string, string> _botClientConnections = new ConcurrentDictionary<string, string>();
        private static readonly ConcurrentDictionary<string, string> _cliRequestMap = new ConcurrentDictionary<string, string>();

        public class Options
        {
            [Option("pipename", Required = false, HelpText = "The name of the pipe to listen on.", Default = "RSBotIPC")]
            public string PipeName { get; set; }
        }

        private static TaskCompletionSource<bool> _serverStopped = new TaskCompletionSource<bool>();

        static async Task Main(string[] args)
        {
            SetupLogging("Server.log");
            await Parser.Default.ParseArguments<Options>(args)
                   .WithParsedAsync(async o =>
                   {
                       await RunServer(o.PipeName);
                   });
        }

        private static void SetupLogging(string logFileName)
        {
            string buildDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logDirectory = Path.Combine(buildDirectory, "User", "Logs", "Environment");
            Directory.CreateDirectory(logDirectory);

            string logFilePath = Path.Combine(logDirectory, logFileName);
            FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream) { AutoFlush = true };
            TextWriter timestampedWriter = new TimestampedTextWriter(streamWriter);

            Console.SetOut(timestampedWriter);
            Console.SetError(timestampedWriter);
        }

        static async Task RunServer(string pipeName)
        {
            Console.WriteLine("RSBot IPC Server Starting...");

            _serverPipe = new NamedPipeServer(pipeName);
            _serverPipe.ClientConnected += OnClientConnected;
            _serverPipe.ClientDisconnected += OnClientDisconnected;
            _serverPipe.MessageReceived += async (clientPipeId, message) => await OnMessageReceived(clientPipeId, message);

            _serverPipe.Start();

            Console.WriteLine($"IPC Server listening on pipe: {pipeName}");
            await _serverStopped.Task;

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
            var botEntry = _botClientConnections.FirstOrDefault(x => x.Value == clientPipeId);
            if (botEntry.Key != null)
            {
                _botClientConnections.TryRemove(botEntry.Key, out _);
                Console.WriteLine($"Bot client '{botEntry.Key}' removed.");
            }
            var requestsToRemove = _cliRequestMap.Where(kvp => kvp.Value == clientPipeId).Select(kvp => kvp.Key).ToList();
            foreach (var requestId in requestsToRemove)
            {
                _cliRequestMap.TryRemove(requestId, out _);
                Console.WriteLine($"Removed pending request '{requestId}' for disconnected client.");
            }
        }

        private static async Task OnMessageReceived(string clientPipeId, string message)
        {
            Console.WriteLine($"Message received from {clientPipeId}: {message}");
            JObject jsonObject;
            try
            {
                jsonObject = JObject.Parse(message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JsonException when parsing message as JObject: {ex.Message}. Message: {message}");
                return;
            }

            if (jsonObject.ContainsKey("CommandType"))
            {
                try
                {
                    IpcCommand command = jsonObject.ToObject<IpcCommand>();
                    if (command != null)
                    {
                        if (command.CommandType == CommandType.RegisterBot)
                        {
                            string profileName = command.Profile;
                            if (!string.IsNullOrEmpty(profileName))
                            {
                                _botClientConnections[profileName] = clientPipeId;
                                Console.WriteLine($"Bot client for profile '{profileName}' registered with pipe ID {clientPipeId}.");
                            }
                            else
                            {
                                Console.WriteLine($"Received RegisterBot command with empty profile from {clientPipeId}. Ignoring.");
                            }
                        }
                        else
                        {
                            lock (_cliRequestMap)
                            {
                                if (!string.IsNullOrEmpty(command.RequestId))
                                {
                                    _cliRequestMap[command.RequestId] = clientPipeId;
                                    Console.WriteLine($"CLI client request '{command.RequestId}' mapped to {clientPipeId}.");
                                }
                            }

                            Console.WriteLine($"Received command '{command.CommandType}' for profile '{command.Profile}' from CLI client {clientPipeId}");

                            if (command.TargetAllProfiles)
                            {
                                Console.WriteLine($"Broadcasting command '{command.CommandType}' to all connected bot clients.");
                                if (_botClientConnections.Any())
                                {
                                    foreach (var botPipeId in _botClientConnections.Values)
                                    {
                                        try
                                        {
                                            await _serverPipe.SendMessageToClientAsync(botPipeId, message);
                                            Console.WriteLine($"Command '{command.CommandType}' successfully broadcasted to bot client {botPipeId}.");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Error broadcasting command '{command.CommandType}' to bot client {botPipeId}: {ex.Message}");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No bot clients connected to broadcast command to. Sending error response to CLI client.");
                                    IpcResponse errorResponse = new IpcResponse
                                    {
                                        RequestId = command.RequestId,
                                        Success = false,
                                        Message = "No bot clients connected.",
                                        Payload = ""
                                    };
                                    await _serverPipe.SendMessageToClientAsync(clientPipeId, errorResponse.ToJson());
                                    lock (_cliRequestMap)
                                    {
                                        _cliRequestMap.TryRemove(command.RequestId, out _);
                                    }
                                }
                            }
                            else
                            {
                                if (_botClientConnections.TryGetValue(command.Profile, out string botClientPipeId))
                                {
                                    Console.WriteLine($"Routing command '{command.CommandType}' to bot client {botClientPipeId} for profile '{command.Profile}'.");
                                    try
                                    {
                                        await _serverPipe.SendMessageToClientAsync(botClientPipeId, message);
                                        Console.WriteLine($"Command '{command.CommandType}' successfully routed to bot client {botClientPipeId}.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error routing command '{command.CommandType}' to bot client {botClientPipeId}: {ex.Message}");
                                        IpcResponse errorResponse = new IpcResponse
                                        {
                                            RequestId = command.RequestId,
                                            Success = false,
                                            Message = $"Error routing command to bot client for profile '{command.Profile}': {ex.Message}",
                                            Payload = ""
                                        };
                                        await _serverPipe.SendMessageToClientAsync(clientPipeId, errorResponse.ToJson());
                                        lock (_cliRequestMap)
                                        {
                                            _cliRequestMap.TryRemove(command.RequestId, out _);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Bot client for profile '{command.Profile}' not found. Sending error response to CLI client {clientPipeId}.");
                                    IpcResponse errorResponse = new IpcResponse
                                    {
                                        RequestId = command.RequestId,
                                        Success = false,
                                        Message = $"Bot client for profile '{command.Profile}' not found.",
                                        Payload = ""
                                    };
                                    await _serverPipe.SendMessageToClientAsync(clientPipeId, errorResponse.ToJson());
                                    lock (_cliRequestMap)
                                    {
                                        _cliRequestMap.TryRemove(command.RequestId, out _);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message as IpcCommand: {ex.Message}. Message: {message}");
                }
            }
            else if (jsonObject.ContainsKey("Success"))
            {
                try
                {
                    IpcResponse response = jsonObject.ToObject<IpcResponse>();
                    if (response != null && !string.IsNullOrEmpty(response.RequestId))
                    {
                        Console.WriteLine($"Received response for request '{response.RequestId}' from bot client {clientPipeId}");

                        lock (_cliRequestMap)
                        {
                            if (_cliRequestMap.TryRemove(response.RequestId, out string cliClientPipeId))
                            {
                                Console.WriteLine($"Routing response for request '{response.RequestId}' back to CLI client {cliClientPipeId}.");
                                try
                                {
                                    Console.WriteLine($"Attempting to send response to CLI client {cliClientPipeId}: {message}");
                                    await _serverPipe.SendMessageToClientAsync(cliClientPipeId, message);
                                    Console.WriteLine($"Response successfully sent to CLI client {cliClientPipeId}.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error sending response to CLI client {cliClientPipeId}: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Could not find originating CLI client for request ID '{response.RequestId}'. Message: {message}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing message as IpcResponse: {ex.Message}. Message: {message}");
                }
            }
            else
            {
                Console.WriteLine($"Unknown message type received from {clientPipeId}: {message}");
            }
        }
    }
}
