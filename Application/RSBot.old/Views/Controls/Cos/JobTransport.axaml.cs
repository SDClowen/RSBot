using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core.Event;
using RSBot.Core.Objects.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Control for displaying JobTransport type Cos (Companion) information
/// </summary>
public partial class JobTransport : CosControlBase
{
    private JobTransport _jobTransport;

    /// <summary>
    /// Initializes a new instance of the <see cref="JobTransport"/> class.
    /// </summary>
    public JobTransport()
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

        _jobTransport = Game.Cos.JobTransport;

        lblPetName.Text = _jobTransport.Name;
        labelLevel.Text = $"Level: {_jobTransport.Level}";

        progressHP.Maximum = _jobTransport.MaxHealth;
        progressHP.Value = _jobTransport.Health;

        MiniCosControl.Hp.Maximum = _jobTransport.MaxHealth;
        MiniCosControl.Hp.Value = _jobTransport.Health;
    }

    private void OnUpdateCos(Core.Objects.Cos.Cos cos)
    {
        if (cos is not JobTransport jobTransport)
            return;

        _jobTransport = jobTransport;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblPetName = this.FindControl<TextBlock>("lblPetName");
            var labelLevel = this.FindControl<TextBlock>("labelLevel");
            var progressHP = this.FindControl<ProgressBar>("progressHP");

            lblPetName.Text = jobTransport.Name;
            labelLevel.Text = $"Level: {jobTransport.Level}";

            progressHP.Maximum = jobTransport.MaxHealth;
            progressHP.Value = jobTransport.Health;

            MiniCosControl.Hp.Maximum = jobTransport.MaxHealth;
            MiniCosControl.Hp.Value = jobTransport.Health;
        });
    }
} 