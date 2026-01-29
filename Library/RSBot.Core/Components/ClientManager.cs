using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

    private static string GetSignature(GameClientType type)
    {
        return type switch
        {
            GameClientType.Turkey => "6A 00 68 78 18 43 01 68 8C 18 43 01",
            GameClientType.VTC_Game => "6A 00 68 F8 91 3F 01 68 0C 92 3F 01",
            GameClientType.Taiwan => "6A 00 68 30 58 43 01 68 44 58 43 01",
            _ => throw new ArgumentOutOfRangeException(nameof(type)),
        };
    }

    /// <summary>
    ///     Start the game client
    /// </summary>
    /// <returns>Has successfully started <c>true</c>; otherwise <c>false</c></returns>
    public static async Task<bool> Start()
    {
        var silkroadDirectory = GlobalConfig.Get<string>("RSBot.SilkroadDirectory");
        var path = Path.Combine(silkroadDirectory, GlobalConfig.Get<string>("RSBot.SilkroadExecutable"));

        string libraryDllName = "Client.Library.dll";
        var buffer = Encoding.UTF8.GetBytes(Path.Combine(Kernel.BasePath, libraryDllName));
        var pathLen = (uint)buffer.Length;

        var gatewayIndex = GlobalConfig.Get<byte>("RSBot.GatewayIndex");
        var divisionIndex = GlobalConfig.Get<byte>("RSBot.DivisionIndex");
        var contentId = Game.ReferenceManager.DivisionInfo.Locale;

        var args = $"/{contentId} {divisionIndex} {gatewayIndex} 0";

        var si = new STARTUPINFO();

        if (
            Game.ClientType == GameClientType.RuSro
            || Game.ClientType == GameClientType.Global
            || Game.ClientType == GameClientType.Korean
            || Game.ClientType == GameClientType.VTC_Game
            || Game.ClientType == GameClientType.Turkey
            || Game.ClientType == GameClientType.Taiwan
            || Game.ClientType == GameClientType.Japanese
        )
        {
            try
            {
                File.Copy(
                    Path.Combine(Kernel.BasePath, libraryDllName), 
                    Path.Combine(silkroadDirectory, "d3d9.dll"), 
                    true
                );
            }
            catch (IOException)
            {
                Log.Debug("DLL is using, can't replace");
            }

            if (Game.ClientType == GameClientType.RuSro)
            {
                string login = GlobalConfig.Get<string>("RSBot.RuSro.login");
                string password = GlobalConfig.Get<string>("RSBot.RuSro.password");
                args = $"-LOGIN:{login} -PASSWORD:{password}";
            }

            uint creationFlags = 0;
            if (
                Game.ClientType == GameClientType.VTC_Game
                || Game.ClientType == GameClientType.Turkey
                || Game.ClientType == GameClientType.Taiwan
            )
            {
                creationFlags = CREATE_SUSPENDED; //for XIGNCODE patching
            }

            var result = CreateProcess(
                null,
                $"\"{path}\" {args}",
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                creationFlags,
                IntPtr.Zero,
                silkroadDirectory,
                ref si,
                out var pi
            );
            if (!result)
                return false;

            PrepareTempConfigFile(pi.dwProcessId, divisionIndex);

            Process sroProcess = Process.GetProcessById((int)pi.dwProcessId);

            if (creationFlags == CREATE_SUSPENDED)
            {
                ApplyXigncodePatch(sroProcess, pi);
                ResumeThread(pi.hThread);
            }

            _process = sroProcess;
            _process.EnableRaisingEvents = true;
            _process.Exited += ClientProcess_Exited;

            return true;
        }
        else
        {
            var result = CreateProcess(
                null,
                $"\"{path}\" {args}",
                IntPtr.Zero,
                IntPtr.Zero,
                false,
                CREATE_SUSPENDED,
                IntPtr.Zero,
                silkroadDirectory,
                ref si,
                out var pi
            );
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
    /// Applies an in-memory patch to the XIGNCODE module of the specified process.
    /// </summary>
    /// <param name="process">The target process to which the XIGNCODE patch will be applied. Must be running and accessible.</param>
    /// <param name="pi">The process information structure containing handles and thread information for the target process.</param>
    private static void ApplyXigncodePatch(Process process, PROCESS_INFORMATION pi)
    {
        ResumeThread(pi.hThread);
        Thread.Sleep(150);
        SuspendThread(pi.hThread);

        var moduleMemory = new byte[process.MainModule.ModuleMemorySize];
        ReadProcessMemory(
            process.Handle,
            process.MainModule.BaseAddress,
            moduleMemory,
            process.MainModule.ModuleMemorySize,
            out _
        );

        var patchNop = new byte[] { 0x90, 0x90 };
        var patchNop2 = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 };
        var patchJmp = new byte[] { 0xEB };

        string signature = GetSignature(Game.ClientType);

        int baseAddress = process.MainModule.BaseAddress.ToInt32();
        var address = FindPattern(signature, moduleMemory, baseAddress);
        if (address == IntPtr.Zero)
        {
            Log.Error("XIGNCODE patching error! Maybe signatures are wrong?");
        }

        WriteProcessMemory(pi.hProcess, address - 0x6F, patchJmp, 1, out _);
        WriteProcessMemory(pi.hProcess, address + 0x13, patchJmp, 1, out _);
        WriteProcessMemory(pi.hProcess, address + 0xC, patchNop2, 5, out _);
        WriteProcessMemory(pi.hProcess, address + 0x95, patchJmp, 1, out _);
        
        GC.Collect();
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
        catch { }
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
        using var writer = new BinaryWriter(
            new FileStream(Path.Combine(Path.GetTempPath(), tmpConfigFile), FileMode.OpenOrCreate)
        );

        writer.Write(GlobalConfig.Get<bool>("RSBot.Loader.DebugMode"));
        writer.WriteAscii(redirectIp);
        writer.Write(Kernel.Proxy.Port);
        writer.Write(division.GatewayServers.Count);
        foreach (var gatewayServer in division.GatewayServers)
            writer.WriteAscii(gatewayServer);

        writer.Write(gatewayPort);
    }

    /// <summary>
    ///     Searches the specified buffer for the first occurrence of a byte pattern defined by a hexadecimal string and
    ///     returns the corresponding memory address.
    /// </summary>
    /// <param name="stringPattern"></param>
    /// <param name="buffer"></param>
    /// <param name="baseAddress"></param>
    /// <returns></returns>
    private static IntPtr FindPattern(string stringPattern, byte[] buffer, int baseAddress)
    {
        var pattern = stringPattern.Split(' ').Select(p => byte.Parse(p, NumberStyles.AllowHexSpecifier)).ToArray();

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
                return (IntPtr)(baseAddress + i);
        }

        return IntPtr.Zero;
    }
}
