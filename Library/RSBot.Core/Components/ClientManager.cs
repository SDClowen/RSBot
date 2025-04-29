using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PeNet;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using static RSBot.Core.Extensions.NativeExtensions;

namespace RSBot.Core.Components;

public class ClientManager
{
    /// <summary>
    ///     The client process
    /// </summary>
    private static Process _process;

    /// <summary>
    ///     Get, has client exited <c>true</c> otherwise; <c>false</c>
    /// </summary>
    public static bool IsRunning => _process != null && !_process.HasExited;

    /// <summary>
    ///     Start the game client
    /// </summary>
    /// <returns>Has successfully started <c>true</c>; otherwise <c>false</c></returns>
    public static async Task<bool> Start()
    {
        var silkroadDirectory = GlobalConfig.Get<string>("RSBot.SilkroadDirectory");
        var path = Path.Combine(
            silkroadDirectory,
            GlobalConfig.Get<string>("RSBot.SilkroadExecutable")
        );

        string libraryDllName = "Client.Library.dll";
        string libraryDllFunc = "_DllMain@12";
        var buffer = Encoding.UTF8.GetBytes(Path.Combine(Kernel.BasePath, libraryDllName));
        var pathLen = (uint)buffer.Length;

        var gatewayIndex = GlobalConfig.Get<byte>("RSBot.GatewayIndex");
        var divisionIndex = GlobalConfig.Get<byte>("RSBot.DivisionIndex");
        var contentId = Game.ReferenceManager.DivisionInfo.Locale;

        var args = $"/{contentId} {divisionIndex} {gatewayIndex} 0";

        var si = new STARTUPINFO();

        var full = $"\"{path}\" {args}";

        if (Game.ClientType == GameClientType.RuSro)
        {
            AddDllImportToClient(path, libraryDllName, libraryDllFunc);
            try
            {
                File.Copy(Path.Combine(Kernel.BasePath, libraryDllName), Path.Combine(silkroadDirectory, libraryDllName), true);
            }
            catch (IOException)
            {
                Log.Debug($"DLL is using, can't replace");
            }
            string login = GlobalConfig.Get<string>("RSBot.RuSro.login");
            string password = GlobalConfig.Get<string>("RSBot.RuSro.password");
            full = $"\"{silkroadDirectory}\\Frost\\sro.exe\" -LOGIN:{login} -PASSWORD:{password} -frostGame \"{path}\" -frostOptions 1 -frostGameNameType silk-ru_live";
            Log.Debug("Full path: " + full);

            var result = CreateProcess(
                null,
                full,
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                0,
                IntPtr.Zero,
                silkroadDirectory,
                ref si,
                out var pi
            );
            if (!result)
                return false;

            Process sroClientProcess;
            var startTime = DateTime.Now;

            do
            {
                sroClientProcess = Process.GetProcessesByName("sro_client")
                    .OrderByDescending(p => p.StartTime)
                    .FirstOrDefault();

                if ((DateTime.Now - startTime).TotalSeconds > 10)
                {
                    Log.Error("sro_client.exe was not started in 10 seconds!");
                    return false;
                }

                Thread.Sleep(10);
            } while (sroClientProcess == null);

            SuspendProcess(sroClientProcess);

            PrepareTempConfigFile((uint)sroClientProcess.Id, divisionIndex);

            ResumeProcess(sroClientProcess);

            var kernelHandle = GetModuleHandleA("kernel32.dll");

            var loadLibAddr = GetProcAddress(kernelHandle, "LoadLibraryA");
            if (loadLibAddr == IntPtr.Zero)
                return false;

            if (sroClientProcess.HasExited)
                return await Task.FromResult(false);

            sroClientProcess.EnableRaisingEvents = true;
            sroClientProcess.Exited += ClientProcess_Exited;
            _process = sroClientProcess;
        }
        else
        {
            var result = CreateProcess(null, full, IntPtr.Zero, IntPtr.Zero, false, CREATE_SUSPENDED, IntPtr.Zero,
            silkroadDirectory, ref si, out var pi);
            if (!result)
                return false;

            PrepareTempConfigFile(pi.dwProcessId, divisionIndex);

            var semaphore = new Semaphore(0, 1, pi.dwProcessId.ToString());

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

            var process = Process.GetProcessById((int)pi.dwProcessId);
            if (process == null || process.HasExited)
                return false;

            if (Game.ClientType == GameClientType.VTC_Game ||
                Game.ClientType == GameClientType.Turkey)
            {
                var moduleMemory = new byte[process.MainModule.ModuleMemorySize];
                ReadProcessMemory(process.Handle, process.MainModule.BaseAddress, moduleMemory,
                    process.MainModule.ModuleMemorySize, out _);

                var patchNop = new byte[] { 0x90, 0x90 };
                var patchNop2 = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 };
                var patchJmp = new byte[] { 0xEB };

                var address = FindPattern(
                    Game.ClientType == GameClientType.Turkey ?
                    "6A 00 68 18 3A 3C 01 68 2C 3A 3C 01" :
                    "6A 00 68 48 A2 38 01 68 5C A2 38 01",
                    moduleMemory);
                if (address == IntPtr.Zero)
                {
                    Log.Error("XIGNCODE patching error! Maybe signatures are wrong?");
                    return false;
                }

                WriteProcessMemory(pi.hProcess, address - 0x6F, patchJmp, 1, out _);
                WriteProcessMemory(pi.hProcess, address + 0x13, patchJmp, 1, out _);
                WriteProcessMemory(pi.hProcess, address + 0xC, patchNop2, 5, out _);
                WriteProcessMemory(pi.hProcess, address + 0x95, patchJmp, 1, out _);

                moduleMemory = null;
                GC.Collect();
            }

            WaitForSingleObject(remoteThread, uint.MaxValue);
            VirtualFreeEx(handle, dereercomp, pathLen, MEM_RELEASE);

            CloseHandle(remoteThread);
            CloseHandle(handle);

            ResumeThread(pi.hThread);
            ResumeThread(pi.hProcess);

            if (process.HasExited)
                return await Task.FromResult(false);

            process.EnableRaisingEvents = true;
            process.Exited += ClientProcess_Exited;
            _process = process;
        }

