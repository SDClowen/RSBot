namespace RSBot.FileSystem.PackFile.Struct;

public record PackHeader
{
    public const string BlowfishChecksumDecoded = "Joymax Pak File";

    /// <summary>
    ///     A value indicating if the archive is encrypted.
    /// </summary>
    public byte Encrypted;

    /// <summary>
    ///     The checksum that can be used to validate the joymax pack file password.
    /// </summary>
    public byte[] EncryptionChecksum = Array.Empty<byte>();

    /// <summary>
    ///     The payload. Can be used to store additional information in the header of the joymax pack file.
    /// </summary>
    public byte[] Payload = new byte[205];

    /// <summary>
    ///     The header signature. Used to verify the type of the file.
    /// </summary>
    public char[] Signature = Array.Empty<char>();

    /// <summary>
    ///     The version of the joymax pack file.
    /// </summary>
    public int Version;

    /// <summary>
    ///     Serializes this instance into a byte array.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="IOException">
    ///     Signature length is too long
    ///     Payload length is too long
    ///     EncryptionChecksum length is not equal to 16
    /// </exception>
    public byte[] ToByteArray()
    {
        if (Signature.Length > 30)
            throw new IOException("The length of the signature exceeds the maximum length of 30 characters.");

        if (Payload.Length > 205)
            throw new IOException("The length of the payload exceeds the maximum count of 205 bytes");

        if (EncryptionChecksum.Length != 16)
            throw new IOException(
                $"The length of the encryption checksum should be 16. The provided length is: {Signature.Length}"
            );

        var buffer = new byte[256];
        var payload = new byte[205];
        var signature = new char[30];

        Signature.CopyTo(signature, 0);
        Payload.CopyTo(payload, 0);

        using var writer = new BinaryWriter(new MemoryStream(buffer));
        writer.Write(signature);
        writer.Write(Version);
        writer.Write(Encrypted);
        writer.Write(EncryptionChecksum);
        writer.Write(payload);

        return buffer;
    }
}
