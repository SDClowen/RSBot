using RSBot.Core.Objects;
using System.IO;

namespace RSBot.Core.Components.Collision;

/// <summary>
/// Represents the structure of a RSBot collision mesh.
/// </summary>
internal struct RSCollisionMesh
{
    /// <summary>
    /// The region identifier this navmesh is used for
    /// </summary>
    public Region Region;

    /// <summary>
    /// Gets the collision lines
    /// </summary>
    public RSCollisionLine[] Collisions;

    /// <summary>
    /// Initializes a new instance of the <see cref="RSCollisionMesh"/> struct.
    /// Takes the binary reader and parses a new instance.
    /// </summary>
    /// <param name="reader">The reader.</param>
    public RSCollisionMesh(BinaryReader reader)
    {
        Region = reader.ReadUInt16();
        var collisionLineCount = reader.ReadInt32();

        Collisions = new RSCollisionLine[collisionLineCount];

        for (var i = 0; i < collisionLineCount; i++)
        {
            var source = new RSCollisionPoint
            {
                X = reader.ReadInt16(),
                Y = reader.ReadInt16()
            };
            var destination = new RSCollisionPoint
            {
                X = reader.ReadInt16(),
                Y = reader.ReadInt16()
            };

            Collisions[i] = new RSCollisionLine(source, destination, Region);
        }
    }
}