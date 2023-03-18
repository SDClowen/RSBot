using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Components;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Spawn;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Map.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
        /// <summary>
        /// Is active debug mode <c>true</c> otherwise <c>false</c>
        /// </summary>
        private bool _debug;

        /// <summary>
        /// The grid size
        /// </summary>
        private const int GridSize = 3;

        /// <summary>
        /// The Sector Image Size
        /// </summary>
        private const int SectorSize = 256;

        /// <summary>
        /// The cached Images
        /// </summary>
        private Dictionary<string, Image> _cachedImages;

        /// <summary>
        /// The current sector graphic
        /// </summary>
        private Image _currentSectorGraphic;

        /// <summary>
        /// The X Sector identifier
        /// </summary>
        private byte _currentXSec;

        /// <summary>
        /// The Y Sector identifier
        /// </summary>
        private byte _currentYSec;

        /// <summary>
        /// The current layer path
        /// </summary>
        private string _currentLayerPath;

        /// <summary>
        /// The map points
        /// </summary>
        private Image[] _mapEntityImages;

        /// <summary>
        /// The Zoom identifier
        /// </summary>
        private float _scale = SectorSize / 192.0f;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private BufferedGraphicsContext bufferedGraphicsContext;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        private BufferedGraphics bufferedGraphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            _debug = GlobalConfig.Get<bool>("RSBot.DebugEnvironment");

            _cachedImages = _cachedImages ?? new Dictionary<string, Image>();

            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);

            bufferedGraphicsContext = BufferedGraphicsManager.Current;
            bufferedGraphicsContext.MaximumBuffer = new Size(mapCanvas.Width + 1, mapCanvas.Height + 1);
            bufferedGraphics = bufferedGraphicsContext.Allocate(mapCanvas.CreateGraphics(), mapCanvas.ClientRectangle);

            // All
            comboViewType.SelectedIndex = 6;
            checkEnableCollisions.Checked = CollisionManager.Enabled;

            if (!_debug)
                labelSectorInfo.Visible = false;
        }

        #region Core Handlers

        private void OnEnterGame()
        {
            _cachedImages.Clear();
            if (_mapEntityImages == null)
            {
                _mapEntityImages = new[] {
                    Game.MediaPk2.GetFile("mm_sign_character.ddj").ToImage(),
                    Game.MediaPk2.GetFile("mm_sign_animal.ddj").ToImage(),
                    Game.MediaPk2.GetFile("mm_sign_npc.ddj").ToImage(),
                    Game.MediaPk2.GetFile("mm_sign_otherplayer.ddj").ToImage(),
                    Game.MediaPk2.GetFile("mm_sign_monster.ddj").ToImage(),
                    Game.MediaPk2.GetFile("mm_sign_unique.ddj").ToImage(),
                    Game.MediaPk2.GetFile("mm_sign_party.ddj").ToImage(),
                    Game.MediaPk2.GetFile("com_diamond.ddj").ToImage()
                };
            }

            checkBoxAutoSelectUniques.Checked = PlayerConfig.Get("RSBot.Map.AutoSelectUnique", false);
            timerUniqueChecker.Enabled = checkBoxAutoSelectUniques.Checked;
        }

        #endregion Core Handlers

        /// <summary>
        /// Adds the grid item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="level">The level.</param>
        /// <param name="position"></param>
        private void AddGridItem(string name, string type, byte level, Position position)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = LanguageManager.GetLang("NoName");

            var item = new ListViewItem(name);
            item.SubItems.Add(type);
            item.SubItems.Add(level.ToString());
            item.SubItems.Add(position.ToString());
            lvMonster.Items.Add(item);
        }

        /// <summary>
        /// Draws the point at.
        /// </summary>
        private void DrawPointAt(Graphics gfx, Position position, int entityIndex)
        {
            var distanceToPosition = position.DistanceToPlayer();
            if (distanceToPosition > 150)
                return;

            try
            {

                var x = GetMapX(position);
                var y = GetMapY(position);

                using var img = (Image)_mapEntityImages[entityIndex].Clone();

                if (entityIndex == 0)
                {
                    gfx.DrawImage(RotateImage(img, Geometry.RadianToDegree(Game.Player.Movement.Angle)),
                        x - img.Width / 2,
                        y - img.Height / 2);
                }
                else
                    gfx.DrawImage(img, x - img.Width / 2, y - img.Height / 2);
            }
            catch { }
        }

        private void DrawRectangleAt(Graphics gfx, Position position, Brush brush, Size size, string label = "")
        {
            var distanceToPosition = position.DistanceToPlayer();
            if (distanceToPosition > 150)
                return;

            try
            {
                var x = GetMapX(position);
                var y = GetMapY(position);

                if (!string.IsNullOrEmpty(label))
                    gfx.DrawString(label, Font, brush, x + size.Width, y - size.Width / 2);

                gfx.FillRectangle(brush, new RectangleF(new PointF(x, y), size));
            }
            catch { }
        }

        private void DrawLineAt(Graphics gfx, Position source, Position destination, Pen color)
        {
            var distanceToPositionA = source.DistanceToPlayer();
            var distanceToPositionB = destination.DistanceToPlayer();
            if (distanceToPositionA > 150 || distanceToPositionB > 150)
                return;

            var srcX = GetMapX(source);
            var srcY = GetMapY(source);
            var destinationX = GetMapX(destination);
            var destinationY = GetMapY(destination);

            gfx.DrawLine(color, srcX, srcY, destinationX, destinationY);
        }

        private void DrawCircleAt(Graphics gfx, Position position, Color color, int diameter)
        {
            var distanceToPosition = position.DistanceToPlayer();
            if (distanceToPosition > 150)
                return;

            try
            {
                var x = GetMapX(position);
                var y = GetMapY(position);

                using var brush = new SolidBrush(color);


                var diameterF = diameter * _scale;
                var point = new PointF(x - diameterF / 2, y - diameterF / 2);

                gfx.FillEllipse(brush, new RectangleF(point, new SizeF(diameterF, diameterF)));
                gfx.DrawEllipse(new Pen(color), new RectangleF(point, new SizeF(diameterF, diameterF)));
            }
            catch { }
        }

        /// <summary>
        /// Fills the grid.
        /// </summary>
        private void PopulateMapAndGrid(Graphics graphics)
        {
            lvMonster.BeginUpdate();
            lvMonster.Items.Clear();

            try
            {
                if (Game.Player.Movement.HasDestination)
                {
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    using var pen = new Pen(Color.BlanchedAlmond, 1);
                    pen.DashStyle = DashStyle.Dot;
                    DrawLineAt(graphics, Game.Player.Movement.Source, Game.Player.Movement.Destination, pen);

                    DrawCircleAt(graphics, Game.Player.Movement.Destination, Color.PaleGreen, 4);
                    graphics.SmoothingMode = SmoothingMode.HighSpeed;
                }

                //Draw walk script
                if (ScriptManager.Running)
                {
                    var walkScript = ScriptManager.GetWalkScript();
                    for (var i = 0; i < walkScript.Count; i++)
                    {
                        var nextPosition = walkScript[i];

                        DrawLineAt(graphics, i != 0 ? walkScript[i - 1] : nextPosition, nextPosition, Pens.LightBlue);
                        DrawCircleAt(graphics, nextPosition, Color.CornflowerBlue.Alpha(150), 4);
                    }
                }

                if (Kernel.Bot.Running)
                {
                    var position = Kernel.Bot.Botbase.Area.Position;
                    var radius = Kernel.Bot.Botbase.Area.Radius;

                    DrawCircleAt(graphics, position, Color.DarkRed.Alpha(100), radius * 2);
                    DrawCircleAt(graphics, position, Color.LawnGreen.Alpha(50), radius);
                }

                if (comboViewType.SelectedIndex == 0 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters))
                    {
                        foreach (var entry in monsters)
                        {
                            AddGridItem(entry.Record.GetRealName(), entry.Rarity.GetName(),
                                entry.Record.Level, entry.Movement.Source);

                            if (Game.SelectedEntity?.UniqueId == entry.UniqueId)
                                DrawCircleAt(graphics, entry.Position, Color.Wheat.Alpha(100), 6);

                            //Other style for mobs behind obstacles
                            if (entry.IsBehindObstacle)
                                DrawCircleAt(graphics, entry.Position, Color.DarkRed.Alpha(100), 6);

                            if (entry.Rarity == MonsterRarity.Unique || entry.Rarity == MonsterRarity.Unique2)
                                DrawPointAt(graphics, entry.Position, 5);
                            else
                                DrawPointAt(graphics, entry.Position, 4);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 4 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedCos>(out var coses))
                    {
                        foreach (var entry in coses)
                        {
                            // Avoid painting vehicles from main player
                            if (Game.Player.Vehicle?.UniqueId != entry.UniqueId)
                            {
                                AddGridItem(entry.Name, "Pet", entry.Record.Level, entry.Movement.Source);
                                DrawPointAt(graphics, entry.Movement.Source, 1);
                            }
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 2 || comboViewType.SelectedIndex == 6)
                {
                    if (Game.Party != null && Game.Party.Members != null)
                    {
                        foreach (var member in Game.Party.Members.ToArray())
                        {
                            if (!(Game.Player.Movement.Source.DistanceTo(member.Position) < 50))
                                continue;
                            DrawPointAt(graphics, member.Position, 6);
                            AddGridItem(member.Name, "Party Member", member.Level, member.Position);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 1 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedPlayer>(out var players))
                    {
                        foreach (var entry in players)
                        {
                            if (Game.Party != null && Game.Party.Members != null && Game.Party.GetMemberByName(entry.Name) != null)
                                return;

                            AddGridItem(entry.Name, "Player", 0, entry.Movement.Source);
                            DrawPointAt(graphics, entry.Movement.Source, 3);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 3 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedNpcNpc>(out var npcs))
                    {
                        foreach (var entry in npcs)
                        {
                            AddGridItem(entry.Record.GetRealName(), entry.UniqueId.ToString(),
                                entry.Record.Level, entry.Movement.Source);
                            DrawPointAt(graphics, entry.Movement.Source, 2);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 5 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedPortal>(out var portals))
                    {
                        foreach (var entry in portals)
                        {
                            AddGridItem(entry.Record.GetRealName(), "Teleport", 0, entry.Movement.Source);
                            DrawPointAt(graphics, entry.Movement.Source, 7);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Debug($"[Map] Render error: {ex.Message}");
            }

            lvMonster.EndUpdate();
        }

        private void DrawCollisions(Graphics gfx)
        {
            if (CollisionManager.HasActiveMeshes && CollisionManager.Enabled)
            {
                //Draw collisions
                foreach (var collisionNavmesh in CollisionManager.ActiveCollisionMeshes)
                {
                    foreach (var collider in collisionNavmesh.Collisions.Where(c => c.Source.DistanceToPlayer() < 100 || c.Destination.DistanceToPlayer() < 100))
                        DrawLineAt(gfx, collider.Source, collider.Destination, Pens.Red);
                }
                if (!SpawnManager.TryGetEntities<SpawnedEntity>(out var entities))
                    return;

                foreach (var entity in entities.Where(e => e.IsBehindObstacle))
                {
                    var collision =
                        CollisionManager.GetCollisionBetween(Game.Player.Position, entity.Position);

                    if (!collision.HasValue)
                        continue;
                    var rayPen = new Pen(Color.DeepSkyBlue);
                    rayPen.DashStyle = DashStyle.Dot;
                    rayPen.EndCap = LineCap.Square;

                    DrawLineAt(gfx, Game.Player.Position, collision.Value.CollidedAt, Pens.DeepSkyBlue);
                    DrawLineAt(gfx, collision.Value.CollidedWith.Source, collision.Value.CollidedWith.Destination, Pens.Yellow);
                }
            }
        }

        private Image LoadSectorImage(string sectorImgName)
        {
            if (_cachedImages.ContainsKey(sectorImgName))
                return (Image)_cachedImages[sectorImgName].Clone();

            if (Game.MediaPk2.FileExists(sectorImgName))
            {
                var img = Game.MediaPk2.GetFile(sectorImgName).ToImage();
                _cachedImages.Add(sectorImgName, img);
                return (Image)img.Clone();
            }

            return new Bitmap(SectorSize, SectorSize);
        }

        /// <summary>
        /// Get path from map layer
        /// </summary>
        private string GetLayerPath(Position p)
        {
            if (p.Region.IsDungeon)
            {
                switch (p.Region)
                {
                    // Donwhang cave
                    case 32769:
                        if (p.ZOffset > 345)
                            return "dh_a01_floor04_{0}x{1}.ddj";
                        if (p.ZOffset > 230)
                            return "dh_a01_floor03_{0}x{1}.ddj";
                        if (p.ZOffset > 115)
                            return "dh_a01_floor02_{0}x{1}.ddj";
                        return "dh_a01_floor01_{0}x{1}.ddj";
                    // QinShi Tomb
                    case 32770:
                        return "qt_a01_floor06_{0}x{1}.ddj";
                    case 32771:
                        return "qt_a01_floor05_{0}x{1}.ddj";
                    case 32772:
                        return "qt_a01_floor04_{0}x{1}.ddj";
                    case 32773:
                        return "qt_a01_floor03_{0}x{1}.ddj";
                    case 32774:
                        return "qt_a01_floor02_{0}x{1}.ddj";
                    case 32775:
                        return "qt_a01_floor01_{0}x{1}.ddj";
                    // Job Temple
                    case 32779:
                    case 32780:
                    case 32781:
                    case 32782:
                    case 32784:
                        return "rn_sd_egypt1_01_{0}x{1}.ddj";
                    case 32783:
                        return "rn_sd_egypt1_02_{0}x{1}.ddj";
                    // Fortress Dungeon
                    case 32785:
                        return "fort_dungeon01_{0}x{1}.ddj";
                    // Mt. Flame
                    case 32786:
                        return "flame_dungeon01_{0}x{1}.ddj";
                    // Jupiter Temple Rooms
                    case 32787:
                        return "rn_jupiter_02_{0}x{1}.ddj";
                    case 32788:
                        return "rn_jupiter_03_{0}x{1}.ddj";
                    case 32789:
                        return "rn_jupiter_04_{0}x{1}.ddj";
                    case 32790:
                        return "rn_jupiter_01_{0}x{1}.ddj";
                    // Bahgdad Room
                    case 32793:
                        return "RN_ARABIA_FIELD_02_BOSS_{0}x{1}.ddj";
                        // 32791 - GM's Room
                        // 32792 - Fortress Prison
                }
            }
            // Default as world map
            return "{0}x{1}.ddj";
        }

        /// <summary>
        /// Redraw the map image
        /// </summary>
        private void RedrawMap()
        {
            // Set layer path & sectors
            var p = Game.Player.Movement.Source;

            var layerPath = GetLayerPath(p);
            if (p.Region.X == _currentXSec && p.Region.Y == _currentYSec && _currentLayerPath == layerPath)
                return;

            _currentXSec = p.Region.X;
            _currentYSec = p.Region.Y;

            if (p.Region.IsDungeon)
            {
                _currentXSec = p.GetSectorFromOffset(p.XOffset);
                _currentYSec = p.GetSectorFromOffset(p.YOffset);
            }

            _currentLayerPath = layerPath;

            if (_cachedImages.Count >= 25)
                _cachedImages.Clear();

            _currentSectorGraphic = new Bitmap(SectorSize * 3, SectorSize * 3, PixelFormat.Format32bppArgb);

            using (var gfx = Graphics.FromImage(_currentSectorGraphic))
            {
                gfx.InterpolationMode = InterpolationMode.Bicubic;
                for (var x = 0; x < GridSize; x++)
                {
                    for (var z = 0; z < GridSize; z++)
                    {
                        var sectorImgName = string.Format(layerPath, _currentXSec + x - 1, _currentYSec + z - 1);
                       
                        using var bitmap = LoadSectorImage(sectorImgName);
                        var pos = new Point(bitmap.Width * x, bitmap.Height * (GridSize - 1 - z));

                        gfx.DrawImage(bitmap, pos);

                        if (_debug)
                        {
                            using var pen = new Pen(Color.Black);
                            pen.DashStyle = DashStyle.Dot;
                            gfx.DrawRectangle(pen, new Rectangle(pos, new Size(SectorSize, SectorSize)));
                        }
                    }
                }
            }
        }

        private Bitmap RotateImage(Image image, float angle)
        {
            var sizedBitmap = new Bitmap(image.Width + 1, image.Height + 1);

            using (var matrix = new Matrix())
            {
                matrix.RotateAt(angle, new PointF(sizedBitmap.Width / 2, sizedBitmap.Height / 2));

                sizedBitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(sizedBitmap))
                {
                    graphics.Transform = matrix;
                    graphics.InterpolationMode = InterpolationMode.Bicubic;
                    graphics.DrawImage(image, 1, 1);
                }
            }

            sizedBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

            return sizedBitmap;
        }

        private void DrawObjects(Graphics graphics)
        {
            if (_currentSectorGraphic != null)
            {
                graphics.InterpolationMode = InterpolationMode.Bicubic;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;

                PointF point = new()
                {
                    X = mapCanvas.Width / 2f - SectorSize - Game.Player.Movement.Source.XSectorOffset / 10f * _scale,
                    Y = mapCanvas.Height / 2f - SectorSize * 2f + Game.Player.Movement.Source.YSectorOffset / 10f * _scale
                };

                graphics.DrawImage(_currentSectorGraphic, point);

                PopulateMapAndGrid(graphics);
                DrawPointAt(graphics, Game.Player.Movement.Source, 0);

                if(_debug)
                    DrawCollisions(graphics);
            }
        }

        private void trmInterval_Tick(object sender, EventArgs e)
        {
            if (Game.Player == null)
                return;

            if (!Visible)
                return;

            lblRegion.Text = Game.ReferenceManager.GetTranslation(Game.Player.Position.Region.ToString()) + (Game.Player.Position.Region.IsDungeon ? " (Dungeon)" : "");

            lblX.Text = Game.Player.Position.X.ToString("0.0");
            lblY.Text = Game.Player.Position.Y.ToString("0.0");

            if(_debug)
                labelSectorInfo.Text = $"{Game.Player.Movement.Source.Region} ({Game.Player.Movement.Source.Region.X}x{Game.Player.Movement.Source.Region.Y})";

            bufferedGraphics.Graphics.Clear(Color.Black);
            RedrawMap();
            DrawObjects(bufferedGraphics.Graphics);
            bufferedGraphics.Render();
        }

        private void checkBoxAutoSelectUniques_CheckedChanged(object sender, EventArgs e)
        {
            PlayerConfig.Set("RSBot.Map.AutoSelectUnique", checkBoxAutoSelectUniques.Checked);
            timerUniqueChecker.Enabled = checkBoxAutoSelectUniques.Checked;
        }

        private void timerUniqueChecker_Tick(object sender, EventArgs e)
        {
            if (!checkBoxAutoSelectUniques.Checked)
                return;

            if (Kernel.Bot.Running)
                return;

            if (Game.SelectedEntity?.Record.Rarity == ObjectRarity.ClassD)
                return;

            if (SpawnManager.TryGetEntity<SpawnedMonster>(p => p.Record.Rarity == ObjectRarity.ClassD || p.Record.Rarity == ObjectRarity.ClassI, out var uniqueEntity))
                uniqueEntity.TrySelect();
        }

        private float GetMapX(Position gamePosition)
        {
            return mapCanvas.Width / 2f + (gamePosition.X - Game.Player.Movement.Source.X) * _scale;
        }

        private float GetMapY(Position gamePosition)
        {
            return mapCanvas.Height / 2f + (gamePosition.Y - Game.Player.Movement.Source.Y) * _scale * -1.0f;
        }

        private void mapCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            var position = Game.Player.Movement.Source;
            position.XOffset = (Game.Player.Movement.Source.XOffset + (((mapCanvas.Width / 2f - e.X) / SectorSize) * 192f * 10 * -1f));
            position.YOffset = (Game.Player.Movement.Source.YOffset + (((mapCanvas.Height / 2f - e.Y) / SectorSize) * 192f * 10));

            Game.Player.MoveTo(position, false);
        }

        private void checkEnableCollisions_CheckedChanged(object sender, EventArgs e)
        {
            CollisionManager.Enabled = checkEnableCollisions.Checked;
        }
    }
}