using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using System.Linq;

namespace RSBot.Default.Bundle.Buff
{
    internal class BuffBundle : IBundle
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        public void Invoke()
        {
            /*
             * #377
             * I think the bug now fixed but As a precaution, I find it appropriate to keep this solution here.
             * If the last fix is working, I will remove this code block from here in v2.4
             * Temporary fixer:
             * Issue: Sometimes the buffs dont removing with token from the active buffs list
             *      Problems: 
             *          ActionBuffRemoveResponse:0xb072 does not calling
             *          There have another opcode for remove buff with token
             */
            foreach (var buff in SkillManager.Buffs.Union(new[] { SkillManager.ImbueSkill, SkillManager.ResurrectionSkill }))
            {
                if (buff == null)
                    continue;

                var isActive = Game.Player.State.HasActiveBuff(buff, out var info);
                if (isActive && buff.Isbugged && info.Isbugged)
                {
                    //#377 bug detected!
                    Log.Notify($"[#377] The buff [{buff.Token}-{buff.Record?.GetRealName()}] expired");

                    EventManager.FireEvent("OnRemoveBuff", buff);

                    var playerSkill = Game.Player.Skills.GetSkillInfoById(buff.Id);
                    playerSkill?.Reset();
                    Game.Player.State.TryRemoveActiveBuff(info.Token, out _);
                }
            }

            var buffs = SkillManager.Buffs.FindAll(p => !Game.Player.State.HasActiveBuff(p, out _) && p.CanBeCasted);
            if (buffs == null || buffs.Count == 0)
                return;

            Log.Status("Buffing");

            foreach (var buff in buffs)
            {
                if (Game.Player.State.LifeState != LifeState.Alive || Game.Player.HasActiveVehicle)
                    break;

                Log.Debug($"Trying to cast buff: {buff} {buff.Record.Basic_Code}");

                buff.Cast(buff: true);
            }
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            //Nothing to do
        }

        public void Stop()
        {
            //Nothing to do
        }
    }
}