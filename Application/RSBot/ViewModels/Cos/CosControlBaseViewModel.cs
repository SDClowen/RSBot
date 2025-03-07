using ReactiveUI;

namespace RSBot.ViewModels.Cos;

/// <summary>
/// Base view model for COS (Companion System) controls
/// </summary>
public class CosControlBaseViewModel : ReactiveObject
{
    protected MiniCosControlViewModel _miniCosControl;
    private string _petName = "No pet found";
    private string _level = "Lv. 1";
    private int _healthMaximum;
    private int _health;

    public string PetName
    {
        get => _petName;
        set
        {
            this.RaiseAndSetIfChanged(ref _petName, value);
            _miniCosControl.Name = value;
        }
    }

    public string Level
    {
        get => _level;
        set
        {
            this.RaiseAndSetIfChanged(ref _level, value);
            _miniCosControl.Level = value;
        }
    }

    public int HealthMaximum
    {
        get => _healthMaximum;
        set
        {
            this.RaiseAndSetIfChanged(ref _healthMaximum, value);
            _miniCosControl.HealthMaximum = value;
        }
    }

    public int Health
    {
        get => _health;
        set
        {
            this.RaiseAndSetIfChanged(ref _health, value);
            _miniCosControl.Health = value;
        }
    }

    public CosControlBaseViewModel(MiniCosControlViewModel miniCosControlModel)
    {
        _miniCosControl = miniCosControlModel;
    }

    public virtual void Initialize()
    {
    }

    public virtual void Reset()
    {
        Health = 0;
        HealthMaximum = 0;
        PetName = "No pet found";
        Level = "Lv. 1";

        _miniCosControl.Reset();
    }
} 