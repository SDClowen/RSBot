using RSBot.Core.Event;
using RSBot.Core.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RSBot.Core.Extensions.NativeExtensions;

namespace RSBot.Core
{
    public class ClientManager
    {
        /// <summary>
        /// The client process
        /// </summary>
        private static Process _process;

        /// <summary>
        /// Get, has client exited <c>true</c> otherwise; <c>false</c>
        /// </summary>
        public static bool IsRunning => _process != null && !_process.HasExited;

        /// <summary>
        /// Start the game client
        /// </summary>
        /// <returns>Has successfully started <c>true</c>; otherwise <c>false</c></returns>
        public static async Task<bool> Start()
        {
            var silkroadDirectory = GlobalConfig.Get<string>("RSBot.SilkroadDirectory");
            var path = Path.Combine(
                silkroadDirectory, 
                GlobalConfig.Get<string>("RSBot.SilkroadExecutable")
            );

            var buffer = Encoding.UTF8.GetBytes(Path.Combine(Environment.CurrentDirectory, "Client.Library.dll"));
            var pathLen = (uint)buffer.Length;

            var gatewayIndex = GlobalConfig.Get<byte>("RSBot.GatewayIndex");
            var divisionIndex = GlobalConfig.Get<byte>("RSBot.DivisionIndex");
            byte contentId = Game.ReferenceManager.DivisionInfo.Locale;

            var args = $"/{contentId} {divisionIndex} {gatewayIndex} 0";

            var si = new STARTUPINFO();

            var full = $"\"{path}\" {args}";
            bool result = CreateProcess(null, full, IntPtr.Zero, IntPtr.Zero, false, CREATE_SUSPENDED, IntPtr.Zero, silkroadDirectory, ref si, out var pi);
            if (!result)
                return false;

            PrepareTempConfigFile(pi.dwProcessId, divisionIndex);

            //CreateSemaphore(IntPtr.Zero, 0, 1,
            //System.Runtime.InteropServices.Marshal.StringToHGlobalAuto(pi.dwProcessId.ToString()));
            //var semaphore = new Semaphore(0, 1, pi.dwProcessId.ToString());

            var handle = OpenProcess(PROCESS_ALL_ACCESS, false, pi.dwProcessId);
            if (handle == IntPtr.Zero)
                return false;

            var kernelHandle = GetModuleHandleA("kernel32.dll");
            
            var loadLibAddr = GetProcAddress(kernelHandle, "LoadLibraryA");
            if (loadLibAddr == IntPtr.Zero)
                return false;

            var dereercomp = VirtualAllocEx(handle, IntPtr.Zero, pathLen, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            if (dereercomp == IntPtr.Zero)
                return false;

            if (!WriteProcessMemory(handle, dereercomp, buffer, pathLen, out var numberOfBytesWritten))
                return false;

            var remoteThread = CreateRemoteThread(handle, IntPtr.Zero, 0, loadLibAddr, dereercomp, 0, IntPtr.Zero);
            if (remoteThread == IntPtr.Zero)
                return false;

            WaitForSingleObject(remoteThread, uint.MaxValue);
            VirtualFreeEx(handle, dereercomp, pathLen, MEM_RELEASE);

            CloseHandle(remoteThread);
            CloseHandle(handle);

            ResumeThread(pi.hThread);
            ResumeThread(pi.hProcess);

            var process = Process.GetProcessById((int)pi.dwProcessId);
            if(process == null)
                return false;

            process.EnableRaisingEvents = true;
            process.Exited += ClientProcess_Exited;
            _process = process;

            EventManager.FireEvent("OnStartClient");

            await Task.Yield();

            return true;
        }

        /// <summary>
        /// Kill the game client process
        /// </summary>
        public static void Kill()
        {
            if (!IsRunning)
                return;

            try
            {
                _process.Kill();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Change client process title
        /// </summary>
        /// <param name="title">The new title</param>
        public static void SetTitle(string title)
        {
            if (_process == null)
                return;

            SetWindowText(_process.MainWindowHandle, title);
        }

        /// <summary>
        /// Change client visible
        /// </summary>
        /// <param name="visible">The visible</param>
        public static void SetVisible(bool visible)
        {
            if (visible)
                ShowWindow(_process.MainWindowHandle, SW_SHOW);
            else
                ShowWindow(_process.MainWindowHandle, SW_HIDE);
        }

        /// <summary>
        /// Observes the process.
        /// </summary>
        private static void ClientProcess_Exited(object sender, EventArgs e)
        {
            Log.Warn("Client process exited!");
            EventManager.FireEvent("OnExitClient");
            _process = null;
        }

        /// <summary>
        /// Prepare the config file for loader
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="divisionIndex"></param>
        private static void PrepareTempConfigFile(uint processId, int divisionIndex)
        {
            var tmpConfigFile = $"RSBot_{processId}.tmp";

            var division = Game.ReferenceManager.DivisionInfo.Divisions[divisionIndex];
            var gatewayPort = Game.ReferenceManager.GatewayInfo.Port;

            var redirectIp = "127.0.0.1";
            using (var writer = new BinaryWriter(new FileStream(Path.Combine(Path.GetTempPath(), tmpConfigFile), FileMode.Create)))
            {
                writer.Write(GlobalConfig.Get<bool>("RSBot.Loader.DebugMode"));
                writer.WriteAscii(redirectIp);
                writer.Write(Kernel.Proxy.Port);
                writer.Write(division.GatewayServers.Count);
                foreach (var gatewayServer in division.GatewayServers)
                    writer.WriteAscii(gatewayServer);

                writer.Write(gatewayPort);
            }
        }
    }
}
