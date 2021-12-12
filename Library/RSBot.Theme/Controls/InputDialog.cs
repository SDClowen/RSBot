using System;
using System.Windows.Forms;

namespace RSBot.Theme.Controls
{
    public partial class InputDialog : Form
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        /// <value>
        /// The selector.
        /// </value>
        public ComboBox Selector => comboBox;

        /// <summary>
        /// <c>true</c> if the selector activated; otherwise <c>false</c>
        /// </summary>
        private bool _isSelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputDialog"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="selector">If you want to active the selector instead of textbox <c>true</c>; otherwise <c>false</c></param>
        public InputDialog(string title, string message, bool selector = false)
        {
            Message = message;
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;
            _isSelector = selector;

            if (selector)
            {
                comboBox.Visible = true;
                txtValue.Visible = false;
            }
        }

        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <param name="title">The title content</param>
        /// <param name="message">The dialog message</param>
        /// <param name="selector">If you want to active the selector instead of textbox <c>true</c>; otherwise <c>false</c></param>
        /// <returns>The <seealso cref="DialogResult"/></returns>
        public static DialogResult Show(string title, string message, bool selector = false)
            => new InputDialog(title, message, selector).ShowDialog();

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            string value;
            if (!_isSelector)
                value = txtValue.Text;
            else
                value = comboBox.SelectedItem.ToString();

            if(string.IsNullOrWhiteSpace(value))
            {
                MessageBox.Show(this, "The value can't be empty!");

                DialogResult = DialogResult.Retry;
                return;
            }

            Value = value;
        }

        /// <summary>
        /// Handles the PreviewKeyDown event of the txtValue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PreviewKeyDownEventArgs"/> instance containing the event data.</param>
        private void txtValue_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Value = txtValue.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void InputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }
    }
}