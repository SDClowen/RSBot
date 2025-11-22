using System;
using System.Windows.Forms;
using Python.Runtime;
using RSBot.Python.Views;

namespace RSBot.Python.API.GUI.Controls
{
    public class CheckBoxWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public CheckBoxWrapper(CheckBox cb, Main form, PyObject callback)
            : base(cb, form)
        {
            _callback = callback;

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

        public bool GetChecked()
        {
            return ((CheckBox)Control).Checked;
        }

        public void SetChecked(bool value)
        {
            Invoke(() => ((CheckBox)Control).Checked = value);
        }
    }
}
