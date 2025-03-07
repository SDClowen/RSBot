using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RSBot.Core.Network;
using RSBot.General.ViewModels;

namespace RSBot.General.Views;

/// <summary>
/// Window for displaying queue status and logs while waiting in the server queue
/// </summary>
public partial class PendingWindow : Window
{
    private PendingWindowViewModel ViewModel => (PendingWindowViewModel)DataContext;

    public PendingWindow()
    {
        InitializeComponent();
        DataContext = new PendingWindowViewModel(this);
    }

    public void ShowAtTop()
    {
        if(Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime owner)
        {
            Owner = owner.MainWindow;
            var point = new PixelPoint(
                owner.MainWindow.Position.X + (int)(owner.MainWindow.Width / 2 - Width / 2),
                owner.MainWindow.Position.Y
            );
            Position = point;
            Show();
        }
    }

    public void Start(int count, int timestamp)
    {
        ViewModel.Start(count, timestamp);
    }

    public void Update(Packet packet)
    {
        ViewModel.Update(packet);
    }
} 