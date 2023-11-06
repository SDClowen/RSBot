using System.Numerics;
using RSBot.NavMeshApi.Helper;

namespace RSBot.NavMeshApi.Mathematics;

public struct RegionPosition
{
    private Region _region;
    private Vector3 _localPosition;

    public Region Region => _region;
    public Vector3 LocalPosition => _localPosition;
    public Vector3 Position => this.Region.Position + this.LocalPosition;

    public RegionPosition(Vector3 position)
    {
        var regionX = (byte)(position.X / Region.Width);
        var regionZ = (byte)(position.Z / Region.Length);

        _region = new Region(regionX, regionZ);
        _localPosition = position - _region.Position;
    }

    public RegionPosition(Region region, Vector3 localPosition)
    {
        _region = region;
        _localPosition = localPosition;
    }

    public void Break()
    {
        // Used to break a position which is exactly on 0 or 1920 after region transition.

        const float breakThreshold = 0.01f;

        if (_localPosition.X.IsApproximately(Region.Width))
            _localPosition.X = breakThreshold;
        else if (_localPosition.X.IsApproximately(0.0f))
            _localPosition.X = Region.Width - breakThreshold;

        if (_localPosition.Z.IsApproximately(Region.Length))
            _localPosition.Z = breakThreshold;
        else if (_localPosition.Z.IsApproximately(0.0f))
            _localPosition.Z = Region.Length - breakThreshold;
    }

    public void Normalize()
    {
        if (_region.IsDungeon)
            return; // local dungeon space is infinite

        // TODO: Measure performance breakpoint against while loop based normalization

        // move x back into region space
        if (_localPosition.X > Region.Width)
        {
            _region.X += (byte)(_localPosition.X / Region.Width);
            _localPosition.X %= Region.Width;
        }
        else if (_localPosition.X < 0.0f)
        {
            _region.X += (byte)(_localPosition.X / Region.Width);
            _localPosition.X %= Region.Width;
        }

        // move z back into region space
        if (_localPosition.Z > Region.Length)
        {
            _region.Z += (byte)(_localPosition.Z / Region.Length);
            _localPosition.Z %= Region.Length;
        }
        else if (_localPosition.Z < 0.0f)
        {
            _region.Z += (byte)(_localPosition.Z / Region.Length);
            _localPosition.Z %= Region.Length;
        }
    }
}