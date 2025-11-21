using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace RSBot.Core.Network.Protocol;

public class SecurityProtocol
{
    private readonly object _lock;
    private bool m_accepted_handshake;

    private readonly Blowfish m_blowfish;
    private ulong m_challenge_key;
    private ulong m_client_key;

    private bool m_client_security;
    private readonly byte[] m_count_byte_seeds;
    private uint m_crc_seed;
    private TransferBuffer m_current_buffer;

    private readonly List<ushort> m_enc_opcodes;
    private ulong m_handshake_blowfish_key;
    private byte m_identity_flag;
    private string m_identity_name;

    private List<Packet> m_incoming_packets;
    private ulong m_initial_blowfish_key;

    private ushort m_massive_count;
    private Packet m_massive_packet;
    private readonly List<Packet> m_outgoing_packets;

    private readonly TransferBuffer m_recv_buffer;
    private byte m_security_flag;
    private SecurityFlags m_security_flags;
    private uint m_seed_count;
    private bool m_started_handshake;
    private uint m_value_A;
    private uint m_value_B;
    private uint m_value_g;
    private uint m_value_K;
    private uint m_value_p;

    private uint m_value_x;

    // Default constructor
    public SecurityProtocol()
    {
        m_value_x = 0;
        m_value_g = 0;
        m_value_p = 0;
        m_value_A = 0;
        m_value_B = 0;
        m_value_K = 0;
        m_seed_count = 0;
        m_crc_seed = 0;
        m_initial_blowfish_key = 0;
        m_handshake_blowfish_key = 0;
        m_count_byte_seeds = new byte[3];
        m_count_byte_seeds[0] = 0;
        m_count_byte_seeds[1] = 0;
        m_count_byte_seeds[2] = 0;
        m_client_key = 0;
        m_challenge_key = 0;

        m_client_security = false;
        m_security_flag = 0;
        m_security_flags = new SecurityFlags();
        m_accepted_handshake = false;
        m_started_handshake = false;
        m_identity_flag = 0;
        m_identity_name = "SR_Client";

        m_outgoing_packets = new List<Packet>();
        m_incoming_packets = new List<Packet>();

        m_enc_opcodes = new List<ushort>();
        m_enc_opcodes.Add(0x2001);
        m_enc_opcodes.Add(0x6100);
        m_enc_opcodes.Add(0x6101);
        m_enc_opcodes.Add(0x6102);
        m_enc_opcodes.Add(0x6103);
        m_enc_opcodes.Add(0x6107);
        m_enc_opcodes.Add(0x704C);

        m_blowfish = new Blowfish();

        m_recv_buffer = new TransferBuffer(8192); // must be at minimal 2 bytes!
        m_current_buffer = null;

        m_massive_count = 0;
        m_massive_packet = null;

        _lock = new object();
    }

    // Changes the 0x2001 identify packet data that will be sent out by
    // this security object.
    public void ChangeIdentity(string name, byte flag)
    {
        lock (_lock)
        {
            m_identity_name = name;
            m_identity_flag = flag;
        }
    }

    // Generates the security settings. This should only be called if the security object
    // is being used to process an incoming connection's data (server).
    public void GenerateSecurity(bool blowfish, bool security_bytes, bool handshake)
    {
        lock (_lock)
        {
            var flags = new SecurityFlags();
            if (blowfish)
            {
                flags.none = 0;
                flags.blowfish = 1;
            }

            if (security_bytes)
            {
                flags.none = 0;
                flags.security_bytes = 1;
            }

            if (handshake)
            {
                flags.none = 0;
                flags.handshake = 1;
            }

            if (!blowfish && !security_bytes && !handshake)
                flags.none = 1;
            GenerateSecurity(flags);
        }
    }

    // Adds an encrypted opcode to the API. Any opcodes registered here will automatically
    // be encrypted as needed. Users should add the current Item Use opcode if they will be
    // mixing security modes.
    public void AddEncryptedOpcode(ushort opcode)
    {
        lock (_lock)
        {
            if (m_enc_opcodes.Contains(opcode) == false)
                m_enc_opcodes.Add(opcode);
        }
    }

    // Queues a packet for processing to be sent. The data is simply formatted and processed during
    // the next call to TransferOutgoing.
    public void Send(Packet packet)
    {
        if (packet.Opcode == 0x5000 || packet.Opcode == 0x9000)
            throw new HandshakeSecurityException(
                "[SecurityAPI::Send] Handshake packets cannot be sent through this function."
            );
        lock (_lock)
        {
            m_outgoing_packets.Add(packet);
        }
    }

    // Transfers raw incoming data into the security object. CallHandler TransferIncoming to
    // obtain a list of ready to process packets.
    public void Recv(byte[] buffer, int offset, int length)
    {
        Recv(new TransferBuffer(buffer, offset, length, true));
    }

