using Python.Runtime;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;
using SDUI.Controls;

namespace RSBot.Python.Components.API.GUI.Controls
{
    public class TextBoxWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public TextBoxWrapper(TextBox tb, Main form, PyObject callback = null)
            : base(tb, form)
        {
            _callback = callback;

            if (_callback != null)
            {
                tb.TextChanged += (sender, args) =>
                {
                    using (Py.GIL())
                    {
                        try
                        {
                            _callback.Invoke(new PyString(tb.Text));
                        }
                        catch (PythonException ex)
                        {
                            form.AppendLog(ex.ToString());
                        }
                    }
                };
            }
        }

        private string GetText()
        {
            return ((SDUI.Controls.TextBox)Control).Text;
        }

        private void SetTextValue(string text)
        {
            Invoke(() => ((SDUI.Controls.TextBox)Control).Text = text);
        }
        public string get_text()
        {
            return GetText();
        }
        public void set_text_value(string text)
        {
            SetTextValue(text);
        }
    }
}
