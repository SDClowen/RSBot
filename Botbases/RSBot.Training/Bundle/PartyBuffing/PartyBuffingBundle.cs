using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Party;
using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Training.Bundle.PartyBuffing;

internal class PartyBuffingBundle : IBundle
{
    /// <summary>
    ///     <c>true</c> if refreshing this bundle; otherwise <c>false</c>
    /// </summary>
    private bool _refreshing;

    /// <summary>
    ///     The buffing party members
    /// </summary>
    private List<BuffingPartyMember> BuffingPartyMembers;

    /// <summary>
    ///     Initialize the instance of <seealso cref="PartyBuffingBundle" />
    /// </summary>
    public PartyBuffingBundle()
    {
        EventManager.SubscribeEvent("OnPartyBuffSettingsChanged", OnPartyBuffSettingsChanged);
    }

    /// <summary>
    ///     Invoke the bundle
    /// </summary>
    public void Invoke()
    {
        if (_refreshing)
            return;

        if (Game.Player.HasActiveVehicle)
            return;

        var selectedGroup = PlayerConfig.Get("RSBot.Party.Buffing.SelectedGroup", "Default");

        SpawnManager.TryGetEntities<SpawnedPlayer>(p =>
            BuffingPartyMembers.Any(s => s.Group == selectedGroup && s.Name == p.Name),
            out var members
        );

        foreach (var member in members)
        {
            var buffingMember = BuffingPartyMembers.Find(p => p.Name == member.Name);
            if (buffingMember == null)
                continue;

            if (buffingMember.Buffs.Count == 0)
                continue;

            //if party member is dead, dont try to buff
            if (member.State.LifeState == LifeState.Dead)
                continue;

            Log.Status($"Buffing party");

            var activeBuffs = member.State.ActiveBuffs;

            foreach (var buff in buffingMember.Buffs)
            {
                var skill = Game.Player.Skills.GetSkillInfoById(buff);

                if (skill == null || skill.HasCooldown)
                    continue;
                var isActive = member.State.HasActiveBuff(skill, out var info);
                if (isActive && skill.Isbugged && info.Isbugged)
                {
                    Log.Notify($"The buff on {member.Name} [{skill.Token}-{skill.Record?.GetRealName()}] expired");

                    skill?.Reset();
                    continue;
                }

                if (isActive)
                    continue;

                Log.Status($"Buffing {skill.Record?.GetRealName()} party member {member.Name}");
                skill.Cast(member.UniqueId, true);
            }
        }
    }

    /// <summary>
    ///     Refresh the bundle
    /// </summary>
    public void Refresh()
    {
        _refreshing = true;

        // Don't need to use clear, because gc will handle the unnecessary objects
        BuffingPartyMembers = new List<BuffingPartyMember>();

        var settings = PlayerConfig.Get("RSBot.Party.Buffing", string.Empty);
        var collection = settings.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in collection)
            BuffingPartyMembers.Add(new BuffingPartyMember(item));

        _refreshing = false;
    }

    public void Stop()
    {
        //Nothing to do here
    }

    /// <summary>
    ///     Update the <see cref="BuffingPartyMembers" /> list when settings changed from another plugins
    /// </summary>
    private void OnPartyBuffSettingsChanged()
    {
        Refresh();
    }
}
