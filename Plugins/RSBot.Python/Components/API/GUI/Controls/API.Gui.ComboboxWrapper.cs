using Python.Runtime;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;
using SDUI.Controls;

namespace RSBot.Python.Components.API.GUI.Controls
{
    public class ComboBoxWrapper : GuiControlWrapper
    {
        private PyObject _callback;

        public ComboBoxWrapper(ComboBox cb, Main form, PyObject callback = null)
            : base(cb, form)
        {
            _callback = callback;
            if (_callback != null)
            {

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
        }

        private void AddItem(string text)
        {
            Invoke(() => ((ComboBox)Control).Items.Add(text));
        }

        private int GetIndex()
        {
            return ((ComboBox)Control).SelectedIndex;
        }

        private void SetIndex(int index)
        {
            Invoke(() => ((ComboBox)Control).SelectedIndex = index);
        }
        private void RemoveItem(int index)
        {
            Invoke(() => ((ComboBox)Control).Items.RemoveAt(index));
        }
        private int GetItemCount()
        {
            return ((ComboBox)Control).Items.Count;
        }
        private string GetItem(int index)
        {
            return ((ComboBox)Control).Items[index].ToString();
        }
        private string GetSelectedItem()
        {
            return ((ComboBox)Control).SelectedItem.ToString();
        }

        public void add_item(string text)
        {
            AddItem(text);
        }
        public int selected_index()
        {
            return GetIndex();
        }
        public void set_index(int index)
        {
            SetIndex(index);
        }
        public void remove_item(int index)
        {
            RemoveItem(index);
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
