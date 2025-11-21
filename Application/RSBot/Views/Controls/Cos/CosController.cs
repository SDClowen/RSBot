using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RSBot.Core.Event;
using SDUI.Controls;
using CosAbility = RSBot.Core.Objects.Cos.Ability;
using CosBase = RSBot.Core.Objects.Cos.Cos;
using CosFellow = RSBot.Core.Objects.Cos.Fellow;
using CosGrowth = RSBot.Core.Objects.Cos.Growth;
using CosJobTransport = RSBot.Core.Objects.Cos.JobTransport;
using CosTransport = RSBot.Core.Objects.Cos.Transport;

namespace RSBot.Views.Controls.Cos;

[ToolboxItem(true)]
public partial class CosController : DoubleBufferedControl
{
    private readonly Dictionary<string, CosControlBase> _cachedControls;
    private int _selectedIndex;

    public CosController()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        InitializeComponent();

        CheckForIllegalCrossThreadCalls = false;
        Visible = false;

        _cachedControls = new Dictionary<string, CosControlBase>();
        SubscribeEvents();
    }

    /// <summary>
    ///     Subscribes the events.
    /// </summary>
    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnSummonCos", new Action<CosBase>(OnSummonCos));
        EventManager.SubscribeEvent("OnTerminateCos", new Action<CosBase>(OnTerminateCos));
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);
    }

    private void OnAgentServerDisconnected()
    {
        panel.Controls.Clear();
        panelTopCenter.Controls.Clear();
        _cachedControls.Clear();
        _selectedIndex = 0;
        Visible = false;
    }

    private void OnSummonCos(CosBase obj)
    {
        switch (obj)
        {
            case CosGrowth _:
                TryAddControlToPanel<Growth>();
                break;

            case CosAbility _:
                TryAddControlToPanel<Ability>();
                break;

            case CosFellow _:
                TryAddControlToPanel<Fellow>();
                break;

            case CosTransport _:
                TryAddControlToPanel<Transport>();
                break;

            case CosJobTransport _:
                TryAddControlToPanel<JobTransport>();
                break;
            default:
                return;
        }
    }

    private void OnTerminateCos(CosBase obj)
    {
        switch (obj)
        {
            case CosGrowth _:
                TryRemoveControlFromPanel<Growth>();
                break;

            case CosAbility _:
                TryRemoveControlFromPanel<Ability>();
                break;

            case CosFellow _:
                TryRemoveControlFromPanel<Fellow>();
                break;

            case CosTransport _:
                TryRemoveControlFromPanel<Transport>();
                break;

            case CosJobTransport _:
                TryRemoveControlFromPanel<JobTransport>();
                break;
            default:
                return;
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
            control.Dock = DockStyle.Fill;
            control.MiniCosControl.Click += MiniCosControl_Click;
            _cachedControls.Add(name, control);
        }

        return control != null;
    }

    private void TryAddControlToPanel<T>()
        where T : CosControlBase, new()
    {
        if (!TryGetCachedControl<T>(out var control))
            return;

        var action = new Action(() =>
        {
            panel.Controls.Add(control);
            panelTopCenter.Controls.Add(control.MiniCosControl);
            control.MiniCosControl.TabIndex = panel.Controls.Count - 1;
            control.Initialize();

            ReOrder();
        });

        if (panel.InvokeRequired)
            panel.Invoke(action);
        else
            action();
    }

    private void TryRemoveControlFromPanel<T>()
        where T : CosControlBase, new()
    {
        if (!TryGetCachedControl<T>(out var control))
            return;

        var action = new Action(() =>
        {
            panel.Controls.Remove(control);
            panelTopCenter.Controls.Remove(control.MiniCosControl);
            control.Reset();

            // Reindex all controls
            for (var i = 0; i < panel.Controls.Count; i++)
                ((CosControlBase)panel.Controls[i]).MiniCosControl.TabIndex = i;

            _selectedIndex = panel.Controls.Count - 1;
            ReOrder();
        });

        if (InvokeRequired)
            panel.Invoke(action);
        else
            action();
    }

    private void ReOrder()
    {
        Visible = panel.Controls.Count > 0;
        if (!Visible)
        {
            _selectedIndex = 0;
            return;
        }

        var startIndex = 0;
        if (_selectedIndex > 3)
            startIndex = _selectedIndex - 4;

        for (var i = startIndex; i < panel.Controls.Count; i++)
        {
            var control = panel.Controls[i] as CosControlBase;
            control.Visible = control.MiniCosControl.TabIndex == _selectedIndex;
            control.MiniCosControl.Selected = control.Visible;

            if (control.Visible)
            {
                AutoSize = false;

                Height = topPanel.Height + control.Height + 20;
            }
        }
    }

    private void buttonNext_Click(object sender, EventArgs e)
    {
        if (_selectedIndex >= panel.Controls.Count - 1)
            return;

        _selectedIndex++;

        ReOrder();
    }

    private void buttonPrev_Click(object sender, EventArgs e)
    {
        if (_selectedIndex <= 0)
            return;

        _selectedIndex--;
        ReOrder();
    }

    private void MiniCosControl_Click(object sender, EventArgs e)
    {
        var index = (sender as MiniCosControl).TabIndex;
        if (_selectedIndex == index)
            return;

        _selectedIndex = index;
        ReOrder();
    }
}
