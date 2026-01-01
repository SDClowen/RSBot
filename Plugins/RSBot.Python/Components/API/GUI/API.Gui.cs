using Python.Runtime;
using RSBot.Python.Components.API.GUI.Controls;
using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSBot.Python.Components.API.GUI
{
    public class WFAPI : IPythonPlugin
    {
        private Main _form;
        public Main Form => _form;

        public string ModuleName => "gui";

        private readonly Dictionary<string, TabPage> _pluginPages = new();

        private readonly List<GuiControlWrapper> _activeControls = new();

        public void Init(Main form)
        {
            _form = form;
        }

        #region GUI WRAPPER SYSTEM
        public class GUI
        {
            private readonly WFAPI _api;
            public string PluginName { get; }

            public GUI(string pluginName)
            {
                PluginName = pluginName;
                _api = ModuleLoader.ModuleLoader.Get("gui") as WFAPI;

                _api.CreatePage(pluginName);
            }

            public LabelWrapper Label(string text, int x, int y, int? width = null, int? height = null)
            {
                var lbl = _api.CreateLabel(PluginName, x, y, text, width, height);
                var wrapper = new LabelWrapper(lbl, _api.Form);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }

            public ButtonWrapper Button(string text, int x, int y, int? width = null, int? height = null, PyObject handler = null)
            {
                var btn = _api.CreateButton(PluginName, x, y, text, width, height);
                var wrapper = new ButtonWrapper(btn, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
            public CheckBoxWrapper CheckBox(string text, int x, int y, int? width = null, int? height = null, PyObject handler = null)
            {
                var cb = _api.CreateCheckBox(PluginName, x, y, text, width, height);
                var wrapper = new CheckBoxWrapper(cb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
            public TextBoxWrapper TextBox(string text, int x, int y, int? width = null, int? height = null, PyObject handler = null)
            {
                var tb = _api.CreateTextBox(PluginName, x, y, text, width, height);
                var wrapper = new TextBoxWrapper(tb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
            public ComboBoxWrapper ComboBox(string text, int x, int y, int? width = null, int? height = null, PyObject handler = null)
            {
                var cb = _api.CreateComboBox(PluginName, x, y, text, width, height);
                var wrapper = new ComboBoxWrapper(cb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
            public ListBoxWrapper ListBox(string text,int x, int y, int? width = null, int? height = null, PyObject handler = null)
            {
                var lb = _api.CreateListBox(PluginName, x, y,text, width, height);
                var wrapper = new ListBoxWrapper(lb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
            public RadioButtonWrapper RadioButton(string text, int x, int y, int? width = null, int? height = null, PyObject handler = null)
            {
                var rb = _api.CreateRadioButton(PluginName, x, y, text, width, height);
                var wrapper = new RadioButtonWrapper(rb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
        }
        #endregion
        #region Controls

        private void AddControl(string pluginName, Control c)
        {
            if (_pluginPages.TryGetValue(pluginName, out var page))
            {
                _form.Invoke(new Action(() => page.Controls.Add(c)));
            }
        }

        private void CreatePage(string pluginName)
        {
            if (_form == null) return;

            _form.Invoke(new Action(() =>
            {
                if (!_pluginPages.ContainsKey(pluginName))
                {
                    var page = new TabPage
                    {
                        Name = pluginName,
                        Text = pluginName,
                        AutoScroll = true
                    };

                    _pluginPages[pluginName] = page;
                    _form.tcPlugin.TabPages.Add(page);
                }
            }));
        }

        private SDUI.Controls.Label CreateLabel(string pluginName, int x, int y, string text, int? width = null, int? height = null)
        {
            var lbl = new SDUI.Controls.Label();
            lbl.Text = text;
            lbl.Left = x;
            lbl.Top = y;
            lbl.AutoSize = true;
            if (width.HasValue) lbl.Width = width.Value;
            if (height.HasValue) lbl.Height = height.Value;

            AddControl(pluginName, lbl);
            return lbl;
        }

        private SDUI.Controls.Button CreateButton(string pluginName, int x, int y, string text, int? width = null, int? height = null)
        {
            var btn = new SDUI.Controls.Button();
            btn.Text = text;
            btn.Left = x;
            btn.Top = y;
            btn.AutoSize = true;
            if (width.HasValue)
            {
                btn.Width = width.Value;                
            }
            if (height.HasValue)
            {
                btn.Height = height.Value;
            }
            AddControl(pluginName, btn);
            return btn;
        }

        private SDUI.Controls.CheckBox CreateCheckBox(string pluginName, int x, int y, string text, int? width = null, int? height = null)
        {
            var cb = new SDUI.Controls.CheckBox();
            cb.Text = text;
            cb.Left = x;
            cb.Top = y;
            cb.AutoSize = true;
            if (width.HasValue) cb.Width = width.Value;
            if (height.HasValue) cb.Height = height.Value;
            AddControl(pluginName, cb);
            return cb;
        }

        private SDUI.Controls.TextBox CreateTextBox(string pluginName, int x, int y, string defaultText,int? width = null,int? height = null)
        {
            var tb = new SDUI.Controls.TextBox();
            tb.Text = defaultText;
            tb.Left = x;
            tb.Top = y;
            tb.Width = width ?? 150;
            if (height.HasValue)
            {
                tb.Height = height.Value;
            }

            AddControl(pluginName, tb);
            return tb;
        }

        private SDUI.Controls.ComboBox CreateComboBox(string pluginName, int x, int y, string? text = null, int? width = null, int? height = null)
        {
            var cb = new SDUI.Controls.ComboBox();
            cb.Text = text;
            cb.Left = x;
            cb.Top = y;
            cb.Width = 150;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            if (height.HasValue) cb.Height= height.Value;
            if (width.HasValue) cb.Width = width.Value;

            AddControl(pluginName, cb);
            return cb;
        }
        private ListBox CreateListBox(string pluginName, int x, int y, string? text = null, int? width = null, int? height = null)
        {
            ListBox lb = new ListBox
            {
                Left = x,
                Top = y,
                Width = 150,
                Text = text,
            };
            if (height.HasValue) lb.Height = height.Value;
            if (width.HasValue) lb.Width = width.Value;

            AddControl(pluginName, lb);
            return lb;
        }
        private SDUI.Controls.Radio CreateRadioButton(string pluginName, int x, int y, string text, int? width = null, int? height = null)
        {
            var rb = new SDUI.Controls.Radio();
            rb.Text = text;
            rb.Left = x;
            rb.Top = y;
            rb.AutoSize = true;
            if (width.HasValue) rb.Width = width.Value;
            if (height.HasValue) rb.Height = height.Value;
            AddControl(pluginName, rb);
            return rb;
        }
        #endregion
        #region Reset
        public void ResetPlugin(string pluginName)
        {
            if (_form == null) return;

            _form.Invoke(new Action(() =>
            {
                if (_pluginPages.TryGetValue(pluginName, out var page))
                {
                    foreach (Control c in page.Controls)
                        c.Dispose();

                    page.Controls.Clear();

                    if (_form.tcPlugin.TabPages.Contains(page))
                        _form.tcPlugin.TabPages.Remove(page);

                    page.Dispose();
                }

                _pluginPages.Remove(pluginName);
            }));

            _form.tcPlugin.Refresh();
        }

        public void ClearAllControls()
        {
            if (_form == null) return;

            _form.Invoke(new Action(() =>
            {
                foreach (var page in _pluginPages.Values)
                    page.Controls.Clear();
            }));

            _activeControls.Clear();
        }

        public void ClearAllPagesExceptFirst()
        {
            if (_form == null) return;

            _form.Invoke(new Action(() =>
            {
                while (_form.tcPlugin.TabPages.Count > 1)
                    _form.tcPlugin.TabPages.RemoveAt(1);
            }));

            _pluginPages.Clear();
        }

        public void ResetPython()
        {
            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");

                if (sys.modules.__contains__("rsbot"))
                    sys.modules.pop("rsbot", null);

                dynamic listFunc = Py.Import("list");
                dynamic modulesList = listFunc.Invoke(sys.modules.keys());

                foreach (PyObject keyObj in modulesList)
                {
                    string moduleName = keyObj.ToString();

                    if (moduleName.StartsWith("plugin_"))
                        sys.modules.pop(moduleName, null);
                }

                dynamic gc = Py.Import("gc");
                gc.collect();
            }
        }

        public void ResetAll()
        {
            ClearAllControls();
            ClearAllPagesExceptFirst();
        }
        #endregion
    }
}
