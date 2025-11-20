using System.Text;

namespace RSBot.FileSystem.PackFile.Cryptography;

public static class BlowfishUtil
{
    /// <summary>
    ///     Generates the final blowfish key.
    /// </summary>
    /// <param name="password">Password</param>
    /// <param name="salt">Salt to make it tasty</param>
    /// <returns></returns>
    public static byte[] GenerateFinalBlowfishKey(string password, byte[] salt)
    {
        //from PK2Builder.cpp by Drew 'pushedx' Benton

        var plainKeyLength = (byte)password.Length;

        //Max count of 56 key bytes
        if (plainKeyLength > 56)
            plainKeyLength = 56;

        //Get bytes from ascii
        var aKey = Encoding.ASCII.GetBytes(password);

        // This is the Silkroad base key used in all versions
        var bKey = new byte[56];

        //Copy key to array to keep the b_key at 56 bytes. b_key has to be bigger than a_key
        //to be able to xor every index of a_key.
        Array.ConstrainedCopy(salt, 0, bKey, 0, salt.Length);

        // The key modification algorithm for the final blowfish key
        var bfKey = new byte[plainKeyLength];
        for (byte x = 0; x < plainKeyLength; ++x)
            bfKey[x] = (byte)(aKey[x] ^ bKey[x]);

        return bfKey;
    }
}
