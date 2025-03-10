using Avalonia.Controls;
using ReactiveUI;
using RSBot.Core;
using System.Reactive;
using System.Text;
using System.Windows.Input;

namespace RSBot.ViewModels.Dialog
{
    /// <summary>
    /// ViewModel for proxy configuration dialog
    /// </summary>
    public class ConfigDialogViewModel : ReactiveObject
    {
        #region Private Fields

        private Window _window;
        private bool _isActive;
        private string _proxyIp = string.Empty;
        private string _proxyPort = "0";
        private string _username = string.Empty;
        private string _password = string.Empty;
        private int _selectedProxyVersionIndex;

        #endregion Private Fields

        #region Constructor

        public ConfigDialogViewModel(Window window)
        {
            LoadConfig();

            _window = window;
            SaveCommand = ReactiveCommand.Create(ExecuteSave);
            CancelCommand = ReactiveCommand.Create(ExecuteCancel);

            this.WhenAnyValue(x => x.ProxyIp, x => x.ProxyPort)
                .Subscribe(_ => ValidateInput());
        }

        #endregion Constructor

        #region Properties

        public bool IsActive
        {
            get => _isActive;
            set => this.RaiseAndSetIfChanged(ref _isActive, value);
        }

        public string ProxyIp
        {
            get => _proxyIp;
            set => this.RaiseAndSetIfChanged(ref _proxyIp, value);
        }

        public string ProxyPort
        {
            get => _proxyPort;
            set => this.RaiseAndSetIfChanged(ref _proxyPort, value);
        }

        public string Username
        {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public int SelectedProxyVersionIndex
        {
            get => _selectedProxyVersionIndex;
            set => this.RaiseAndSetIfChanged(ref _selectedProxyVersionIndex, value);
        }

        public bool CanSave { get; private set; }

        #endregion Properties

        #region Commands

        public ReactiveCommand<Unit, Unit> SaveCommand { get; }
        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        #endregion Commands

        #region Private Methods

        private void LoadConfig()
        {
            var values = GlobalConfig.GetArray<string>("RSBot.Network.Proxy", '|', StringSplitOptions.TrimEntries);
            if (values.Length != 6)
                return;

            try
            {
                bool.TryParse(values[0], out var isActive);
                IsActive = isActive;
                ProxyIp = values[1];

                if (int.TryParse(values[2], out var proxyPort))
                    ProxyPort = proxyPort.ToString();

                Username = values[3];
                Password = values[4];

                if (byte.TryParse(values[5], out var version))
                    SelectedProxyVersionIndex = version == 4 ? 0 : 1;
            }
            catch
            {
                // Ignore parsing errors and keep default values
            }
        }

        private void ValidateInput()
        {
            CanSave = !string.IsNullOrWhiteSpace(ProxyIp) && ProxyPort != "0";
            this.RaisePropertyChanged(nameof(CanSave));
        }

        private void ExecuteSave()
        {
            if (!CanSave) return;

            StringBuilder builder = new();
            builder.AppendFormat("{0}|", IsActive);
            builder.AppendFormat("{0}|", ProxyIp);
            builder.AppendFormat("{0}|", ProxyPort);
            builder.AppendFormat("{0}|", Username);
            builder.AppendFormat("{0}|", Password);
            builder.AppendFormat("{0}", SelectedProxyVersionIndex == 0 ? 4 : 5);

            GlobalConfig.Set("RSBot.Network.Proxy", builder.ToString());
            GlobalConfig.Save();
            
            _window.Close();
        }

        private void ExecuteCancel()
        {
            _window?.Close();
        }

        #endregion Private Methods
    }
}