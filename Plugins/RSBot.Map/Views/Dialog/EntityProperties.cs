using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using SDUI.Controls;
using System.ComponentModel;
using System.Drawing;

namespace RSBot.Map.Views.Dialog;

public partial class EntityProperties : CleanForm
{
    public SpawnedBionic Bionic { get; }

    public EntityProperties(SpawnedBionic bionic)
    {
        InitializeComponent();

        Bionic = bionic;
        Text = $"Entity properties - {bionic.Record.GetRealName()} [UniqueId: {bionic.UniqueId}, Id: {bionic.Record.ID}, TID2: {bionic.Record.TypeID2}, TID3: {bionic.Record.TypeID3}, TID4: {bionic.Record.TypeID4}]";
        Size = new Size(620, 800);

        propEntity.SelectedObject = new EntityDebugInformation(bionic);
    }
}

internal class EntityDebugInformation
{
    [Category("SpawnedBionic")]
    public double DistanceToPlayer { get; }

    [Category("SpawnedBionic")]
    public bool AttackingPlayer { get; }

    [Category("SpawnedBionic")]
    public int Health { get; }

    [Category("SpawnedBionic")]
    public BadEffect BadEffect { get; }

    [Category("SpawnedBionic")]
    public uint TargetId { get; }

    [Category("SpawnedEntity")]
    public uint UniqueId { get; }

    [Category("SpawnedEntity")]
    public uint Id { get; }

    [Category("SpawnedEntity")]
    public Position Position { get; }

    [Category("SpawnedEntity")]
    public bool IsBehindObstacle { get; }

    [Category("SpawnedEntity")]
    public float ActualSpeed { get; }

    [Category("RefObjChar")]
    public byte Level { get; }

    [Category("RefObjChar")]
    public ObjectGender Gender { get; }

    [Category("RefObjChar")]
    public int MaxHealth { get; }

    [Category("RefObjChar")]
    public byte InventorySize { get; }

    [Category("RefObjChar")]
    public byte CanStore_TID1 { get; }

    [Category("RefObjChar")]
    public byte CanStore_TID2 { get; }

    [Category("RefObjChar")]
    public byte CanStore_TID3 { get; }

    [Category("RefObjChar")]
    public byte CanStore_TID4 { get; }

    [Category("RefObjChar")]
    public byte CanBeVehicle { get; }

    [Category("RefObjChar")]
    public byte CanControl { get; }

    [Category("RefObjChar")]
    public byte DamagePortion { get; }

    [Category("RefObjChar")]
    public short MaxPassenger { get; }

    [Category("RefObjCommon")]
    public string CodeName { get; }

    [Category("RefObjCommon")]
    public string ObjName { get; }

    [Category("RefObjCommon")]
    public string NameStrID { get; }

    [Category("RefObjCommon")]
    public short TID1 { get; }

    [Category("RefObjCommon")]
    public short TID2 { get; }

    [Category("RefObjCommon")]
    public short TID3 { get; }

    [Category("RefObjCommon")]
    public short TID4 { get; }

    public EntityDebugInformation(SpawnedBionic bionic)
    {
        DistanceToPlayer = bionic.DistanceToPlayer;
        AttackingPlayer = bionic.AttackingPlayer;
        Health = bionic.Health;
        BadEffect = bionic.BadEffect;
        TargetId = bionic.TargetId;
        UniqueId = bionic.UniqueId;
        Id = bionic.Id;
        Position = bionic.Position;
        IsBehindObstacle = bionic.IsBehindObstacle;
        ActualSpeed = bionic.ActualSpeed;
        MaxHealth = bionic.Record.MaxHealth;
        InventorySize = bionic.Record.InventorySize;
        CanStore_TID1 = bionic.Record.CanStore_TID1;
        CanStore_TID2 = bionic.Record.CanStore_TID2;
        CanStore_TID3 = bionic.Record.CanStore_TID3;
        CanStore_TID4 = bionic.Record.CanStore_TID4;
        CanBeVehicle = bionic.Record.CanBeVehicle;
        CanControl = bionic.Record.CanControl;
        DamagePortion = bionic.Record.DamagePortion;
        MaxPassenger = bionic.Record.MaxPassenger;
        CodeName = bionic.Record.CodeName;
        ObjName = bionic.Record.ObjName;
        NameStrID = bionic.Record.NameStrID;
        TID1 = bionic.Record.TypeID1;
        TID2 = bionic.Record.TypeID2;
        TID3 = bionic.Record.TypeID3;
        TID4 = bionic.Record.TypeID4;
    }
}