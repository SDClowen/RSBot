using System.Numerics;
using RSBot.NavMeshApi.Helper;

namespace RSBot.NavMeshApi.Mathematics;

public struct RegionPosition
{
    private RID _region;
    private Vector3 _localPosition;

    public RID Region => _region;
    public Vector3 LocalPosition => _localPosition;
    public Vector3 Position => this.Region.Position + this.LocalPosition;

    public RegionPosition(Vector3 position)
    {
        var regionX = (byte)(position.X / RID.Width);
        var regionZ = (byte)(position.Z / RID.Length);

        _region = new RID(regionX, regionZ);
        _localPosition = position - _region.Position;
    }

    public RegionPosition(RID region, Vector3 localPosition)
    {
        _region = region;
        _localPosition = localPosition;
    }

    public void Break()
    {
        // Used to break a position which is exactly on 0 or 1920 after region transition.

        const float breakThreshold = 0.01f;

        if (_localPosition.X.IsApproximately(RID.Width))
            _localPosition.X = breakThreshold;
        else if (_localPosition.X.IsApproximately(0.0f))
            _localPosition.X = RID.Width - breakThreshold;

        if (_localPosition.Z.IsApproximately(RID.Length))
            _localPosition.Z = breakThreshold;
        else if (_localPosition.Z.IsApproximately(0.0f))
            _localPosition.Z = RID.Length - breakThreshold;
    }

    public void Normalize()
    {
        if (_region.IsDungeon)
            return; // local dungeon space is infinite

        // TODO: Measure performance breakpoint against while loop based normalization

        // move x back into region space
        if (_localPosition.X > RID.Width)
        {
            _region.X += (byte)(_localPosition.X / RID.Width);
            _localPosition.X %= RID.Width;
        }
        else if (_localPosition.X < 0.0f)
        {
            _region.X += (byte)(_localPosition.X / RID.Width);
            _localPosition.X %= RID.Width;
        }

        // move z back into region space
        if (_localPosition.Z > RID.Length)
        {
            _region.Z += (byte)(_localPosition.Z / RID.Length);
            _localPosition.Z %= RID.Length;
        }
        else if (_localPosition.Z < 0.0f)
        {
            _region.Z += (byte)(_localPosition.Z / RID.Length);
            _localPosition.Z %= RID.Length;
        }
    }

    public override string ToString() =>
        $"RID: {Region:X4}, X: {_localPosition.X}, Y: {_localPosition.Y}, Z: {_localPosition.Z}";
}