    // Transfers raw incoming data into the security object. CallHandler TransferIncoming to
    // obtain a list of ready to process packets.
    public void Recv(TransferBuffer raw_buffer)
    {
        var incoming_buffers_tmp = new List<TransferBuffer>();
        lock (_lock)
        {
            var length = raw_buffer.Size - raw_buffer.Offset;
            var index = 0;
            while (length > 0)
            {
                var max_length = length;
                var calc_length = m_recv_buffer.Buffer.Length - m_recv_buffer.Size;

                if (max_length > calc_length)
                    max_length = calc_length;
                length -= max_length;

                Buffer.BlockCopy(
                    raw_buffer.Buffer,
                    raw_buffer.Offset + index,
                    m_recv_buffer.Buffer,
                    m_recv_buffer.Size,
                    max_length
                );

                m_recv_buffer.Size += max_length;
                index += max_length;

                // Loop while we have data to process
                while (m_recv_buffer.Size > 0)
                {
                    // If we do not have a current packet object, try to allocate one.
                    if (m_current_buffer == null)
                    {
                        // We need at least two bytes to allocate a packet.
                        if (m_recv_buffer.Size < 2)
                            break;

                        // Calculate the packet size.
                        var packet_size = (m_recv_buffer.Buffer[1] << 8) | m_recv_buffer.Buffer[0];

                        // Check to see if this packet is encrypted.
                        if ((packet_size & 0x8000) > 0)
                        {
                            // If so, calculate the total payload size.
                            packet_size &= 0x7FFF; // Mask off the encryption.
                            if (m_security_flags.blowfish == 1)
                                packet_size = 2 + m_blowfish.GetOutputLength(packet_size + 4);
                            else
                                packet_size += 6;
                        }
                        else
                        {
                            // The packet is unencrypted. The final size is simply
                            // header size + payload size.
                            packet_size += 6;
                        }

                        // Allocate the final buffer the packet will be written to
                        m_current_buffer = new TransferBuffer(packet_size, 0, packet_size);
                    }

                    // Calculate how many bytes are left to receive in the packet.
                    var max_copy_count = m_current_buffer.Size - m_current_buffer.Offset;

                    // If we need more bytes than we currently have, update the size.
                    if (max_copy_count > m_recv_buffer.Size)
                        max_copy_count = m_recv_buffer.Size;

                    // Copy the buffer data to the packet buffer
                    Buffer.BlockCopy(
                        m_recv_buffer.Buffer,
                        0,
                        m_current_buffer.Buffer,
                        m_current_buffer.Offset,
                        max_copy_count
                    );

                    // Update how many bytes we now have
                    m_current_buffer.Offset += max_copy_count;
                    m_recv_buffer.Size -= max_copy_count;

                    // If there is data remaining in the buffer, copy it over the data
                    // we just removed (sliding buffer).
                    if (m_recv_buffer.Size > 0)
                        Buffer.BlockCopy(
                            m_recv_buffer.Buffer,
                            max_copy_count,
                            m_recv_buffer.Buffer,
                            0,
                            m_recv_buffer.Size
                        );

                    // Check to see if the current packet is now complete.
                    if (m_current_buffer.Size == m_current_buffer.Offset)
                    {
                        // If so, dispatch it to the manager class for processing by the system.
                        m_current_buffer.Offset = 0;
                        incoming_buffers_tmp.Add(m_current_buffer);

                        // Set the current packet to null so we can process the next packet
                        // in the stream.
                        m_current_buffer = null;
                    }
                    else
                    {
                        // Otherwise, we are done with this loop, since we need more
                        // data for the current packet.
                        break;
                    }
                }
            }

            if (incoming_buffers_tmp.Count > 0)
                foreach (var buffer in incoming_buffers_tmp)
                {
                    var packet_encrypted = false;

                    var packet_size = (buffer.Buffer[1] << 8) | buffer.Buffer[0];
                    if ((packet_size & 0x8000) > 0)
                    {
                        if (m_security_flags.blowfish == 1)
                        {
                            packet_size &= 0x7FFF;
                            packet_encrypted = true;
                        }
                        else
                        {
                            packet_size &= 0x7FFF;
                        }
                    }

                    if (packet_encrypted)
                    {
                        var decrypted = m_blowfish.Decode(buffer.Buffer, 2, buffer.Size - 2);
                        var new_buffer = new byte[6 + packet_size];
                        Buffer.BlockCopy(BitConverter.GetBytes((ushort)packet_size), 0, new_buffer, 0, 2);
                        Buffer.BlockCopy(decrypted, 0, new_buffer, 2, 4 + packet_size);
                        buffer.Buffer = null;
                        buffer.Buffer = new_buffer;
                    }

                    var packet_data = new PacketReader(buffer.Buffer);
                    packet_size = packet_data.ReadUInt16();
                    var packet_opcode = packet_data.ReadUInt16();
                    var packet_security_count = packet_data.ReadByte();
                    var packet_security_crc = packet_data.ReadByte();

                    // Client object whose bytes the server might need to verify
                    if (m_client_security)
                        if (m_security_flags.security_bytes == 1)
                        {
                            var expected_count = GenerateCountByte(true);
                            if (packet_security_count != expected_count)
                                throw new HandshakeSecurityException("[SecurityAPI::Recv] Count byte mismatch.");

                            if (
                                packet_encrypted
                                || (m_security_flags.security_bytes == 1 && m_security_flags.blowfish == 0)
                            )
                                if (packet_encrypted || m_enc_opcodes.Contains(packet_opcode))
                                {
                                    packet_size |= 0x8000;
                                    Buffer.BlockCopy(
                                        BitConverter.GetBytes((ushort)packet_size),
                                        0,
                                        buffer.Buffer,
                                        0,
                                        2
                                    );
                                }

                            buffer.Buffer[5] = 0;

                            var expected_crc = GenerateCheckByte(buffer.Buffer);
                            if (packet_security_crc != expected_crc)
                                throw new HandshakeSecurityException("[SecurityAPI::Recv] CRC byte mismatch.");

                            buffer.Buffer[4] = 0;

                            if (
                                packet_encrypted
                                || (m_security_flags.security_bytes == 1 && m_security_flags.blowfish == 0)
                            )
                                if (packet_encrypted || m_enc_opcodes.Contains(packet_opcode))
                                {
                                    packet_size &= 0x7FFF;
                                    Buffer.BlockCopy(
                                        BitConverter.GetBytes((ushort)packet_size),
                                        0,
                                        buffer.Buffer,
                                        0,
                                        2
                                    );
                                }
                        }

                    if (packet_opcode == 0x5000 || packet_opcode == 0x9000) // New logic processing!
                    {
                        Handshake(packet_opcode, packet_data, packet_encrypted);

                        // Pass the handshake packets to the user so they can at least see them.
                        // They do not need to actually do anything with them. This was added to
                        // help debugging and make output logs complete.
                        var packet = new Packet(packet_opcode, packet_encrypted, false, buffer.Buffer, 6, packet_size);
                        packet.Lock();
                        m_incoming_packets.Add(packet);
                    }
                    else
                    {
                        if (m_client_security)
                            // Make sure the client accepted the security system first
                            if (!m_accepted_handshake)
                                throw new HandshakeSecurityException(
                                    "[SecurityAPI::Recv] The client has not accepted the handshake."
                                );
                        if (packet_opcode == 0x600D) // Auto process massive messages for the user
                        {
                            var mode = packet_data.ReadByte();
                            if (mode == 1)
                            {
                                m_massive_count = packet_data.ReadUInt16();
                                var contained_packet_opcode = packet_data.ReadUInt16();
                                m_massive_packet = new Packet(contained_packet_opcode, packet_encrypted, true);
                            }
                            else
                            {
                                if (m_massive_packet == null)
                                    throw new HandshakeSecurityException(
                                        "[SecurityAPI::Recv] A malformed 0x600D packet was received."
                                    );
                                m_massive_packet.WriteBytes(packet_data.ReadBytes(packet_size - 1));
                                m_massive_count--;
                                if (m_massive_count == 0)
                                {
                                    m_massive_packet.Lock();
                                    m_incoming_packets.Add(m_massive_packet);
                                    m_massive_packet = null;
                                }
                            }
                        }
                        else
                        {
                            var packet = new Packet(
                                packet_opcode,
                                packet_encrypted,
                                false,
                                buffer.Buffer,
                                6,
                                packet_size
                            );
                            packet.Lock();
                            m_incoming_packets.Add(packet);
                        }
                    }
                }
        }
    }

    public IEnumerable<byte[]> TransferOutgoing()
    {
        lock (_lock)
        {
            if (HasPacketToSend())
                while (HasPacketToSend())
                    yield return GetBufferToSend();
        }
    }

    // Returns a list of all packets that are ready for processing. If no packets are available,
    // null is returned.
    public List<Packet> TransferIncoming()
    {
        List<Packet> packets = null;
        lock (_lock)
        {
            if (m_incoming_packets.Count > 0)
            {
                packets = m_incoming_packets;
                m_incoming_packets = new List<Packet>();
            }
        }

        return packets;
    }

