namespace RSBot.Pk2.IO.Stream;

internal enum StreamOperation
{
    /// <summary>
    ///     Providing this flag will grant you read access. No writer will be initialized
    /// </summary>
    Read,

    /// <summary>
    ///     Providing this flag will grant you write access. No reader will be initialized
    /// </summary>
    Write,

    /// <summary>
    ///     Providing this flag will grant you read and write access.
    /// </summary>
    ReadWrite
}