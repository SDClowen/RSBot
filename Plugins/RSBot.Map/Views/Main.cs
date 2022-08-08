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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Map.Views
{
    [System.ComponentModel.ToolboxItem(false)]
    public partial class Main : UserControl
    {
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
        /// The map points
        /// </summary>
        private Image[] _mapEntityImages;

        /// <summary>
        /// The Zoom identifier
        /// </summary>
        private float _scale = SectorSize / 192.0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();

            _cachedImages = _cachedImages ?? new Dictionary<string, Image>();

            EventManager.SubscribeEvent("OnEnterGame", OnEnterGame);

            // All
            comboViewType.SelectedIndex = 6;

#if !DEBUG
            labelSectorInfo.Visible = false;
#endif
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

                var img = (Image)_mapEntityImages[entityIndex].Clone();

                if (entityIndex == 0)
                {
                    gfx.DrawImage(RotateImage(img, Geometry.RadianToDegree(Game.Player.Movement.Angle)), 
                        x - img.Width / 2,
                        y - img.Height / 2);
                }
                else
                    gfx.DrawImage(img, x - img.Width, y - img.Height);
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

                var semiTransBrush = new SolidBrush(Color.FromArgb(90, color.R, color.G, color.B));


                var diameterF = diameter * _scale;
                var point = new PointF(x - diameterF / 2, y - diameterF / 2);

                gfx.FillEllipse(semiTransBrush, new RectangleF(point, new SizeF(diameterF, diameterF)));
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
#if DEBUG
                if (Game.Player.Movement.HasDestination)
                    DrawCircleAt(graphics, Game.Player.Movement.Destination, Color.DarkBlue, 5);
#endif
                //Draw walk script
                if (ScriptManager.Running)
                {
                    var walkScript = ScriptManager.GetWalkScript();
                    for (var i = 0; i < walkScript.Count; i++)
                    {
                        var nextPosition = walkScript[i];

                        DrawLineAt(graphics, i != 0 ? walkScript[i - 1] : nextPosition, nextPosition, Pens.LightBlue);
                        DrawCircleAt(graphics, nextPosition, Color.CornflowerBlue, 4);
                    }
                }

                if (Kernel.Bot.Running)
                {
                    if (float.TryParse(PlayerConfig.Get("RSBot.Area.X", "0"), out var xCoord) &&
                        float.TryParse(PlayerConfig.Get("RSBot.Area.Y", "0"), out var yCoord) &&
                        int.TryParse(PlayerConfig.Get("RSBot.Area.Radius", "50"), out var radius))
                    {
                        var position = new Position { XCoordinate = xCoord, YCoordinate = yCoord };

                        DrawCircleAt(graphics, position, Color.FromArgb(100, 250, 50, 50), radius * 2);
                        DrawCircleAt(graphics, position, Color.SteelBlue, radius);
                    }
                }

                if (comboViewType.SelectedIndex == 0 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters))
                    {
                        foreach (var entry in monsters)
                        {
                            AddGridItem(entry.Record.GetRealName(), entry.Rarity.GetName(),
                                entry.Record.Level, entry.Movement.Source);

                            if (entry.Rarity == MonsterRarity.Unique || entry.Rarity == MonsterRarity.Unique2)
                                DrawPointAt(graphics, entry.Movement.Source, 5);
                            else
                                DrawPointAt(graphics, entry.Movement.Source, 4);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 4 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedCos>(out var coses))
                    {
                        foreach (var entry in coses)
                        {
                            AddGridItem(entry.Name, "", entry.Record.Level, entry.Movement.Source);
                            DrawPointAt(graphics, entry.Movement.Source, 1);
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
                            AddGridItem(entry.Record.GetRealName(), "", 0, entry.Movement.Source);
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

        private Image LoadSectorImage(int xSec, int ySec)
        {
            var sectorImgName = $"{xSec}x{ySec}.ddj";

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
        /// Redraw the map image
        /// </summary>
        private void RedrawMap()
        {
            var xSec = Game.Player.Movement.Source.XSector;
            var ySec = Game.Player.Movement.Source.YSector;

            if (xSec == _currentXSec && ySec == _currentYSec)
                return;

            if (_cachedImages.Count >= 25)
                _cachedImages.Clear();

            _currentXSec = xSec;
            _currentYSec = ySec;

            _currentSectorGraphic = new Bitmap(SectorSize * 3, SectorSize * 3, PixelFormat.Format32bppArgb);

            using (var gfx = Graphics.FromImage(_currentSectorGraphic))
            {
                gfx.InterpolationMode = InterpolationMode.Bicubic;
                for (var x = 0; x < GridSize; x++)
                {
                    for (var z = 0; z < GridSize; z++)
                    {
                        var bitmap = LoadSectorImage(_currentXSec + x - 1, _currentYSec + z - 1);
                        var pos = new Point(bitmap.Width * x, bitmap.Height * (GridSize - 1 - z));

                        gfx.DrawImage(bitmap, pos);

#if DEBUG
                        var pen = new Pen(Color.Black);
                        pen.DashStyle  = DashStyle.Dot;
                        gfx.DrawRectangle(pen, new Rectangle(pos, new Size(SectorSize, SectorSize)));
#endif
                        bitmap.Dispose();
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

        private void mapCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (_currentSectorGraphic != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.Bicubic;
                e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;

                var pointX = mapCanvas.Width / 2f - SectorSize - Game.Player.Movement.Source.XOffset / 10f * _scale;
                var pointY = mapCanvas.Height / 2f - SectorSize * 2f + Game.Player.Movement.Source.YOffset / 10f * _scale;

                var point = new PointF(pointX, pointY);

                e.Graphics.DrawImage(_currentSectorGraphic, point);

                PopulateMapAndGrid(e.Graphics);
                DrawPointAt(e.Graphics, Game.Player.Movement.Source, 0);
            }
        }

        private void trmInterval_Tick(object sender, EventArgs e)
        {
            if (Game.Player == null)
                return;

            lblRegion.Text = Game.ReferenceManager.GetTranslation(Game.Player.Movement.Source.RegionID.ToString());

            lblX.Text = Game.Player.Movement.Source.XCoordinate.ToString("0.00");
            lblY.Text = Game.Player.Movement.Source.YCoordinate.ToString("0.00");

#if DEBUG
            labelSectorInfo.Text = $"{Game.Player.Movement.Source.RegionID} ({Game.Player.Movement.Source.XSector}x{Game.Player.Movement.Source.YSector})";
#endif

            RedrawMap();
            mapCanvas.Invalidate();
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

            if (SpawnManager.TryGetEntity<SpawnedMonster>(p => p.Record.Rarity == ObjectRarity.ClassD, out var uniqueEntity))
                uniqueEntity.TrySelect();
        }

        private float GetMapX(Position gamePosition)
        {
            return mapCanvas.Width / 2f + (gamePosition.XCoordinate - Game.Player.Movement.Source.XCoordinate) * _scale;
        }

        private float GetMapY(Position gamePosition)
        {
            return mapCanvas.Height / 2f + (gamePosition.YCoordinate - Game.Player.Movement.Source.YCoordinate) * _scale * -1.0f;
        }

        private void mapCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            var mapX = (Game.Player.Movement.Source.XCoordinate + (((mapCanvas.Width / 2f - e.X) / SectorSize) * 192f * -1f));
            var mapY = (Game.Player.Movement.Source.YCoordinate + (((mapCanvas.Height / 2f - e.Y) / SectorSize) * 192f));

            Game.Player.MoveTo(new Position
            {
                XCoordinate = mapX,
                YCoordinate = mapY
            }, false);
        }
    }
}