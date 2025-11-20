namespace RSBot.FileSystem.IO;

public interface IFileWriter
{
    public void Write(byte[] data);

    public void Write(byte[] data, int position);

    public Stream GetStream();
}
