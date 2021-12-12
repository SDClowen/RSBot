using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using System;

namespace RSBot.Core.Objects.Skill
{
    public class SkillInfo : ISkillDataInfo
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
        public bool IsAttack => Record.Params[1] == 6386804;

        /// <summary>
        /// Gets a value indicating whether this <see cref="SkillInfo"/> is imbue.
        /// </summary>
        /// <value>
        ///   <c>true</c> if imbue; otherwise, <c>false</c>.
        /// </value>
        public bool IsImbue => Record.Basic_Activity == 1 && (Record.Action_Overlap == 1 || Record.Action_Overlap == 352321537);
        
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
        public bool CanBeCasted => !CanNotBeCasted && !HasCooldown && Game.Player.Mana >= Record.Consume_MP;

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
            _cooldownTick = Environment.TickCount;
            _canNotBeCastedTick = Environment.TickCount;
        }

        /// <summary>
        /// Reset the ticks
        /// </summary>
        public void Reset()
        {
            //_cooldownTick = 0;
            _canNotBeCastedTick = 0;
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
            return Record.ReqCommon_MasteryLevel1 <
                                       Game.Player.Skills.GetMasteryInfoById((uint)Record.ReqCommon_Mastery1).Level - 20;
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