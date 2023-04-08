using System.Collections.Generic;
using System.Linq;
using RSBot.Core;
using RSBot.Core.Objects;

namespace RSBot.Trade.Components;

internal static class TradeConfig
{
    public static string TracePlayerName
    {
        get => PlayerConfig.Get("RSBot.Trade.TracePlayerName", "");
        set => PlayerConfig.Set("RSBot.Trade.TracePlayerName", value);
    }

    public static bool TracePlayer
    {
        get => PlayerConfig.Get("RSBot.Trade.TracePlayer", false);
        set => PlayerConfig.Set("RSBot.Trade.TracePlayer", value);
    }

    public static bool UseRouteScripts
    {
        get => PlayerConfig.Get("RSBot.Trade.UseRouteScripts", true);
        set => PlayerConfig.Set("RSBot.Trade.UseRouteScripts", value);
    }

    public static int SelectedRouteListIndex
    {
        get => PlayerConfig.Get("RSBot.Trade.SelectedRouteListIndex", 0);
        set => PlayerConfig.Set("RSBot.Trade.SelectedRouteListIndex", value);
    }
    
    public static bool RunTownScript
    {
        get => PlayerConfig.Get("RSBot.Trade.RunTownScript", false);
        set => PlayerConfig.Set("RSBot.Trade.RunTownScript", value);
    }

    public static bool WaitForHunter
    {
        get => PlayerConfig.Get("RSBot.Trade.WaitForHunter", false);
        set => PlayerConfig.Set("RSBot.Trade.WaitForHunter", value);
    }

    public static bool AttackThiefPlayers
    {
        get => PlayerConfig.Get("RSBot.Trade.AttackThiefPlayers", false);
        set => PlayerConfig.Set("RSBot.Trade.AttackThiefPlayer", value);
    }

    public static bool AttackThiefNpcs
    {
        get => PlayerConfig.Get("RSBot.Trade.AttackThiefNpc", false);
        set => PlayerConfig.Set("RSBot.Trade.AttackThiefNpc", value);
    }

    public static bool CastBuffsWhileWalking
    {
        get => PlayerConfig.Get("RSBot.Trade.CastBuffsWhileWalking", false);
        set => PlayerConfig.Set("RSBot.Trade.CastBuffsWhileWalking", value);
    }
    public static bool CastBuffsWhileFighting
    {
        get => PlayerConfig.Get("RSBot.Trade.CastBuffsWhileFighting", false);
        set => PlayerConfig.Set("RSBot.Trade.CastBuffsWhileFighting", value);
    }

    public static bool CounterAttack
    {
        get => PlayerConfig.Get("RSBot.Trade.CounterAttack", false);
        set => PlayerConfig.Set("RSBot.Trade.CounterAttack", value);
    }

    public static bool ProtectTransport
    {
        get => PlayerConfig.Get("RSBot.Trade.ProtectTransport", false);
        set => PlayerConfig.Set("RSBot.Trade.ProtectTransport", value);
    }

    public static bool BuyGoods
    {
        get => PlayerConfig.Get("RSBot.Trade.BuyGoods", false);
        set => PlayerConfig.Set("RSBot.Trade.BuyGoods", value);
    }

    public static bool SellGoods
    {
        get => PlayerConfig.Get("RSBot.Trade.SellGoods", false);
        set => PlayerConfig.Set("RSBot.Trade.SellGoods", value);
    }

    public static int BuyGoodsQuantity
    {
        get => PlayerConfig.Get("RSBot.Trade.BuyGoodsQuantity", 0);
        set => PlayerConfig.Set("RSBot.Trade.BuyGoodsQuantity", value);
    }


    public static List<string> RouteScriptList
    {
        get
        {
            var result = PlayerConfig.GetArray<string>("RSBot.Trade.RouteScriptList", ';').ToList();

            if (!result.Contains("Default")) 
                result.Add("Default");

            return result;
        }
        set => PlayerConfig.SetArray("RSBot.Trade.RouteScriptList", value, ";");
    }


    public static Dictionary<string, List<string>> RouteScripts
    {
        get
        {
            var result = new Dictionary<string, List<string>>(16);

            foreach (var scriptList in RouteScriptList)
            {
                var scripts = PlayerConfig.GetArray<string>($"RSBot.Trade.RouteScriptList.{scriptList}").ToList() ?? new List<string>();

                result.Add(scriptList, scripts);
            }

            return result;
        }
        set
        {
            foreach (var scriptList in value)
                PlayerConfig.SetArray($"RSBot.Trade.RouteScriptList.{scriptList.Key}", scriptList.Value);

            RouteScriptList = value.Keys.ToList();
        }
    }
}