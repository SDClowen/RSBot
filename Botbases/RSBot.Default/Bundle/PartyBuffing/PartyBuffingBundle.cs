using System;
using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects.Party;

namespace RSBot.Default.Bundle.PartyBuffing;

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

        if (Game.Party == null ||
            Game.Party.Members == null ||
            Game.Player.HasActiveVehicle)
            return;

        var selectedGroup = PlayerConfig.Get("RSBot.Party.Buffing.SelectedGroup", "Default");

        var members = Game.Party.Members
            .Where(p => BuffingPartyMembers.Any(s => s.Group == selectedGroup && s.Name == p.Name));
        foreach (var member in members)
        {
            if (member.Player == null)
                continue;

            var buffingMember = BuffingPartyMembers.Find(p => p.Name == member.Name);
            if (buffingMember == null)
                continue;

            if (buffingMember.Buffs.Count == 0)
                continue;

            Log.Status("Buffing party");

            var activeBuffs = member.Player.State.ActiveBuffs;

            // Loop through the buffs defined for the buffing member
            foreach (var buff in buffingMember.Buffs)
            {
                // Retrieve skill information based on skill ID
                var skill = Game.Player.Skills.GetSkillInfoById(buff);

                var isActive = member.Player.State.HasActiveBuff(Game.Player.Skills.GetSkillInfoById(buff), out var info);
                if (isActive && skill.Isbugged && info.Isbugged)
                {
                    Log.Notify($"[#377] The buff on {member.Name} [{skill.Token}-{skill.Record?.GetRealName()}] expired");

                    skill?.Reset();
                }

                // Skip if skill is null or has cooldown
                if (skill == null || skill.HasCooldown)
                    continue;

                // Cast the skill on the current party member
                if (member.Player != null)
                    skill.Cast(member.Player.UniqueId, true);
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