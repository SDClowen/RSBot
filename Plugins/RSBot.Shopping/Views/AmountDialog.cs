using System;
using System.Windows.Forms;

namespace RSBot.Shopping.Views
{
    public partial class AmountDialog : Form
    {
        /// <summary>
        /// Gets the selected amount.
        /// </summary>
        /// <value>
        /// The selected amount.
        /// </value>
        public int SelectedValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AmountDialog"/> class.
        /// </summary>
        public AmountDialog(string itemName, int defaultValue = 1)
        {
            InitializeComponent();
            numValue.Value = defaultValue;
            lblItemName.Text = itemName;
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            SelectedValue = Convert.ToInt32(numValue.Value);
        }

        /// <summary>
        /// Handles the KeyUp event of the numValue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void numValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            SelectedValue = Convert.ToInt32(numValue.Value);
            DialogResult = DialogResult.OK;
        }
    }
}