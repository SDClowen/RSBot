using System;
using System.Windows.Forms;
using Python.Runtime;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;

namespace RSBot.Python.Components.API.GUI.Controls
{
    public class ListBoxWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public ListBoxWrapper(ListBox lb, Main form, PyObject callback = null)
            : base(lb, form)
        {
            _callback = callback;

            if (_callback != null)
            {
                lb.SelectedIndexChanged += (sender, args) =>
                {
                    using (Py.GIL())
                    {
                        try
                        {
                            _callback.Invoke(new PyInt(lb.SelectedIndex));
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
            return ((ListBox)Control).Text;
        }

        private void AddItem(string text)
        {
            Invoke(() => ((ListBox)Control).Items.Add(text));
        }
        private void SetIndex(int index)
        {
            Invoke(() => ((ListBox)Control).SelectedIndex = index);
        }
        private void RemoveItem(int index)
        {
            Invoke(() => ((ListBox)Control).Items.RemoveAt(index));
        }
        private int GetIndex()
        {
            return ((ListBox)Control).SelectedIndex;
        }
        private int GetItemCount()
        {
            return ((ListBox)Control).Items.Count;
        }
        private string GetItem(int index)
        {
            return ((ListBox)Control).Items[index].ToString();
        }
        private string GetSelectedItem()
        {
            return ((ListBox)Control).SelectedItem.ToString();
        }
        public string get_text()
        {
            return GetText();
        }
        public void add_item(string text)
        {
            AddItem(text);
        }
        public void set_index(int index)
        {
            SetIndex(index);
        }
        public void remove_item(int index)
        {
            RemoveItem(index);
        }
        public int selected_index()
        {
            return GetIndex();
        }
        public int item_count()
        {
            return GetItemCount();
        }
        public string get_item(int index)
        {
            return GetItem(index);
        }
        public string get_selected_item()
        {
            return GetSelectedItem();
        }
    }
}