    #region SecurityFlags

    // Security flags container
    [StructLayout(LayoutKind.Explicit, Size = 8, CharSet = CharSet.Ansi)]
    private class SecurityFlags
    {
        [FieldOffset(5)]
        public byte _6;

        [FieldOffset(6)]
        public byte _7;

        [FieldOffset(7)]
        public byte _8;

        [FieldOffset(1)]
        public byte blowfish;

        [FieldOffset(3)]
        public byte handshake;

        [FieldOffset(4)]
        public byte handshake_response;

        [FieldOffset(0)]
        public byte none;

        [FieldOffset(2)]
        public byte security_bytes;
    }

    private static SecurityFlags CopySecurityFlags(SecurityFlags flags)
    {
        var copy = new SecurityFlags();
        copy.none = flags.none;
        copy.blowfish = flags.blowfish;
        copy.security_bytes = flags.security_bytes;
        copy.handshake = flags.handshake;
        copy.handshake_response = flags.handshake_response;
        copy._6 = flags._6;
        copy._7 = flags._7;
        copy._8 = flags._8;
        return copy;
    }

    // Returns a byte from a SecurityFlags object.
    private static byte FromSecurityFlags(SecurityFlags flags)
    {
        return (byte)(
            flags.none
            | (flags.blowfish << 1)
            | (flags.security_bytes << 2)
            | (flags.handshake << 3)
            | (flags.handshake_response << 4)
            | (flags._6 << 5)
            | (flags._7 << 6)
            | (flags._8 << 7)
        );
    }

    // Returns a SecurityFlags object from a byte.
    private static SecurityFlags ToSecurityFlags(byte value)
    {
        var flags = new SecurityFlags();
        flags.none = (byte)(value & 1);
        value >>= 1;
        flags.blowfish = (byte)(value & 1);
        value >>= 1;
        flags.security_bytes = (byte)(value & 1);
        value >>= 1;
        flags.handshake = (byte)(value & 1);
        value >>= 1;
        flags.handshake_response = (byte)(value & 1);
        value >>= 1;
        flags._6 = (byte)(value & 1);
        value >>= 1;
        flags._7 = (byte)(value & 1);
        value >>= 1;
        flags._8 = (byte)(value & 1);
        value >>= 1;
        return flags;
    }

    #endregion SecurityFlags

    #region SecurityTable

