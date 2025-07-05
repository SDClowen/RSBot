namespace RSBot.Core.UI;

public struct TreeViewItem
{
    public TreeViewGroup Parent { get; set; }
    public string Name { get; set; }
    public object Tag { get; set; }
}
