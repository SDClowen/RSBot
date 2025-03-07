using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Core.Event;
using RSBot.Core.Objects.Cos;

namespace RSBot.Views.Controls.Cos;

/// <summary>
/// Controller for managing and displaying Cos (Companion) entities
/// </summary>
public partial class CosController : UserControl
{
    private readonly Dictionary<string, CosControlBase> _cachedControls;
    private int _selectedIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="CosController"/> class.
    /// </summary>
    public CosController()
    {
        InitializeComponent();

        _cachedControls = new Dictionary<string, CosControlBase>();
        SubscribeEvents();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnSummonCos", new Action<Core.Objects.Cos.Cos>(OnSummonCos));
        EventManager.SubscribeEvent("OnTerminateCos", new Action<Core.Objects.Cos.Cos>(OnTerminateCos));
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
    }

    private void OnAgentServerDisconnected()
    {
        var panel = this.FindControl<Panel>("panel");
        var panelTopCenter = this.FindControl<Panel>("panelTopCenter");

        panel.Children.Clear();
        panelTopCenter.Children.Clear();
        _cachedControls.Clear();
        _selectedIndex = 0;
        IsVisible = false;
    }

    private void OnSummonCos(Core.Objects.Cos.Cos obj)
    {
        switch (obj)
        {
            case Growth _:
                TryAddControlToPanel<Growth>();
                break;

            case Ability _:
                TryAddControlToPanel<Ability>();
                break;

            case Fellow _:
                TryAddControlToPanel<Fellow>();
                break;

            case Transport _:
                TryAddControlToPanel<Transport>();
                break;

            case JobTransport _:
                TryAddControlToPanel<JobTransport>();
                break;
        }
    }

    private void OnTerminateCos(Core.Objects.Cos.Cos obj)
    {
        switch (obj)
        {
            case Growth _:
                TryRemoveControlFromPanel<Growth>();
                break;

            case Ability _:
                TryRemoveControlFromPanel<Ability>();
                break;

            case Fellow _:
                TryRemoveControlFromPanel<Fellow>();
                break;

            case Transport _:
                TryRemoveControlFromPanel<Transport>();
                break;

            case JobTransport _:
                TryRemoveControlFromPanel<JobTransport>();
                break;
        }
    }

    private bool TryGetCachedControl<T>(out CosControlBase control)
        where T : CosControlBase, new()
    {
        control = null;
        var name = typeof(T).Name;

        if (!_cachedControls.TryGetValue(name, out control))
        {
            control = new T();
            control.MiniCosControl.Tapped += MiniCosControl_Tapped;
            _cachedControls.Add(name, control);
        }

        return control != null;
    }

    private void TryAddControlToPanel<T>()
        where T : CosControlBase, new()
    {
        if (!TryGetCachedControl<T>(out var control))
            return;

        var panel = this.FindControl<Panel>("panel");
        var panelTopCenter = this.FindControl<Panel>("panelTopCenter");

        if (!panel.Children.Contains(control))
        {
            panel.Children.Add(control);
            panelTopCenter.Children.Add(control.MiniCosControl);
            control.Initialize();
        }

        IsVisible = true;
    }

    private void TryRemoveControlFromPanel<T>()
        where T : CosControlBase, new()
    {
        if (!TryGetCachedControl<T>(out var control))
            return;

        var panel = this.FindControl<Panel>("panel");
        var panelTopCenter = this.FindControl<Panel>("panelTopCenter");

        panel.Children.Remove(control);
        panelTopCenter.Children.Remove(control.MiniCosControl);

        if (panel.Children.Count == 0)
            IsVisible = false;
    }

    private void MiniCosControl_Tapped(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var miniControl = (MiniCosControl)sender;
        var panel = this.FindControl<Panel>("panel");

        foreach (CosControlBase control in panel.Children)
        {
            if (control.MiniCosControl == miniControl)
            {
                control.IsVisible = true;
                control.MiniCosControl.Selected = true;
            }
            else
            {
                control.IsVisible = false;
                control.MiniCosControl.Selected = false;
            }
        }
    }
} 