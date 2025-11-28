using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;
using RSBot.IPC;

namespace RSBot.Controller
{
    internal class Program
    {
        public class Options
        {
            [Option('p', "profile", Required = false, HelpText = "The profile name to target. Required unless --all is used.")]
            public string Profile { get; set; }

            [Option('c', "command", Required = true, HelpText = "The command to execute.")]
            public string Command { get; set; }

            [Option('d', "data", Required = false, HelpText = "The data payload for the command.")]
            public string Data { get; set; }

            [Option('x', "pipename", Required = false, HelpText = "The name of the pipe to connect to.", Default = "RSBotIPC")]
            public string PipeName { get; set; }

            [Option('a', "all", Required = false, HelpText = "Send command to all listening bot instances.", Default = false)]
            public bool AllProfiles { get; set; }
        }

        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args)
                .WithParsedAsync(async opts =>
                {
                    if (!opts.AllProfiles && string.IsNullOrEmpty(opts.Profile))
                    {
                        Console.WriteLine("Error: Either --profile or --all must be specified.");
                        return;
                    }

                    if (!Enum.TryParse<CommandType>(opts.Command, true, out var commandType))
                    {
                        Console.WriteLine($"Error: Invalid command '{opts.Command}'.");
                        return;
                    }

                    var command = new IpcCommand
                    {
                        RequestId = Guid.NewGuid().ToString(),
                        CommandType = commandType,
                        Profile = opts.Profile,
                        Payload = opts.Data,
                        TargetAllProfiles = opts.AllProfiles
                    };

                    await ExecuteCommand(command, opts.PipeName);
                });
        }

        static async Task ExecuteCommand(IpcCommand command, string pipeName)
        {
            var pipeClient = new NamedPipeClient(pipeName, Console.WriteLine);
            var collectedResponses = new ConcurrentBag<IpcResponse>();
            var singleResponseTcs = new TaskCompletionSource<bool>();
            const int BATCH_COMMAND_TIMEOUT_MS = 5000;

            pipeClient.MessageReceived += (message) =>
            {
                try
                {
                    var response = IpcResponse.FromJson(message);
                    if (response != null && response.RequestId == command.RequestId)
                    {
                        collectedResponses.Add(response);
                        if (!command.TargetAllProfiles)
                        {
                            singleResponseTcs.TrySetResult(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing response: {ex.Message}");
                    if (!command.TargetAllProfiles)
                    {
                        singleResponseTcs.TrySetResult(false);
                    }
                }
            };

            pipeClient.Disconnected += () =>
            {
                if (!command.TargetAllProfiles && !singleResponseTcs.Task.IsCompleted)
                {
                    Console.WriteLine("Disconnected from server before receiving a response.");
                    singleResponseTcs.TrySetResult(false);
                }
            };

            await pipeClient.ConnectAsync();

            await pipeClient.SendMessageAsync(command.ToJson());

            Task completedTask;
            if (command.TargetAllProfiles)
            {
                // For batch commands, wait for a fixed duration to collect multiple responses
                completedTask = await Task.WhenAny(Task.Delay(BATCH_COMMAND_TIMEOUT_MS), singleResponseTcs.Task);
            }
            else
            {
                // For single commands, wait for a single response or timeout
                completedTask = await Task.WhenAny(singleResponseTcs.Task, Task.Delay(BATCH_COMMAND_TIMEOUT_MS));
            }

            if (completedTask == singleResponseTcs.Task && !singleResponseTcs.Task.Result)
            {
                Console.WriteLine("Failed to receive a valid response or disconnected unexpectedly.");
            }
            else if (collectedResponses.IsEmpty)
            {
                Console.WriteLine("Timeout waiting for a response from the server, or no responses received.");
            }
            else
            {
                Console.WriteLine($"--- Responses for Request ID: {command.RequestId} ---");
                foreach (var response in collectedResponses)
                {
                    Console.WriteLine($"  Success: {response.Success}");
                    Console.WriteLine($"  Message: {response.Message}");
                    if (!string.IsNullOrEmpty(response.Payload))
                    {
                        Console.WriteLine($"  Payload: {response.Payload}");
                    }
                    Console.WriteLine("-------------------------------------");
                }
            }

            pipeClient.Disconnect();
        }
    }
}
