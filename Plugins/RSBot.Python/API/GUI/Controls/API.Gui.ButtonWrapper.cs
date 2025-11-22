using System;
using System.Windows.Forms;
using Python.Runtime;
using RSBot.Python.Views;

namespace RSBot.Python.API.GUI.Controls
{
    public class ButtonWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public ButtonWrapper(Button btn, Main form, PyObject callback)
            : base(btn, form)
        {
            _callback = callback;

            btn.Click += (sender, args) =>
            {
                using (Py.GIL())
                {
                    try
                    {
                        _callback.Invoke();
                    }
                    catch (PythonException ex)
                    {
                        form.AppendLog(ex.ToString());
                    }
                }
            };
        }
    }
}
