using RSBot.Core.Event;
using RSBot.Core.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace RSBot.Core.Plugins;

public class ExtensionManager
{
    /// <summary>
    ///     Gets the extension directory for plugins.
    /// </summary>
    private static readonly string _directoryForPlugins = Path.Combine(Kernel.BasePath, "Data", "Plugins");

    /// <summary>
    ///     Gets the extension directory for botbases.
    /// </summary>
    private static readonly string _directoryForBotbases = Path.Combine(Kernel.BasePath, "Data", "Bots");

    /// <summary>
    ///     Gets the extensions.
    /// </summary>
    private static readonly List<IExtension> _extensions = [];

    /// <summary>
    ///    Gets the plugins.
    /// </summary>
    public static IEnumerable<IPlugin> Plugins => _extensions.OfType<IPlugin>().OrderBy(p => p.Index);

    /// <summary>
    /// Gets the botbases.
    /// </summary>
    public static IEnumerable<IBotbase> Bots => _extensions.OfType<IBotbase>();

    /// <summary>
    ///     Gets the packet handlers registered by plugins.
    /// </summary>
    private static Dictionary<string, List<IPacketHandler>> PluginHandlers { get; set; } = [];

    /// <summary>
    ///     Gets the packet hooks registered by plugins.
    /// </summary>
    private static Dictionary<string, List<IPacketHook>> PluginHooks { get; set; } = [];

    /// <summary>
    ///     HTTP client for downloading plugins from web.
    /// </summary>
    private static readonly HttpClient HttpClient = new()
    {
        Timeout = TimeSpan.FromMinutes(5)
    };

    /// <summary>
    ///     Event for download progress updates.
    /// </summary>
    public static event EventHandler<DownloadProgressEventArgs> DownloadProgressChanged;

    /// <summary>
    /// Loads the assemblies.
    /// </summary>
    public static bool LoadAssemblies<T>() where T : IExtension
    {
        try
        {
            var name = typeof(T).Name;

            foreach (var extension in from file in
                                          Directory.GetFiles(name == "IPlugin" ? _directoryForPlugins : _directoryForBotbases)
                                      let fileInfo = new FileInfo(file)
                                      where fileInfo.Extension == ".dll"
                                      select GetExtensionsFromAssembly<T>(file)
                                      into loadedExtensions
                                      from extension in loadedExtensions
                                      select extension)
            {
                _extensions.Add(extension);
                Log.Debug($"Loaded {name} [{extension.Name}]");
            }

            if (name == "IPlugin")
                EventManager.FireEvent("OnLoadPlugins");
            else
                EventManager.FireEvent("OnLoadBotbases");

            return true;
        }
        catch (Exception ex)
        {
            File.WriteAllText(Kernel.BasePath + "\\boot-error.log",
                $"The plugin manager encountered a problem: \n{ex.Message} at {ex.StackTrace}");
            return false;
        }
    }

    /// <summary>
    ///     Gets the extensions from assembly.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns></returns>
    private static List<T> GetExtensionsFromAssembly<T>(string file)
        where T : IExtension
    {
        var result = new List<T>();

        var assembly = Assembly.LoadFrom(file);

        try
        {
            var disabledList = LoadDisabledPlugins();
            var assemblyTypes = assembly.GetTypes();

            foreach (var extension in (from type in assemblyTypes
                                       where type.IsPublic && !type.IsAbstract && type.GetInterface(typeof(T).Name) != null
                                       select Activator.CreateInstance(type)).OfType<T>())
            {
                result.Add(extension);

                var plugin = extension as IExtension;
                plugin.Enabled = !disabledList.Contains(plugin.Name);
            }

            if (result.Count == 0)
                return result;

            var handlerType = typeof(IPacketHandler);
            var hookType = typeof(IPacketHook);

            var types = assemblyTypes
                .Where(p => handlerType.IsAssignableFrom(p) && !p.IsInterface);

            var handlers = new List<IPacketHandler>();
            foreach (var handler in types)
            {
                var instance = (IPacketHandler)Activator.CreateInstance(handler);
                PacketManager.RegisterHandler(instance);
                handlers.Add(instance);
            }

            types = assemblyTypes
                .Where(p => hookType.IsAssignableFrom(p) && !p.IsInterface);

            var hooks = new List<IPacketHook>();
            foreach (var hook in types)
            {
                var instance = (IPacketHook)Activator.CreateInstance(hook);
                PacketManager.RegisterHook(instance);
                hooks.Add(instance);
            }

            // Store handlers and hooks for each plugin
            foreach (var plugin in result)
            {
                PluginHandlers[plugin.Name] = handlers;
                PluginHooks[plugin.Name] = hooks;
            }
        }
        catch
        {
            /* ignore, it's an invalid extension */
        }

        return result;
    }

