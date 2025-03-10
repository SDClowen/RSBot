using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Components.Scripting;
using RSBot.Core.Event;
using RSBot.ViewModels;
using RSBot.Views.Dialogs;

namespace RSBot.Views
{
    /// <summary>
    /// Interaction logic for ScriptRecorder window
    /// </summary>
    public partial class ScriptRecorder : Window
    {
        private readonly TextBox _scriptTextBox;
        private readonly ScriptRecorderViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the ScriptRecorder class
        /// </summary>
        public ScriptRecorder(int ownerId = 0, bool startRecording = false)
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _viewModel = new ScriptRecorderViewModel(this, ownerId, startRecording);
            DataContext = _viewModel;
            
            _scriptTextBox = this.FindControl<TextBox>("ScriptText");
            
            this.Loaded += (s, e) => LanguageManager.Translate(this, Kernel.Language);
            EventManager.SubscribeEvent("ShowCommandDialog", new Action<IScriptCommand>(ShowCommandDialog));
            EventManager.SubscribeEvent("HighlightScriptLine", new Action<int, IBrush>(HighlightLine));

            this.Closing += (s, e) => 
            {
                if (_viewModel.IsRecording)
                    _viewModel.IsRecording = false;

                if (_viewModel.IsRunning)
                    ScriptManager.Stop();
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async void ShowCommandDialog(IScriptCommand command)
        {
            try
            {
                var dialog = new CommandDialog(command);
                var result = await dialog.ShowDialog<bool?>(this);
                
                if (result == true && !string.IsNullOrEmpty(dialog.CommandText))
                {
                    _viewModel.IsRecording = true;
                    _viewModel.AppendScriptCommand(dialog.CommandText);
                    _viewModel.IsRecording = false;
                }
            }
            catch (Exception ex)
            {
                Log.Debug($"Error showing command dialog: {ex.Message}");
            }
        }

        private void HighlightLine(int lineNumber, IBrush brush)
        {
            if (_scriptTextBox == null) return;

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                try
                {
                    var lines = _scriptTextBox.Text.Split('\n');
                    if (lineNumber < 0 || lineNumber >= lines.Length)
                        return;

                    var startIndex = 0;
                    for (int i = 0; i < lineNumber; i++)
                        startIndex += lines[i].Length + 1;

                    var length = lines[lineNumber].Length;

                    _scriptTextBox.SelectionStart = startIndex;
                    _scriptTextBox.SelectionEnd = startIndex + length;
                    // Note: In Avalonia, direct text highlighting might require custom TextBox implementation
                    // For now, we'll use selection to indicate the current line
                }
                catch
                {
                    // Ignore any text selection errors
                }
            });
        }
    }
} 