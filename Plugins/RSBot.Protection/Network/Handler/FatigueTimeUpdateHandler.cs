using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Network;
using RSBot.Protection.Components.Town;

namespace RSBot.Protection.Network.Handler
{
    internal class FatigueTimeUpdateHandler : IPacketHandler
    {
        public ushort Opcode => 0x3123; //0x3122 for old greenbook system

        public PacketDestination Destination => PacketDestination.Client;

        public void Invoke(Packet packet)
        {
            if (Game.ClientType == GameClientType.VTC_Game)
            {
                uint serviceFatigueSecondsSpent = packet.ReadUInt();
                packet.ReadByte(); //serviceFatigue type or color of bar (0x80 - 100%, 0x00 - 50%)
                packet.ReadByte(); //serviceFatigue???
                packet.ReadByte(); //<0x04 and >0x0F changes notice on hover
                packet.ReadBytes(2); //serviceFatigue???
                byte serviceFatigueGreenHours = packet.ReadByte();
                packet.ReadByte(); //serviceFatigueTotalHours (green+yellow)
                packet.ReadByte(); //serviceFatigue???
                packet.ReadByte(); //serviceFatigue???

                packet.ReadBytes(4); //???

                FatigueHandler.ShardFatigueFullExpSeconds = GetFullExpSeconds(
                    serviceFatigueSecondsSpent,
                    serviceFatigueGreenHours
                );
                Log.Debug(
                    $"Service fatigue : {FatigueHandler.ShardFatigueFullExpSeconds / 3600}hr {(FatigueHandler.ShardFatigueFullExpSeconds % 3600) / 60}min"
                );
            }
            else
            {
                packet.ReadUInt(); //serviceFatigueSecondsSpent
                packet.ReadByte(); //serviceFatigue type or color of bar (0x80 - 100%, 0x00 - 50%)
                packet.ReadByte(); //serviceFatigue???
                packet.ReadByte(); //<0x04 and >0x0F changes notice on hover
                packet.ReadBytes(2); //serviceFatigue???
                packet.ReadByte(); //serviceFatigueYellowHours
                packet.ReadByte(); //serviceFatigueTotalHours (yellow+red)
                packet.ReadByte(); //serviceFatigue???
                packet.ReadByte(); //serviceFatigue???

                packet.ReadBytes(2); //???

                uint shardFatigueSecondsSpent = packet.ReadUInt();
                packet.ReadByte(); //shardFatigue type or color of bar (0x80 - 100%, 0x00 - 50%)
                packet.ReadByte(); //shardFatigue???
                packet.ReadByte(); //<0x04 and >0x0F changes notice on hover
                packet.ReadBytes(2); //shardFatigue???
                byte shardFatigueBlueHours = packet.ReadByte();
                packet.ReadByte(); //shardFatigueTotalHours (blue+purple)
                packet.ReadByte(); //shardFatigue???
                packet.ReadByte(); //shardFatigue???

                FatigueHandler.ShardFatigueFullExpSeconds = GetFullExpSeconds(
                    shardFatigueSecondsSpent,
                    shardFatigueBlueHours
                );
                Log.Debug(
                    $"Shard fatigue : {FatigueHandler.ShardFatigueFullExpSeconds / 3600}hr {(FatigueHandler.ShardFatigueFullExpSeconds % 3600) / 60}min"
                );
            }

            EventManager.FireEvent("OnFatigueTimeUpdate");
        }

        private static int GetFullExpSeconds(uint secondsSpent, byte fullExpHours)
        {
            int fullExpSeconds = fullExpHours * 3600;
            int remainingSeconds = fullExpSeconds - (int)secondsSpent;
            if (remainingSeconds < 0)
                remainingSeconds = 0;
            return remainingSeconds;
        }
    }
}
