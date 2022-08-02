using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Objects;

namespace RSBot.Alchemy.Views.Settings
{
    public partial class AttributeInfoPanel : UserControl
    {
        public byte AttributeSlot { get; set; }


        public AttributeInfoPanel(IEnumerable<InventoryItem>? stones, InventoryItem item, string paramName, byte attributeSlot)
        {
            InitializeComponent();

            if (stones == null || !stones.Any())
                lblItemAmount.Text = "x0";
            else
                lblItemAmount.Text = $"x{stones?.Sum(i => i.Amount)}";
            
            checkSelected.Text = $"{Game.ReferenceManager.GetTranslation(paramName)} +{item.Attributes.GetPercentage(attributeSlot)}%";
        }
    }
}
