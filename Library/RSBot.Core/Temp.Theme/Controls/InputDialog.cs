using System;
using System.Windows.Forms;

namespace RSBot.Theme.Controls
{
    public partial class InputDialog : CleanForm
    {
        public enum InputType
        {
            Combobox,
            Textbox,
            Numeric
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public object Value { get; private set; }

        /// <summary>
        /// Gets the selector.
        /// </summary>
        /// <value>
        /// The selector.
        /// </value>
        public ComboBox Selector => comboBox;

        /// <summary>
        /// Gets the selector.
        /// </summary>
        /// <value>
        /// The selector.
        /// </value>
        public NumericUpDown Numeric => numValue;

        /// <summary>
        /// Form input type
        /// </summary>
        private InputType _inputType;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputDialog"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <param name="selector">If you want to active the selector instead of textbox <c>true</c>; otherwise <c>false</c></param>
        public InputDialog(string formTitle, string title, string message, InputType inputType = InputType.Textbox)
        {
            InitializeComponent();
            BackColor = ColorScheme.BackColor;
            ForeColor = ColorScheme.ForeColor;

            Text = formTitle;
            lblTitle.Text = title;
            lblMessage.Text = message;
            _inputType = inputType;

            switch (_inputType)
            {
                case InputType.Combobox:
                    comboBox.Visible = true;
                    txtValue.Visible = false;
                    numValue.Visible = false;
                    break;
                case InputType.Textbox:
                    comboBox.Visible = false;
                    txtValue.Visible = true;
                    numValue.Visible = false;
                    break;
                case InputType.Numeric:
                    comboBox.Visible = false;
                    txtValue.Visible = false;
                    numValue.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <param name="title">The title content</param>
        /// <param name="message">The dialog message</param>
        /// <param name="selector">If you want to active the selector instead of textbox <c>true</c>; otherwise <c>false</c></param>
        /// <returns>The <seealso cref="DialogResult"/></returns>
        public static DialogResult Show(string formTitle, string title, string message, InputType inputType)
            => new InputDialog(formTitle, title, message, inputType).ShowDialog();

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            object value = null;
            switch (_inputType)
            {
                case InputType.Combobox:
                    value = comboBox.SelectedItem;
                    break;
                case InputType.Textbox:
                    value = txtValue.Text;
                    break;
                case InputType.Numeric:
                    value = numValue.Value;
                    break;
                default:
                    break;
            }

            if (_inputType == InputType.Textbox && string.IsNullOrWhiteSpace(value.ToString()))
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

        /// <summary>
        /// Handles the FormClosing event of the form control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void InputDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Retry)
                e.Cancel = true;
        }

        /// <summary>
        /// Handles the KeyUp event of the numValue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void numValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            Value = numValue.Value;
            DialogResult = DialogResult.OK;
        }
    }
}