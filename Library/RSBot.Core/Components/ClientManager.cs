using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RSBot.Core.Event;
using RSBot.Core.Extensions;
using static RSBot.Core.Extensions.NativeExtensions;

namespace RSBot.Core.Components;

public class ClientManager
{
    private static Process _process;
    private static readonly string GitHubSignatureUrl =
        "https://raw.githubusercontent.com/myildirimofficial/rsbot/master/client-signatures.cfg";

    private static readonly HttpClient _httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(10)
    };

    /// <summary>
    /// Get, has client exited <c>true</c> otherwise; <c>false</c>
    /// </summary>
    public static bool IsRunning => _process?.HasExited == false;

    /// <summary>
    /// Loads client signatures from GitHub repository
    /// </summary>
    private static async Task<Dictionary<GameClientType, string>> LoadSignaturesFromGitHub()
    {
        var signatures = new Dictionary<GameClientType, string>();

        try
        {
            Log.Notify("Fetching client signatures from GitHub...");
            var response = await _httpClient.GetStringAsync(GitHubSignatureUrl);

            foreach (var line in response.Split('\n'))
            {
                var trimmedLine = line.Trim();

                // Skip empty lines and comments
                if (string.IsNullOrWhiteSpace(trimmedLine) ||
                    trimmedLine.StartsWith("#") ||
                    trimmedLine.StartsWith("//"))
                    continue;

                var parts = trimmedLine.Split('=', 2);
                if (parts.Length != 2)
                    continue;

                var clientTypeName = parts[0].Trim();
                var signature = parts[1].Replace('"', ' ').Trim();

                if (Enum.TryParse<GameClientType>(clientTypeName, true, out var clientType))
                {
                    signatures[clientType] = signature;
                }
                else
                {
                    Log.Warn($"Unknown client type in signatures: {clientTypeName}");
                }
            }

            Log.Notify($"Successfully loaded {signatures.Count} client signatures from GitHub");
        }
        catch (HttpRequestException ex)
        {
            Log.Error($"Failed to fetch signatures from GitHub: {ex.Message}");

            return [];
        }
        catch (Exception ex)
        {
            Log.Error($"Unexpected error loading signatures: {ex.Message}");
            return [];
        }

        return signatures;
    }

    /// <summary>
    /// Gets the signature for the specified client type
    /// </summary>
    private static async Task<string> GetSignature(GameClientType type, Dictionary<GameClientType, string> signatures)
    {
        if (signatures.TryGetValue(type, out var signature))
            return signature;

        throw new ArgumentOutOfRangeException(nameof(type),
            $"No signature found for client type: {type}");
    }

    /// <summary>
    /// Start the game client
    /// </summary>
    /// <returns>Has successfully started <c>true</c>; otherwise <c>false</c></returns>
    public static async Task<bool> Start()
    {
        var silkroadDirectory = GlobalConfig.Get<string>("RSBot.SilkroadDirectory");
        var executable = GlobalConfig.Get<string>("RSBot.SilkroadExecutable");
        var path = Path.Combine(silkroadDirectory, executable);

        if (!File.Exists(path))
        {
            Log.Error($"Silkroad executable not found: {path}");
            return false;
        }

        var libraryDllName = "Client.Library.dll";
        var fullPath = Path.Combine(Kernel.BasePath, libraryDllName);

        if (!File.Exists(fullPath))
        {
            Log.Error($"Client library not found: {fullPath}");
            return false;
        }

        // UTF-16 + null terminator
        var buffer = Encoding.Unicode.GetBytes(fullPath + "\0");
        var pathLen = (uint)buffer.Length;

        var gatewayIndex = GlobalConfig.Get<byte>("RSBot.GatewayIndex");
        var divisionIndex = GlobalConfig.Get<byte>("RSBot.DivisionIndex");
        var contentId = Game.ReferenceManager.DivisionInfo.Locale;

        var args = BuildCommandLineArguments(contentId, divisionIndex, gatewayIndex);

        var si = new STARTUPINFO();

        // Create suspended process
        if (!CreateProcess(
            null,
            $"\"{path}\" {args}",
            IntPtr.Zero,
            IntPtr.Zero,
            false,
            CREATE_SUSPENDED,
            IntPtr.Zero,
            silkroadDirectory,
            ref si,
            out var pi))
        {
            Log.Error("Failed to create game process");
            return false;
        }

        try
        {
            PrepareTempConfigFile(pi.dwProcessId, divisionIndex);

            var sroProcess = Process.GetProcessById((int)pi.dwProcessId);

            if (RequiresXigncodePatch(Game.ClientType) && !await ApplyXigncodePatch(sroProcess, pi))
                return false;

            _process = sroProcess;

            if (!InjectClientLibrary(pi, buffer, pathLen))
            {
                CleanupProcess(pi);
                return false;
            }

            ResumeThread(pi.hThread);
            ResumeThread(pi.hProcess);

            _process = Process.GetProcessById((int)pi.dwProcessId);
            if (_process?.HasExited != false)
            {
                Log.Error("Process exited immediately after start");
                return false;
            }

            _process.EnableRaisingEvents = true;
            _process.Exited += ClientProcess_Exited;

            EventManager.FireEvent("OnStartClient");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to start client: {ex.Message}");
            CleanupProcess(pi);
            return false;
        }
    }

    /// <summary>
    /// Builds command line arguments based on client type
    /// </summary>
    private static string BuildCommandLineArguments(byte contentId, byte divisionIndex, byte gatewayIndex)
    {
        if (Game.ClientType == GameClientType.RuSro)
        {
            var login = GlobalConfig.Get<string>("RSBot.RuSro.login");
            var password = GlobalConfig.Get<string>("RSBot.RuSro.password");
            return $"-LOGIN:{login} -PASSWORD:{password}";
        }

        return $"/{contentId} {divisionIndex} {gatewayIndex} 0";
    }

    /// <summary>
    /// Checks if the client type requires XIGNCODE patching
    /// </summary>
    private static bool RequiresXigncodePatch(GameClientType clientType)
    {
        return clientType == GameClientType.VTC_Game
            || clientType == GameClientType.Turkey
            || clientType == GameClientType.Taiwan;
    }

    /// <summary>
    /// Injects the client library into the target process
    /// </summary>
    private static bool InjectClientLibrary(PROCESS_INFORMATION pi, byte[] buffer, uint pathLen)
    {
        var handle = OpenProcess(PROCESS_ALL_ACCESS, false, pi.dwProcessId);
        if (handle == IntPtr.Zero)
        {
            Log.Error("Failed to open process");
            return false;
        }

        try
        {
            var kernelHandle = GetModuleHandleW("kernel32.dll");
            if (kernelHandle == IntPtr.Zero)
            {
                Log.Error("Failed to get kernel32.dll handle");
                return false;
            }

            var loadLibAddr = GetProcAddress(kernelHandle, "LoadLibraryW");
            if (loadLibAddr == IntPtr.Zero)
            {
                Log.Error("Failed to get LoadLibraryW address");
                return false;
            }

            var remotePath = VirtualAllocEx(
                handle,
                IntPtr.Zero,
                pathLen,
                MEM_COMMIT | MEM_RESERVE,
                PAGE_READWRITE);

            if (remotePath == IntPtr.Zero)
            {
                Log.Error("Failed to allocate remote memory");
                return false;
            }

            try
            {
                if (!WriteProcessMemory(handle, remotePath, buffer, pathLen, out _))
                {
                    Log.Error("Failed to write library path to remote process");
                    return false;
                }

                var remoteThread = CreateRemoteThread(
                    handle,
                    IntPtr.Zero,
                    0,
                    loadLibAddr,
                    remotePath,
                    0,
                    IntPtr.Zero);

                if (remoteThread == IntPtr.Zero)
                {
                    Log.Error("Failed to create remote thread");
                    return false;
                }

                try
                {
                    WaitForSingleObject(remoteThread, uint.MaxValue);
                    return true;
                }
                finally
                {
                    CloseHandle(remoteThread);
                }
            }
            finally
            {
                VirtualFreeEx(handle, remotePath, 0, MEM_RELEASE);
            }
        }
        finally
        {
            CloseHandle(handle);
        }
    }

    /// <summary>
    /// Applies an in-memory patch to the XIGNCODE module of the specified process
    /// </summary>
    private static async Task<bool> ApplyXigncodePatch(Process process, PROCESS_INFORMATION pi)
    {
        try
        {
            var signatures = await LoadSignaturesFromGitHub();
            if (signatures.Count == 0)
            {
                Log.Error("No client signatures loaded. Cannot start client.");
                return false;
            }

            ResumeThread(pi.hThread);
            await Task.Delay(250);
            SuspendThread(pi.hThread);

            var moduleMemory = new byte[process.MainModule.ModuleMemorySize];
            if (!ReadProcessMemory(
                process.Handle,
                process.MainModule.BaseAddress,
                moduleMemory,
                process.MainModule.ModuleMemorySize,
                out _))
            {
                Log.Error("Failed to read process memory for XIGNCODE patch");
                return false;
            }

            var signature = await GetSignature(Game.ClientType, signatures);
            var baseAddress = process.MainModule.BaseAddress.ToInt32();
            var address = FindPattern(signature, moduleMemory, baseAddress);

            if (address == IntPtr.Zero)
            {
                Log.Error("XIGNCODE patching failed! Signature not found.");
                Log.Error($"Please check if the signature for {Game.ClientType} is correct in the GitHub repository.");
                return false;
            }

            // Apply patches
            var patchJmp = new byte[] { 0xEB };
            var patchNop2 = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 };

            WriteProcessMemory(pi.hProcess, address - 0x6F, patchJmp, 1, out _);
            WriteProcessMemory(pi.hProcess, address + 0x13, patchJmp, 1, out _);
            WriteProcessMemory(pi.hProcess, address + 0xC, patchNop2, 5, out _);
            WriteProcessMemory(pi.hProcess, address + 0x95, patchJmp, 1, out _);

            Log.Notify("XIGNCODE patch applied successfully");
        }
        catch (Exception ex)
        {
            Log.Error($"XIGNCODE patching exception: {ex.Message}");
        }
        finally
        {
            GC.Collect();
        }

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
        catch (Exception ex)
        {
            Log.Error($"Failed to kill client process: {ex.Message}");
        }
    }

    /// <summary>
    /// Change client process title
    /// </summary>
    public static void SetTitle(string title)
    {
        if (_process?.MainWindowHandle != IntPtr.Zero)
            SetWindowText(_process.MainWindowHandle, title);
    }

    /// <summary>
    /// Change client visibility
    /// </summary>
    public static void SetVisible(bool visible)
    {
        if (_process?.MainWindowHandle == IntPtr.Zero)
            return;

        ShowWindow(_process.MainWindowHandle, visible ? SW_SHOW : SW_HIDE);
    }

    /// <summary>
    /// Handles client process exit event
    /// </summary>
    private static void ClientProcess_Exited(object sender, EventArgs e)
    {
        Log.Warn("Client process exited!");
        EventManager.FireEvent("OnExitClient");
    }

    /// <summary>
    /// Prepare the config file for loader
    /// </summary>
    private static void PrepareTempConfigFile(uint processId, int divisionIndex)
    {
        try
        {
            var tmpConfigFile = $"RSBot_{processId}.tmp";
            var division = Game.ReferenceManager.DivisionInfo.Divisions[divisionIndex];
            var gatewayPort = Game.ReferenceManager.GatewayInfo.Port;
            var redirectIp = "127.0.0.1";

            using var writer = new BinaryWriter(
                new FileStream(
                    Path.Combine(Path.GetTempPath(), tmpConfigFile),
                    FileMode.Create));

            writer.Write(GlobalConfig.Get<bool>("RSBot.Loader.DebugMode"));
            writer.WriteAscii(redirectIp);
            writer.Write(Kernel.Proxy.Port);
            writer.Write(division.GatewayServers.Count);

            foreach (var gatewayServer in division.GatewayServers)
                writer.WriteAscii(gatewayServer);

            writer.Write(gatewayPort);
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to prepare temp config file: {ex.Message}");
        }
    }

    /// <summary>
    /// Searches the specified buffer for the first occurrence of a byte pattern
    /// </summary>
    private static IntPtr FindPattern(string stringPattern, byte[] buffer, int baseAddress)
    {
        try
        {
            var pattern = stringPattern
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(p => byte.Parse(p, NumberStyles.AllowHexSpecifier))
                .ToArray();

            var patternLength = pattern.Length;
            var searchLength = buffer.Length - patternLength;

            for (var i = 0; i < searchLength; i++)
            {
                var found = true;
                for (var j = 0; j < patternLength; j++)
                {
                    if (buffer[i + j] != pattern[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                    return (IntPtr)(baseAddress + i);
            }
        }
        catch (Exception ex)
        {
            Log.Error($"Pattern search failed: {ex.Message}");
        }

        return IntPtr.Zero;
    }

    /// <summary>
    /// Cleanup process handles
    /// </summary>
    private static void CleanupProcess(PROCESS_INFORMATION pi)
    {
        try
        {
            if (pi.hThread != IntPtr.Zero)
                CloseHandle(pi.hThread);

            if (pi.hProcess != IntPtr.Zero)
            {
                var process = Process.GetProcessById((int)pi.dwProcessId);
                process?.Kill();
                CloseHandle(pi.hProcess);
            }
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to cleanup process: {ex.Message}");
        }
    }
}
