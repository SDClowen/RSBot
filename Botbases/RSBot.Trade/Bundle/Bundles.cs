namespace RSBot.Trade.Bundle
{
    internal static class Bundles
    {
        public static TransportBundle TransportBundle { get; } = new ();
        public static RouteBundle RouteBundle { get; } = new ();
        public static AttackBundle AttackBundle { get; } = new ();

        public static void Tick()
        {
            TransportBundle.Tick();
            RouteBundle.Tick();
            AttackBundle.Tick();
        }

        public static void Stop()
        {
            TransportBundle.Stop();
            RouteBundle.Stop();
            AttackBundle.Stop();
        }

        public static void Initialize()
        {
            TransportBundle.Initialize();
            RouteBundle.Initialize();
            AttackBundle.Initialize();
        }

        public static void Start()
        {
            TransportBundle.Start();
            RouteBundle.Start();
            AttackBundle.Start();
        }
    }
}
