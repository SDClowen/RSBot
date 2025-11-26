using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using SDUI.Controls;

namespace RSBot.Alchemy.Views.Settings;

[ToolboxItem(false)]
public partial class AttributeInfoPanel : DoubleBufferedControl
{
    public delegate void OnChangedEventHandler(bool @checked, int maxValue);

    /// <summary>
    ///     Gets the current attribute.
    /// </summary>
    /// <value>
    ///     The current attribute.
    /// </value>
    private ItemAttributesInfo _currentAttribute;

    /// <summary>
    ///     The current attribute slot
    /// </summary>
    private readonly byte _currentAttributeSlot;

    /// Initializes a new instance of the
    /// <see cref="AttributeInfoPanel" />
    /// class.
    /// </summary>
    /// <param name="group">The group.</param>
    /// <param name="stones">The stones.</param>
    /// <param name="item">The item.</param>
    public AttributeInfoPanel(
        ItemAttributeGroup group,
        IEnumerable<InventoryItem>? stones,
        InventoryItem item,
        int maxValue = 22
    )
    {
        CheckForIllegalCrossThreadCalls = false;

        InitializeComponent();

        AttributeGroup = group;
        Stones = stones;
        _currentAttribute = item.Attributes;
        _currentAttributeSlot = ItemAttributesInfo.GetAttributeSlotForItem(group, item.Record);

        SetMaxValue(maxValue);

        var totalAmount = stones == null || !stones.Any() ? 0 : stones.Sum(i => i.Amount);

        if (totalAmount == 0)
        {
            lblItemAmount.Text = "x0";

            comboMaxValue.Enabled = false;
            lblItemAmount.Enabled = false;
            checkSelected.Enabled = false;
        }
        else
        {
            lblItemAmount.Text = $"x{totalAmount}";
        }

        var attributeSlot = ItemAttributesInfo.GetAttributeSlotForItem(group, item.Record);
        checkSelected.Text = $"{group.GetTranslation()} +{item.Attributes.GetPercentage(attributeSlot)}%";
        checkSelected.CheckedChanged += CheckSelected_CheckedChanged;
        comboMaxValue.SelectedIndexChanged += ComboMaxValue_SelectedIndexChanged;

        if (Stones.Any())
            tipStone.SetToolTip(checkSelected, $"{Stones.First().Record.GetRealName()}x{totalAmount}");

        if (GetMaxValue() <= _currentAttribute.GetPercentage(_currentAttributeSlot))
            lblFinished.Show();
        else
            lblFinished.Hide();
    }

    public event OnChangedEventHandler OnChange;

    private void ComboMaxValue_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (comboMaxValue.SelectedItem == null)
            return;

        if (GetMaxValue() <= _currentAttribute.GetPercentage(_currentAttributeSlot))
        {
            checkSelected.Checked = false;
            lblFinished.Show();
        }
        else
        {
            checkSelected.Checked = true;
            lblFinished.Hide();
        }

        OnChange?.Invoke(checkSelected.Checked, GetMaxValue());
    }

    #region Events

    private void CheckSelected_CheckedChanged(object? sender, EventArgs e)
    {
        OnChange?.Invoke(checkSelected.Checked, GetMaxValue());
    }

    #endregion Events

    #region Properties

    /// <summary>
    ///     Gets or sets a value indicating whether this <see cref="AttributeInfoPanel" /> is checked.
    /// </summary>
    /// <value>
    ///     <c>true</c> if checked; otherwise, <c>false</c>.
    /// </value>
    public bool Checked
    {
        get => checkSelected.Checked;
        set => checkSelected.Checked = GetMaxValue() > _currentAttribute.GetPercentage(_currentAttributeSlot) && value;
    }

    /// <summary>
    ///     Gets the maximum value this attribute should have.
    /// </summary>
    /// <value>
    ///     The maximum value.
    /// </value>
    public int MaxValue => GetMaxValue();

    /// <summary>
    ///     Gets or sets the attribute group.
    /// </summary>
    /// <value>
    ///     The attribute group.
    /// </value>
    public ItemAttributeGroup AttributeGroup { get; set; }

    /// <summary>
    ///     Gets the stones assigned to this attribute.
    /// </summary>
    /// <value>
    ///     The stones.
    /// </value>
    public IEnumerable<InventoryItem>? Stones { get; init; }

    #endregion Properties

    #region Methods

    /// <summary>
    ///     Gets the maximum value selected by the user.
    /// </summary>
    /// <returns></returns>
    private int GetMaxValue()
    {
        return comboMaxValue.SelectedIndex switch
        {
            0 => 22,
            1 => 41,
            2 => 61,
            3 => 80,
            4 => 100,
            _ => 22,
        };
    }

    private void SetMaxValue(int maxValue)
    {
        switch (maxValue)
        {
            case <= 22:
                comboMaxValue.SelectedIndex = 0;

                return;

            case <= 41:
                comboMaxValue.SelectedIndex = 1;

                return;

            case <= 61:
                comboMaxValue.SelectedIndex = 2;

                return;

            case <= 80:
                comboMaxValue.SelectedIndex = 3;

                return;

            default:
                comboMaxValue.SelectedIndex = 0;
                break;
        }

        if (GetMaxValue() <= _currentAttribute.GetPercentage(_currentAttributeSlot))
            checkSelected.Checked = false;
    }

    #endregion Methods
}
