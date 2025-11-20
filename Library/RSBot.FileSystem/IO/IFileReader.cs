namespace RSBot.FileSystem.IO;

public interface IFileReader : IDisposable
{
    public byte[] ReadAllBytes();
    public byte[] Read(int offset, int length);
    public string ReadAllText();
    public string[] ReadAllLines();
    public Stream GetStream();
    public void Close();
}
