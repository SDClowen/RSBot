namespace RSBot.Alchemy.Bundle;

internal interface IAlchemyBundle
{
    void Start();

    void Stop();

    void Run<T>(T config);
}
