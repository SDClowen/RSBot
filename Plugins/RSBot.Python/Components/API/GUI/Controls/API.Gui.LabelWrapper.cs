using RSBot.Python.Components.API.GUI.Wrapper;
using RSBot.Python.Views;
using System.Windows.Forms;

namespace RSBot.Python.Components.API.GUI.Controls
{
    public class LabelWrapper : GuiControlWrapper
    {
        public LabelWrapper(Label lbl, Main form)
            : base(lbl, form)
        {
        }
    }
}
