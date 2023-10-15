namespace RSBot.Pk2;

public enum PK2Mode
{
    /// <summary>
    /// This mode will index the blocks of the PK2 but will not order them in any way.
    /// Use this mode if you wish to access files fast and uncomplicated
    /// </summary>
    IndexBlocks = 0,

    /// <summary>
    /// This mode will create its very own index to provide possibilities like file paths and sub directory structures.
    /// Costs a lot more RAM but is the most detailed mode.
    /// </summary>
    Index = 1
}