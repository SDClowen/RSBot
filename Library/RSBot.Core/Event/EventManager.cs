using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Event;

public class EventManager
{
    private static readonly List<(string name, Delegate handler)> _listeners = new();

    /// <summary>
    ///     Registers the event.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="handler">The handler.</param>
    public static void SubscribeEvent(string name, Delegate handler)
    {
        if (handler == null)
            return;

        _listeners.Add((name, handler));
    }

    /// <summary>
    ///     Registers the event.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="handler">The handler.</param>
    public static void SubscribeEvent(string name, Action handler)
    {
        if (handler == null)
            return;

        _listeners.Add((name, handler));
    }

    /// <summary>
    ///     Fires the event.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="parameters">The parameters.</param>
    public static void FireEvent(string name, params object[] parameters)
    {
        try
        {
            var targets = (
                from o in _listeners
                where o.name == name && o.handler.Method.GetParameters().Length == parameters.Length
                select o.handler
            ).ToArray();

            foreach (var target in targets)
                if (Thread.CurrentThread.Name == "Network.PacketProcessor")
                    Task.Run(() => target.DynamicInvoke(parameters));
                else
                    target.DynamicInvoke(parameters);
        }
        catch (Exception e)
        {
            Log.Fatal(e);
        }
    }
}
