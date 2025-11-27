using System;
using System.Threading.Tasks;
using CommandLine;
using RSBot.IPC;

namespace RSBot.Controller
{
    internal class Program
    {
        public class Options
        {
            [Option('p', "profile", Required = true, HelpText = "The profile name to target.")]
            public string Profile { get; set; }

            [Option('c', "command", Required = true, HelpText = "The command to execute.")]
            public string Command { get; set; }

            [Option('d', "data", Required = false, HelpText = "The data payload for the command.")]
            public string Data { get; set; }

            [Option('x', "pipename", Required = false, HelpText = "The name of the pipe to connect to.", Default = "RSBotIPC")]
            public string PipeName { get; set; }
        }

        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args)
                .WithParsedAsync(RunOptions);
        }

        static async Task RunOptions(Options opts)
        {
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
                Payload = opts.Data
            };

            var pipeClient = new NamedPipeClient(opts.PipeName, Console.WriteLine);
            var responseTcs = new TaskCompletionSource<bool>();

            pipeClient.MessageReceived += (message) =>
            {
                try
                {
                    var response = IpcResponse.FromJson(message);
                    if (response != null && response.RequestId == command.RequestId)
                    {
                        Console.WriteLine($"Success: {response.Success}");
                        Console.WriteLine($"Message: {response.Message}");
                        if (!string.IsNullOrEmpty(response.Payload))
                        {
                            Console.WriteLine($"Payload: {response.Payload}");
                        }
                        responseTcs.TrySetResult(true);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing response: {ex.Message}");
                    responseTcs.TrySetResult(false);
                }
            };

            pipeClient.Disconnected += () =>
            {
                if (!responseTcs.Task.IsCompleted)
                {
                    Console.WriteLine("Disconnected from server before receiving a response.");
                    responseTcs.TrySetResult(false);
                }
            };

            await pipeClient.ConnectAsync();

            await pipeClient.SendMessageAsync(command.ToJson());
            var timeoutTask = Task.Delay(5000);
            var completedTask = await Task.WhenAny(responseTcs.Task, timeoutTask);

            if (completedTask == timeoutTask)
            {
                Console.WriteLine("Timeout waiting for a response from the server.");
            }
            else if (responseTcs.Task.Result)
            {
            }
            else
            {
                Console.WriteLine("Failed to receive a valid response or disconnected unexpectedly.");
            }

            pipeClient.Disconnect();
        }
    }
}
