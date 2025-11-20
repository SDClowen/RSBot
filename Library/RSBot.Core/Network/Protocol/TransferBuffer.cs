namespace RSBot.Core.Network.Protocol;

public class TransferBuffer
{
    private byte[] m_buffer;
    private readonly object m_lock;
    private int m_offset;
    private int m_size;

    public TransferBuffer(TransferBuffer rhs)
    {
        lock (rhs.m_lock)
        {
            m_buffer = new byte[rhs.m_buffer.Length];
            System.Buffer.BlockCopy(rhs.m_buffer, 0, m_buffer, 0, m_buffer.Length);
            m_offset = rhs.m_offset;
            m_size = rhs.m_size;
            m_lock = new object();
        }
    }

    public TransferBuffer()
    {
        m_buffer = null;
        m_offset = 0;
        m_size = 0;
        m_lock = new object();
    }

    public TransferBuffer(int length, int offset, int size)
    {
        m_buffer = new byte[length];
        m_offset = offset;
        m_size = size;
        m_lock = new object();
    }

    public TransferBuffer(int length)
    {
        m_buffer = new byte[length];
        m_offset = 0;
        m_size = 0;
        m_lock = new object();
    }

    public TransferBuffer(byte[] buffer, int offset, int size, bool assign)
    {
        if (assign)
        {
            m_buffer = buffer;
        }
        else
        {
            m_buffer = new byte[buffer.Length];
            System.Buffer.BlockCopy(buffer, 0, m_buffer, 0, buffer.Length);
        }

        m_offset = offset;
        m_size = size;
        m_lock = new object();
    }

    public byte[] Buffer
    {
        get => m_buffer;
        set
        {
            lock (m_lock)
            {
                m_buffer = value;
            }
        }
    }

    public int Offset
    {
        get => m_offset;
        set
        {
            lock (m_lock)
            {
                m_offset = value;
            }
        }
    }

    public int Size
    {
        get => m_size;
        set
        {
            lock (m_lock)
            {
                m_size = value;
            }
        }
    }
}
