using RSBot.Core.Network;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects
{
    public class Action
    {
        /// <summary>
        /// Gets or sets the skill identifier.
        /// </summary>
        /// <value>
        /// The skill identifier.
        /// </value>
        public uint SkillId { get; set; }

        /// <summary>
        /// Gets or sets the executor identifier.
        /// </summary>
        /// <value>
        /// The executor identifier.
        /// </value>
        public uint ExecutorId { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the target identifier.
        /// </summary>
        /// <value>
        /// The target identifier.
        /// </value>
        public uint TargetId { get; set; }

        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>
        /// The flag.
        /// </value>
        public byte Flag { get; set; }

        /// <summary>
        /// Gets a value indicating whether [player is executor].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [player is executor]; otherwise, <c>false</c>.
        /// </value>
        public bool PlayerIsExecutor => Game.Player.UniqueId == ExecutorId;

        /// <summary>
        /// Gets a value indicating whether [player is target].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [player is target]; otherwise, <c>false</c>.
        /// </value>
        public bool PlayerIsTarget => Game.Player.UniqueId == TargetId;

        /// <summary>
        /// Froms the packet.
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public static Action FromPacket(Packet packet)
        {
            return new Action
            {
                SkillId = packet.ReadUInt(),
                ExecutorId = packet.ReadUInt(),
                Id = packet.ReadUInt(),
                TargetId = packet.ReadUInt(),
                Flag = packet.ReadByte()
            };
        }

        /// <summary>
        /// Gets the executor.
        /// </summary>
        public SpawnedBionic GetExecutor()
        {
            return ExecutorId == Game.Player.UniqueId ? null : Game.Spawns.GetBionic(ExecutorId);
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <returns></returns>
        public SpawnedBionic GetTarget()
        {
            if (TargetId == Game.Player.UniqueId) return null;

            return Game.Spawns.GetBionic(TargetId);
        }
    }
}