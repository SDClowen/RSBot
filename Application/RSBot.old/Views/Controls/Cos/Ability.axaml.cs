using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core.Event;
using RSBot.Core.Objects.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Control for displaying Ability type Cos (Companion) information
/// </summary>
public partial class Ability : CosControlBase
{
    private Ability _ability;

    /// <summary>
    /// Initializes a new instance of the <see cref="Ability"/> class.
    /// </summary>
    public Ability()
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

        _ability = Game.Cos.Ability;

        lblPetName.Text = _ability.Name;
        labelLevel.Text = $"Level: {_ability.Level}";

        progressHP.Maximum = _ability.MaxHealth;
        progressHP.Value = _ability.Health;

        progressMP.Maximum = _ability.MaxMana;
        progressMP.Value = _ability.Mana;

        progressExperience.Maximum = _ability.MaxExperience;
        progressExperience.Value = _ability.Experience;

        MiniCosControl.Hp.Maximum = _ability.MaxHealth;
        MiniCosControl.Hp.Value = _ability.Health;
    }

    private void OnUpdateCos(Core.Objects.Cos.Cos cos)
    {
        if (cos is not Ability ability)
            return;

        _ability = ability;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblPetName = this.FindControl<TextBlock>("lblPetName");
            var labelLevel = this.FindControl<TextBlock>("labelLevel");
            var progressHP = this.FindControl<ProgressBar>("progressHP");
            var progressMP = this.FindControl<ProgressBar>("progressMP");
            var progressExperience = this.FindControl<ProgressBar>("progressExperience");

            lblPetName.Text = ability.Name;
            labelLevel.Text = $"Level: {ability.Level}";

            progressHP.Maximum = ability.MaxHealth;
            progressHP.Value = ability.Health;

            progressMP.Maximum = ability.MaxMana;
            progressMP.Value = ability.Mana;

            progressExperience.Maximum = ability.MaxExperience;
            progressExperience.Value = ability.Experience;

            MiniCosControl.Hp.Maximum = ability.MaxHealth;
            MiniCosControl.Hp.Value = ability.Health;
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