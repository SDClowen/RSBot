using RSBot.Core.Event;
using RSBot.Training.Bundle;

namespace RSBot.Training.Subscriber;

internal class BundleSubscriber
{
    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("Bundle.Loop.Start", Bundles.Loop.Start);
        EventManager.SubscribeEvent("Bundle.Loop.Stop", Bundles.Loop.Stop);
        EventManager.SubscribeEvent("Bundle.Loop.Invoke", Bundles.Loop.Invoke);

        EventManager.SubscribeEvent("Bundle.Attack.Stop", Bundles.Attack.Stop);
        EventManager.SubscribeEvent("Bundle.Attack.Invoke", Bundles.Attack.Invoke);

        EventManager.SubscribeEvent("Bundle.Buff.Stop", Bundles.Buff.Stop);
        EventManager.SubscribeEvent("Bundle.Buff.Invoke", Bundles.Buff.Invoke);

        EventManager.SubscribeEvent("Bundle.Berzerk.Stop", Bundles.Berzerk.Stop);
        EventManager.SubscribeEvent("Bundle.Berzerk.Invoke", Bundles.Berzerk.Invoke);

        EventManager.SubscribeEvent("Bundle.Target.Stop", Bundles.Target.Stop);
        EventManager.SubscribeEvent("Bundle.Target.Invoke", Bundles.Target.Invoke);

        EventManager.SubscribeEvent("Bundle.Loot.Stop", Bundles.Loot.Stop);
        EventManager.SubscribeEvent("Bundle.Loot.Invoke", Bundles.Loot.Invoke);

        EventManager.SubscribeEvent("Bundle.Movement.Stop", Bundles.Movement.Stop);
        EventManager.SubscribeEvent("Bundle.Movement.Invoke", Bundles.Movement.Invoke);

        EventManager.SubscribeEvent("Bundle.PartyBuffing.Stop", Bundles.PartyBuff.Stop);
        EventManager.SubscribeEvent("Bundle.PartyBuffing.Invoke", Bundles.PartyBuff.Invoke);

        EventManager.SubscribeEvent("Bundle.Resurrect.Stop", Bundles.Resurrect.Stop);
        EventManager.SubscribeEvent("Bundle.Resurrect.Invoke", Bundles.Resurrect.Invoke);

        EventManager.SubscribeEvent("Bundle.Protection.Stop", Bundles.Protection.Stop);
        EventManager.SubscribeEvent("Bundle.Protection.Invoke", Bundles.Protection.Invoke);
    }
}
