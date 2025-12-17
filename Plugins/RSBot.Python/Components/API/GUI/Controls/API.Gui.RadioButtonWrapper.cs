using System.Windows.Forms;
using Python.Runtime;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;

namespace RSBot.Python.Components.API.GUI.Controls
{
    public class RadioButtonWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public RadioButtonWrapper(RadioButton rb, Main form, PyObject callback = null)
            : base(rb, form)
        {
            _callback = callback;
            if (_callback != null)
            {

                rb.CheckedChanged += (sender, args) =>
                {
                    using (Py.GIL())
                    {
                        try
                        {
                            _callback.Invoke(PyObject.FromManagedObject(rb.Checked));
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
            return ((RadioButton)Control).Checked;
        }

        private void SetChecked(bool value)
        {
            Invoke(() => ((RadioButton)Control).Checked = value);
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
