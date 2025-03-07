using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using RSBot.Core;
using RSBot.Core.Event;
using RSBot.Core.Objects;

namespace RSBot.Views.Controls;

/// <summary>
/// Control for displaying entity (player/monster) information including HP and MP
/// </summary>
public partial class Entity : UserControl
{
    private IEntity _entity;

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    public Entity()
    {
        InitializeComponent();

        EventManager.SubscribeEvent("OnUpdateEntity", new Action<IEntity>(OnUpdateEntity));
        EventManager.SubscribeEvent("OnSelectEntity", new Action<IEntity>(OnSelectEntity));
        EventManager.SubscribeEvent("OnDeselectEntity", OnDeselectEntity);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OnUpdateEntity(IEntity entity)
    {
        if (_entity == null || entity.UniqueId != _entity.UniqueId)
            return;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var progressHP = this.FindControl<ProgressBar>("progressHP");
            var progressMP = this.FindControl<ProgressBar>("progressMP");
            var lblHP = this.FindControl<TextBlock>("lblHP");
            var lblMP = this.FindControl<TextBlock>("lblMP");

            progressHP.Maximum = entity.MaxHealth;
            progressHP.Value = entity.Health;
            lblHP.Text = $"{entity.Health} / {entity.MaxHealth}";

            progressMP.Maximum = entity.MaxMana;
            progressMP.Value = entity.Mana;
            lblMP.Text = $"{entity.Mana} / {entity.MaxMana}";
        });
    }

    private void OnSelectEntity(IEntity entity)
    {
        _entity = entity;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblEntityName = this.FindControl<TextBlock>("lblEntityName");
            var progressHP = this.FindControl<ProgressBar>("progressHP");
            var progressMP = this.FindControl<ProgressBar>("progressMP");
            var lblHP = this.FindControl<TextBlock>("lblHP");
            var lblMP = this.FindControl<TextBlock>("lblMP");

            lblEntityName.Text = entity.Name;

            progressHP.Maximum = entity.MaxHealth;
            progressHP.Value = entity.Health;
            lblHP.Text = $"{entity.Health} / {entity.MaxHealth}";

            progressMP.Maximum = entity.MaxMana;
            progressMP.Value = entity.Mana;
            lblMP.Text = $"{entity.Mana} / {entity.MaxMana}";
        });
    }

    private void OnDeselectEntity()
    {
        _entity = null;

        Dispatcher.UIThread.InvokeAsync(() =>
        {
            var lblEntityName = this.FindControl<TextBlock>("lblEntityName");
            var progressHP = this.FindControl<ProgressBar>("progressHP");
            var progressMP = this.FindControl<ProgressBar>("progressMP");
            var lblHP = this.FindControl<TextBlock>("lblHP");
            var lblMP = this.FindControl<TextBlock>("lblMP");

            lblEntityName.Text = "No target";

            progressHP.Maximum = 100;
            progressHP.Value = 0;
            lblHP.Text = "0 / 0";

            progressMP.Maximum = 100;
            progressMP.Value = 0;
            lblMP.Text = "0 / 0";
        });
    }
} 