using System;
using System.ComponentModel;
using System.Drawing;
using SDUI.Controls;

namespace RSBot.Views.Controls;

[ToolboxItem(false)]
public partial class MiniCosControl : DoubleBufferedControl
{
    private bool _selected;

    public MiniCosControl()
    {
        InitializeComponent();
    }

    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            panel.BorderColor = value ? Color.Yellow : Color.Transparent;
        }
    }

    private void OnClick_Redirector(object sender, EventArgs e)
    {
        OnClick(e);
    }
}
