using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Network;
using System.Timers;

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
        /// Gets or sets the cooldown timer.
        /// </summary>
        private Timer _cooldownTimer;

        /// <summary>
        /// Gets or sets the  cannot be casted timer.
        /// </summary>
        private Timer _canNotBeCastedTimer;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has cooldown.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance has cooldown; otherwise, <c>false</c>.
        /// </value>
        public bool HasCooldown;

        /// <summary>
        /// Gets or sets a value indicating whether this instance can be used.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can be used; otherwise, <c>false</c>.
        /// </value>
        public bool CanNotBeCasted;

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

            _cooldownTimer = new Timer(Record.Action_ReuseDelay);
            _cooldownTimer.Elapsed += CooldownTimer_Elapsed;

            var duraTimeIndex = Record.Params.IndexOf(1685418593) + 1;
            var duration = duraTimeIndex != 0 ? Record.Params[duraTimeIndex] : 20000;

            _canNotBeCastedTimer = new Timer(duration);
            _canNotBeCastedTimer.Elapsed += CanNotBeCastedTimer_Elapsed;
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
        /// Starts the cooldown timer.
        /// </summary>
        public void StartCooldownTimer()
        {
            if (Record.Action_ReuseDelay <= 1 || IsPassive) return;

            _cooldownTimer?.Start();
            HasCooldown = true;
        }

        /// <summary>
        /// Stop the cooldown timer.
        /// </summary>
        public void StopCooldownTimer()
            => CooldownTimer_Elapsed(null, null);

        /// <summary>
        /// Starts the cannot be casted timer.
        /// </summary>
        public void StartCannotBeCastedTimer()
        {
            if (IsAttack)
                return;

            CanNotBeCasted = true;

            _canNotBeCastedTimer.Start();

            Log.Debug($"Lock skill [{Record.GetRealName()}] for {_canNotBeCastedTimer.Interval / 1000} seconds.");
        }

        /// <summary>
        /// Stop the cannot be casted timer.
        /// </summary>
        public void StopCannotBeCastedTimer()
            => CanNotBeCastedTimer_Elapsed(null, null);

        /// <summary>
        /// Handles the Elapsed event of the CanNotBeCastedTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void CanNotBeCastedTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CanNotBeCasted = false;
            _canNotBeCastedTimer.Stop();
            Log.Debug($"Skill [{Record.GetRealName()}] can be casted again.");
        }

        /// <summary>
        /// Handles the Elapsed event of the CooldownTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void CooldownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            HasCooldown = false;
            _cooldownTimer.Stop();
        }
    }
}