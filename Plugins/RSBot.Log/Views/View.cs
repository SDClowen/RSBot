namespace RSBot.Log.Views;

internal class View
{
    private static Main _instance;

    /// <summary>
    /// Gets the singleton instance of the Main view
    /// </summary>
    public static Main Instance => _instance ??= new Main();

}