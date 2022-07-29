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
        public uint Id { get; set; }

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
        public bool IsAttack => Record.Params.Contains(6386804);

        /// <summary>
        /// Gets a value indicating whether this <see cref="SkillInfo"/> is a DoT.
        /// </summary>
        /// <value>
        ///   <c>true</c> if DoT; otherwise, <c>false</c>.
        /// </value>
        public bool IsDot => Record.Basic_Code.StartsWith("SKILL_EU_WARLOCK_DOTA");

        /// <summary>
        /// Gets a value indicating whether this <see cref="SkillInfo"/> is imbue.
        /// </summary>
        /// <value>
        ///   <c>true</c> if imbue; otherwise, <c>false</c>.
        /// </value>
        public bool IsImbue => Record.Basic_Activity == 1 && IsAttack;

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
        private int _lastCastTick;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has cooldown.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has cooldown; otherwise, <c>false</c>.
        /// </value>
        public bool HasCooldown
            => (Kernel.TickCount - _cooldownTick) < Record.Action_ReuseDelay;

        /// <summary>
        /// Gets or sets a value indicating whether this instance can be used.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can be used; otherwise, <c>false</c>.
        /// </value>
        public bool DoTCanNotBeCasted
        {
            get
            {
                if (_lastCastTick == 0)
                    return false;

                return (Kernel.TickCount - _lastCastTick) < _duration;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can be used.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can be used; otherwise, <c>false</c>.
        /// </value>
        public bool CanBeCasted
        {
            get
            {
                var hasCooldown = HasCooldown;
                var notEnoughMana = Game.Player.Mana < Record.Consume_MP;

                if (hasCooldown)
                    return false;

                if (notEnoughMana)
                    return false;

                if (IsDot && DoTCanNotBeCasted)
                    return false;

                return true;
            }
        }

        /// <summary>
        /// Skill Token (using for buffs)
        /// </summary>
        public uint Token { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillInfo"/> class.
        /// </summary>
        public SkillInfo(uint id, uint token)
            : this(id, false)
        {
            Token = token;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillInfo"/> class.
        /// </summary>
        public SkillInfo(uint id, bool enabled)
        {
            Id = id;
            Enabled = enabled;

            if (Record == null || IsPassive)
                return;

            // skill buff duration param: dura
            var index = Record.Params.IndexOf(1685418593);
            if (index != -1)
                _duration = Record.Params[index + 1];
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
        /// Update the ticks
        /// </summary>
        public void Update()
        {
            _cooldownTick = Kernel.TickCount;
            _lastCastTick = Kernel.TickCount;
        }

        /// <summary>
        /// Set cooldown
        /// </summary>
        public void SetCoolDown(int milliseconds)
        {
            _cooldownTick = Kernel.TickCount - milliseconds;
        }

        /// <summary>
        /// Reset the ticks
        /// </summary>
        public void Reset()
        {
            //_cooldownTick = 0;
            _lastCastTick = 0;
        }

        /// <summary>
        /// Check if the skill is low level for character (Lazy basic :-;)
        /// </summary>
        /// <param name="skill"></param>
        /// <returns>
        /// <c>true</c> otherwise, <c>false</c>.
        /// </returns>
        public bool IsLowLevel()
        {
            var mastery = Game.Player.Skills.GetMasteryInfoById((uint)Record.ReqCommon_Mastery1);
            if (mastery == null)
                return true;

            return Record.ReqCommon_MasteryLevel1 < mastery.Level - 20;
        }

        /// <summary>
        /// Get skill info
        /// </summary>
        public override string ToString()
        {
            return $"{Record}";
        }
    }
}