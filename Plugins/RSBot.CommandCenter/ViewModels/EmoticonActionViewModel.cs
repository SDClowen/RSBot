using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RSBot.CommandCenter.Components;

namespace RSBot.CommandCenter.ViewModels
{
    /// <summary>
    /// ViewModel for managing emoticon actions, handling the binding between emoticons and their associated commands
    /// </summary>
    public class EmoticonActionViewModel : INotifyPropertyChanged
    {
        private readonly EmoticonItem _emoticonItem;
        private string _selectedCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EmoticonName => _emoticonItem.Name;
        public IEnumerable<string> AvailableCommands { get; }

        public string SelectedCommand
        {
            get => _selectedCommand;
            set
            {
                if (_selectedCommand == value) return;
                _selectedCommand = value;
                OnPropertyChanged();
            }
        }

        public EmoticonActionViewModel(EmoticonItem emoticonItem, IEnumerable<string> availableCommands, string selectedCommand)
        {
            _emoticonItem = emoticonItem;
            AvailableCommands = availableCommands;
            _selectedCommand = selectedCommand;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 