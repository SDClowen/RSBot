using System.Diagnostics;
using RSBot.NavMeshApi.Mathematics;

namespace RSBot.NavMeshApi;

public class RegionManager
{
    public const int REGIONS_X = 256;
    public const int REGIONS_Y = 256;
    public const int REGIONS_TOTAL = REGIONS_X * REGIONS_Y;

    public short MapWidth { get; private set; }
    public short MapLength { get; private set; }
    public short Short2 { get; private set; }
    public short Short3 { get; private set; }
    public short Short4 { get; private set; }
    public short Short5 { get; private set; }
    public int ActiveRegions { get; private set; }

    private byte[] _mapRegions;

    public void Load(Stream stream)
    {
        using (var reader = new NavMeshReader(stream))
        {
            var signature = reader.ReadString(12);
            if (signature != "JMXVMFO 1000")
                throw new Exception("Invalid signature");

            this.MapWidth = reader.ReadInt16();
            this.MapLength = reader.ReadInt16();
            Debug.WriteLine($"RegionManager: Map project resolution {this.MapWidth}x{this.MapLength}");

            this.Short2 = reader.ReadInt16();
            this.Short3 = reader.ReadInt16();
            this.Short4 = reader.ReadInt16();
            this.Short5 = reader.ReadInt16();
            _mapRegions = reader.ReadBytes(REGIONS_TOTAL / 8);
        }

        // Count active regions
        for (int z = 0; z < this.MapLength; z++)
        {
            for (int x = 0; x < this.MapWidth; x++)
            {
                if (this.IsEnabled((byte)x, (byte)z))
                    this.ActiveRegions++;
            }
        }
    }

    public bool IsEnabled(RID region)
    {
        if (region.IsDungeon)
            return false;

        if (region.X >= this.MapWidth || region.Z >= this.MapLength)
            return false;

        return (_mapRegions[(ushort)region >> 3] & (byte)(128 >> (ushort)region % 8)) != 0;
    }

    public bool IsEnabled(byte x, byte z) => this.IsEnabled(new RID(x, z));
}
