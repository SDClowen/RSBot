using System;
using System.Collections.Generic;
using System.IO;

namespace RSBot.Core.Components.Collision;

/// <summary>
/// Represents the structure of a RSBot collision mesh.
/// </summary>
internal struct RSCollisionMesh
{
    private const int SupportedVersion = 1100;

    /// <summary>
    /// The header of the rs navmesh file
    /// </summary>
    public string Header;

    /// <summary>
    /// The version of the rs navmesh file
    /// </summary>
    public int Version;

    /// <summary>
    /// The region identifier this navmesh is used for
    /// </summary>
    public ushort RegionId;

    /// <summary>
    /// Gets the collision lines
    /// </summary>
    public RSCollisionLine[] FloorCollisions;

    /// <summary>
    /// The collision objects
    /// </summary>
    public RSCollisionObject[] ObjectCollisions;

    /// <summary>
    /// Initializes a new instance of the <see cref="RSCollisionMesh"/> struct.
    /// Takes the binary reader and parses a new instance.
    /// </summary>
    /// <param name="reader">The reader.</param>
    public RSCollisionMesh(BinaryReader reader)
    {
        Header = reader.ReadString();
        Version = reader.ReadInt32();

        if (Version != SupportedVersion)
            throw new Exception("The collision mesh has an unsupported version.");

        RegionId = reader.ReadUInt16();
        var collisionLineCount = reader.ReadInt32();

        FloorCollisions = new RSCollisionLine[collisionLineCount];

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

            FloorCollisions[i] = new RSCollisionLine(source, destination, RegionId);
        }

        ObjectCollisions = new RSCollisionObject[reader.ReadInt32()];
        for (var iObject = 0; iObject < ObjectCollisions.Length; iObject++)
        {
            var id = reader.ReadString();
            var fileName = reader.ReadString();
            var outlines = new RSCollisionLine[reader.ReadInt32()];

            for (var iOutline = 0; iOutline < outlines.Length; iOutline++)
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

                outlines[iOutline] = new RSCollisionLine(source, destination, RegionId);
            }

            ObjectCollisions[iObject] = new RSCollisionObject(id, fileName, outlines);
        }
    }

    public RSCollisionLine[] GetCollisions()
    {
        var collisionLinesObjects = new List<RSCollisionLine>();

        foreach (var obj in ObjectCollisions)
            collisionLinesObjects.AddRange(obj.Outlines);
        
        var result = new List<RSCollisionLine>(collisionLinesObjects.Count + FloorCollisions.Length);
        result.AddRange(collisionLinesObjects);
        result.AddRange(FloorCollisions);

        return result.ToArray();
    }
}