namespace RSBot.NavMeshApi;

public class ObjectIndexEntry
{
    public int Flag { get; set; }
    public string Path { get; set; }

    public ObjectIndexEntry(int flag, string path)
    {
        this.Flag = flag;
        this.Path = path;
    }
}
