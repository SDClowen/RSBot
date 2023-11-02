using System;
using System.Text;

namespace RSBot.Pk2.Security;

internal class BlowfishUtilities
{
    #region Fields

    /// <summary>
    ///     Application wide instance of the blowfish. Nothing but this instance should be used while working with the archive.
    ///     Use BlowfishUtilities.GetBlowfish() to get this instance
    /// </summary>
    private static Blowfish _blowfish;

    #endregion Fields

    /// <summary>
    ///     Generates the final blowfish key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="baseKey">The base key.</param>
    /// <returns></returns>
    public static byte[] GenerateFinalBlowfishKey(string key, byte[] baseKey)
    {
        var plainKeyLength = (byte)key.Length;

        //Max count of 56 key bytes
        if (plainKeyLength > 56) plainKeyLength = 56;

        //Get bytes from ascii
        var asciiKey = Encoding.ASCII.GetBytes(key);

        //This is the Silkroad bas key used in all versions
        var bKey = new byte[56];

        //Copy key to array to keep the b_key at 56 bytes. b_key has to be bigger than a_key
        //to be able to xor every index of a_key.
        Array.ConstrainedCopy(baseKey, 0, bKey, 0, baseKey.Length);

        // The key modification algorithm for the final blowfish key
        var blowfishKey = new byte[plainKeyLength];
        for (byte x = 0; x < plainKeyLength; ++x) blowfishKey[x] = (byte)(asciiKey[x] ^ bKey[x]);

        return blowfishKey;
    }

    /// <summary>
    ///     Gets the blowfish.
    /// </summary>
    /// <returns></returns>
    public static Blowfish GetBlowfish()
    {
        return _blowfish;
    }

    /// <summary>
    ///     Sets the blowfish.
    /// </summary>
    /// <param name="instance">The instance.</param>
    public static void SetBlowfish(Blowfish instance)
    {
        _blowfish = instance;
    }
}