    // Generates the crc bytes lookup table
    private static uint[] GenerateSecurityTable()
    {
        var security_table = new uint[0x10000];
        byte[] base_security_table =
        {
            0xB1,
            0xD6,
            0x8B,
            0x96,
            0x96,
            0x30,
            0x07,
            0x77,
            0x2C,
            0x61,
            0x0E,
            0xEE,
            0xBA,
            0x51,
            0x09,
            0x99,
            0x19,
            0xC4,
            0x6D,
            0x07,
            0x8F,
            0xF4,
            0x6A,
            0x70,
            0x35,
            0xA5,
            0x63,
            0xE9,
            0xA3,
            0x95,
            0x64,
            0x9E,
            0x32,
            0x88,
            0xDB,
            0x0E,
            0xA4,
            0xB8,
            0xDC,
            0x79,
            0x1E,
            0xE9,
            0xD5,
            0xE0,
            0x88,
            0xD9,
            0xD2,
            0x97,
            0x2B,
            0x4C,
            0xB6,
            0x09,
            0xBD,
            0x7C,
            0xB1,
            0x7E,
            0x07,
            0x2D,
            0xB8,
            0xE7,
            0x91,
            0x1D,
            0xBF,
            0x90,
            0x64,
            0x10,
            0xB7,
            0x1D,
            0xF2,
            0x20,
            0xB0,
            0x6A,
            0x48,
            0x71,
            0xB1,
            0xF3,
            0xDE,
            0x41,
            0xBE,
            0x8C,
            0x7D,
            0xD4,
            0xDA,
            0x1A,
            0xEB,
            0xE4,
            0xDD,
            0x6D,
            0x51,
            0xB5,
            0xD4,
            0xF4,
            0xC7,
            0x85,
            0xD3,
            0x83,
            0x56,
            0x98,
            0x6C,
            0x13,
            0xC0,
            0xA8,
            0x6B,
            0x64,
            0x7A,
            0xF9,
            0x62,
            0xFD,
            0xEC,
            0xC9,
            0x65,
            0x8A,
            0x4F,
            0x5C,
            0x01,
            0x14,
            0xD9,
            0x6C,
            0x06,
            0x63,
            0x63,
            0x3D,
            0x0F,
            0xFA,
            0xF5,
            0x0D,
            0x08,
            0x8D,
            0xC8,
            0x20,
            0x6E,
            0x3B,
            0x5E,
            0x10,
            0x69,
            0x4C,
            0xE4,
            0x41,
            0x60,
            0xD5,
            0x72,
            0x71,
            0x67,
            0xA2,
            0xD1,
            0xE4,
            0x03,
            0x3C,
            0x47,
            0xD4,
            0x04,
            0x4B,
            0xFD,
            0x85,
            0x0D,
            0xD2,
            0x6B,
            0xB5,
            0x0A,
            0xA5,
            0xFA,
            0xA8,
            0xB5,
            0x35,
            0x6C,
            0x98,
            0xB2,
            0x42,
            0xD6,
            0xC9,
            0xBB,
            0xDB,
            0x40,
            0xF9,
            0xBC,
            0xAC,
            0xE3,
            0x6C,
            0xD8,
            0x32,
            0x75,
            0x5C,
            0xDF,
            0x45,
            0xCF,
            0x0D,
            0xD6,
            0xDC,
            0x59,
            0x3D,
            0xD1,
            0xAB,
            0xAC,
            0x30,
            0xD9,
            0x26,
            0x3A,
            0x00,
            0xDE,
            0x51,
            0x80,
            0x51,
            0xD7,
            0xC8,
            0x16,
            0x61,
            0xD0,
            0xBF,
            0xB5,
            0xF4,
            0xB4,
            0x21,
            0x23,
            0xC4,
            0xB3,
            0x56,
            0x99,
            0x95,
            0xBA,
            0xCF,
            0x0F,
            0xA5,
            0xB7,
            0xB8,
            0x9E,
            0xB8,
            0x02,
            0x28,
            0x08,
            0x88,
            0x05,
            0x5F,
            0xB2,
            0xD9,
            0xEC,
            0xC6,
            0x24,
            0xE9,
            0x0B,
            0xB1,
            0x87,
            0x7C,
            0x6F,
            0x2F,
            0x11,
            0x4C,
            0x68,
            0x58,
            0xAB,
            0x1D,
            0x61,
            0xC1,
            0x3D,
            0x2D,
            0x66,
            0xB6,
            0x90,
            0x41,
            0xDC,
            0x76,
            0x06,
            0x71,
            0xDB,
            0x01,
            0xBC,
            0x20,
            0xD2,
            0x98,
            0x2A,
            0x10,
            0xD5,
            0xEF,
            0x89,
            0x85,
            0xB1,
            0x71,
            0x1F,
            0xB5,
            0xB6,
            0x06,
            0xA5,
            0xE4,
            0xBF,
            0x9F,
            0x33,
            0xD4,
            0xB8,
            0xE8,
            0xA2,
            0xC9,
            0x07,
            0x78,
            0x34,
            0xF9,
            0xA0,
            0x0F,
            0x8E,
            0xA8,
            0x09,
            0x96,
            0x18,
            0x98,
            0x0E,
            0xE1,
            0xBB,
            0x0D,
            0x6A,
            0x7F,
            0x2D,
            0x3D,
            0x6D,
            0x08,
            0x97,
            0x6C,
            0x64,
            0x91,
            0x01,
            0x5C,
            0x63,
            0xE6,
            0xF4,
            0x51,
            0x6B,
            0x6B,
            0x62,
            0x61,
            0x6C,
            0x1C,
            0xD8,
            0x30,
            0x65,
            0x85,
            0x4E,
            0x00,
            0x62,
            0xF2,
            0xED,
            0x95,
            0x06,
            0x6C,
            0x7B,
            0xA5,
            0x01,
            0x1B,
            0xC1,
            0xF4,
            0x08,
            0x82,
            0x57,
            0xC4,
            0x0F,
            0xF5,
            0xC6,
            0xD9,
            0xB0,
            0x63,
            0x50,
            0xE9,
            0xB7,
            0x12,
            0xEA,
            0xB8,
            0xBE,
            0x8B,
            0x7C,
            0x88,
            0xB9,
            0xFC,
            0xDF,
            0x1D,
            0xDD,
            0x62,
            0x49,
            0x2D,
            0xDA,
            0x15,
            0xF3,
            0x7C,
            0xD3,
            0x8C,
            0x65,
            0x4C,
            0xD4,
            0xFB,
            0x58,
            0x61,
            0xB2,
            0x4D,
            0xCE,
            0x51,
            0xB5,
            0x3A,
            0x74,
            0x00,
            0xBC,
            0xA3,
            0xE2,
            0x30,
            0xBB,
            0xD4,
            0x41,
            0xA5,
            0xDF,
            0x4A,
            0xD7,
            0x95,
            0xD8,
            0x3D,
            0x6D,
            0xC4,
            0xD1,
            0xA4,
            0xFB,
            0xF4,
            0xD6,
            0xD3,
            0x6A,
            0xE9,
            0x69,
            0x43,
            0xFC,
            0xD9,
            0x6E,
            0x34,
            0x46,
            0x88,
            0x67,
            0xAD,
            0xD0,
            0xB8,
            0x60,
            0xDA,
            0x73,
            0x2D,
            0x04,
            0x44,
            0xE5,
            0x1D,
            0x03,
            0x33,
            0x5F,
            0x4C,
            0x0A,
            0xAA,
            0xC9,
            0x7C,
            0x0D,
            0xDD,
            0x3C,
            0x71,
            0x05,
            0x50,
            0xAA,
            0x41,
            0x02,
            0x27,
            0x10,
            0x10,
            0x0B,
            0xBE,
            0x86,
            0x20,
            0x0C,
            0xC9,
            0x25,
            0xB5,
            0x68,
            0x57,
            0xB3,
            0x85,
            0x6F,
            0x20,
            0x09,
            0xD4,
            0x66,
            0xB9,
            0x9F,
            0xE4,
            0x61,
            0xCE,
            0x0E,
            0xF9,
            0xDE,
            0x5E,
            0x08,
            0xC9,
            0xD9,
            0x29,
            0x22,
            0x98,
            0xD0,
            0xB0,
            0xB4,
            0xA8,
            0x57,
            0xC7,
            0x17,
            0x3D,
            0xB3,
            0x59,
            0x81,
            0x0D,
            0xB4,
            0x3E,
            0x3B,
            0x5C,
            0xBD,
            0xB7,
            0xAD,
            0x6C,
            0xBA,
            0xC0,
            0x20,
            0x83,
            0xB8,
            0xED,
            0xB6,
            0xB3,
            0xBF,
            0x9A,
            0x0C,
            0xE2,
            0xB6,
            0x03,
            0x9A,
            0xD2,
            0xB1,
            0x74,
            0x39,
            0x47,
            0xD5,
            0xEA,
            0xAF,
            0x77,
            0xD2,
            0x9D,
            0x15,
            0x26,
            0xDB,
            0x04,
            0x83,
            0x16,
            0xDC,
            0x73,
            0x12,
            0x0B,
            0x63,
            0xE3,
            0x84,
            0x3B,
            0x64,
            0x94,
            0x3E,
            0x6A,
            0x6D,
            0x0D,
            0xA8,
            0x5A,
            0x6A,
            0x7A,
            0x0B,
            0xCF,
            0x0E,
            0xE4,
            0x9D,
            0xFF,
            0x09,
            0x93,
            0x27,
            0xAE,
            0x00,
            0x0A,
            0xB1,
            0x9E,
            0x07,
            0x7D,
            0x44,
            0x93,
            0x0F,
            0xF0,
            0xD2,
            0xA2,
            0x08,
            0x87,
            0x68,
            0xF2,
            0x01,
            0x1E,
            0xFE,
            0xC2,
            0x06,
            0x69,
            0x5D,
            0x57,
            0x62,
            0xF7,
            0xCB,
            0x67,
            0x65,
            0x80,
            0x71,
            0x36,
            0x6C,
            0x19,
            0xE7,
            0x06,
            0x6B,
            0x6E,
            0x76,
            0x1B,
            0xD4,
            0xFE,
            0xE0,
            0x2B,
            0xD3,
            0x89,
            0x5A,
            0x7A,
            0xDA,
            0x10,
            0xCC,
            0x4A,
            0xDD,
            0x67,
            0x6F,
            0xDF,
            0xB9,
            0xF9,
            0xF9,
            0xEF,
            0xBE,
            0x8E,
            0x43,
            0xBE,
            0xB7,
            0x17,
            0xD5,
            0x8E,
            0xB0,
            0x60,
            0xE8,
            0xA3,
            0xD6,
            0xD6,
            0x7E,
            0x93,
            0xD1,
            0xA1,
            0xC4,
            0xC2,
            0xD8,
            0x38,
            0x52,
            0xF2,
            0xDF,
            0x4F,
            0xF1,
            0x67,
            0xBB,
            0xD1,
            0x67,
            0x57,
            0xBC,
            0xA6,
            0xDD,
            0x06,
            0xB5,
            0x3F,
            0x4B,
            0x36,
            0xB2,
            0x48,
            0xDA,
            0x2B,
            0x0D,
            0xD8,
            0x4C,
            0x1B,
            0x0A,
            0xAF,
            0xF6,
            0x4A,
            0x03,
            0x36,
            0x60,
            0x7A,
            0x04,
            0x41,
            0xC3,
            0xEF,
            0x60,
            0xDF,
            0x55,
            0xDF,
            0x67,
            0xA8,
            0xEF,
            0x8E,
            0x6E,
            0x31,
            0x79,
            0x0E,
            0x69,
            0x46,
            0x8C,
            0xB3,
            0x51,
            0xCB,
            0x1A,
            0x83,
            0x63,
            0xBC,
            0xA0,
            0xD2,
            0x6F,
            0x25,
            0x36,
            0xE2,
            0x68,
            0x52,
            0x95,
            0x77,
            0x0C,
            0xCC,
            0x03,
            0x47,
            0x0B,
            0xBB,
            0xB9,
            0x14,
            0x02,
            0x22,
            0x2F,
            0x26,
            0x05,
            0x55,
            0xBE,
            0x3B,
            0xB6,
            0xC5,
            0x28,
            0x0B,
            0xBD,
            0xB2,
            0x92,
            0x5A,
            0xB4,
            0x2B,
            0x04,
            0x6A,
            0xB3,
            0x5C,
            0xA7,
            0xFF,
            0xD7,
            0xC2,
            0x31,
            0xCF,
            0xD0,
            0xB5,
            0x8B,
            0x9E,
            0xD9,
            0x2C,
            0x1D,
            0xAE,
            0xDE,
            0x5B,
            0xB0,
            0x72,
            0x64,
            0x9B,
            0x26,
            0xF2,
            0xE3,
            0xEC,
            0x9C,
            0xA3,
            0x6A,
            0x75,
            0x0A,
            0x93,
            0x6D,
            0x02,
            0xA9,
            0x06,
            0x09,
            0x9C,
            0x3F,
            0x36,
            0x0E,
            0xEB,
            0x85,
            0x68,
            0x07,
            0x72,
            0x13,
            0x07,
            0x00,
            0x05,
            0x82,
            0x48,
            0xBF,
            0x95,
            0x14,
            0x7A,
            0xB8,
            0xE2,
            0xAE,
            0x2B,
            0xB1,
            0x7B,
            0x38,
            0x1B,
            0xB6,
            0x0C,
            0x9B,
            0x8E,
            0xD2,
            0x92,
            0x0D,
            0xBE,
            0xD5,
            0xE5,
            0xB7,
            0xEF,
            0xDC,
            0x7C,
            0x21,
            0xDF,
            0xDB,
            0x0B,
            0x94,
            0xD2,
            0xD3,
            0x86,
            0x42,
            0xE2,
            0xD4,
            0xF1,
            0xF8,
            0xB3,
            0xDD,
            0x68,
            0x6E,
            0x83,
            0xDA,
            0x1F,
            0xCD,
            0x16,
            0xBE,
            0x81,
            0x5B,
            0x26,
            0xB9,
            0xF6,
            0xE1,
            0x77,
            0xB0,
            0x6F,
            0x77,
            0x47,
            0xB7,
            0x18,
            0xE0,
            0x5A,
            0x08,
            0x88,
            0x70,
            0x6A,
            0x0F,
            0xF1,
            0xCA,
            0x3B,
            0x06,
            0x66,
            0x5C,
            0x0B,
            0x01,
            0x11,
            0xFF,
            0x9E,
            0x65,
            0x8F,
            0x69,
            0xAE,
            0x62,
            0xF8,
            0xD3,
            0xFF,
            0x6B,
            0x61,
            0x45,
            0xCF,
            0x6C,
            0x16,
            0x78,
            0xE2,
            0x0A,
            0xA0,
            0xEE,
            0xD2,
            0x0D,
            0xD7,
            0x54,
            0x83,
            0x04,
            0x4E,
            0xC2,
            0xB3,
            0x03,
            0x39,
            0x61,
            0x26,
            0x67,
            0xA7,
            0xF7,
            0x16,
            0x60,
            0xD0,
            0x4D,
            0x47,
            0x69,
            0x49,
            0xDB,
            0x77,
            0x6E,
            0x3E,
            0x4A,
            0x6A,
            0xD1,
            0xAE,
            0xDC,
            0x5A,
            0xD6,
            0xD9,
            0x66,
            0x0B,
            0xDF,
            0x40,
            0xF0,
            0x3B,
            0xD8,
            0x37,
            0x53,
            0xAE,
            0xBC,
            0xA9,
            0xC5,
            0x9E,
            0xBB,
            0xDE,
            0x7F,
            0xCF,
            0xB2,
            0x47,
            0xE9,
            0xFF,
            0xB5,
            0x30,
            0x1C,
            0xF9,
            0xBD,
            0xBD,
            0x8A,
            0xCD,
            0xBA,
            0xCA,
            0x30,
            0x9E,
            0xB3,
            0x53,
            0xA6,
            0xA3,
            0xBC,
            0x24,
            0x05,
            0x3B,
            0xD0,
            0xBA,
            0xA3,
            0x06,
            0xD7,
            0xCD,
            0xE9,
            0x57,
            0xDE,
            0x54,
            0xBF,
            0x67,
            0xD9,
            0x23,
            0x2E,
            0x72,
            0x66,
            0xB3,
            0xB8,
            0x4A,
            0x61,
            0xC4,
            0x02,
            0x1B,
            0x38,
            0x5D,
            0x94,
            0x2B,
            0x6F,
            0x2B,
            0x37,
            0xBE,
            0xCB,
            0xB4,
            0xA1,
            0x8E,
            0xCC,
            0xC3,
            0x1B,
            0xDF,
            0x0D,
            0x5A,
            0x8D,
            0xED,
            0x02,
            0x2D,
        };

        using (var in_memory_stream = new MemoryStream(base_security_table, false))
        {
            using (var reader = new BinaryReader(in_memory_stream))
            {
                var index = 0;
                for (var edi = 0; edi < 1024; edi += 4)
                {
                    var edx = reader.ReadUInt32();
                    for (uint ecx = 0; ecx < 256; ++ecx)
                    {
                        var eax = ecx >> 1;
                        if ((ecx & 1) != 0)
                            eax ^= edx;
                        for (var bit = 0; bit < 7; ++bit)
                            if ((eax & 1) != 0)
                            {
                                eax >>= 1;
                                eax ^= edx;
                            }
                            else
                            {
                                eax >>= 1;
                            }

                        security_table[index++] = eax;
                    }
                }
            }
        }

        return security_table;
    }

