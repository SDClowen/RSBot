namespace RSBot.Lure.Views;

internal static class View
{
    private static Main _mainInstance;

    public static Main Main
    {
        get
        {
            if (_mainInstance == null || _mainInstance.IsDisposed || _mainInstance.Disposing)
                _mainInstance = new Main();

            return _mainInstance;
        }
    }
}