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

            [Option("pipename", Required = false, HelpText = "The name of the pipe to connect to.", Default = "RSBotIpcServer")]
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
            bool responseReceived = false;

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
                        responseReceived = true;
                        pipeClient.Disconnect();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing response: {ex.Message}");
                    responseReceived = true;

                }
            };

            pipeClient.Disconnected += () =>
            {
                if (!responseReceived)
                {
                    Console.WriteLine("Disconnected from server before receiving a response.");
                }
            };

            await pipeClient.ConnectAsync();
            await pipeClient.SendMessageAsync(command.ToJson());

            // Wait for a response or timeout
            var timeout = Task.Delay(5000); // 5 second timeout
            while (!responseReceived)
            {
                if (await Task.WhenAny(timeout) == timeout)
                {
                    Console.WriteLine("Timeout waiting for a response from the server.");
                    break;
                }
                await Task.Delay(100);
            }
        }
    }
}
