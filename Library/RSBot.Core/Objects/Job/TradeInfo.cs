using System.Collections.Generic;

namespace RSBot.Core.Objects.Job;

public class TradeInfo
{
    public Dictionary<uint, uint> Prices { get; set; } = null;

    public byte Scale { get; internal set; } = 0;
}