    // Use one security table for all objects.
    private static readonly uint[] global_security_table = GenerateSecurityTable();

    #endregion SecurityTable

    #region WIN32_Helper_Functions

    private static ulong MAKELONGLONG_(uint a, uint b)
    {
        ulong a_ = a;
        ulong b_ = b;
        return (b_ << 32) | a_;
    }

    private static uint MAKELONG_(ushort a, ushort b)
    {
        uint a_ = a;
        uint b_ = b;
        return (b_ << 16) | a_;
    }

    private static ushort MAKEWORD_(byte a, byte b)
    {
        ushort a_ = a;
        ushort b_ = b;
        return (ushort)((b_ << 8) | a_);
    }

    private static ushort LOWORD_(uint a)
    {
        return (ushort)(a & 0xFFFF);
    }

    private static ushort HIWORD_(uint a)
    {
        return (ushort)((a >> 16) & 0xFFFF);
    }

    private static byte LOBYTE_(ushort a)
    {
        return (byte)(a & 0xFF);
    }

    private static byte HIBYTE_(ushort a)
    {
        return (byte)((a >> 8) & 0xFF);
    }

    #endregion WIN32_Helper_Functions

    #region Random

    private static readonly Random random = new();

    private static ulong NextUInt64()
    {
        var buffer = new byte[sizeof(ulong)];
        random.NextBytes(buffer);
        return BitConverter.ToUInt64(buffer, 0);
    }

