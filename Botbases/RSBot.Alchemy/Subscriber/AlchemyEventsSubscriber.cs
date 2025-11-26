using System;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Subscriber;

internal class AlchemyEventsSubscriber
{
    public static void Subscribe()
    {
        EventManager.SubscribeEvent("OnAlchemyError", new Action<ushort, AlchemyType>(OnAlchemyError));
        EventManager.SubscribeEvent("OnAlchemyDestroyed", new Action<InventoryItem, AlchemyType>(OnAlchemyDestroyed));
        EventManager.SubscribeEvent("OnFuseRequest", new Action<AlchemyAction, AlchemyType>(OnFuseRequest));
    }

    private static void OnAlchemyDestroyed(InventoryItem oldItem, AlchemyType type)
    {
        if (!Bootstrap.IsActive)
            return;

        Globals.Botbase.EnhanceBundleConfig = null;
        Globals.Botbase.MagicBundleConfig = null;

        Globals.View.SelectedItem = null;
        Globals.View.AddLog(
            oldItem.Record.GetRealName(),
            Game.ReferenceManager.GetTranslation("UIIT_MSG_REINFORCERR_BREAKDOWN")
        );
        Log.Warn("[Alchemy] The item has been destroyed, stopping now...");

        Kernel.Bot?.Stop();
    }

    private static void OnAlchemyError(ushort errorCode, AlchemyType type)
    {
        if (!Bootstrap.IsActive)
            return;

        if (errorCode is 0x5423)
            return;

        Kernel.Bot?.Stop();

        Log.Error($"[Alchemy] Alchemy fusion error: {errorCode:X}");
    }

    /// <summary>
    ///     Will be triggered if any fuse request (either elixir or magic stone..) was sent to the server. Adds a log message.
    /// </summary>
    /// <param name="action">The alchemy action</param>
    /// <param name="type">The type of alchemy</param>
    private static void OnFuseRequest(AlchemyAction action, AlchemyType type)
    {
        if (AlchemyManager.ActiveAlchemyItems == null)
            return;

        var ingredient = AlchemyManager.ActiveAlchemyItems.ElementAtOrDefault(1);
        var item = AlchemyManager.ActiveAlchemyItems.ElementAtOrDefault(0);

        switch (type)
        {
            case AlchemyType.Elixir:
                Globals.View.AddLog(item?.Record.GetRealName(), $"Fusing elixir [{ingredient.Record.GetRealName()}]");
                break;

            case AlchemyType.MagicStone:
                Globals.View.AddLog(
                    item?.Record.GetRealName(),
                    $"Fusing magic stone [{ingredient.Record.GetRealName()}]"
                );
                break;

            case AlchemyType.AttributeStone:
                Globals.View.AddLog(
                    item?.Record.GetRealName(),
                    $"Fusing attribute stone [{ingredient.Record.GetRealName()}]"
                );
                break;

            default:
                Globals.View.AddLog(item?.Record.GetRealName(), $"Fusing [{ingredient.Record.GetRealName()}]");
                break;
        }
    }
}
