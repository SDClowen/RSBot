using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RSBot.Views.Controls
{
    [ToolboxItem(false)]
    public partial class MiniCosControl : UserControl
    {
        private bool _selected = false;
        public bool Selected 
        {
            get => _selected;
            set
            {
                _selected = value;
                panel.BorderColor = value ? Color.Yellow : Color.Transparent;
            }
        }

        public MiniCosControl()
        {
            InitializeComponent();
        }

        private void OnClick_Redirector(object sender, System.EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
