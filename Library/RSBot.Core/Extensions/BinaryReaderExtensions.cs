using System.Drawing;
using System.IO;
using System.Numerics;
using System.Text;

namespace RSBot.Core.Extensions;

public static class BinaryReaderExtensions
{
    /// <summary>
    ///     Reads the joymax string.
    ///     korean codepage: 949
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    public static string ReadJoymaxString(this BinaryReader reader)
    {
        var stringLength = reader.ReadInt32();
        return Encoding.UTF8.GetString(reader.ReadBytes(stringLength));
    }

    /// <summary>
    ///     Reads the vector3.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    public static Vector3 ReadVector3(this BinaryReader reader)
    {
        return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
    }

    /// <summary>
    ///     Reads the vector3.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    public static Vector2 ReadVector2(this BinaryReader reader)
    {
        return new Vector2(reader.ReadSingle(), reader.ReadSingle());
    }

    /// <summary>
    ///     Reads the rectangle f.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns></returns>
    public static RectangleF ReadRectangleF(this BinaryReader reader)
    {
        var x1 = reader.ReadSingle();
        var y1 = reader.ReadSingle();
        var x2 = reader.ReadSingle();
        var y2 = reader.ReadSingle();
        return new RectangleF(x1, y1, x2 - x1, y2 - y1);
    }
}
