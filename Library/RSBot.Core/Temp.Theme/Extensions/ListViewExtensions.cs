using System.Linq;
using System.Windows.Forms;

namespace RSBot.Theme.Extensions
{
    public static class ListViewExtensions
    {
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
}
