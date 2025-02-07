using ReactiveUI;
using RSBot.Core.Event;
using RSBot.Views.Controls.Cos;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RSBot.ViewModels.Cos;

using CosAbility = RSBot.Core.Objects.Cos.Ability;
using CosBase = RSBot.Core.Objects.Cos.Cos;
using CosFellow = RSBot.Core.Objects.Cos.Fellow;
using CosGrowth = RSBot.Core.Objects.Cos.Growth;
using CosJobTransport = RSBot.Core.Objects.Cos.JobTransport;
using CosTransport = RSBot.Core.Objects.Cos.Transport;

/// <summary>
/// View model for managing COS (Companion System) controls and their visibility
/// </summary>
public class CosManagerViewModel : ReactiveObject
{
    private int _selectedIndex;
    private bool _navigationVisible;

    public CosManagerViewModel()
    {
        Controls = [];
        MiniControls = [];

        PreviousCommand = ReactiveCommand.Create(ExecutePrevious);
        NextCommand = ReactiveCommand.Create(ExecuteNext);

        SubscribeEvents();
    }

    public ObservableCollection<CosControlBase> Controls { get; }
    public ObservableCollection<MiniCosControl> MiniControls { get; }

    public bool NavigationVisible
    {
        get => _navigationVisible;
        private set => this.RaiseAndSetIfChanged(ref _navigationVisible, value);
    }

    public ICommand PreviousCommand { get; }
    public ICommand NextCommand { get; }

    private void SubscribeEvents()
    {
        EventManager.SubscribeEvent("OnSummonCos", new Action<CosBase>(OnSummonCos));
        EventManager.SubscribeEvent("OnTerminateCos", new Action<CosBase>(OnTerminateCos));
        EventManager.SubscribeEvent("OnAgentServerDisconnected", OnAgentServerDisconnected);


        TryAddControl<Growth>();
        TryAddControl<Ability>();
        TryAddControl<Fellow>();
        TryAddControl<Transport>();
        TryAddControl<JobTransport>();

    }

    private void OnAgentServerDisconnected()
    {
        Controls.Clear();
        MiniControls.Clear();
        _selectedIndex = 0;
        NavigationVisible = false;
    }

    private void OnSummonCos(CosBase obj)
    {
        switch (obj)
        {
            case CosGrowth:
                TryAddControl<Growth>();
                break;

            case CosAbility:
                TryAddControl<Ability>();
                break;

            case CosFellow:
                TryAddControl<Fellow>();
                break;

            case CosTransport:
                TryAddControl<Transport>();
                break;

            case CosJobTransport:
                TryAddControl<JobTransport>();
                break;
        }
    }

    private void OnTerminateCos(CosBase obj)
    {
        switch (obj)
        {
            case CosGrowth:
                TryRemoveControl<Growth>();
                break;

            case CosAbility:
                TryRemoveControl<Ability>();
                break;

            case CosFellow:
                TryRemoveControl<Fellow>();
                break;

            case CosTransport:
                TryRemoveControl<Transport>();
                break;

            case CosJobTransport:
                TryRemoveControl<JobTransport>();
                break;
        }
    }

    private void TryAddControl<T>() where T : CosControlBase, new()
    {
        var control = new T();
        control.Initialize();
        Controls.Add(control);

        var miniControl = control.MiniCosControl;
        miniControl.PointerPressed += (s, e) => SelectControl(Controls.IndexOf(control));
        MiniControls.Add(miniControl);

        ReOrder();
    }

    private void TryRemoveControl<T>() where T : CosControlBase
    {
        var control = Controls.FirstOrDefault(c => c is T);
        if (control == null)
            return;

        var index = Controls.IndexOf(control);
        Controls.RemoveAt(index);
        MiniControls.RemoveAt(index);

        control.Reset();

        _selectedIndex = Controls.Count - 1;
        ReOrder();
    }

    private void ReOrder()
    {
        NavigationVisible = Controls.Count > 0;
        if (!NavigationVisible)
        {
            _selectedIndex = 0;
            return;
        }

        for (var i = 0; i < Controls.Count; i++)
        {
            var control = Controls[i];
            control.IsVisible = i == _selectedIndex;
            (MiniControls[i].DataContext as MiniCosControlViewModel).Selected = control.IsVisible;
        }
    }

    private void ExecutePrevious()
    {
        if (_selectedIndex <= 0)
            return;

        _selectedIndex--;
        ReOrder();
    }

    private void ExecuteNext()
    {
        if (_selectedIndex >= Controls.Count - 1)
            return;

        _selectedIndex++;
        ReOrder();
    }

    private void SelectControl(int index)
    {
        if (_selectedIndex == index)
            return;

        _selectedIndex = index;
        ReOrder();
    }
} 