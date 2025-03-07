using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core.Event;
using RSBot.Core.Objects.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Control for displaying Growth type Cos (Companion) information
/// </summary>
public partial class Growth : CosControlBase
{
    private Growth _growth;

    /// <summary>
    /// Initializes a new instance of the <see cref="Growth"/> class.
    /// </summary>
    public Growth()
    {
        InitializeComponent();

        EventManager.SubscribeEvent("OnUpdateCos", new Action<Core.Objects.Cos.Cos>(OnUpdateCos));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void Initialize()
    {
        base.Initialize();

        var lblPetName = this.FindControl<TextBlock>("lblPetName");
        var labelLevel = this.FindControl<TextBlock>("labelLevel");
        var progressHP = this.FindControl<ProgressBar>("progressHP");
        var progressHunger = this.FindControl<ProgressBar>("progressHunger");
        var progressExperience = this.FindControl<ProgressBar>("progressExperience");

        _growth = Game.Cos.Growth;

        lblPetName.Text = _growth.Name;
        labelLevel.Text = $"Level: {_growth.Level}";

        progressHP.Maximum = _growth.MaxHealth;
        progressHP.Value = _growth.Health;

        progressHunger.Maximum = _growth.MaxHunger;
        progressHunger.Value = _growth.Hunger;

        progressExperience.Maximum = _growth.MaxExperience;
        progressExperience.Value = _growth.Experience;

        MiniCosControl.Hp.Maximum = _growth.MaxHealth;
        MiniCosControl.Hp.Value = _growth.Health;
    }

    private void OnUpdateCos(Core.Objects.Cos.Cos cos)
    {
        if (cos is not Growth growth)
            return;

        _growth = growth;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblPetName = this.FindControl<TextBlock>("lblPetName");
            var labelLevel = this.FindControl<TextBlock>("labelLevel");
            var progressHP = this.FindControl<ProgressBar>("progressHP");
            var progressHunger = this.FindControl<ProgressBar>("progressHunger");
            var progressExperience = this.FindControl<ProgressBar>("progressExperience");

            lblPetName.Text = growth.Name;
            labelLevel.Text = $"Level: {growth.Level}";

            progressHP.Maximum = growth.MaxHealth;
            progressHP.Value = growth.Health;

            progressHunger.Maximum = growth.MaxHunger;
            progressHunger.Value = growth.Hunger;

            progressExperience.Maximum = growth.MaxExperience;
            progressExperience.Value = growth.Experience;

            MiniCosControl.Hp.Maximum = growth.MaxHealth;
            MiniCosControl.Hp.Value = growth.Health;
        });
    }

    public override void Reset()
    {
        base.Reset();

        var progressHunger = this.FindControl<ProgressBar>("progressHunger");
        var progressExperience = this.FindControl<ProgressBar>("progressExperience");

        progressHunger.Value = 0;
        progressHunger.Maximum = 0;

        progressExperience.Value = 0;
        progressExperience.Maximum = 0;
    }
} 