        EventManager.FireEvent("OnStartClient");

        return await Task.FromResult(true);
    }

    /// <summary>
    ///     Kill the game client process
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
    ///     Change client process title
    /// </summary>
    /// <param name="title">The new title</param>
    public static void SetTitle(string title)
    {
        if (_process == null)
            return;

        SetWindowText(_process.MainWindowHandle, title);
    }

    /// <summary>
    ///     Change client visible
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
    ///     Observes the process.
    /// </summary>
    private static void ClientProcess_Exited(object sender, EventArgs e)
    {
        Log.Warn("Client process exited!");
        EventManager.FireEvent("OnExitClient");
    }

    /// <summary>
    ///     Prepare the config file for loader
    /// </summary>
    /// <param name="processId"></param>
    /// <param name="divisionIndex"></param>
    private static void PrepareTempConfigFile(uint processId, int divisionIndex)
    {
        var tmpConfigFile = $"RSBot_{processId}.tmp";

        var division = Game.ReferenceManager.DivisionInfo.Divisions[divisionIndex];
        var gatewayPort = Game.ReferenceManager.GatewayInfo.Port;

        var redirectIp = "127.0.0.1";
        using var writer =
            new BinaryWriter(new FileStream(Path.Combine(Path.GetTempPath(), tmpConfigFile), FileMode.OpenOrCreate));

        writer.Write(GlobalConfig.Get<bool>("RSBot.Loader.DebugMode"));
        writer.WriteAscii(redirectIp);
        writer.Write(Kernel.Proxy.Port);
        writer.Write(division.GatewayServers.Count);
        foreach (var gatewayServer in division.GatewayServers)
            writer.WriteAscii(gatewayServer);

        writer.Write(gatewayPort);
    }

    private static IntPtr FindPattern(string stringPattern, byte[] buffer)
    {
        var pattern = stringPattern.Split(' ')
            .Select(p => byte.Parse(p, NumberStyles.AllowHexSpecifier))
            .ToArray();

        for (uint i = 0; i < buffer.Length - pattern.Length; i++)
        {
            var found = true;
            for (uint j = 0; j < pattern.Length; j++)
                if (buffer[i + j] != pattern[j])
                {
                    found = false;
                    break;
                }

            if (found)
                return (IntPtr)(0x400000 + i);
        }

        return IntPtr.Zero;
    }

    private static void SuspendProcess(Process process)
    {
        foreach (ProcessThread thread in process.Threads)
        {
            IntPtr threadHandle = OpenThread(THREAD_SUSPEND_RESUME, false, (uint)thread.Id);
            if (threadHandle != IntPtr.Zero)
            {
                SuspendThread(threadHandle);
                CloseHandle(threadHandle);
            }
        }
    }

    private static void ResumeProcess(Process process)
    {
        foreach (ProcessThread thread in process.Threads)
        {
            IntPtr threadHandle = OpenThread(THREAD_SUSPEND_RESUME, false, (uint)thread.Id);
            if (threadHandle != IntPtr.Zero)
            {
                ResumeThread(threadHandle);
                CloseHandle(threadHandle);
            }
        }
    }

    private static void AddDllImportToClient(string exePath, string dllName, string funcName)
    {
        var peFile = new PeFile(exePath);
        bool isDllInjected = false;

        foreach (var imp in peFile.ImportedFunctions)
        {
            if (imp.DLL.Contains(dllName, StringComparison.OrdinalIgnoreCase))
                isDllInjected = true;
        }

        if (!isDllInjected)
        {
            peFile.AddImport(dllName, funcName);
            File.WriteAllBytes(exePath, peFile.RawFile.ToArray());
            Log.Debug($"Client {exePath} was patched with {dllName}");
        }
        else
        { 
            Log.Debug($"Client {exePath} is already patched with {dllName}. Patching skipped"); 
        }
    }
}
