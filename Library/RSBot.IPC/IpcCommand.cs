using Newtonsoft.Json;
using RSBot.IPC;

namespace RSBot.IPC
{
    public class IpcCommand
    {
        public string RequestId { get; set; } // Unique identifier for the request
        public CommandType CommandType { get; set; }
        public string Profile { get; set; }
        public string Payload { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static IpcCommand FromJson(string json)
        {
            return JsonConvert.DeserializeObject<IpcCommand>(json);
        }
    }
}
