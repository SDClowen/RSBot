using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core.Event;
using RSBot.Core.Objects.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Control for displaying Transport type Cos (Companion) information
/// </summary>
public partial class Transport : CosControlBase
{
    private Transport _transport;

    /// <summary>
    /// Initializes a new instance of the <see cref="Transport"/> class.
    /// </summary>
    public Transport()
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

        _transport = Game.Cos.Transport;

        lblPetName.Text = _transport.Name;
        labelLevel.Text = $"Level: {_transport.Level}";

        progressHP.Maximum = _transport.MaxHealth;
        progressHP.Value = _transport.Health;

        MiniCosControl.Hp.Maximum = _transport.MaxHealth;
        MiniCosControl.Hp.Value = _transport.Health;
    }

    private void OnUpdateCos(Core.Objects.Cos.Cos cos)
    {
        if (cos is not Transport transport)
            return;

        _transport = transport;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblPetName = this.FindControl<TextBlock>("lblPetName");
            var labelLevel = this.FindControl<TextBlock>("labelLevel");
            var progressHP = this.FindControl<ProgressBar>("progressHP");

            lblPetName.Text = transport.Name;
            labelLevel.Text = $"Level: {transport.Level}";

            progressHP.Maximum = transport.MaxHealth;
            progressHP.Value = transport.Health;

            MiniCosControl.Hp.Maximum = transport.MaxHealth;
            MiniCosControl.Hp.Value = transport.Health;
        });
    }
} 