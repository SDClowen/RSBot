using System.Linq;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Lure.Components;

internal class LoopConditionValidator
{
    public static string CheckLoopConditions()
    {
        if (Game.Player.State.LifeState == LifeState.Dead)
            return "[Lure] Pausing lure bot because the player is dead.";

        if (!CheckNumPartyMember())
            return $"[Lure] Pausing lure bot because there are less than {LureConfig.NumPartyMember} in the party.";

        if (!CheckNumPartyMemberDead())
            return
                $"[Lure] Pausing lure bot because there more than {LureConfig.NumPartyMember} people in the party are dead.";

        if (!CheckNumMonsterType())
            return
                $"[Lure] Pausing lure bot because there are more monsters than {LureConfig.NumMonsterType} monsters around.";

        return null;
    }

    private static bool CheckNumPartyMember()
    {
        if (!LureConfig.StopIfNumPartyMember)
            return true;

        //Skip check if player is not in a pt.
        if (Game.Party == null || Game.Party.Members == null)
            return true;

        return Game.Party.Members.Count <= LureConfig.NumPartyMember;
    }

    private static bool CheckNumPartyMemberDead()
    {
        if (!LureConfig.StopIfNumPartyMemberDead)
            return true;

        //Skip check if player is not in a pt.
        if (Game.Party == null || Game.Party.Members == null)
            return true;

        return Game.Party.Members.Count(p => p.Player != null && p.Player.State.LifeState == LifeState.Dead) <=
               LureConfig.NumPartyMemberDead;
    }

    private static bool CheckNumMonsterType()
    {
        if (!LureConfig.StopIfNumMonsterType)
            return true;

        if (!SpawnManager.TryGetEntities<SpawnedMonster>(m => m.Rarity >= LureConfig.SelectedMonsterType &&
                                                              m.Position.DistanceTo(LureConfig.Area.Position) <= 15,
                out var mobs))
            return true;

        return mobs.Count() <= LureConfig.NumMonsterType;
    }
}