    private static uint NextUInt32()
    {
        var buffer = new byte[sizeof(uint)];
        random.NextBytes(buffer);
        return BitConverter.ToUInt32(buffer, 0);
    }

    private static ushort NextUInt16()
    {
        var buffer = new byte[sizeof(ushort)];
        random.NextBytes(buffer);
        return BitConverter.ToUInt16(buffer, 0);
    }

    private static byte NextUInt8()
    {
        return (byte)(NextUInt16() & 0xFF);
    }

    #endregion Random

    #region CoreSecurityFunction

    // This function's logic was written by jMerlin as part of the article "How to generate the security bytes for SRO"
    private uint GenerateValue(ref uint val)
    {
        for (var i = 0; i < 32; ++i)
            val =
                (((((((((((val >> 2) ^ val) >> 2) ^ val) >> 1) ^ val) >> 1) ^ val) >> 1) ^ val) & 1)
                | ((((val & 1) << 31) | (val >> 1)) & 0xFFFFFFFE);
        return val;
    }

    // Sets up the count bytes
    // This function's logic was written by jMerlin as part of the article "How to generate the security bytes for SRO"
    private void SetupCountByte(uint seed)
    {
        if (seed == 0)
            seed = 0x9ABFB3B6;
        var mut = seed;
        var mut1 = GenerateValue(ref mut);
        var mut2 = GenerateValue(ref mut);
        var mut3 = GenerateValue(ref mut);
        GenerateValue(ref mut);
        var byte1 = (byte)((mut & 0xFF) ^ (mut3 & 0xFF));
        var byte2 = (byte)((mut1 & 0xFF) ^ (mut2 & 0xFF));
        if (byte1 == 0)
            byte1 = 1;
        if (byte2 == 0)
            byte2 = 1;
        m_count_byte_seeds[0] = (byte)(byte1 ^ byte2);
        m_count_byte_seeds[1] = byte2;
        m_count_byte_seeds[2] = byte1;
    }

    // Helper function used in the handshake, XCoordinate may be a or b, this clean version of the function is from jMerlin (Func_X_4)
    private uint G_pow_X_mod_P(uint P, uint X, uint G)
    {
        long result = 1;
        long mult = G;
        if (X == 0)
            return 1;
        while (X != 0)
        {
            if ((X & 1) > 0)
                result = mult * result % P;
            X = X >> 1;
            mult = mult * mult % P;
        }

        return (uint)result;
    }

    // Helper function used in the handshake (Func_X_2)
    private void KeyTransformValue(ref ulong val, uint key, byte key_byte)
    {
        var stream = BitConverter.GetBytes(val);
        stream[0] ^= (byte)(stream[0] + LOBYTE_(LOWORD_(key)) + key_byte);
        stream[1] ^= (byte)(stream[1] + HIBYTE_(LOWORD_(key)) + key_byte);
        stream[2] ^= (byte)(stream[2] + LOBYTE_(HIWORD_(key)) + key_byte);
        stream[3] ^= (byte)(stream[3] + HIBYTE_(HIWORD_(key)) + key_byte);
        stream[4] ^= (byte)(stream[4] + LOBYTE_(LOWORD_(key)) + key_byte);
        stream[5] ^= (byte)(stream[5] + HIBYTE_(LOWORD_(key)) + key_byte);
        stream[6] ^= (byte)(stream[6] + LOBYTE_(HIWORD_(key)) + key_byte);
        stream[7] ^= (byte)(stream[7] + HIBYTE_(HIWORD_(key)) + key_byte);
        val = BitConverter.ToUInt64(stream, 0);
    }

    // Function called to generate a count byte
    // This function's logic was written by jMerlin as part of the article "How to generate the security bytes for SRO"
    private byte GenerateCountByte(bool update)
    {
        var result = (byte)(m_count_byte_seeds[2] * (~m_count_byte_seeds[0] + m_count_byte_seeds[1]));
        result = (byte)(result ^ (result >> 4));
        if (update)
            m_count_byte_seeds[0] = result;
        return result;
    }

    // Function called to generate the crc byte
    // This function's logic was written by jMerlin as part of the article "How to generate the security bytes for SRO"
    private byte GenerateCheckByte(byte[] stream, int offset, int length)
    {
        var checksum = 0xFFFFFFFF;
        var moddedseed = m_crc_seed << 8;
        for (var x = offset; x < offset + length; ++x)
            checksum = (checksum >> 8) ^ global_security_table[moddedseed + ((stream[x] ^ checksum) & 0xFF)];
        return (byte)(
            ((checksum >> 24) & 0xFF) + ((checksum >> 8) & 0xFF) + ((checksum >> 16) & 0xFF) + (checksum & 0xFF)
        );
    }

    private byte GenerateCheckByte(byte[] stream)
    {
        return GenerateCheckByte(stream, 0, stream.Length);
    }

    #endregion CoreSecurityFunction

    #region ExtendedSecurityFunctions

    private void GenerateSecurity(SecurityFlags flags)
    {
        m_security_flag = FromSecurityFlags(flags);
        m_security_flags = flags;
        m_client_security = true;

        var response = new Packet(0x5000);

        response.WriteByte(m_security_flag);

        if (m_security_flags.blowfish == 1)
        {
            m_initial_blowfish_key = NextUInt64();

            m_blowfish.Initialize(BitConverter.GetBytes(m_initial_blowfish_key));

            response.WriteULong(m_initial_blowfish_key);
        }

        if (m_security_flags.security_bytes == 1)
        {
            m_seed_count = NextUInt8();
            SetupCountByte(m_seed_count);
            m_crc_seed = NextUInt8();

            response.WriteUInt(m_seed_count);
            response.WriteUInt(m_crc_seed);
        }

        if (m_security_flags.handshake == 1)
        {
            m_handshake_blowfish_key = NextUInt64();
            m_value_x = NextUInt32() & 0x7FFFFFFF;
            m_value_g = NextUInt32() & 0x7FFFFFFF;
            m_value_p = NextUInt32() & 0x7FFFFFFF;
            m_value_A = G_pow_X_mod_P(m_value_p, m_value_x, m_value_g);

            response.WriteULong(m_handshake_blowfish_key);
            response.WriteUInt(m_value_g);
            response.WriteUInt(m_value_p);
            response.WriteUInt(m_value_A);
        }

        m_outgoing_packets.Add(response);
    }

