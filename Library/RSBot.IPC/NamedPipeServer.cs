using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace RSBot.IPC
{
    public class NamedPipeServer
    {
        private readonly string _pipeName;
        private readonly ConcurrentDictionary<string, NamedPipeServerStream> _clientPipesMap = new ConcurrentDictionary<string, NamedPipeServerStream>();
        private bool _isRunning;

        public event Func<string, string, Task> MessageReceived;
        public event Action<string> ClientConnected;
        public event Action<string> ClientDisconnected;

        public NamedPipeServer(string pipeName)
        {
            _pipeName = pipeName;
        }

        public void Start()
        {
            _isRunning = true;
            Task.Run(ListenForConnections);
        }

        public void Stop()
        {
            _isRunning = false;
            foreach (var pipe in _clientPipesMap.Values)
            {
                pipe.Close();
                pipe.Dispose();
            }
            _clientPipesMap.Clear();
        }

        private async Task ListenForConnections()
        {
            while (_isRunning)
            {
                try
                {
                    Console.WriteLine("Creating pipe server stream...");
                    NamedPipeServerStream pipeServer = new NamedPipeServerStream(
                        _pipeName,
                        PipeDirection.InOut,
                        NamedPipeServerStream.MaxAllowedServerInstances,
                        PipeTransmissionMode.Byte,
                        PipeOptions.Asynchronous);
                    Console.WriteLine("Waiting for a client to connect...");
                    await pipeServer.WaitForConnectionAsync();

                    if (_isRunning)
                    {
                        Console.WriteLine("Client connected.");
                        string clientPipeId = Guid.NewGuid().ToString();
                        _clientPipesMap.TryAdd(clientPipeId, pipeServer);
                        ClientConnected?.Invoke(clientPipeId);
                        _ = HandleClientConnection(pipeServer, clientPipeId);
                    }
                    else
                    {
                        pipeServer.Close();
                        pipeServer.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ListenForConnections: {ex.Message}");
                }
            }
        }

        private async Task HandleClientConnection(NamedPipeServerStream pipeServer, string clientPipeId)
        {
            byte[] buffer = new byte[4096];
            try
            {
                while (pipeServer.IsConnected && _isRunning)
                {
                    int bytesRead = await pipeServer.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        MessageReceived?.Invoke(clientPipeId, message);
                    }
                    else if (bytesRead == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling client connection {clientPipeId}: {ex.Message}");
            }
            finally
            {
                DisconnectClient(pipeServer, clientPipeId);
            }
        }

        public async Task SendMessageToClientAsync(string clientPipeId, string message)
        {
            if (_clientPipesMap.TryGetValue(clientPipeId, out NamedPipeServerStream pipe))
            {
                if (pipe.IsConnected)
                {
                    try
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(message);
                        await pipe.WriteAsync(buffer, 0, buffer.Length);
                        pipe.WaitForPipeDrain();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error sending message to client {clientPipeId}: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Client {clientPipeId} is not connected. Cannot send message.");
                }
            }
            else
            {
                Console.WriteLine($"Client {clientPipeId} not found in map. Cannot send message.");
            }
        }

        private void DisconnectClient(NamedPipeServerStream pipeServer, string clientPipeId)
        {
            if (_clientPipesMap.TryRemove(clientPipeId, out _))
            {
                pipeServer.Close();
                pipeServer.Dispose();
                ClientDisconnected?.Invoke(clientPipeId);
            }
        }
    }
}
