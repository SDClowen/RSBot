namespace RSBot.Core.Client;

internal interface IReference
{
    bool Load(ReferenceParser parser);
}

internal interface IReference<TKey> : IReference
{
    TKey PrimaryKey { get; }
}
