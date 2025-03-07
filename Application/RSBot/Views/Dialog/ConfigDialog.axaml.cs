using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.ViewModels.Dialog;

namespace RSBot.Views.Dialog
{
    /// <summary>
    /// Dialog window for configuring proxy settings in RSBot
    /// </summary>
    public partial class ConfigDialog : Window, ICloseable
    {
        /// <summary>
        /// Initializes a new instance of the ConfigDialog class
        /// </summary>
        public ConfigDialog()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new ConfigDialogViewModel();
            this.Loaded += (s, e) => LanguageManager.Translate(this, Kernel.Language);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
} 