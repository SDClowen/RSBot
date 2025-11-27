using System;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace RSBot.IPC
{
    public class NamedPipeClient
    {
        private readonly string _pipeName;
        private NamedPipeClientStream _pipeClient;
        private readonly Action<string> _logger;

        public event Action<string> MessageReceived;
        public event Action Connected;
        public event Action Disconnected;

        public NamedPipeClient(string pipeName, Action<string> logger = null)
        {
            _pipeName = pipeName;
            _logger = logger;
        }

        private void Log(string message)
        {
            _logger?.Invoke(message);
        }

        public async Task ConnectAsync()
        {
            _pipeClient = new NamedPipeClientStream(".", _pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
            try
            {
                Log($"Attempting to connect to pipe {_pipeName}...");
                await _pipeClient.ConnectAsync(5000); // 5 second timeout
                Log("Successfully connected to pipe.");
                Connected?.Invoke();
                _ = ReadMessagesAsync(); // Start listening for messages
            }
            catch (TimeoutException)
            {
                Log($"Could not connect to pipe {_pipeName}. Timeout.");
                Disconnected?.Invoke();
            }
            catch (Exception ex)
            {
                Log($"Error connecting to pipe {_pipeName}: {ex.Message}");
                Disconnected?.Invoke();
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (_pipeClient != null && _pipeClient.IsConnected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await _pipeClient.WriteAsync(buffer, 0, buffer.Length);
                _pipeClient.WaitForPipeDrain();
            }
            else
            {
                Log("Client not connected. Cannot send message.");
            }
        }

        private async Task ReadMessagesAsync()
        {
            byte[] buffer = new byte[4096];
            try
            {
                while (_pipeClient.IsConnected)
                {
                    int bytesRead = await _pipeClient.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        MessageReceived?.Invoke(message);
                    }
                    else if (bytesRead == 0)
                    {
                        // Pipe was closed
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Error reading from pipe: {ex.Message}");
            }
            finally
            {
                Disconnect();
            }
        }

        public void Disconnect()
        {
            if (_pipeClient != null)
            {
                _pipeClient.Close();
                _pipeClient.Dispose();
                _pipeClient = null;
                Disconnected?.Invoke();
            }
        }
    }
}
