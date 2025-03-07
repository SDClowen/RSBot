using ReactiveUI;
using RSBot.Core;
using RSBot.Core.Event;
using System;
using System.IO;
using System.Reactive;
using System.Threading;

namespace RSBot.Log.ViewModels;

/// <summary>
/// View model for the main log view that handles log operations and filtering
/// </summary>
public class MainViewModel : ReactiveObject
{
    private SemaphoreSlim _fileLock = new(1, 1);
    private bool _isEnabled;
    private bool _showNormal;
    private bool _showDebug;
    private bool _showWarning;
    private bool _showError;
    private string _logText;

    public MainViewModel()
    {
        LoadConfig();
        SubscribeEvents();

        ClearCommand = ReactiveCommand.Create(ExecuteClear);

        if (!Kernel.Debug)
        {
            ShowDebug = false;
            ShowError = false;
            ShowNormal = false;
            ShowWarning = false;
        }
    }

    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            this.RaiseAndSetIfChanged(ref _isEnabled, value);
            GlobalConfig.Set("RSBot.Log.logEnabled", value.ToString());
        }
    }

    public bool ShowNormal
    {
        get => _showNormal;
        set => this.RaiseAndSetIfChanged(ref _showNormal, value);
    }

    public bool ShowDebug
    {
        get => _showDebug;
        set => this.RaiseAndSetIfChanged(ref _showDebug, value);
    }

    public bool ShowWarning
    {
        get => _showWarning;
        set => this.RaiseAndSetIfChanged(ref _showWarning, value);
    }

    public bool ShowError
    {
        get => _showError;
        set => this.RaiseAndSetIfChanged(ref _showError, value);
    }

    public string LogText
    {
        get => _logText;
        set => this.RaiseAndSetIfChanged(ref _logText, value);
    }

    public ReactiveCommand<Unit, Unit> ClearCommand { get; }

    private void LoadConfig()
    {
        IsEnabled = GlobalConfig.Get("RSBot.Log.logEnabled", true);
        ShowNormal = true;
        ShowDebug = true;
        ShowWarning = true;
        ShowError = true;
    }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnAddLog", new Action<string, LogLevel>(AppendLog));
    }

    public async void AppendLog(string message, LogLevel level = LogLevel.Notify)
    {
        if (!IsEnabled)
            return;

        if (level == LogLevel.Debug && !ShowDebug)
            return;

        if (level == LogLevel.Error && !ShowError)
            return;

        if (level == LogLevel.Notify && !ShowNormal)
            return;

        if (level == LogLevel.Warning && !ShowWarning)
            return;

        message = $"<{level}> \t{message}";

        if (!string.IsNullOrEmpty(LogText))
            LogText += Environment.NewLine;

        LogText += message;

        if (Kernel.Debug)
        {
            try
            {
                await _fileLock.WaitAsync();

                var filePath = Path.Combine(Kernel.BasePath, "User", "Logs",
                Game.Player == null ? "Environment" : Game.Player.Name, $"{DateTime.Now:dd-MM-yyyy}.txt");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                await File.AppendAllTextAsync(filePath, message);
            }
            catch (Exception)
            {

            }
            finally
            {
                _fileLock.Release();
            }
        }
    }

    private void ExecuteClear()
    {
        LogText = string.Empty;
    }
} 