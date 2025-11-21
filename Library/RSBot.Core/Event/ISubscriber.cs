using System;
using System.Collections.Generic;

namespace RSBot.Core.Event;

public interface ISubscriber
{
    /// <summary>
    ///     Gets the subscribed events.
    /// </summary>
    /// <returns></returns>
    IEnumerable<(string name, Delegate handler)> GetSubscribedEvents();
}
