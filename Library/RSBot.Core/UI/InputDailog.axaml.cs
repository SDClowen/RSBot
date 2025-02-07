using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace RSBot.Core.UI;

public partial class InputDialog : Window
{
    public enum InputType
    {
        Combobox,
        Textbox,
        Numeric
    }

    private readonly InputType _inputType;

    public object Value { get; private set; }

    public ComboBox Selector => _comboBox;

    public NumericUpDown Numeric => _numValue;

    public InputDialog(string windowTitle, string title, string message, InputType inputType = InputType.Textbox, object defaultValue = null)
    {
        InitializeComponent();

        Title = windowTitle;
        _lblTitle.Text = title;
        _lblMessage.Text = message;
        _inputType = inputType;

        switch (_inputType)
        {
            case InputType.Combobox:
                _comboBox.IsVisible = true;
                _txtValue.IsVisible = false;
                _numValue.IsVisible = false;

                if (defaultValue != null)
                    _comboBox.SelectedIndex = (int)defaultValue;
                break;

            case InputType.Textbox:
                _comboBox.IsVisible = false;
                _txtValue.IsVisible = true;
                _numValue.IsVisible = false;

                if (defaultValue != null)
                    _txtValue.Text = defaultValue.ToString();
                break;

            case InputType.Numeric:
                _comboBox.IsVisible = false;
                _txtValue.IsVisible = false;
                _numValue.IsVisible = true;

                if (defaultValue != null)
                    _numValue.Value = (decimal)defaultValue;
                break;
        }

        _btnOK.Click += BtnOK_Click;
        _btnCancel.Click += (s, e) => Close(false);
        _txtValue.KeyDown += TxtValue_KeyDown;
        _numValue.KeyDown += NumValue_KeyDown;
    }

    public static async Task<(bool result, object value)> ShowDialog(Window parent, string windowTitle, string title, string message, InputType inputType)
    {
        var dialog = new InputDialog(windowTitle, title, message, inputType);
        var result = await dialog.ShowDialog<bool>(parent);
        
        return (result, dialog.Value);
    }

    private void BtnOK_Click(object sender, RoutedEventArgs e)
    {
        object value = null;
        switch (_inputType)
        {
            case InputType.Combobox:
                value = _comboBox.SelectedItem;
                break;
            case InputType.Textbox:
                value = _txtValue.Text;
                break;
            case InputType.Numeric:
                value = _numValue.Value;
                break;
        }

        if (_inputType == InputType.Textbox && string.IsNullOrWhiteSpace(value?.ToString()))
        {
            // In Avalonia we use MessageBox from the community toolkit
            //_ = MessageBoxManager.Show("Error", "The value cannot be empty!");
            return;
        }

        Value = value;
        Close(true);
    }

    private void TxtValue_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Value = _txtValue.Text;
            Close(true);
        }
    }

    private void NumValue_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Value = _numValue.Value;
            Close(true);
        }
    }
}
