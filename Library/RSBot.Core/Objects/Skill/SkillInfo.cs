using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using System;

namespace RSBot.Core.Objects.Skill
{
    public class SkillInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public uint Id;

        /// <summary>
        /// Gets or sets the enabled.
        /// </summary>
        public bool Enabled;

        /// <summary>
        /// Gets the record.
        /// </summary>
        public RefSkill Record => Game.ReferenceManager.GetRefSkill(Id);

        /// <summary>
        /// Gets a value indicating whether this <see cref="SkillInfo"/> is passive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if passive; otherwise, <c>false</c>.
        /// </value>
        public bool IsPassive => Record.Basic_Activity == 0;

        /// <summary>
        /// Gets a value indicating whether this <see cref="SkillInfo"/> is attack.
        /// </summary>
        /// <value>
        ///   <c>true</c> if attack; otherwise, <c>false</c>.
        /// </value>
        public bool IsAttack => Record.Params[1] == 6386804;

        /// <summary>
        /// The skill buff duration
        /// </summary>
        private int _duration;

        /// <summary>
        /// Skill cool down environment tick
        /// </summary>
        private int _cooldownTick;
        
        /// <summary>
        /// Skill can not be casted environment tick
        /// </summary>
        private int _canNotBeCastedTick;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has cooldown.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has cooldown; otherwise, <c>false</c>.
        /// </value>
        public bool HasCooldown 
            => (Environment.TickCount - _cooldownTick) < Record.Action_ReuseDelay;

        /// <summary>
        /// Gets or sets a value indicating whether this instance can be used.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can be used; otherwise, <c>false</c>.
        /// </value>
        public bool CanNotBeCasted
            => (Environment.TickCount - _canNotBeCastedTick) < _duration;

        /// <summary>
        /// Gets a value indicating whether this instance can be used.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can be used; otherwise, <c>false</c>.
        /// </value>
        public bool CanBeCasted => !CanNotBeCasted && !HasCooldown;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillInfo"/> class.
        /// </summary>
        public SkillInfo(uint id, bool enabled)
        {
            Id = id;
            Enabled = enabled;

            if (!enabled) return;
            if (Record == null) return;
            if (Record.Action_ReuseDelay <= 1 || IsPassive) return;

            var duraTimeIndex = Record.Params.IndexOf(1685418593) + 1;
            _duration = duraTimeIndex != 0 ? Record.Params[duraTimeIndex] : 20000;
        }

        /// <summary>
        /// Creates a new SkillInfo object from the given packet
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        internal static SkillInfo FromPacket(Packet packet)
        {
            return new SkillInfo(packet.ReadUInt(), packet.ReadBool());
        }

        /// <summary>
        /// Update the cooldown tick
        /// </summary>
        public void UpdateTicks()
        {
            _cooldownTick = Environment.TickCount;
            _canNotBeCastedTick = Environment.TickCount;

            Log.Debug($"Lock skill [{Record.GetRealName()}] for {_duration / 1000} seconds.");
        }
    }
}