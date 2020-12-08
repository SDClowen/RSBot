using System;
using System.Windows.Forms;

namespace RSBot.Party.Views
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
        /// Initializes a new instance of the <see cref="InputDialog"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        public InputDialog(string title, string message)
        {
            Message = message;
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Value = txtValue.Text;
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
    }
}