    private void Handshake(ushort packet_opcode, PacketReader packet_data, bool packet_encrypted)
    {
        if (packet_encrypted)
            throw new HandshakeSecurityException(
                "[SecurityAPI::Handshake] Received an illogical (encrypted) handshake packet."
            );
        if (m_client_security)
        {
            // If this object does not need a handshake
            if (m_security_flags.handshake == 0)
            {
                // Client should only accept it then
                if (packet_opcode == 0x9000)
                {
                    if (m_accepted_handshake)
                        throw new HandshakeSecurityException(
                            "[SecurityAPI::Handshake] Received an illogical handshake packet (duplicate 0x9000)."
                        );
                    m_accepted_handshake = true; // Otherwise, all good here
                    return;
                }
                // Client should not send any 0x5000s!

                if (packet_opcode == 0x5000)
                    throw new HandshakeSecurityException(
                        "[SecurityAPI::Handshake] Received an illogical handshake packet (0x5000 with no handshake)."
                    );
                // Programmer made a mistake in calling this function
                throw new HandshakeSecurityException(
                    "[SecurityAPI::Handshake] Received an illogical handshake packet (programmer error)."
                );
            }

            // Client accepts the handshake
            if (packet_opcode == 0x9000)
            {
                // Can't accept it before it's started!
                if (!m_started_handshake)
                    throw new HandshakeSecurityException(
                        "[SecurityAPI::Handshake] Received an illogical handshake packet (out of order 0x9000)."
                    );
                if (m_accepted_handshake) // Client error
                    throw new HandshakeSecurityException(
                        "[SecurityAPI::Handshake] Received an illogical handshake packet (duplicate 0x9000)."
                    );
                // Otherwise, all good here
                m_accepted_handshake = true;
                return;
            }
            // Client sends a handshake response

            if (packet_opcode == 0x5000)
            {
                if (m_started_handshake) // Client error
                    throw new HandshakeSecurityException(
                        "[SecurityAPI::Handshake] Received an illogical handshake packet (duplicate 0x5000)."
                    );
                m_started_handshake = true;
            }
            // Programmer made a mistake in calling this function
            else
            {
                throw new HandshakeSecurityException(
                    "[SecurityAPI::Handshake] Received an illogical handshake packet (programmer error)."
                );
            }

            ulong key_array = 0;
            byte[] tmp_bytes;

            m_value_B = packet_data.ReadUInt32();
            m_client_key = packet_data.ReadUInt64();

            m_value_K = G_pow_X_mod_P(m_value_p, m_value_x, m_value_B);

            key_array = MAKELONGLONG_(m_value_A, m_value_B);
            KeyTransformValue(ref key_array, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_K)) & 0x03));
            m_blowfish.Initialize(BitConverter.GetBytes(key_array));

            tmp_bytes = m_blowfish.Decode(BitConverter.GetBytes(m_client_key));
            m_client_key = BitConverter.ToUInt64(tmp_bytes, 0);

            key_array = MAKELONGLONG_(m_value_B, m_value_A);
            KeyTransformValue(ref key_array, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_B)) & 0x07));
            if (m_client_key != key_array)
                throw new HandshakeSecurityException("[SecurityAPI::Handshake] Client signature error.");

            key_array = MAKELONGLONG_(m_value_A, m_value_B);
            KeyTransformValue(ref key_array, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_K)) & 0x03));
            m_blowfish.Initialize(BitConverter.GetBytes(key_array));

            m_challenge_key = MAKELONGLONG_(m_value_A, m_value_B);
            KeyTransformValue(ref m_challenge_key, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_A)) & 0x07));
            tmp_bytes = m_blowfish.Encode(BitConverter.GetBytes(m_challenge_key));
            m_challenge_key = BitConverter.ToUInt64(tmp_bytes, 0);

            KeyTransformValue(ref m_handshake_blowfish_key, m_value_K, 0x3);
            m_blowfish.Initialize(BitConverter.GetBytes(m_handshake_blowfish_key));

            var tmp_flags = new SecurityFlags();
            tmp_flags.handshake_response = 1;
            var tmp_flag = FromSecurityFlags(tmp_flags);

            var response = new Packet(0x5000);
            response.WriteByte(tmp_flag);
            response.WriteULong(m_challenge_key);
            m_outgoing_packets.Add(response);
        }
        else
        {
            if (packet_opcode != 0x5000)
                throw new HandshakeSecurityException(
                    "[SecurityAPI::Handshake] Received an illogical handshake packet (programmer error)."
                );

            var flag = packet_data.ReadByte();

            var flags = ToSecurityFlags(flag);

            if (m_security_flag == 0)
            {
                m_security_flag = flag;
                m_security_flags = flags;
            }

            if (flags.blowfish == 1)
            {
                m_initial_blowfish_key = packet_data.ReadUInt64();
                m_blowfish.Initialize(BitConverter.GetBytes(m_initial_blowfish_key));
            }

            if (flags.security_bytes == 1)
            {
                m_seed_count = packet_data.ReadUInt32();
                m_crc_seed = packet_data.ReadUInt32();
                SetupCountByte(m_seed_count);
            }

            if (flags.handshake == 1)
            {
                m_handshake_blowfish_key = packet_data.ReadUInt64();
                m_value_g = packet_data.ReadUInt32();
                m_value_p = packet_data.ReadUInt32();
                m_value_A = packet_data.ReadUInt32();

                m_value_x = NextUInt32() & 0x7FFFFFFF;

                m_value_B = G_pow_X_mod_P(m_value_p, m_value_x, m_value_g);
                m_value_K = G_pow_X_mod_P(m_value_p, m_value_x, m_value_A);

                var key_array = MAKELONGLONG_(m_value_A, m_value_B);
                KeyTransformValue(ref key_array, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_K)) & 0x03));
                m_blowfish.Initialize(BitConverter.GetBytes(key_array));

                m_client_key = MAKELONGLONG_(m_value_B, m_value_A);
                KeyTransformValue(ref m_client_key, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_B)) & 0x07));
                var tmp_bytes = m_blowfish.Encode(BitConverter.GetBytes(m_client_key));
                m_client_key = BitConverter.ToUInt64(tmp_bytes, 0);
            }

            if (flags.handshake_response == 1)
            {
                m_challenge_key = packet_data.ReadUInt64();

                var expected_challenge_key = MAKELONGLONG_(m_value_A, m_value_B);
                KeyTransformValue(ref expected_challenge_key, m_value_K, (byte)(LOBYTE_(LOWORD_(m_value_A)) & 0x07));
                var tmp_bytes = m_blowfish.Encode(BitConverter.GetBytes(expected_challenge_key));
                expected_challenge_key = BitConverter.ToUInt64(tmp_bytes, 0);

                if (m_challenge_key != expected_challenge_key)
                    throw new HandshakeSecurityException("[SecurityAPI::Handshake] Server signature error.");

                KeyTransformValue(ref m_handshake_blowfish_key, m_value_K, 0x3);
                m_blowfish.Initialize(BitConverter.GetBytes(m_handshake_blowfish_key));
            }

            // Generate the outgoing packet now
            if (flags.handshake == 1 && flags.handshake_response == 0)
            {
                // Check to see if we already started a handshake
                if (m_started_handshake || m_accepted_handshake)
                    throw new HandshakeSecurityException(
                        "[SecurityAPI::Handshake] Received an illogical handshake packet (duplicate 0x5000)."
                    );

                // Handshake challenge
                var response = new Packet(0x5000);
                response.WriteUInt(m_value_B);
                response.WriteULong(m_client_key);
                m_outgoing_packets.Insert(0, response);

                // The handshake has started
                m_started_handshake = true;
            }
            else
            {
                // Check to see if we already accepted a handshake
                if (m_accepted_handshake)
                    throw new HandshakeSecurityException(
                        "[SecurityAPI::Handshake] Received an illogical handshake packet (duplicate 0x5000)."
                    );

                // Handshake accepted
                var response1 = new Packet(0x9000);

                // Identify
                var response2 = new Packet(0x2001, true, false);
                response2.WriteString(m_identity_name);
                response2.WriteByte(m_identity_flag);

                // Insert at the front, we want 0x9000 first, then 0x2001
                m_outgoing_packets.Insert(0, response2);
                m_outgoing_packets.Insert(0, response1);

                // Mark the handshake as accepted now
                m_started_handshake = true;
                m_accepted_handshake = true;
            }
        }
    }

    private byte[] FormatPacket(ushort opcode, byte[] data, bool encrypted)
    {
        // Sanity check
        if (data.Length >= 0x8000)
            throw new HandshakeSecurityException("[SecurityAPI::FormatPacket] Payload is too large!");

        var data_length = (ushort)data.Length;

        // Add the packet header to the start of the data
        var writer = new PacketWriter();
        writer.Write(data_length); // packet size
        writer.Write(opcode); // packet opcode
        writer.Write((ushort)0); // packet security bytes
        writer.Write(data);
        writer.Flush();

        // Determine if we need to mark the packet size as encrypted
        if (
            encrypted
            && (
                m_security_flags.blowfish == 1
                || (m_security_flags.security_bytes == 1 && m_security_flags.blowfish == 0)
            )
        )
        {
            var seek_index = writer.BaseStream.Seek(0, SeekOrigin.Current);

            var packet_size = (ushort)(data_length | 0x8000);

            writer.BaseStream.Seek(0, SeekOrigin.Begin);
            writer.Write(packet_size);
            writer.Flush();

            writer.BaseStream.Seek(seek_index, SeekOrigin.Begin);
        }

        // Only need to stamp bytes if this is a clientless object
        if (m_client_security == false && m_security_flags.security_bytes == 1)
        {
            var seek_index = writer.BaseStream.Seek(0, SeekOrigin.Current);

            var sb1 = GenerateCountByte(true);
            writer.BaseStream.Seek(4, SeekOrigin.Begin);
            writer.Write(sb1);
            writer.Flush();

            var sb2 = GenerateCheckByte(writer.GetBytes());
            writer.BaseStream.Seek(5, SeekOrigin.Begin);
            writer.Write(sb2);
            writer.Flush();

            writer.BaseStream.Seek(seek_index, SeekOrigin.Begin);
        }

        // If the packet should be physically encrypted, return an encrypted version of it
        if (encrypted && m_security_flags.blowfish == 1)
        {
            var raw_data = writer.GetBytes();
            var encrypted_data = m_blowfish.Encode(raw_data, 2, raw_data.Length - 2);

            writer.BaseStream.Seek(2, SeekOrigin.Begin);

            writer.Write(encrypted_data);
            writer.Flush();
        }
        else
        {
            // Determine if we need to unmark the packet size from being encrypted but not physically encrypted
            if (encrypted && m_security_flags.security_bytes == 1 && m_security_flags.blowfish == 0)
            {
                var seek_index = writer.BaseStream.Seek(0, SeekOrigin.Current);

                writer.BaseStream.Seek(0, SeekOrigin.Begin);
                writer.Write(data_length);
                writer.Flush();

                writer.BaseStream.Seek(seek_index, SeekOrigin.Begin);
            }
        }

        // Return the final data
        return writer.GetBytes();
    }

    private bool HasPacketToSend()
    {
        // No packets, easy case
        if (m_outgoing_packets.Count == 0)
            return false;

        // If we have packets and have accepted the handshake, we can send whenever,
        // so return true.
        if (m_accepted_handshake)
            return true;

        // Otherwise, check to see if we have pending handshake packets to send
        var packet = m_outgoing_packets[0];
        if (packet.Opcode == 0x5000 || packet.Opcode == 0x9000)
            return true;

        // If we get here, we have out of order packets that cannot be sent yet.
        return false;
    }

    private byte[] GetBufferToSend()
    {
        if (m_outgoing_packets.Count == 0)
            throw new HandshakeSecurityException("[SecurityAPI::GetPacketToSend] No packets are avaliable to send.");

        var packet = m_outgoing_packets[0];
        m_outgoing_packets.RemoveAt(0);

        if (packet.Massive)
        {
            ushort parts = 0;

            var final = new PacketWriter();
            var final_data = new PacketWriter();

            var input_data = packet.GetBytes();
            var input_reader = new PacketReader(input_data);

            var workspace = new TransferBuffer(4089, 0, input_data.Length);

            while (workspace.Size > 0)
            {
                var part_data = new PacketWriter();

                var cur_size = workspace.Size > 4089 ? 4089 : workspace.Size; // Max buffer size is 4kb for the client

                part_data.Write((byte)0); // Durability flag

                part_data.Write(input_data, workspace.Offset, cur_size);

                workspace.Offset += cur_size;
                workspace.Size -= cur_size; // Update the size

                final_data.Write(FormatPacket(0x600D, part_data.GetBytes(), false));

                ++parts; // Track how many parts there are
            }

            // Write the final header packet to the front of the packet
            var final_header = new PacketWriter();
            final_header.Write((byte)1); // Header flag
            final_header.Write((short)parts);
            final_header.Write(packet.Opcode);
            final_header.Write((byte)0);
            final.Write(FormatPacket(0x600D, final_header.GetBytes(), false));

            // Finish the large packet of all the data
            final.Write(final_data.GetBytes());

            // Return the collated data
            var raw_bytes = final.GetBytes();
            packet.Lock();
            return raw_bytes;
        }
        else
        {
            var encrypted = packet.Encrypted;
            if (!m_client_security)
                if (m_enc_opcodes.Contains(packet.Opcode))
                    encrypted = true;
            var raw_bytes = FormatPacket(packet.Opcode, packet.GetBytes(), encrypted);
            packet.Lock();
            return raw_bytes;
        }
    }

    #endregion ExtendedSecurityFunctions
}
