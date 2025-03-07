using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Core;
using RSBot.Core.Components.Scripting;
using RSBot.Core.Event;
using RSBot.ViewModels;
using RSBot.Views.Dialog;

namespace RSBot.Views
{
    /// <summary>
    /// Interaction logic for ScriptRecorder window
    /// </summary>
    public partial class ScriptRecorder : Window
    {
        private readonly TextBox _scriptTextBox;

        /// <summary>
        /// Initializes a new instance of the ScriptRecorder class
        /// </summary>
        public ScriptRecorder(int ownerId = 0, bool startRecording = false)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new ScriptRecorderViewModel(ownerId, startRecording);
            
            _scriptTextBox = this.FindControl<TextBox>("ScriptText");
            
            this.Loaded += (s, e) => LanguageManager.Translate(this, Kernel.Language);
            EventManager.SubscribeEvent("ShowCommandDialog", new System.Action<IScriptCommand>(ShowCommandDialog));
            EventManager.SubscribeEvent("HighlightScriptLine", new System.Action<int, IBrush>(HighlightLine));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ShowCommandDialog(IScriptCommand command)
        {
            var dialog = new CommandDialog(command);
            if (dialog.ShowDialog(this) == true)
            {
                var viewModel = (ScriptRecorderViewModel)DataContext;
                viewModel.AppendScriptCommand(dialog.CommandText);
            }
        }

        private void HighlightLine(int lineNumber, IBrush brush)
        {
            // Implementation of line highlighting in Avalonia
            // This would require custom TextBox styling and selection handling
            // For now, we'll leave it as a TODO
        }
    }
} 