namespace RSBot.Training.Bundle;

internal interface IBundle
{
    /// <summary>
    ///     Invokes this instance.
    /// </summary>
    void Invoke();

    /// <summary>
    ///     Refreshes this instance.
    /// </summary>
    void Refresh();

    /// <summary>
    ///     Stops this instance.
    /// </summary>
    void Stop();
}
