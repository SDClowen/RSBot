namespace RSBot.Pk2;

public class PK2Config
{
    /// <summary>
    /// Gets or sets the mode.
    /// </summary>
    /// <value>
    /// The mode.
    /// </value>
    public PK2Mode Mode { get; set; }

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    /// <value>
    /// The key.
    /// </value>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the base key.
    /// </summary>
    /// <value>
    /// The base key.
    /// </value>
    public byte[] BaseKey { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PK2Config"/> class.
    /// </summary>
    public PK2Config() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PK2Config" /> class.
    /// </summary>
    /// <param name="mode">The mode.</param>
    /// <param name="key">The key.</param>
    /// <param name="baseKey">The base key.</param>
    public PK2Config(PK2Mode mode, string key, byte[] baseKey)
    {
        Mode = mode;
        Key = key;
        BaseKey = baseKey;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PK2Config" /> class.
    /// </summary>
    /// <param name="mode">The mode.</param>
    /// <param name="key">The key.</param>
    public PK2Config(PK2Mode mode, string key)
    {
        Mode = mode;
        Key = key;
        BaseKey = new byte[] { 0x03, 0xF8, 0xE4, 0x44, 0x88, 0x99, 0x3F, 0x64, 0xFE, 0x35 };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PK2Config" /> class.
    /// </summary>
    /// <param name="mode">The mode.</param>
    public PK2Config(PK2Mode mode)
    {
        Mode = mode;
        Key = "169841";
        BaseKey = new byte[] { 0x03, 0xF8, 0xE4, 0x44, 0x88, 0x99, 0x3F, 0x64, 0xFE, 0x35 };
    }

    /// <summary>
    /// Gets the default configuration.
    /// </summary>
    /// <returns></returns>
    public static PK2Config GetDefault()
    {
        return new PK2Config(PK2Mode.Index, "169841", new byte[] { 0x03, 0xF8, 0xE4, 0x44, 0x88, 0x99, 0x3F, 0x64, 0xFE, 0x35 });
    }
}