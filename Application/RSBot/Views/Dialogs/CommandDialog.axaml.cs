using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using RSBot.Core.Components;
using RSBot.Core.Components.Scripting;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSBot.Views.Dialogs
{
    /// <summary>
    /// Dialog window for configuring script commands with their arguments
    /// </summary>
    public partial class CommandDialog : Window
    {
        #region Members

        private readonly IScriptCommand _command;
        private readonly Dictionary<string, TextBox> _argumentInputs;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the CommandDialog class
        /// </summary>
        /// <param name="command">The script command to configure</param>
        public CommandDialog(IScriptCommand command)
        {
            _command = command;
            _argumentInputs = new Dictionary<string, TextBox>();
            Arguments = new Dictionary<string, string>(command.Arguments.Count);

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            Title = $"Add command: {command.Name}";

            var argumentsPanel = this.FindControl<StackPanel>("ArgumentsPanel");
            foreach (var arg in command.Arguments)
            {
                var panel = new Border
                {
                    Height = 85,
                };

                var stackPanel = new StackPanel
                {
                    Margin = new Thickness(13, 2, 13, 2)
                };

                var labelKey = new TextBlock
                {
                    Text = arg.Key,
                    Background = Brushes.Transparent
                };

                var input = new TextBox
                {
                    Width = 200,
                    Name = arg.Key,
                    Margin = new Thickness(0, 5, 0, 5)
                };

                input.GetObservable(TextBox.TextProperty)
                    .Subscribe(text => OnInputTextChanged(input.Name, text));

                _argumentInputs[arg.Key] = input;

                var labelValue = new TextBlock
                {
                    Text = arg.Value,
                    Width = 250
                };

                stackPanel.Children.Add(labelKey);
                stackPanel.Children.Add(input);
                stackPanel.Children.Add(labelValue);

                panel.Child = stackPanel;
                argumentsPanel.Children.Add(panel);
            }

            var height = 85 + (command.Arguments.Count == 1 ? 85 : 85 * command.Arguments.Count);
            Height = height;

            var btnAdd = this.FindControl<Button>("btnAdd");
            var btnCancel = this.FindControl<Button>("btnCancel");

            btnAdd.Click += (s, e) => Close(true);
            btnCancel.Click += (s, e) => Close(false);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the dictionary of argument names and their values
        /// </summary>
        public Dictionary<string, string> Arguments { get; }

        /// <summary>
        /// Gets the complete command text with arguments
        /// </summary>
        public string CommandText => Arguments.Aggregate(_command.Name,
            (current, arg) => current + ScriptManager.ArgumentSeparator + arg.Value);

        #endregion Properties

        #region Methods

        private void OnInputTextChanged(string name, string text)
        {
            Arguments[name] = text;
        }

        #endregion Methods
    }
}