    /// <summary>
    /// Returns the directory path associated with the specified extension type parameter.
    /// </summary>
    /// <typeparam name="T">The extension type for which to retrieve the directory path. Must implement the IExtension interface.</typeparam>
    /// <returns>The directory path for the specified extension type. Returns the plugin directory if T is IPlugin; otherwise,
    /// returns the botbase directory.</returns>
    private static string getPath<T>() where T : IExtension
    {
        return typeof(T) == typeof(IPlugin) ? _directoryForPlugins : _directoryForBotbases;
    }

    /// <summary>
    ///     Downloads a plugin from a URL.
    /// </summary>
    /// <param name="url">The URL to download from.</param>
    /// <param name="targetFileName">The target file name (without path).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The path to the downloaded file, or null if failed.</returns>
    public static async Task<string> DownloadPluginFromWeb<T>(string url, string targetFileName = null, CancellationToken cancellationToken = default)
        where T : IExtension
    {
        try
        {
            Log.Notify($"Starting download from: {url}");

            using var response = await HttpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength ?? 0;
            var fileName = targetFileName ?? Path.GetFileName(url);

            if (string.IsNullOrEmpty(fileName) || !fileName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                fileName = "plugin_" + DateTime.Now.Ticks + ".dll";

            var targetPath = Path.Combine(getPath<T>(), fileName);
            var tempPath = targetPath + ".tmp";

            using (var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken))
            using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
            {
                var buffer = new byte[8192];
                long totalRead = 0;
                int bytesRead;

                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead, cancellationToken);
                    totalRead += bytesRead;

                    if (totalBytes > 0)
                    {
                        var progress = (int)((totalRead * 100) / totalBytes);
                        DownloadProgressChanged?.Invoke(null, new DownloadProgressEventArgs
                        {
                            ProgressPercentage = progress,
                            BytesReceived = totalRead,
                            TotalBytesToReceive = totalBytes,
                            FileName = fileName
                        });
                    }
                }
            }

            // Move temp file to final location
            if (File.Exists(targetPath))
                File.Delete(targetPath);

            File.Move(tempPath, targetPath);

