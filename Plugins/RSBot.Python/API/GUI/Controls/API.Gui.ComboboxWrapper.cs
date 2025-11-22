using System;
using System.Windows.Forms;
using Python.Runtime;
using RSBot.Python.Views;

namespace RSBot.Python.API.GUI.Controls
{
    public class ComboBoxWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public ComboBoxWrapper(ComboBox cb, Main form, PyObject callback)
            : base(cb, form)
        {
            _callback = callback;

            cb.SelectedIndexChanged += (sender, args) =>
            {
                using (Py.GIL())
                {
                    try
                    {
                        _callback.Invoke(new PyInt(cb.SelectedIndex));
                    }
                    catch (PythonException ex)
                    {
                        form.AppendLog(ex.ToString());
                    }
                }
            };
        }

        public void AddItem(string text)
        {
            Invoke(() => ((ComboBox)Control).Items.Add(text));
        }

        public int GetIndex()
        {
            return ((ComboBox)Control).SelectedIndex;
        }

        public void SetIndex(int index)
        {
            Invoke(() => ((ComboBox)Control).SelectedIndex = index);
        }
    }
}
