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
        // Initialize with some default areas if needed
        Areas.Add(new Area("Default Area", new Position(0, 0, new Region(25000)), 100));
    }
}
