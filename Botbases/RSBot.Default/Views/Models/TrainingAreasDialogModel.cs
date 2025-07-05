using ReactiveUI;
using RSBot.Core.Objects;
using System.Collections.ObjectModel;

namespace RSBot.Default.Views.Models;

public class TrainingAreasDialogModel : ReactiveObject
{
    public ObservableCollection<Area> Areas { get; }

    public TrainingAreasDialogModel()
    {
        Areas = new();
    }
}
