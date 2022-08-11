namespace RSBot.Alchemy.Bot
{
    internal interface IAlchemyEngine
    {
        void Start();

        void Stop();

        void Run<T>(T config);
    }
}