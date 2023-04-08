
namespace RSBot.Trade.Components.Statistics
{
    internal class TradeStatistics
    {
        public static int TradesCompleted { get; set; }

        public static ulong Revenue { get; set; }

        public static void Reset()
        {
            TradesCompleted = 0;
            Revenue = 0;
        }
    }
}
