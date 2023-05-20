using RSBot.Core;
using SDUI.Controls;
using System.Windows.Forms;

namespace RSBot.Default.Views.Dialogs
{
    public partial class CreateTrainingAreaDialog : UIWindowBase
    {
        public CreateTrainingAreaDialog()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TrainingName.Text))
                DialogResult = DialogResult.Retry;
        }

        private void CreateTrainingAreaDialog_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }

        private void CreateTrainingAreaDialog_Load(object sender, System.EventArgs e)
        {
            var pos = Game.Player.Movement.Source;
            labelPos.Text = $"X: {pos.X:0.0}  Y:{pos.Y:0.0}";
            labelArea.Text = Game.ReferenceManager.GetTranslation(pos.Region.ToString());
        }
    }
}
