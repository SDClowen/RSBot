using Avalonia.Media;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// View model for the mini COS control that displays a small preview with health bar
/// </summary>
public class MiniCosControlViewModel : ReactiveObject
{
    private readonly IBrush activedColor = new SolidColorBrush(Color.FromArgb(135, 70, 70, 70));

    private bool _selected;
    private string _name;
    private string _level;
    private IBrush _borderColor = Brushes.Transparent;
    private IImage _imageSource;
    private int _healthMaximum;
    private int _health;
    private bool _hgpVisible = true;
    private int _hgp;
    private int _hgpMaximum;
    private bool _satietyVisible = true;
    private int _satiety;
    private int _satietyMaximum;

    public MiniCosControlViewModel()
    {
        HgpVisible = true;
        _satietyVisible = true;
        _name = "Unknown";
        _level = "lv.1";

        var stream = Avalonia.Platform.AssetLoader.Open(new Uri("avares://RSBot/Assets/app.png"));
        _imageSource = new Bitmap(stream);

    }

    public bool Selected
    {
        get => _selected;
        set
        {
            this.RaiseAndSetIfChanged(ref _selected, value);
            BorderColor = value ? activedColor : Brushes.Transparent;
            this.RaisePropertyChanged(nameof(IsSelected));
        }
    }

    public bool IsSelected => Selected;

    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }

    public string Level
    {
        get => _level;
        set => this.RaiseAndSetIfChanged(ref _level, value);
    }

    public IBrush BorderColor
    {
        get => _borderColor;
        private set => this.RaiseAndSetIfChanged(ref _borderColor, value);
    }

    public IImage ImageSource
    {
        get => _imageSource;
        set => this.RaiseAndSetIfChanged(ref _imageSource, value);
    }

    public int HealthMaximum
    {
        get => _healthMaximum;
        set => this.RaiseAndSetIfChanged(ref _healthMaximum, value);
    }

    public int Health
    {
        get => _health;
        set => this.RaiseAndSetIfChanged(ref _health, value);
    }

    public bool HgpVisible
    {
        get => _hgpVisible;
        set => this.RaiseAndSetIfChanged(ref _hgpVisible, value);
    }

    public int HgpMaximum
    {
        get => _hgpMaximum;
        set => this.RaiseAndSetIfChanged(ref _hgpMaximum, value);
    }

    public int Hgp
    {
        get => _hgp;
        set => this.RaiseAndSetIfChanged(ref _hgp, value);
    }

    public bool SatietyVisible
    {
        get => _satietyVisible;
        set => this.RaiseAndSetIfChanged(ref _satietyVisible, value);
    }

    public int SatietyMaximum
    {
        get => _satietyMaximum;
        set => this.RaiseAndSetIfChanged(ref _satietyMaximum, value);
    }

    public int Satiety
    {
        get => _satiety;
        set => this.RaiseAndSetIfChanged(ref _satiety, value);
    }

    public void Reset()
    {
        Selected = false;
        Health = 0;
        HealthMaximum = 0;
        ImageSource = new Bitmap("avares://RSBot/Assets/app.png");
    }
}
