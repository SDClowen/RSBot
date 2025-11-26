using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RSBot.Core.Network;

public class PacketManager
{
    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    private static readonly object _lock = new();

    /// <summary>
    ///     Gets the handlers.
    /// </summary>
    /// <value>
    ///     The handlers.
    /// </value>
    internal static List<IPacketHandler> Handlers;

    /// <summary>
    ///     Gets the hooks.
    /// </summary>
    internal static List<IPacketHook> Hooks;

    /// <summary>
    ///     The callbacks
    /// </summary>
    private static readonly List<AwaitCallback> _callbacks = new();

    /// <summary>
    ///     Registers the handler.
    /// </summary>
    /// <param name="handler">The handler.</param>
    public static void RegisterHandler(IPacketHandler handler)
    {
        if (Handlers == null)
            Handlers = new List<IPacketHandler>();

        Handlers.Add(handler);
    }

    /// <summary>
    ///     Removes the handler.
    /// </summary>
    /// <param name="handler">The handler.</param>
    public static void RemoveHandler(IPacketHandler handler)
    {
        Handlers?.Remove(handler);
    }

    /// <summary>
    ///     Registers the hook.
    /// </summary>
    /// <param name="hook">The hook.</param>
    public static void RegisterHook(IPacketHook hook)
    {
        if (Hooks == null)
            Hooks = new List<IPacketHook>();

        Hooks.Add(hook);
    }

    /// <summary>
    ///     Removes the hook.
    /// </summary>
    /// <param name="hook">The hook.</param>
    public static void RemoveHook(IPacketHook hook)
    {
        Hooks?.Remove(hook);
    }

    /// <summary>
    ///     Calls the specified packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="destination">The destination.</param>
    internal static void CallHandler(Packet packet, PacketDestination destination)
    {
        if (Handlers == null)
            return;

        foreach (
            var handler in Handlers.Where(handler =>
                handler != null && handler.Opcode == packet.Opcode && handler.Destination == destination
            )
        )
        {
            handler.Invoke(packet);
            packet.SeekRead(0, SeekOrigin.Begin);
        }
    }

    /// <summary>
    ///     Calls the registered hooks and returns a replaced packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="destination">The destination.</param>
    /// <returns></returns>
    internal static Packet CallHook(Packet packet, PacketDestination destination)
    {
        var hooks = Hooks?.Where(hook =>
            packet != null && hook.Opcode == packet.Opcode && hook.Destination == destination
        );
        foreach (var hook in hooks)
            packet = hook.ReplacePacket(packet);

        return packet;
    }

    /// <summary>
    ///     Calls the callback.
    /// </summary>
    /// <param name="packet">The packet.</param>
    internal static void CallCallback(Packet packet)
    {
        lock (_lock)
        {
            var tempCallbacks = _callbacks.Where(c => c.ResponseOpcode == packet.Opcode);

            foreach (var callback in tempCallbacks)
            {
                packet.SeekRead(0, SeekOrigin.Begin);
                callback.Invoke(packet);
            }

            _callbacks.RemoveAll(c => c.IsClosed);
        }
    }

    /// <summary>
    ///     Sends the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="destination">The destination.</param>
    public static void SendPacket(Packet packet, PacketDestination destination)
    {
        if (Kernel.Proxy == null)
            return;

        if (!packet.Locked)
            packet.Lock();

        try
        {
            switch (destination)
            {
                case PacketDestination.Client:
                    if (!Game.Clientless)
                        Kernel.Proxy.Client?.Send(packet);
                    break;

                case PacketDestination.Server:
                    Kernel.Proxy.Server?.Send(packet);
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Fatal(e);
        }
    }

    /// <summary>
    ///     Sends the packet.
    /// </summary>
    /// <param name="packet">The packet.</param>
    /// <param name="destination">The destination.</param>
    /// <param name="callback">The callback.</param>
    public static void SendPacket(Packet packet, PacketDestination destination, params AwaitCallback[] callbacks)
    {
        if (Kernel.Proxy == null)
            return;

        lock (_lock)
        {
            _callbacks.AddRange(callbacks);
        }

        SendPacket(packet, destination);
    }

    /// <summary>
    ///     Gets the handlers by the specified opcode. If none specified, all handlers will be returned.
    /// </summary>
    /// <param name="opcode">The opcode.</param>
    /// <returns></returns>
    public static List<IPacketHandler> GetHandlers(ushort? opcode = null)
    {
        if (opcode == null)
            return Handlers;

        return Handlers.Where(h => h.Opcode == opcode).ToList();
    }

    /// <summary>
    ///     Gets the hooks by the specified opcode. If none specified, all hooks will be returned.
    /// </summary>
    /// <param name="opcode">The opcode.</param>
    /// <returns></returns>
    public static List<IPacketHook> GetHooks(ushort? opcode = null)
    {
        return opcode == null ? Hooks : Hooks.Where(h => h.Opcode == opcode).ToList();
    }
}
