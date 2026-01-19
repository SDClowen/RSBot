using RSBot.Core;
using RSBot.Core.Client;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using RSBot.Map.Renderer;
using RSBot.NavMeshApi.Dungeon;
using SDUI.Controls;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Region = RSBot.Core.Objects.Region;

namespace RSBot.Map.Views;

[ToolboxItem(false)]
public partial class Main : DoubleBufferedControl
{
    private const int GridSize = 3;
    private const int SectorSize = 256;
    private readonly Dictionary<string, SKBitmap> _cachedImages;
    private SKBitmap _currentSectorGraphic;
    private byte _currentXSec;
    private byte _currentYSec;
    private SKBitmap[] _mapEntityImages;
    private readonly float _scale = SectorSize / 192.0f;
    private readonly NavMeshRenderer _navMeshRenderer;
    private string _regionName;
    private bool _autoSelectUnqiue = false;
    private bool _isUniqueSpotted = false;

    public Main()
    {
        InitializeComponent();
        _cachedImages ??= new();
        EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);

        // All
        comboViewType.SelectedIndex = 6;
        checkEnableCollisions.Checked = Kernel.EnableCollisionDetection;
        tabNavMeshViewer.Visible = Kernel.Debug;

        if (Kernel.Debug)
        {
            _navMeshRenderer = new NavMeshRenderer() { Dock = DockStyle.Fill };
            panelNavMeshRendererCanvas.Controls.Add(_navMeshRenderer);
            labelSectorInfo.Visible = true;
        }
    }

    #region Core Handlers

    private void OnEnterGame()
    {
        _cachedImages.Clear();
        if (_mapEntityImages == null)
            _mapEntityImages =
            [
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_character.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_animal.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_npc.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_otherplayer.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_monster.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_unique.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_party.ddj").ToSKImage(),
                Game.MediaPk2.GetFile("interface\\minimap\\mm_sign_unique.ddj").ToSKImage(),
            ];
    }

    #endregion Core Handlers

    #region Skia Helpers

    private void DrawSkiaPointAt(SKCanvas canvas, Position position, int entityIndex, float angle = 0)
    {
        if (position.DistanceToPlayer() > 150) return;

        var x = GetMapX(position);
        var y = GetMapY(position);

        if (_mapEntityImages == null || entityIndex >= _mapEntityImages.Length) return;

        using (var skBitmap = _mapEntityImages[entityIndex].Copy())
        {
            canvas.Save();
            canvas.Translate(x, y);
            if (entityIndex == 0) // Rotate only for player
                canvas.RotateDegrees(Geometry.RadianToDegree(angle));

            canvas.DrawBitmap(skBitmap, -skBitmap.Width / 2f, -skBitmap.Height / 2f);
            canvas.Restore();
        }
    }

    private void DrawSkiaCircleAt(SKCanvas canvas, Position position, SKColor color, float diameter, bool fill = true)
    {
        if (position.DistanceToPlayer() > 150) return;

        var x = GetMapX(position);
        var y = GetMapY(position);
        float scaledRadius = (diameter * _scale) / 2f;

        using var paint = new SKPaint
        {
            Color = color,
            IsAntialias = true,
            Style = fill ? SKPaintStyle.Fill : SKPaintStyle.Stroke,
            StrokeWidth = 1
        };

        canvas.DrawCircle(x, y, scaledRadius, paint);
    }

    private void DrawSkiaLineAt(SKCanvas canvas, Position source, Position destination, SKColor color, bool dashed = false)
    {
        if (source.DistanceToPlayer() > 150 || destination.DistanceToPlayer() > 150) return;

        using var paint = new SKPaint
        {
            Color = color,
            IsAntialias = true,
            StrokeWidth = 1,
            Style = SKPaintStyle.Stroke
        };

        if (dashed)
            paint.PathEffect = SKPathEffect.CreateDash(new float[] { 4, 4 }, 0);

        canvas.DrawLine(GetMapX(source), GetMapY(source), GetMapX(destination), GetMapY(destination), paint);
    }

    #endregion

    private void AddGridItem(string name, string type, byte level, Position position)
    {
        if (lvMonster.InvokeRequired)
        {
            lvMonster.Invoke(() => AddGridItem(name, type, level, position));
            return;
        }

        if (string.IsNullOrWhiteSpace(name))
            name = LanguageManager.GetLang("NoName");

        var item = new SDUI.Controls.ListViewItem(name);
        item.SubItems.Add(type);
        item.SubItems.Add(level.ToString());
        item.SubItems.Add(position.ToString());
        lvMonster.Items.Add(item);
    }

    private void PopulateMapAndGrid(SKCanvas canvas)
    {
        int topIndex = lvMonster.TopItem?.Index ?? 0;
        int selectedIndex = lvMonster.SelectedIndices.Count > 0 ? lvMonster.SelectedIndices[0] : -1;

        lvMonster.Items.Clear();

        try
        {
            if (Game.Player.Movement.HasDestination)
            {
                DrawSkiaLineAt(canvas, Game.Player.Movement.Source, Game.Player.Movement.Destination, SKColors.BlanchedAlmond, true);
                DrawSkiaCircleAt(canvas, Game.Player.Movement.Destination, SKColors.PaleGreen, 4);
            }

            if (ScriptManager.Running)
            {
                var walkScript = ScriptManager.GetWalkScript();
                for (var i = 0; i < walkScript.Count; i++)
                {
                    var nextPosition = walkScript[i];
                    DrawSkiaLineAt(canvas, i != 0 ? walkScript[i - 1] : nextPosition, nextPosition, SKColors.LightBlue);
                    DrawSkiaCircleAt(canvas, nextPosition, SKColors.CornflowerBlue.WithAlpha(150), 4);
                }
            }

            if (Kernel.Bot.Running)
            {
                var position = Kernel.Bot.Botbase.Area.Position;
                var radius = Kernel.Bot.Botbase.Area.Radius;
                DrawSkiaCircleAt(canvas, position, SKColors.DarkRed.WithAlpha(100), radius * 2);
                DrawSkiaCircleAt(canvas, position, SKColors.LawnGreen.WithAlpha(50), radius);
            }

            // Entity Rendering logic (Same as original, but using DrawSkiaPointAt)
            if (comboViewType.SelectedIndex == 0 || comboViewType.SelectedIndex == 6)
                if (SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters))
                    foreach (var entry in monsters)
                    {
                        AddGridItem(entry.Record.GetRealName(), entry.Rarity.GetName(), entry.Record.Level, entry.Movement.Source);
                        if (Game.SelectedEntity?.UniqueId == entry.UniqueId)
                            DrawSkiaCircleAt(canvas, entry.Position, SKColors.Wheat.WithAlpha(100), 6);

                        DrawSkiaPointAt(canvas, entry.Position, (entry.Rarity == MonsterRarity.Unique || entry.Rarity == MonsterRarity.Unique2) ? 5 : 4);
                    }

            if (comboViewType.SelectedIndex == 4 || comboViewType.SelectedIndex == 6)
                if (SpawnManager.TryGetEntities<SpawnedCos>(out var coses))
                    foreach (var entry in coses)
                        if (Game.Player.Vehicle?.UniqueId != entry.UniqueId)
                        {
                            AddGridItem(entry.Name, "Pet", entry.Record.Level, entry.Movement.Source);
                            DrawSkiaPointAt(canvas, entry.Movement.Source, 1);
                        }

            if (comboViewType.SelectedIndex == 2 || comboViewType.SelectedIndex == 6)
                if (Game.Party != null && Game.Party.Members != null)
                    foreach (var member in Game.Party.Members.ToArray())
                    {
                        if (Game.Player.Position.DistanceTo(member.Position) > 50 || member.Name == Game.Player.Name) continue;
                        DrawSkiaPointAt(canvas, member.Position, 6);
                        AddGridItem(member.Name, "Party Member", member.Level, member.Position);
                    }

            if (comboViewType.SelectedIndex == 1 || comboViewType.SelectedIndex == 6)
                if (SpawnManager.TryGetEntities<SpawnedPlayer>(out var players))
                    foreach (var entry in players)
                    {
                        if (Game.Party?.GetMemberByName(entry.Name) != null) continue;
                        AddGridItem(entry.Name, "Player", 0, entry.Movement.Source);
                        DrawSkiaPointAt(canvas, entry.Movement.Source, 3);
                    }

            if (comboViewType.SelectedIndex == 3 || comboViewType.SelectedIndex == 6)
                if (SpawnManager.TryGetEntities<SpawnedNpcNpc>(out var npcs))
                    foreach (var entry in npcs)
                    {
                        AddGridItem(entry.Record.GetRealName(), entry.UniqueId.ToString(), entry.Record.Level, entry.Movement.Source);
                        DrawSkiaPointAt(canvas, entry.Movement.Source, 2);
                    }

            if (comboViewType.SelectedIndex == 5 || comboViewType.SelectedIndex == 6)
                if (SpawnManager.TryGetEntities<SpawnedPortal>(out var portals))
                    foreach (var entry in portals)
                    {
                        AddGridItem(entry.Record.GetRealName(), "Teleport", 0, entry.Movement.Source);
                        DrawSkiaPointAt(canvas, entry.Movement.Source, 7);
                    }
        }
        catch (Exception ex)
        {
            Log.Debug($"[Map] Render error: {ex.Message}");
        }

        if (lvMonster.Items.Count > 0)
        {
            if (topIndex < lvMonster.Items.Count) lvMonster.TopItem = lvMonster.Items[topIndex];
            if (selectedIndex >= 0 && selectedIndex < lvMonster.Items.Count) lvMonster.Items[selectedIndex].Selected = true;
        }
    }

    private SKBitmap LoadSectorImage(string sectorImgName)
    {
        if (_cachedImages.ContainsKey(sectorImgName))
            return _cachedImages[sectorImgName].Copy();

        if (Game.MediaPk2.FileExists(sectorImgName) && Game.MediaPk2.TryGetFile(sectorImgName, out var file))
        {
            var img = file.ToSKImage();
            _cachedImages.Add(sectorImgName, img);
            return img.Copy();
        }

        return new SKBitmap(SectorSize, SectorSize);
    }

    private void RedrawMap(SKCanvas canvas)
    {
        var p = Game.Player.Movement.Source;
        var tempX = p.Region.X;
        var tempY = p.Region.Y;

        if (p.Region.IsDungeon)
        {
            tempX = p.GetSectorFromOffset(p.XOffset);
            tempY = p.GetSectorFromOffset(p.YOffset);
        }

        if (tempX == _currentXSec && tempY == _currentYSec) return;

        _currentXSec = tempX;
        _currentYSec = tempY;

        if (_cachedImages.Count >= 25) _cachedImages.Clear();

        try
        {
            _currentSectorGraphic = new SKBitmap(SectorSize * 3, SectorSize * 3);
            
            var floorName = string.Empty;
            var dungeonName = string.Empty;
            if (p.Region.IsDungeon)
            {
                if (p.TryGetNavMeshTransform(out var pTransform) && pTransform.Instance is NavMeshInstBlock dungeonBlock && dungeonBlock.Parent is NavMeshDungeon dungeon)
                {
                    floorName = dungeon.FloorStringIDs[dungeonBlock.FloorIndex];
                    _regionName = Game.ReferenceManager.GetTranslation(dungeon.RoomStringIDs[dungeonBlock.RoomIndex]);
                    dungeonName = RegionInfoManager.GetDungeonName(p.Region);
                }
            }
            else _regionName = Game.ReferenceManager.GetTranslation(Game.Player.Position.Region.ToString());

            for (byte x = 0; x < GridSize; x++)
            {
                for (byte z = 0; z < GridSize; z++)
                {
                    var xSector = (byte)(_currentXSec + x - 1);
                    var ySector = (byte)(_currentYSec + z - 1);
                    var sectorImgName = GetMinimapFileName(new Region(xSector, ySector), dungeonName, floorName);
                    using var bitmap = LoadSectorImage(sectorImgName);
                    canvas.DrawBitmap(bitmap, new SKPoint(bitmap.Width * x, bitmap.Height * (GridSize - 1 - z)));
                }
            }
        }
        catch (Exception e) { Log.Warn($"Error in minimap: {e.Message}"); }
    }

    private string GetMinimapFileName(Region region, string dungeonName, string floorName)
    {
        return (!string.IsNullOrWhiteSpace(dungeonName) && !string.IsNullOrWhiteSpace(floorName))
            ? $"minimap_d\\{dungeonName}\\{floorName}_{region.X}x{region.Y}.ddj"
            : $"minimap\\{region.X}x{region.Y}.ddj";
    }

    private void trmInterval_Tick(object sender, EventArgs e)
    {
        if (Game.Player == null || !Visible) return;

        if (Kernel.Debug)
        {
            labelSectorInfo.Text = $"{Game.Player.Movement.Source.Region} ({Game.Player.Movement.Source.Region.X}x{Game.Player.Movement.Source.Region.Y})";
            if (Kernel.EnableCollisionDetection && Game.Player.Position.TryGetNavMeshTransform(out var playerTransform))
                _navMeshRenderer?.Update(playerTransform);
        }

        mapCanvas.Invalidate();
    }

    private void tabMinimap_Paint(object sender, SDUI.SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear(SKColors.Black);

        if (Game.Player == null) return;

        RedrawMap(canvas);

        if (_currentSectorGraphic != null)
        {
            using (var skMap = _currentSectorGraphic.Copy())
            {
                float mapX = mapCanvas.Width / 2f - SectorSize - Game.Player.Movement.Source.XSectorOffset / 10f * _scale;
                float mapY = mapCanvas.Height / 2f - SectorSize * 2f + Game.Player.Movement.Source.YSectorOffset / 10f * _scale;
                canvas.DrawBitmap(skMap, mapX, mapY);
            }

            PopulateMapAndGrid(canvas);
            DrawSkiaPointAt(canvas, Game.Player.Movement.Source, 0, Game.Player.Movement.Angle);
        }

        // Overlays (Region & Position Text)
        using var paint = new SKPaint
        {
            Color = SKColors.White,
            IsAntialias = true,
            TextSize = 14,
            Typeface = SKTypeface.FromFamilyName(Font.FontFamily.Name, SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright)
        };

        paint.Color = SKColors.Black;
        canvas.DrawText(_regionName, 12, 22, paint);
        paint.Color = SKColors.White;
        canvas.DrawText(_regionName, 10, 20, paint);

        var posText = Game.Player.Position.ToString();
        var textBounds = new SKRect();
        paint.MeasureText(posText, ref textBounds);
        float xPos = mapCanvas.Width - textBounds.Width - 15;
        
        paint.Color = SKColors.Black;
        canvas.DrawText(posText, xPos + 2, 42, paint);
        paint.Color = SKColors.White;
        canvas.DrawText(posText, xPos, 40, paint);
    }

    private float GetMapX(Position gamePosition) => mapCanvas.Width / 2f + (gamePosition.X - Game.Player.Movement.Source.X) * _scale;
    private float GetMapY(Position gamePosition) => mapCanvas.Height / 2f + (gamePosition.Y - Game.Player.Movement.Source.Y) * _scale * -1.0f;

    private void mapCanvas_MouseClick(object sender, MouseEventArgs e)
    {
        if (!Game.Ready) return;
        var position = Game.Player.Movement.Source;
        position.XOffset = Game.Player.Movement.Source.XOffset + (mapCanvas.Width / 2f - e.X) / SectorSize * 192f * 10 * -1f;
        position.YOffset = Game.Player.Movement.Source.YOffset + (mapCanvas.Height / 2f - e.Y) / SectorSize * 192f * 10;
        Game.Player.MoveTo(position, false);
    }

    private void checkEnableCollisions_CheckedChanged(object sender, EventArgs e) => Kernel.EnableCollisionDetection = checkEnableCollisions.Checked;

    private void Main_Load(object sender, EventArgs e)
    {
        _autoSelectUnqiue = PlayerConfig.Get("RSBot.Map.AutoSelectUnique", false);
        checkBoxAutoSelectUniques.Checked = _autoSelectUnqiue;
        checkBoxAutoSelectUniques.Enabled = Game.Player != null;
        timerUniqueChecker.Enabled = _autoSelectUnqiue && Game.Player != null;
    }

    private void btnNvmResetToPlayer_Click(object sender, EventArgs e)
    {
        if (Game.Player.Position.TryGetNavMeshTransform(out var playerTransform))
            _navMeshRenderer?.Update(playerTransform);
    }

    public void InitUniqueObjects()
    {
        _autoSelectUnqiue = PlayerConfig.Get("RSBot.Map.AutoSelectUnique", false);
        checkBoxAutoSelectUniques.Enabled = true;
        timerUniqueChecker.Enabled = _autoSelectUnqiue;
    }

    private void checkBoxAutoSelectUniques_CheckedChanged(object sender, EventArgs e)
    {
        PlayerConfig.Set("RSBot.Map.AutoSelectUnique", checkBoxAutoSelectUniques.Checked);
        _autoSelectUnqiue = checkBoxAutoSelectUniques.Checked;
        timerUniqueChecker.Enabled = _autoSelectUnqiue;
    }

    private void timerUniqueChecker_Tick(object sender, EventArgs e)
    {
        if (Game.Player == null || !_autoSelectUnqiue || Kernel.Bot.Running) return;

        if (SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters))
        {
            bool atleastOneUnqiueFound = false;
            foreach (var entry in monsters)
            {
                if (entry.Rarity == MonsterRarity.Unique || entry.Rarity == MonsterRarity.Unique2)
                {
                    if (!_isUniqueSpotted)
                    {
                        _isUniqueSpotted = true;
                        Game.Player.NotificationSounds?.PlayUniqueInRange();
                    }
                    atleastOneUnqiueFound = true;
                }
            }
            if (!atleastOneUnqiueFound) _isUniqueSpotted = false;
        }
        else _isUniqueSpotted = false;

        if (Game.SelectedEntity?.Record.Rarity == ObjectRarity.ClassD || Game.SelectedEntity?.Record.Rarity == ObjectRarity.ClassI) return;

        if (SpawnManager.TryGetEntity<SpawnedMonster>(p => p.Record.Rarity == ObjectRarity.ClassD || p.Record.Rarity == ObjectRarity.ClassI, out var uniqueEntity))
            uniqueEntity.TrySelect();
    }
}
