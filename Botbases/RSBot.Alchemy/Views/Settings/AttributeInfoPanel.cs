using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.Objects.Inventory.Item;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RSBot.Alchemy.Views.Settings
{
    public partial class AttributeInfoPanel : UserControl
    {
        public delegate void OnChangeEventHandler();

        public event OnChangeEventHandler OnChange;

        private bool _checked;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AttributeInfoPanel"/> is checked.
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        public bool Checked
        {
            get
            {
                return checkSelected.Checked;
            }

            set
            {
                _checked = value;
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
        /// Gets the stones assigned to this attribute.
        /// </summary>
        /// <value>
        /// The stones.
        /// </value>
        public IEnumerable<InventoryItem>? Stones { get; init; }

        public AttributeInfoPanel(AttributesGroup group, IEnumerable<InventoryItem>? stones, InventoryItem item)
        {
            InitializeComponent();

            Stones = stones;

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

            var attributeSlot = AttributesInfo.GetAttributeSlotForItem(group, item.Record);
            checkSelected.Text = $"{group.GetTranslation()} +{item.Attributes.GetPercentage(attributeSlot)}%";
        }

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
                _ => 0
            };
        }

        #endregion Methods
    }
}