            Log.Notify($"Plugin downloaded successfully: {targetPath}");
            return targetPath;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to download plugin from {url}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    ///     Downloads and installs a plugin from a URL.
    /// </summary>
    /// <param name="url">The URL to download from.</param>
    /// <param name="autoLoad">If true, loads the plugin immediately after download.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if successful, otherwise false.</returns>
    public static async Task<bool> DownloadAndInstallPlugin<T>(string url, bool autoLoad = true, CancellationToken cancellationToken = default)
        where T : IExtension
    {
        try
        {
            var downloadedPath = await DownloadPluginFromWeb<T>(url, null, cancellationToken);

            if (string.IsNullOrEmpty(downloadedPath))
                return false;

            if (autoLoad)
            {
                return LoadPluginFromFile<T>(downloadedPath);
            }

            Log.Notify("Plugin downloaded. Restart required to load it.");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to download and install plugin: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Verifies a plugin file's integrity using SHA256 hash.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="expectedHash">The expected SHA256 hash (hex string).</param>
    /// <returns>True if hash matches, otherwise false.</returns>
    public static bool VerifyPluginHash(string filePath, string expectedHash)
    {
        try
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(filePath);
            var hash = sha256.ComputeHash(stream);
            var hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

            return hashString.Equals(expectedHash, StringComparison.OrdinalIgnoreCase);
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    ///     Loads a plugin repository from a JSON URL.
    /// </summary>
    /// <param name="repositoryUrl">The repository JSON URL.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The loaded repository, or null if failed.</returns>
    public static async Task<PluginRepository> LoadRepositoryFromUrl(string repositoryUrl, CancellationToken cancellationToken = default)
    {
        try
        {
            Log.Notify($"Loading plugin repository from: {repositoryUrl}");

            var json = await HttpClient.GetStringAsync(repositoryUrl, cancellationToken);
            var repository = JsonSerializer.Deserialize<PluginRepository>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (repository == null)
            {
                Log.Error("Failed to parse repository JSON");
                return null;
            }

            Log.Notify($"Loaded repository '{repository.Name}' with {repository.Plugins.Count} plugins");
            return repository;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to load repository: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    ///     Enables a plugin.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully enabled, otherwise false.</returns>
    public static bool EnablePlugin(string internalName)
    {
        if (!_extensions.Any(p => p.Name == internalName))
            return false;

        var plugin = _extensions.FirstOrDefault(p => p.Name == internalName);
        if (plugin.Enabled)
            return true;

        try
        {
            plugin.Enable();
            plugin.Enabled = true;

            // Re-register packet handlers
            if (PluginHandlers.ContainsKey(internalName))
            {
                foreach (var handler in PluginHandlers[internalName])
                    PacketManager.RegisterHandler(handler);
            }

            // Re-register packet hooks
            if (PluginHooks.ContainsKey(internalName))
            {
                foreach (var hook in PluginHooks[internalName])
                    PacketManager.RegisterHook(hook);
            }

            SaveDisabledPlugins(); // Save state
            EventManager.FireEvent("OnPluginEnabled", plugin);
            Log.Notify($"Plugin [{plugin.Title}] enabled!");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to enable plugin [{plugin.Title}]: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Disables a plugin.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully disabled, otherwise false.</returns>
    public static bool DisablePlugin(string internalName)
    {
        if (!_extensions.Any(p => p.Name == internalName))
            return false;

        var plugin = _extensions.FirstOrDefault(p => p.Name == internalName);
        if (!plugin.Enabled)
            return true;

        try
        {
            plugin.Disable();
            plugin.Enabled = false;

            // Unregister packet handlers
            if (PluginHandlers.ContainsKey(internalName))
            {
                foreach (var handler in PluginHandlers[internalName])
                    PacketManager.RemoveHandler(handler);
            }

            // Unregister packet hooks
            if (PluginHooks.ContainsKey(internalName))
            {
                foreach (var hook in PluginHooks[internalName])
                    PacketManager.RemoveHook(hook);
            }

            SaveDisabledPlugins(); // Save state
            EventManager.FireEvent("OnPluginDisabled", plugin);
            Log.Notify($"Plugin [{plugin.Title}] disabled!");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to disable plugin [{plugin.Title}]: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Toggles a plugin's enabled state.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>The new enabled state.</returns>
    public static bool TogglePlugin(string internalName)
    {
        if (!_extensions.Any(p => p.Name == internalName))
            return false;

        var plugin = _extensions.FirstOrDefault(p => p.Name == internalName);

        return plugin.Enabled ? DisablePlugin(internalName) : EnablePlugin(internalName);
    }

    /// <summary>
    ///     Reloads a plugin.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully reloaded, otherwise false.</returns>
    public static bool ReloadPlugin(string internalName)
    {
        if (!_extensions.Any(p => p.Name == internalName))
            return false;

        var plugin = _extensions.FirstOrDefault(p => p.Name == internalName);

        if (!DisablePlugin(internalName))
            return false;

        if (plugin.Enabled)
            return EnablePlugin(internalName);

        return true;
    }

    /// <summary>
    ///     Loads a plugin from a file at runtime.
    /// </summary>
    /// <param name="filePath">The path to the plugin DLL file.</param>
    /// <returns>True if successfully loaded, otherwise false.</returns>
    public static bool LoadPluginFromFile<T>(string filePath)
        where T : IExtension
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Log.Error($"Plugin file not found: {filePath}");
                return false;
            }

            var newPlugins = GetExtensionsFromAssembly<T>(filePath);

            if (newPlugins.Count == 0)
            {
                Log.Error($"No valid plugins found in: {filePath}");
                return false;
            }


            foreach (var plugin in newPlugins)
            {
                if (!_extensions.Any(p => p.Name == plugin.Name))
                {
                    Log.Warn($"Plugin '{plugin.Name}' is already loaded. Skipping.");
                    continue;
                }

                _extensions.Add(plugin);

                Log.Notify($"Plugin '{plugin.Title}' loaded successfully!");
                EventManager.FireEvent("OnPluginLoaded", plugin);
            }

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to load plugin from {filePath}: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Unloads a plugin (removes it from the manager).
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully unloaded, otherwise false.</returns>
    public static bool UnloadPlugin(string internalName)
    {
        if (!_extensions.Any(p => p.Name == internalName))
            return false;

        try
        {
            var plugin = _extensions.FirstOrDefault(p => p.Name == internalName);

            // Disable first
            if (plugin.Enabled)
            {
                if (!DisablePlugin(internalName))
                    return false;
            }

            // Remove from extensions
            _extensions.Remove(plugin);

            // Remove handlers and hooks
            if (PluginHandlers.ContainsKey(internalName))
                PluginHandlers.Remove(internalName);

            if (PluginHooks.ContainsKey(internalName))
                PluginHooks.Remove(internalName);

            EventManager.FireEvent("OnPluginUnloaded", plugin);
            Log.Notify($"Plugin '{plugin.Title}' unloaded successfully!");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to unload plugin '{internalName}': {ex.Message}");
            return false;
        }
    }


    /// <summary>
    /// Get the disabled plugins list from config.
    /// </summary>
    private static string[] LoadDisabledPlugins()
    {
        var list = GlobalConfig.Get("RSBot.DisabledPlugins", "");

        return list.Split(",", StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Saves the disabled plugins list to config.
    /// </summary>
    private static void SaveDisabledPlugins()
    {
        var disabledPlugins = _extensions
            .Where(p => !p.Enabled)
            .Select(p => p.Name)
            .ToArray();

        GlobalConfig.Set("RSBot.DisabledPlugins", string.Join(",", disabledPlugins));
        GlobalConfig.Save();
    }
}
