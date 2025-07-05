using System.Collections.ObjectModel;

namespace RSBot.Core.UI;
public struct TreeViewGroup
{
    public string Header { get; set; }
    public ObservableCollection<object> Children { get; set; } = [];

    public TreeViewGroup(string header)
    {
        Header = header;
    }
}