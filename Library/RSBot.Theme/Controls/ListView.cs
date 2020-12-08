using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;
        private const int LVS_EX_DOUBLEBUFFER = 0x10000;

        /// <summary>
        /// Initializes a new instance of the <see cref="AeroListView"/> class.
        /// </summary>
        public ListView()
            : base()
        {
            this.FullRowSelect = true;
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
                NativeMethods.SetWindowTheme(this.Handle, "explorer", null);
                NativeMethods.SendMessage(this.Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, new IntPtr(LVS_EX_DOUBLEBUFFER), new IntPtr(LVS_EX_DOUBLEBUFFER));
            }
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}