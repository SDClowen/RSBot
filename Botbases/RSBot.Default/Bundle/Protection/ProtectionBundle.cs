using RSBot.Core;
using RSBot.Core.Components;

namespace RSBot.Default.Bundle.Protection
{
    internal class ProtectionBundle : IBundle
    {
        public void Invoke()
        {
            if(HealthRecovery.Active && HealthRecovery.Value > HealthRecovery.Current)
                //if ((Game.Player.BadEffect & BadEffect.Zombie) != BadEffect.Zombie) // is it need?
                    SkillManager.CastBuff(Game.Player.Skills.GetSkillInfoById(HealthRecovery.SkillId));

            if (ManaRecovery.Active && ManaRecovery.Value > ManaRecovery.Current)
                SkillManager.CastBuff(Game.Player.Skills.GetSkillInfoById(ManaRecovery.SkillId));


            if (BadStateRecovery.Active)
            {
                if (BadStateRecovery.IsUniversall)
                    SkillManager.CastBuff(Game.Player.Skills.GetSkillInfoById(BadStateRecovery.SkillIdForUniversall));
                
                if (BadStateRecovery.IsPurification)
                    SkillManager.CastBuff(Game.Player.Skills.GetSkillInfoById(BadStateRecovery.SkillIdForPurification));
                
            }
        }

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
