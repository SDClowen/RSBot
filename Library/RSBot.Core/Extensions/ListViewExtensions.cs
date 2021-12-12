using RSBot.Core.Objects.Skill;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBot.Core.Extensions
{
    public static class ListViewExtensions
    {
        /// <summary>
        /// The cached image list for skills
        /// </summary>
        public static ImageList StaticImageList;

        /// <summary>
        /// The sync object
        /// </summary>
        private static object _lock { get; } = new object();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        static ListViewExtensions()
        {
            StaticImageList = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = new Size(24, 24)
            };
        }

        /// <summary>
        /// Load the skill image into the ImageList of the <seealso cref="ListViewItem"/>
        /// </summary>
        public static Task LoadSkillImage(this ListViewItem item)
        {
            lock (_lock)
            {
                var skill = item.Tag as ISkillDataInfo;
                if (StaticImageList.Images.Keys.Cast<string>().Contains(skill.Id.ToString()))
                {
                    item.ImageKey = skill.Id.ToString();
                }

                else if (Game.MediaPk2.FileExists(Path.GetFileName(skill.Record.UI_IconFile)))
                {
                    var imageFile = Game.MediaPk2.GetFile(Path.GetFileName(skill.Record.UI_IconFile));
                    StaticImageList.Images.Add(skill.Id.ToString(), imageFile.ToImage());
                    item.ImageKey = skill.Id.ToString();
                }
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Load the skill image into the ImageList of the <seealso cref="ListViewItem"/> with async
        /// </summary>
        public static async void LoadSkillImageAsync(this ListViewItem item)
        {
            await item.LoadSkillImage();
        }

        /// <summary>
        /// Loads the skill images into the ImageList of the <seealso cref="ListView"/> control.
        /// </summary>
        public static async void LoadSkillImagesAsync(this ListView listView)
        {
            listView.BeginUpdate();

            foreach (ListViewItem item in listView.Items)
                await item.LoadSkillImage();

            listView.EndUpdate();
        }
    }
}
