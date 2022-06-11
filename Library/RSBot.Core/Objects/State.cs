using RSBot.Core.Network;
using RSBot.Core.Objects.Skill;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects
{
    public class State
    {
        /// <summary>
        /// Gets or sets the state of the life.
        /// </summary>
        /// <value>
        /// The state of the life.
        /// </value>
        public LifeState LifeState { get; set; }

        /// <summary>
        /// Gets or sets the motion.
        /// </summary>
        /// <value>
        /// The motion.
        /// </value>
        public MotionState MotionState { get; set; }

        /// <summary>
        /// Gets or sets the state of the body.
        /// </summary>
        /// <value>
        /// The state of the body.
        /// </value>
        public BodyState BodyState { get; set; }

        /// <summary>
        /// Gets or sets the state of the hit.
        /// </summary>
        /// <value>
        /// The state of the hit.
        /// </value>
        public ActionHitStateFlag HitState { get; set; }

        /// <summary>
        /// Gets or sets the walk speed.
        /// </summary>
        /// <value>
        /// The walk speed.
        /// </value>
        public float WalkSpeed { get; set; }

        /// <summary>
        /// Gets or sets the run speed.
        /// </summary>
        /// <value>
        /// The run speed.
        /// </value>
        public float RunSpeed { get; set; }

        /// <summary>
        /// Gets or sets the berzerk speed.
        /// </summary>
        /// <value>
        /// The berzerk speed.
        /// </value>
        public float BerzerkSpeed { get; set; }

        /// <summary>
        /// Gets or sets the active buffs.
        /// </summary>
        /// <value>
        /// The active buffs.
        /// </value>
        public List<SkillInfo> ActiveBuffs { get; } = new();

        /// <summary>
        /// Gets the active item perks.
        /// </summary>
        /// <value>
        /// The active item perks.
        /// </value>
        public Dictionary<uint, ItemPerk> ActiveItemPerks { get; } = new();

        /// <summary>
        /// Gets or sets the state of the PVP.
        /// </summary>
        /// <value>
        /// The state of the PVP.
        /// </value>
        public PvpState PvpState { get; set; }

        /// <summary>
        /// Gets or sets the state of the battle.
        /// </summary>
        /// <value>
        /// The state of the battle.
        /// </value>
        public BattleState BattleState { get; set; }

        /// <summary>
        /// Gets or sets the state of the scroll.
        /// </summary>
        /// <value>
        /// The state of the scroll.
        /// </value>
        public ScrollState ScrollState { get; set; }

        /// <summary>
        /// Creates a new state object by the given packet
        /// </summary>
        /// <param name="packet">The packet.</param>
        /// <returns></returns>
        public void Deserialize(Packet packet)
        {
            LifeState = (LifeState)packet.ReadByte();

            if (LifeState == 0)
                LifeState = LifeState.Alive;

            if(Game.ClientType > GameClientType.Thailand)
                packet.ReadByte(); //unkByte0

            MotionState = (MotionState)packet.ReadByte();
            BodyState = (BodyState)packet.ReadByte();

            if (Game.ClientType > GameClientType.Vietnam193)
                packet.ReadByte(); // hasRedArrowEffect

            WalkSpeed = packet.ReadFloat();
            RunSpeed = packet.ReadFloat();
            BerzerkSpeed = packet.ReadFloat();

            var buffCount = packet.ReadByte();
            for (var i = 0; i < buffCount; i++)
            {
                var id = packet.ReadUInt();
                var token = packet.ReadUInt();

                var buff = new SkillInfo(id, token);
                if (buff.Record == null)
                    continue;

                if (buff.Record.Params.Contains(1701213281))
                    packet.ReadBool(); //IsCreator

                ActiveBuffs.Add(buff);
            }
        }

        /// <summary>
        /// Gets the active buff by skill identifier.
        /// </summary>
        /// <returns></returns>
        public bool HasActiveBuff(SkillInfo skill, out SkillInfo buff)
        {
            buff = ActiveBuffs.Find(p => p.Record.Action_Overlap == skill.Record.Action_Overlap && p.Record.Basic_Activity == skill.Record.Basic_Activity);

            return buff != null;
        }

        /// <summary>
        /// Gets the active buff by skill identifier.
        /// </summary>
        /// <returns></returns>
        public bool TryGetActiveBuff(uint token, out SkillInfo buff)
        {
            buff = ActiveBuffs.Find(p => p.Token == token);

            return buff != null;
        }

        /// <summary>
        /// Gets the active buff by skill identifier.
        /// </summary>
        /// <returns></returns>
        public bool TryRemoveActiveBuff(uint token, out SkillInfo removedBuff)
        {
            removedBuff = ActiveBuffs.Find(p => p.Token == token);
            if (removedBuff == null)
                return false;

            return ActiveBuffs.Remove(removedBuff);
        }

        /// <summary>
        /// Checks two active DoTs.
        /// </summary>
        /// <returns></returns>
        public bool HasTwoDots()
        {
            return ActiveBuffs.Where(b => b.IsDot).Count() >= 2;
        }
    }
}