using System.Collections.Generic;
using System.IO;

namespace RSBot.Core.Components.Collision;

internal struct RSCollisionObject
{
    /// <summary>
    /// The file name of the mesh
    /// </summary>
    public string FileName;

    /// <summary>
    /// Gets the name of the mesh.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name => Path.GetFileNameWithoutExtension(FileName);

    /// <summary>
    /// The outlines of the mesh
    /// </summary>
    public RSCollisionLine[] Outlines;

    /// <summary>
    /// The identifier of the mesh
    /// </summary>
    public string Id;

    public RSCollisionObject(string id, string fileName, RSCollisionLine[] outlines)
    {
        Id = id;
        FileName = fileName;
        Outlines = outlines;
    }
}