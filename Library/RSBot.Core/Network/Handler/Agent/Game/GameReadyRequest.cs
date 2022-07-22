using RSBot.Core.Components;
using RSBot.Core.Event;
using System.Timers;

namespace RSBot.Core.Network.Handler.Agent
{
    internal class GameReadyRequest : IPacketHandler
    {
        /// <summary>
        /// Gets or sets the opcode.
        /// </summary>
        /// <value>
        /// The opcode.
        /// </value>
        public ushort Opcode => 0x3077;

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        public PacketDestination Destination => PacketDestination.Client;

        /// <summary>
        /// Handles the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        public void Invoke(Packet packet)
        {
            var itemCount = packet.ReadByte();
            for (int i = 0; i < itemCount; i++)
            {
                var itemId = packet.ReadUInt();
                var milliseconds = packet.ReadInt();
            }

            var skillCount = packet.ReadByte();
            for (int i = 0; i < skillCount; i++)
            {
                var skillId = packet.ReadUInt();
                var milliseconds = packet.ReadInt();

                var skillInfo = Game.Player.Skills.GetSkillInfoById(skillId);
                if (skillInfo == null)
                    skillInfo = SkillManager.Buffs.Find(p => p.Id == skillId);

                skillInfo.SetCoolDown(milliseconds);
            }

            Game.Player.Teleportation = null;

            Log.Debug("The player is untouchable for 5s");
            var untouchableTimer = new Timer(5000) { AutoReset = false };
            untouchableTimer.Elapsed += UntouchableTimer_Elapsed;
            untouchableTimer.Start();
            Log.Debug("Teleportation complete");
            EventManager.FireEvent("OnTeleportComplete");

            Game.Ready = true;
        }

        /// <summary>
        /// Handles the Elapsed event of the UntouchableTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void UntouchableTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Log.Debug("The player is no longer untouchable");
            Game.Player.Untouchable = false;
        }
    }
}