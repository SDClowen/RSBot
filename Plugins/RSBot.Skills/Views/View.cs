namespace RSBot.Skills.Views;

internal class View
{
    private static Main _instance;

    /// <summary>
    ///     Gets or sets the instance.
    /// </summary>
    /// <value>
    ///     The instance.
    /// </value>
    public static Main Instance
    {
        get
        {
            if (_instance == null || _instance.IsDisposed || _instance.Disposing)
                _instance = new Main();

            return _instance;
        }
    }
}
