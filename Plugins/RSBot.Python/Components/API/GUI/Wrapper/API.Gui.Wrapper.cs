using RSBot.Python.Views;
using System;
using System.Windows.Forms;

namespace RSBot.Python.Components.API.GUI.Wrapper
{
    public abstract class GuiControlWrapper
    {
        protected Control Control { get; }
        protected Main Form { get; }

        protected GuiControlWrapper(Control control, Main form)
        {
            Control = control;
            Form = form;
        }

        protected void Invoke(Action action)
        {
            if (Form.InvokeRequired)
                Form.Invoke(action);
            else
                action();
        }

        private void SetVisible(bool visible)
        {
            Invoke(() => Control.Visible = visible);
        }

        private void SetText(string text)
        {
            Invoke(() => Control.Text = text);
        }

        private void SetEnabled(bool enabled)
        {
            Invoke(() => Control.Enabled = enabled);
        }
        private void Move(int x, int y)
        {
            Invoke(() => Control.Location = new System.Drawing.Point(x, y));
        }

        public void set_visible(bool visible)
        {
            SetVisible(visible);
        }
        public void set_text(string text)
        {
            SetText(text);
        }
        public void set_enabled(bool enabled)
        {
            SetEnabled(enabled);
        }
        public void move_position(int x, int y)
        {
            Move(x, y);
        }
    }
}
