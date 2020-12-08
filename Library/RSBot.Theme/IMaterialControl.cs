namespace RSBot.Theme
{
    internal interface IMaterialControl
    {
        int Depth { get; set; }
        MaterialSkinManager SkinManager { get; }
        IMatMouseState MouseState { get; set; }
    }

    public enum IMatMouseState
    {
        HOVER,
        DOWN,
        OUT
    }
}