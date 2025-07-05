using ReactiveUI;
using RSBot.Core.Extensions;
using RSBot.Core.Objects;
using RSBot.Core.UI;
using System.Collections.ObjectModel;

namespace RSBot.Default.Views.Models;

public class MainViewModel : ReactiveObject
{
    public ObservableCollection<TreeViewGroup> Groups { get; }

    public MainViewModel()
    {
        Groups = new();

        var allGroup = new TreeViewGroup("all");
        var avoidGroup = new TreeViewGroup("avoid");
        var preferGroup = new TreeViewGroup("prefer");
        var berserkGroup = new TreeViewGroup("berserk");

        foreach (MonsterRarity rarity in Enum.GetValues(typeof(MonsterRarity)))
            allGroup.Children.Add(new TreeViewItem { Parent = allGroup, Name = rarity.GetName(), Tag = rarity });

        Groups.Add(avoidGroup);
        Groups.Add(preferGroup);
        Groups.Add(berserkGroup);
        Groups.Add(allGroup);
    }
}