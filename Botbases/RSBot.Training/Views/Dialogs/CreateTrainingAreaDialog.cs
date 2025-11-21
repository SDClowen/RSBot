using System;
using System.Windows.Forms;
using RSBot.Core;
using SDUI.Controls;

namespace RSBot.Training.Views.Dialogs;

public partial class CreateTrainingAreaDialog : UIWindowBase
{
    public CreateTrainingAreaDialog()
    {
        InitializeComponent();
    }

    private void buttonAccept_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TrainingName.Text))
            DialogResult = DialogResult.Retry;
    }

    private void CreateTrainingAreaDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DialogResult == DialogResult.Retry)
            e.Cancel = true;
    }

    private void CreateTrainingAreaDialog_Load(object sender, EventArgs e)
    {
        var pos = Game.Player.Movement.Source;
        labelPos.Text = $"X: {pos.X:0.0}  Y:{pos.Y:0.0}";
        labelArea.Text = Game.ReferenceManager.GetTranslation(pos.Region.ToString());
    }
}
