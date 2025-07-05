using Avalonia.Controls;
using Avalonia.Interactivity;
using RSBot.Core;
using System;

namespace RSBot.Default.Views.Dialogs;

public partial class CreateTrainingAreaDialog : Window
{
    public DialogResult Result { get; private set; } = DialogResult.None;

    public CreateTrainingAreaDialog()
    {
        InitializeComponent();
    }

    private void buttonAccept_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TrainingName.Text))
        {
            Result = DialogResult.Retry;
            this.Close(DialogResult.Retry);
        }
    }

    private void buttonCancel_Click(object sender, RoutedEventArgs e)
    {
        Result = DialogResult.Cancel;
        this.Close(DialogResult.Cancel);
    }

    public void CreateTrainingAreaDialog_FormClosing(object sender, WindowClosingEventArgs e)
    {
        if (this.Result  == DialogResult.Retry)
            e.Cancel = true;
    }

    private void CreateTrainingAreaDialog_Load(object sender, EventArgs e)
    {
        if (!Game.Ready)
            return;

        var pos = Game.Player.Movement.Source;
        labelPos.Text = $"X: {pos.X:0.0}  Y:{pos.Y:0.0}";
        labelArea.Text = Game.ReferenceManager.GetTranslation(pos.Region.ToString());
    }

}