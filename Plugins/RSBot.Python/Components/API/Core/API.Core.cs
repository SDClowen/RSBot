using RSBot.Python.Components.API.Interface;
using RSBot.Python.Views;
using System;
using System.Linq;
using Python.Runtime;
using RSBot.Core;
using RSBot.Core.Network;

namespace RSBot.Python.Components.API.Core
{
    /// <summary>
    /// Core-Functions for Python like logging, info, char data and start/stop.
    /// </summary>
    public class CoreAPI : IPythonPlugin
    {
        private Main _main;

        /// <summary>
        /// Unique module name of the plugin.
        /// </summary>
        public string ModuleName => "core";

        /// <summary>
        /// Called once at startup to provide the main form to the plugin.
        /// </summary>
        /// <param name="main">Main form</param>
        public void Init(Main main)
        {
            _main = main;
        }

        private bool StartBot()
        {
            try
            {
                if (Kernel.Proxy == null)
                    return false;

                if (!Kernel.Proxy.IsConnectedToAgentserver)
                    return false;

                if (Kernel.Bot == null)
                {
                    return false;
                }

                if (Game.Player == null)
                {
                    return false;
                }

                if (!Kernel.Bot.Running)
                {
                    Kernel.Bot.Start();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Log.Error($"[Python-API] Error while trying to start the bot from Plugin: {ex}" );
                return false;
            }
        }
        private bool StopBot()
        {
            try
            {
                if (Kernel.Proxy == null)
                    return false;

                if (!Kernel.Proxy.IsConnectedToAgentserver)
                    return false;

                if (Kernel.Bot == null)
                {
                    return false;
                }

                if (Game.Player == null)
                {
                    return false;
                }

                if (Kernel.Bot.Running)
                {
                    Kernel.Bot.Stop();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.Error($"[Python-API] Error while trying to stop the bot from Plugin: {ex}");
                return false;
            }
        }
        private void SendServer(ushort opcode, byte[] data, bool encrypted = false)
        {
            Packet packet = new Packet(opcode,encrypted);
            packet.WriteBytes(data);
            PacketManager.SendPacket(packet, PacketDestination.Server);
        }
        private void SendClient(ushort opcode, byte[] data, bool encrypted = false)
        {
            Packet packet = new Packet(opcode, encrypted);
            packet.WriteBytes(data);
            PacketManager.SendPacket(packet, PacketDestination.Client);
        }
        public void log(params object[] args)
        {
            if (args == null || args.Length == 0)
            {
                _main?.AppendLog(string.Empty);
                return;
            }

            string msg = string.Join(" ", args.Select(a =>
            {
                if (a == null) return "None";

                if (a is PyObject pyObj)
                {
                    using (Py.GIL())
                    {
                        return pyObj.ToString();
                    }
                }
                return a.ToString();
            }));

            _main?.AppendLog(msg);
        }
        public bool start_bot()
        {
            return StartBot();
        }
        public bool stop_bot()
        {
            return StopBot();
        }
        public void send_server(ushort opcode, byte[] data, bool encrypted)
        {
            SendServer(opcode, data, encrypted);
        }
        public void send_client(ushort opcode, byte[] data, bool encrypted)
        {
            SendClient(opcode, data, encrypted);
        }
    }
}
