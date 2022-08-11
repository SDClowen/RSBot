using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Alchemy.Views.Settings
{
    public partial class AttributeInfoPanel : UserControl
    {
        public delegate void OnChangedEventHandler(bool @checked, int maxValue);

        public event OnChangedEventHandler OnChange;

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AttributeInfoPanel"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        public bool Checked
        {
            get => checkSelected.Checked;

            set
            {
                if (checkSelected != null)
                    checkSelected.Checked = value;
            }
        }

        /// <summary>
        /// Gets the maximum value this attribute should have.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public int MaxValue => GetMaxValue();

        /// <summary>
        /// Gets or sets the attribute group.
        /// </summary>
        /// <value>
        /// The attribute group.
        /// </value>
        public ItemAttributeGroup AttributeGroup { get; set; }

        /// <summary>
        /// Gets the stones assigned to this attribute.
        /// </summary>
        /// <value>
        /// The stones.
        /// </value>
        public IEnumerable<InventoryItem>? Stones { get; init; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeInfoPanel"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="stones">The stones.</param>
        /// <param name="item">The item.</param>
        public AttributeInfoPanel(ItemAttributeGroup group, IEnumerable<InventoryItem>? stones, InventoryItem item, int maxValue = 22)
        {
            InitializeComponent();

            AttributeGroup = group;
            Stones = stones;

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
                lblItemAmount.Text = $"x{stones?.Sum(i => i.Amount)}";

            var attributeSlot = ItemAttributesInfo.GetAttributeSlotForItem(group, item.Record);
            checkSelected.Text = $"{group.GetTranslation()} +{item.Attributes.GetPercentage(attributeSlot)}%";
            checkSelected.CheckedChanged += CheckSelected_CheckedChanged;
            comboMaxValue.SelectedIndexChanged += ComboMaxValue_SelectedIndexChanged;
        }

        private void ComboMaxValue_SelectedIndexChanged(object? sender, System.EventArgs e)
        {
            if (comboMaxValue.SelectedItem == null)
                return;

            OnChange?.Invoke(checkSelected.Checked, GetMaxValue());
        }

        #region Events

        private void CheckSelected_CheckedChanged(object? sender, System.EventArgs e)
        {
            OnChange?.Invoke(checkSelected.Checked, GetMaxValue());
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Gets the maximum value selected by the user.
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
                _ => 22
            };
        }

        private void SetMaxValue(int maxValue)
        {
            if (maxValue <= 22)
            {
                comboMaxValue.SelectedIndex = 0;

                return;
            }


            if (maxValue <= 41)
            {
                comboMaxValue.SelectedIndex = 1;

                return;
            }

            if (maxValue <= 61)
            {
                comboMaxValue.SelectedIndex = 2;

                return;
            }

            if (maxValue <= 80)
            {
                comboMaxValue.SelectedIndex = 3;

                return;
            }

            comboMaxValue.SelectedIndex = 4;
        }

        #endregion Methods
    }
}