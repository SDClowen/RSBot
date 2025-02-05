using RSBot.Core;
using RSBot.Core.Client.ReferenceObjects;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Skill;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms;

public static class ListViewExtensions
{
    /// <summary>
    ///     The cached image list for skills
    /// </summary>
    public static ImageList StaticImageList;

    /// <summary>
    ///     The cached image list for items
    /// </summary>
    public static ImageList StaticItemsImageList;

    /// <summary>
    ///     <inheritdoc />
    /// </summary>
    static ListViewExtensions()
    {
        StaticImageList = new ImageList
        {
            ColorDepth = ColorDepth.Depth32Bit,
            ImageSize = new Size(24, 24)
        };

        StaticItemsImageList = new ImageList
        {
            ColorDepth = ColorDepth.Depth32Bit,
            ImageSize = new Size(24, 24)
        };
    }

    /// <summary>
    ///     The sync object
    /// </summary>
    private static object _lock { get; } = new();

    /// <summary>
    /// Append string to type in the text controls
    /// </summary>
    /// <param name="value">The TextBoxBase</param>
    /// <param name="str">The string to type in the <seealso cref="TextBoxBase"/></param>
    /// <param name="time">The time</param>
    public static void Write(this TextBoxBase value, string str, bool time = true, bool writeToFile = false, string filePath = "")
    {
        var stringBuilder = new StringBuilder();
        if (time)
            stringBuilder.Append(DateTime.Now.ToString("[hh:mm:ss]\t"));

        stringBuilder.Append(str);
        stringBuilder.Append(Environment.NewLine);

        value.RunInUIThread(() =>
        {
            value.AppendText(stringBuilder.ToString());
            value.ScrollToCaret();
        });

        if (writeToFile)
        {
            lock (_lock)
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = File.AppendText(filePath))
                    stream.Write(stringBuilder.ToString());
            }
        }
    }

    /// <summary>
    /// Run action a required thread on controls
    /// </summary>
    /// <param name="target">The target</param>
    /// <param name="action">The action</param>
    public static void RunInUIThread(this Control target, Action action)
    {
        if (target.InvokeRequired)
            target.Invoke(action);
        else
            action();
    }

    /// <summary>
    ///     Load the skill image into the ImageList of the <seealso cref="ListViewItem" />
    /// </summary>
    public static Task LoadSkillImage(this ListViewItem listViewItem)
    {
        lock (_lock)
        {
            try
            {
                if (listViewItem.Tag is SkillInfo skill)
                {
                    var imageKey = "skill:" + skill.Id;
                    if (!StaticImageList.Images.ContainsKey(imageKey))
                        StaticImageList.Images.Add(imageKey, skill.Record.GetIcon());

                    //Renders the image
                    listViewItem.ImageKey = imageKey;
                }

                if (listViewItem.Tag is ItemPerk perk)
                {
                    var imageKey = "perk:" + perk.ItemId;
                    if (!StaticImageList.Images.ContainsKey(imageKey))
                        StaticImageList.Images.Add(imageKey, perk.Item?.GetIcon() ?? new Bitmap(0, 0));

                    listViewItem.ImageKey = imageKey;
                }
            }
            catch
            {
                Log.Debug("Error while loading skill image");
            }
        }

        return Task.CompletedTask;
    }

    /// <summary>
    ///     Load the item image into the ListViewItem
    /// </summary>
    public static Task LoadItemImage(this ListViewItem listViewItem, RefObjItem item)
    {
        lock (_lock)
        {
            //No need to reload the image from the PK2
            if (!StaticItemsImageList.Images.ContainsKey(item.CodeName))
                StaticItemsImageList.Images.Add(item.CodeName, item.GetIcon());

            //Renders the image
            listViewItem.ImageKey = item.CodeName;
        }

        return Task.CompletedTask;
    }

    /// <summary>
    ///     Load the skill image into the ImageList of the <seealso cref="ListViewItem" /> with async
    /// </summary>
    public static async void LoadSkillImageAsync(this ListViewItem item)
    {
        await item.LoadSkillImage();
    }

    /// <summary>
    ///     Load the skill image into the ImageList of the <seealso cref="ListViewItem" /> with async
    /// </summary>
    public static async void LoadItemImageAsync(this ListViewItem listViewItem, RefObjItem item)
    {
        await listViewItem.LoadItemImage(item);
    }

    /// <summary>
    ///     Load the skill image into the ImageList of the <seealso cref="ListViewItem" /> with async
    /// </summary>
    public static async void LoadItemImageAsync(this ListViewItem listViewItem, RefShopGood good)
    {
        try
        {
            var refPackageItem = Game.ReferenceManager.GetRefPackageItem(good.RefPackageItemCodeName);
            var refItem = Game.ReferenceManager.GetRefItem(refPackageItem.RefItemCodeName);

            await listViewItem.LoadItemImage(refItem);
        }
        catch
        {
        }
    }

    /// <summary>
    ///     Loads the skill images into the ImageList of the <seealso cref="ListView" /> control.
    /// </summary>
    public static async void LoadSkillImagesAsync(this ListView listView)
    {
        listView.BeginUpdate();

        foreach (ListViewItem item in listView.Items)
            await item.LoadSkillImage();

        listView.EndUpdate();
    }

    /// <summary>
    /// Move the selected items by <seealso cref="MoveDirection"/>
    /// </summary>
    /// <param name="sender">The ListView</param>
    /// <param name="direction">The move direction</param>
    public static void MoveSelectedItems(this ListView sender, MoveDirection direction)
    {
        var valid = sender.SelectedItems.Count > 0 &&
                    ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                    || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

        if (valid)
        {
            var firstIndex = sender.SelectedItems[0].Index;
            var selectedItems = sender.SelectedItems.Cast<ListViewItem>().ToList();

            sender.BeginUpdate();

            foreach (ListViewItem item in sender.SelectedItems)
                item.Remove();

            if (direction == MoveDirection.Up)
            {
                var insertTo = firstIndex - 1;
                foreach (var item in selectedItems)
                {
                    sender.Items.Insert(insertTo, item);
                    insertTo++;
                }
            }
            else
            {
                var insertTo = firstIndex + 1;
                foreach (var item in selectedItems)
                {
                    sender.Items.Insert(insertTo, item);
                    insertTo++;
                }
            }
            sender.EndUpdate();
        }
    }
}