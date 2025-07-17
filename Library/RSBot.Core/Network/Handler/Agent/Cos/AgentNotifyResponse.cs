using RSBot.Core.Components;
using RSBot.Core.Components.Scripting.Commands;

namespace RSBot.Core.Network.Handler.Agent
{
    internal class AgentNotifyResponse : IPacketHandler
    {
        public ushort Opcode => 0x300C;

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            var noticeType = packet.ReadByte();
            if (Game.ClientType > GameClientType.Thailand)
                packet.ReadByte();

            if (noticeType == 0x4 && ScriptManager.Running) //can't teleport while riding on vehicle
            {
                MoveScriptCommand.MustDismount = true;
            }
        }
    }
}
