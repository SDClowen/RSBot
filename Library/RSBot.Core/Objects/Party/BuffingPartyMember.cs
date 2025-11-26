using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Core.Objects.Party;

public class BuffingPartyMember
{
    /// <summary>
    ///     The player buffs
    /// </summary>
    public List<uint> Buffs;

    /// <summary>
    ///     The buffing player group
    /// </summary>
    public string Group;

    /// <summary>
    ///     The buffing player name
    /// </summary>
    public string Name;

    /// <summary>
    ///     Create instance of the <seealso cref="BuffingPartyMember" /> and deserialize settings obj
    /// </summary>
    /// <param name="obj"></param>
    public BuffingPartyMember(string obj)
    {
        var split = obj.Split(':');
        if (split.Length != 3)
            throw new InvalidOperationException();

        Name = split[0];
        Group = split[1];
        Buffs = split[2].Split(',').Where(p => uint.TryParse(p, out _)).Select(p => uint.Parse(p)).ToList();
    }

    /// <summary>
    ///     Create instance of the <seealso cref="BuffingPartyMember" />
    /// </summary>
    /// <param name="obj"></param>
    public BuffingPartyMember()
    {
        Buffs = new List<uint>();
    }

    /// <summary>
    ///     Serialize the struct
    /// </summary>
    public string Serialize()
    {
        return $"{Name}:{Group}:{string.Join(",", Buffs)};";
    }
}
