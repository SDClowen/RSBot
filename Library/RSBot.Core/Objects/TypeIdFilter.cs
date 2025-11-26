using System;
using RSBot.Core.Client.ReferenceObjects;

namespace RSBot.Core.Objects;

public class TypeIdFilter
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TypeIdFilter" /> class.
    /// </summary>
    /// <param name="t1">The t1.</param>
    /// <param name="t2">The t2.</param>
    /// <param name="t3">The t3.</param>
    /// <param name="t4">The t4.</param>
    public TypeIdFilter(byte t1, byte t2, byte t3, byte t4)
    {
        TypeID1 = t1;
        TypeID2 = t2;
        TypeID3 = t3;
        TypeID4 = t4;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="TypeIdFilter" /> class.
    /// </summary>
    public TypeIdFilter(Predicate<RefObjCommon> condition)
    {
        _condition = condition;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="TypeIdFilter" /> class.
    /// </summary>
    public TypeIdFilter() { }

    public byte TypeID1 { get; set; }
    public byte TypeID2 { get; set; }
    public byte TypeID3 { get; set; }
    public byte TypeID4 { get; set; }

    public bool CompareByTypeID1 { get; set; }
    public bool CompareByTypeID2 { get; set; }
    public bool CompareByTypeID3 { get; set; }
    public bool CompareByTypeID4 { get; set; }

    private Predicate<RefObjCommon> _condition { get; }

    /// <summary>
    ///     Equalses the reference item.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns></returns>
    public bool EqualsRefItem(RefObjCommon item)
    {
        if (_condition != null && _condition(item))
            return true;

        if (CompareByTypeID1)
            return TypeID1 == item.TypeID1;

        if (CompareByTypeID2)
            return TypeID2 == item.TypeID2;

        if (CompareByTypeID3)
            return TypeID3 == item.TypeID3;

        if (CompareByTypeID4)
            return TypeID4 == item.TypeID4;

        return TypeID1 == item.TypeID1 && TypeID2 == item.TypeID2 && TypeID3 == item.TypeID3 && TypeID4 == item.TypeID4;
    }
}
