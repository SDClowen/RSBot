using Python.Runtime;
using RSBot.Python.API;
using RSBot.Python.API.GUI.Controls;
using RSBot.Python.API.ModuleLoader;
using RSBot.Python.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RSBot.Python.API.GUI
{
    public class WFAPI : IPythonPlugin
    {
        private Main _form;                    // <-- Form1 ersetzt durch Main
        public Main Form => _form;

        public string ModuleName => "gui";

        // Alle Plugin-Seiten
        private readonly Dictionary<string, TabPage> _pluginPages = new();

        // Alle erzeugten Wrapper (für Reset)
        private readonly List<GuiControlWrapper> _activeControls = new();

        public void Init(Main form)
        {
            _form = form;
        }

        // ---------------------------------------------------------
        // GUI WRAPPER SYSTEM
        // ---------------------------------------------------------
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

            public LabelWrapper Label(string text, int x, int y)
            {
                var lbl = _api.CreateLabel(PluginName, x, y, text);
                var wrapper = new LabelWrapper(lbl, _api.Form);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }

            public ButtonWrapper Button(string text, int x, int y, PyObject handler)
            {
                var btn = _api.CreateButton(PluginName, x, y, text);
                var wrapper = new ButtonWrapper(btn, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }

            public CheckBoxWrapper CheckBox(string text, int x, int y, PyObject handler)
            {
                var cb = _api.CreateCheckBox(PluginName, x, y, text);
                var wrapper = new CheckBoxWrapper(cb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }

            public TextBoxWrapper TextBox(string defaultText, int x, int y, PyObject handler)
            {
                var tb = _api.CreateTextBox(PluginName, x, y, defaultText);
                var wrapper = new TextBoxWrapper(tb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }

            public ComboBoxWrapper ComboBox(int x, int y, PyObject handler)
            {
                var cb = _api.CreateComboBox(PluginName, x, y);
                var wrapper = new ComboBoxWrapper(cb, _api.Form, handler);
                _api._activeControls.Add(wrapper);
                return wrapper;
            }
        }

        // ---------------------------------------------------------
        //   CREATE CONTROLS
        // ---------------------------------------------------------

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

        private Label CreateLabel(string pluginName, int x, int y, string text)
        {
            Label lbl = new Label { Text = text, Left = x, Top = y, AutoSize = true };
            AddControl(pluginName, lbl);
            return lbl;
        }

        private Button CreateButton(string pluginName, int x, int y, string text)
        {
            Button btn = new Button { Text = text, Left = x, Top = y, AutoSize = true };
            AddControl(pluginName, btn);
            return btn;
        }

        private CheckBox CreateCheckBox(string pluginName, int x, int y, string text)
        {
            CheckBox cb = new CheckBox { Text = text, Left = x, Top = y, AutoSize = true };
            AddControl(pluginName, cb);
            return cb;
        }

        private TextBox CreateTextBox(string pluginName, int x, int y, string defaultText)
        {
            TextBox tb = new TextBox
            {
                Text = defaultText,
                Left = x,
                Top = y,
                Width = 150
            };

            AddControl(pluginName, tb);
            return tb;
        }

        private ComboBox CreateComboBox(string pluginName, int x, int y)
        {
            ComboBox cb = new ComboBox
            {
                Left = x,
                Top = y,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            AddControl(pluginName, cb);
            return cb;
        }


        // ---------------------------------------------------------
        // RESET SYSTEM
        // ---------------------------------------------------------

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

                // pycross löschen, wenn vorhanden
                if (sys.modules.__contains__("rsbot"))
                    sys.modules.pop("rsbot", null);

                // Alle Plugin-Module entfernen
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
            //ResetPython();
        }
    }
}
