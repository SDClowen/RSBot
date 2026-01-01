using Python.Runtime;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;
using SDUI.Controls;

namespace RSBot.Python.Components.API.GUI.Controls
{
    public class CheckBoxWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public CheckBoxWrapper(CheckBox cb, Main form, PyObject callback = null)
            : base(cb, form)
        {
            _callback = callback;
            if (_callback != null)
            {

                cb.CheckedChanged += (sender, args) =>
                {
                    using (Py.GIL())
                    {
                        try
                        {
                            _callback.Invoke(PyObject.FromManagedObject(cb.Checked));
                        }
                        catch (PythonException ex)
                        {
                            form.AppendLog(ex.ToString());
                        }
                    }
                };
            }

        }

        private bool GetChecked()
        {
            return ((CheckBox)Control).Checked;
        }

        private void SetChecked(bool value)
        {
            Invoke(() => ((CheckBox)Control).Checked = value);
        }

        public bool get_checked()
        {
            return GetChecked();
        }
        public void set_checked(bool value)
        {
            SetChecked(value);
        }
    }
}
