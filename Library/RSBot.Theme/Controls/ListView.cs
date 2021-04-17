using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RSBot.Theme.Helpers;
using static RSBot.Theme.NativeMethods;

namespace RSBot.Theme.Controls
{
    /// <summary>
    /// An aero-styled ListView.
    /// </summary>
    /// <remarks>
    /// A ListView with the "Explorer"-WindowTheme applied.
    /// If the operating system is Windows XP or older, nothing will be changed.
    /// </remarks>
    [DesignerCategory("Code")]
    [DisplayName("Aero ListView")]
    [Description("An aero-styled ListView.")]
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(ListView))]
    public class ListView
        : System.Windows.Forms.ListView
    {
        private const int LVS_EX_DOUBLEBUFFER = 0x10000;
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;

        private const short UIS_SET = 1;
        private const short UISF_HIDEFOCUS = 0x1;

        private ListViewColumnSorter LvwColumnSorter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AeroListView"/> class.
        /// </summary>
        public ListView()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            LvwColumnSorter = new ListViewColumnSorter();
            ListViewItemSorter = LvwColumnSorter;
            View = View.Details;
            FullRowSelect = true;

            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        /// <summary>
        /// Raises the <see cref="E:HandleCreated" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetWindowTheme(Handle, "explorer", null);
                SendMessage(Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, new IntPtr(LVS_EX_DOUBLEBUFFER), new IntPtr(LVS_EX_DOUBLEBUFFER));
            }
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ColumnClick" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ColumnClickEventArgs"/> instance containing the event data.</param>
        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == LvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                LvwColumnSorter.Order = (LvwColumnSorter.Order == SortOrder.Ascending)
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                LvwColumnSorter.SortColumn = e.Column;
                LvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            if (!VirtualMode)
                Sort();
        }

        /// <summary>
        /// Select all rows on the given listview
        /// </summary>
        /// <param name="list">The listview whose items are to be selected</param>
        public void SelectAllItems()
        {
            var s = System.Diagnostics.Stopwatch.StartNew();
            Focus();
            SetItemState(-1, 2, 2);
            //MessageBox.Show($"Selected in: {s.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Deselect all rows on the given listview
        /// </summary>
        /// <param name="list">The listview whose items are to be deselected</param>
        public void DeselectAllItems()
        {
            SetItemState(-1, 2, 0);
        }

        /// <summary>
        /// Set the item state on the given item
        /// </summary>
        /// <param name="list">The listview whose item's state is to be changed</param>
        /// <param name="itemIndex">The index of the item to be changed</param>
        /// <param name="mask">Which bits of the value are to be set?</param>
        /// <param name="value">The value to be set</param>
        public void SetItemState(int itemIndex, int mask, int value)
        {
            LVITEM lvItem = new LVITEM();
            lvItem.stateMask = mask;
            lvItem.state = value;
            SendMessageLVItem(Handle, LVM_SETITEMSTATE, itemIndex, ref lvItem);

            EnsureVisible(itemIndex);
        }
    }
}