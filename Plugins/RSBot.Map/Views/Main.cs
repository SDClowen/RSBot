using RSBot.Core;
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

#if RELEASE
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
        }

        #endregion Core Handlers

        /// <summary>
        /// Adds the grid item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="level">The level.</param>
        private void AddGridItem(string name, string type, byte level, Position position)
        {
            if (string.IsNullOrWhiteSpace(name))
                name = "<No name>";

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
            try
            {
                var x = (mapCanvas.Width / 2f) + (position.XCoordinate - Game.Player.Tracker.Position.XCoordinate) * _scale;
                var y = (mapCanvas.Height / 2f) + (position.YCoordinate - Game.Player.Tracker.Position.YCoordinate) * _scale * -1.0f;

                var img = (Image)_mapEntityImages[entityIndex].Clone();

                if (entityIndex == 0)
                    gfx.DrawImage(RotateImage(img, Geometry.RadianToDegree(Game.Player.Tracker.Angle)), 119.5f, 119.5f);
                else
                    gfx.DrawImage(img, x - img.Width, y - img.Height);
            }
            catch { }
        }

        /// <summary>
        /// Fills the grid.
        /// </summary>
        private void FillGrid(Graphics graphics)
        {
            lvMonster.BeginUpdate();
            lvMonster.Items.Clear();

            try
            {
                if (comboViewType.SelectedIndex == 0 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedMonster>(out var monsters))
                    {
                        foreach (var entry in monsters)
                        {
                            if (entry.Tracker == null)
                                continue;

                            AddGridItem(entry.Record.GetRealName(), entry.Rarity.GetName(),
                                entry.Record.Level, entry.Tracker.Position);

                            if (entry.Rarity == MonsterRarity.Unique || entry.Rarity == MonsterRarity.Unique2)
                                DrawPointAt(graphics, entry.Tracker.Position, 5);
                            else
                                DrawPointAt(graphics, entry.Tracker.Position, 4);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 4 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedCos>(out var coses))
                    {
                        foreach (var entry in coses)
                        {
                            if (entry.Tracker == null)
                                continue;

                            AddGridItem(entry.Name, "", entry.Record.Level, entry.Tracker.Position);
                            DrawPointAt(graphics, entry.Tracker.Position, 1);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 2 || comboViewType.SelectedIndex == 6)
                {
                    if (Game.Party != null && Game.Party.Members != null)
                    {
                        foreach (var member in Game.Party.Members.ToArray())
                        {
                            if (Game.Player.Tracker.Position.DistanceTo(member.Position) < 50)
                            {
                                DrawPointAt(graphics, member.Position, 6);
                                AddGridItem(member.Name, "Party Member", member.Level, member.Position);
                            }
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 1 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedPlayer>(out var players))
                    {
                        foreach (var entry in players)
                        {
                            if (entry.Tracker == null)
                                continue;

                            if (Game.Party != null && Game.Party.Members != null && Game.Party.GetMemberByName(entry.Name) != null)
                                return;

                            AddGridItem(entry.Name, "Player", 0, entry.Tracker.Position);
                            DrawPointAt(graphics, entry.Tracker.Position, 3);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 3 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedNpcNpc>(out var npcs))
                    {
                        foreach (var entry in npcs)
                        {
                            if (entry.Tracker == null)
                                continue;

                            AddGridItem(entry.Record.GetRealName(), entry.UniqueId.ToString(),
                                entry.Record.Level, entry.Tracker.Position);
                            DrawPointAt(graphics, entry.Tracker.Position, 2);
                        }
                    }
                }

                if (comboViewType.SelectedIndex == 5 || comboViewType.SelectedIndex == 6)
                {
                    if (SpawnManager.TryGetEntities<SpawnedPortal>(out var portals))
                    {
                        foreach (var entry in portals)
                        {
                            AddGridItem(entry.Record.GetRealName(), "", 0, entry.Tracker.Position);
                            DrawPointAt(graphics, entry.Tracker.Position, 7);
                        }
                    }
                }
            }
            catch (Exception)
            {

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
            else
                return new Bitmap(SectorSize, SectorSize);
        }

        /// <summary>
        /// Redraw the map image
        /// </summary>
        private void RedrawMap()
        {
            var xSec = Game.Player.Tracker.Position.XSector;
            var ySec = Game.Player.Tracker.Position.YSector;

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

                var pointX = mapCanvas.Width / 2f - SectorSize - Game.Player.Tracker.Position.XOffset / 10f * _scale;
                var pointY = mapCanvas.Height / 2f - SectorSize * 2f + Game.Player.Tracker.Position.YOffset / 10f * _scale;

                var point = new PointF(pointX, pointY);

                e.Graphics.DrawImage(_currentSectorGraphic, point);

                FillGrid(e.Graphics);

                DrawPointAt(e.Graphics, Game.Player.Tracker.Position, 0);
            }
        }

        private void trmInterval_Tick(object sender, EventArgs e)
        {
            if (Game.Player == null)
                return;

            if (Game.Player.Tracker == null)
                return;

            trmInterval.Interval = (int)Math.Truncate(1000 / Game.Player.Tracker.ActualSpeed);

            lblRegion.Text = Game.ReferenceManager.GetTranslation(Game.Player.Tracker.Position.RegionID.ToString());

            lblX.Text = Game.Player.Tracker.Position.XCoordinate.ToString("0.00");
            lblY.Text = Game.Player.Tracker.Position.YCoordinate.ToString("0.00");

#if DEBUG
            labelSectorInfo.Text = $"{Game.Player.Tracker.Position.RegionID} ({Game.Player.Tracker.Position.XSector}x{Game.Player.Tracker.Position.YSector})";
#endif

            RedrawMap();
            mapCanvas.Invalidate();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            //if (_scale >= 2.0)
            //    return;

            Task.Run(() =>
            {
                var r = _scale / 0.75f;

                while (r >= _scale)
                {
                    _scale += r * 0.0175f;

                    mapCanvas.Refresh();
                }
            });
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            //if (_scale <= 1.0)
            //    return;
            Task.Run(() =>
            {
                var r = _scale * 0.75f;

                while (r <= _scale)
                {
                    _scale -= r * 0.0175f;
                    mapCanvas.Refresh();
                }
            });
        }

        private void buttonZoomReset_Click(object sender, EventArgs e)
        {
            var originalZoom = SectorSize / 192.0f;
            if (originalZoom == _scale)
                return;

            Task.Run(() =>
            {
                if (originalZoom > _scale)
                    while (originalZoom >= _scale)
                    {
                        _scale += originalZoom * 0.035f;
                        mapCanvas.Refresh();
                    }
                else
                    while (originalZoom <= _scale)
                    {
                        _scale -= originalZoom * 0.035f;
                        mapCanvas.Refresh();
                    }
            });
        }
    }
}