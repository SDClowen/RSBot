using Python.Runtime;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;
using SDUI.Controls;

namespace RSBot.Python.Components.API.GUI.Controls
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
