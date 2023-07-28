namespace RSBot.ServerInfo.Views;

internal static class View
{
    private static Main _main = new();

    public static Main Main
    {
        get
        {
            if (_main == null || _main.IsDisposed)
                _main = new Main();

            return _main;
        }
    }
}
