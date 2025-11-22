using RSBot.Python.Views;
using System;
using System.Windows.Forms;

namespace RSBot.Python.API.GUI.Controls
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

        public void SetVisible(bool visible)
        {
            Invoke(() => Control.Visible = visible);
        }

        public void SetText(string text)
        {
            Invoke(() => Control.Text = text);
        }

        public void SetEnabled(bool enabled)
        {
            Invoke(() => Control.Enabled = enabled);
        }
        public void Move(int x, int y)
        {
            Invoke(() => Control.Location = new System.Drawing.Point(x, y));
        }
    }
}
