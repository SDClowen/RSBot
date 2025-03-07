using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core.Event;
using RSBot.Core.Objects.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Control for displaying Fellow type Cos (Companion) information
/// </summary>
public partial class Fellow : CosControlBase
{
    private Fellow _fellow;

    /// <summary>
    /// Initializes a new instance of the <see cref="Fellow"/> class.
    /// </summary>
    public Fellow()
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
        var progressMP = this.FindControl<ProgressBar>("progressMP");
        var progressExperience = this.FindControl<ProgressBar>("progressExperience");

        _fellow = Game.Cos.Fellow;

        lblPetName.Text = _fellow.Name;
        labelLevel.Text = $"Level: {_fellow.Level}";

        progressHP.Maximum = _fellow.MaxHealth;
        progressHP.Value = _fellow.Health;

        progressMP.Maximum = _fellow.MaxMana;
        progressMP.Value = _fellow.Mana;

        progressExperience.Maximum = _fellow.MaxExperience;
        progressExperience.Value = _fellow.Experience;

        MiniCosControl.Hp.Maximum = _fellow.MaxHealth;
        MiniCosControl.Hp.Value = _fellow.Health;
    }

    private void OnUpdateCos(Core.Objects.Cos.Cos cos)
    {
        if (cos is not Fellow fellow)
            return;

        _fellow = fellow;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblPetName = this.FindControl<TextBlock>("lblPetName");
            var labelLevel = this.FindControl<TextBlock>("labelLevel");
            var progressHP = this.FindControl<ProgressBar>("progressHP");
            var progressMP = this.FindControl<ProgressBar>("progressMP");
            var progressExperience = this.FindControl<ProgressBar>("progressExperience");

            lblPetName.Text = fellow.Name;
            labelLevel.Text = $"Level: {fellow.Level}";

            progressHP.Maximum = fellow.MaxHealth;
            progressHP.Value = fellow.Health;

            progressMP.Maximum = fellow.MaxMana;
            progressMP.Value = fellow.Mana;

            progressExperience.Maximum = fellow.MaxExperience;
            progressExperience.Value = fellow.Experience;

            MiniCosControl.Hp.Maximum = fellow.MaxHealth;
            MiniCosControl.Hp.Value = fellow.Health;
        });
    }

    public override void Reset()
    {
        base.Reset();

        var progressMP = this.FindControl<ProgressBar>("progressMP");
        var progressExperience = this.FindControl<ProgressBar>("progressExperience");

        progressMP.Value = 0;
        progressMP.Maximum = 0;

        progressExperience.Value = 0;
        progressExperience.Maximum = 0;
    }
} 