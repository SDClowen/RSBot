using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Network.Handler.Agent.Entity
{
    public class EntityUpdatePvpFlag : IPacketHandler
    {
        public ushort Opcode => 0xB516;

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            if (!packet.ReadBool())
                return;

            var uniqueId = packet.ReadUInt();
            var flag = (PvpFlag)packet.ReadByte();

            if(Game.Player.UniqueId == uniqueId)
            {
                var oldFlag = Game.Player.PvpFlag;
                Game.Player.PvpFlag = flag;
                Log.Notify($"Player pvp status updated from {oldFlag} to {flag}");
                return;
            }

            var entity = SpawnManager.GetEntity<SpawnedPlayer>(uniqueId);
            if (entity == null)
                return;

            var oldPvpFlag = entity.PvpCape;
            entity.PvpCape = flag;


            Log.Notify($"[{entity.Name}] pvp status updated from {oldPvpFlag} to {flag}");
        }
    }
}
