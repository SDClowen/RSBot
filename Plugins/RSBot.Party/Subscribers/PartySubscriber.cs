using System.Linq;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Party.Bundle;

namespace RSBot.Party.Subscribers;

internal class PartySubscriber
{
    /// <summary>
    ///     Gets the subscribed events.
    /// </summary>
    /// <returns></returns>
    public static void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnPartyRequest", OnPartyRequest);
    }

    /// <summary>
    ///     Checks the request.
    /// </summary>
    /// <returns></returns>
    private static bool CheckRequest()
    {
        //Check for the pending request
        if (!Game.Party.HasPendingRequest) return false;

        Log.NotifyLang("PartyPlayerInvite", Game.AcceptanceRequest.Player.Name);

        //Check if we are near the training place
        if (Container.AutoParty.Config.OnlyAtTrainingPlace &&
            Game.Player.Movement.Source.DistanceTo(Container.AutoParty.Config.CenterPosition) > 50) return false;

        //Check if the inviting player matches out party list
        if (Container.AutoParty.Config.AcceptFromList &&
            Container.AutoParty.Config.PlayerList.Contains(Game.AcceptanceRequest.Player.Name)) return true;

        return Container.AutoParty.Config.AcceptAll;
    }

    /// <summary>
    ///     Will be fired when the player is being invited to a party
    /// </summary>
    private static void OnPartyRequest()
    {
        if (!Kernel.Bot.Running && !Container.AutoParty.Config.AcceptIfBotIsStopped) return;

        if (CheckRequest())
            Game.AcceptanceRequest.Accept();
        else
            Game.AcceptanceRequest.Refuse();
    }
}