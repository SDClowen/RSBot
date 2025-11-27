using Newtonsoft.Json;

namespace RSBot.IPC
{
    public class IpcResponse
    {
        public string RequestId { get; set; } // Unique identifier for the request this is a response to
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Payload { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static IpcResponse FromJson(string json)
        {
            return JsonConvert.DeserializeObject<IpcResponse>(json);
        }
    }
}
