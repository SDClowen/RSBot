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
using RSBot.Core.Event;
using RSBot.Core.Network;

namespace RSBot.Core.Plugins;

public class PluginManager
{
    /// <summary>
    ///     Gets the extension directory.
    /// </summary>
    /// <value>
    ///     The extension directory.
    /// </value>
    public string InitialDirectory => Path.Combine(Kernel.BasePath, "Data", "Plugins");

    /// <summary>
    ///     Gets the extensions.
    /// </summary>
    /// <value>
    ///     The extensions.
    /// </value>
    public Dictionary<string, IPlugin> Extensions { get; private set; }

    /// <summary>
    ///     Gets the loaded assemblies.
    /// </summary>
    private Dictionary<string, Assembly> LoadedAssemblies { get; set; }

    /// <summary>
    ///     Gets the packet handlers registered by plugins.
    /// </summary>
    private Dictionary<string, List<IPacketHandler>> PluginHandlers { get; set; }

    /// <summary>
    ///     Gets the packet hooks registered by plugins.
    /// </summary>
    private Dictionary<string, List<IPacketHook>> PluginHooks { get; set; }

    /// <summary>
    ///     HTTP client for downloading plugins from web.
    /// </summary>
    private static readonly HttpClient HttpClient = new HttpClient
    {
        Timeout = TimeSpan.FromMinutes(5)
    };

    /// <summary>
    ///     Event for download progress updates.
    /// </summary>
    public event EventHandler<DownloadProgressEventArgs> DownloadProgressChanged;

    /// <summary>
    ///     Downloads a plugin from a URL.
    /// </summary>
    /// <param name="url">The URL to download from.</param>
    /// <param name="targetFileName">The target file name (without path).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The path to the downloaded file, or null if failed.</returns>
    public async Task<string> DownloadPluginFromWeb(string url, string targetFileName = null, CancellationToken cancellationToken = default)
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

            var targetPath = Path.Combine(InitialDirectory, fileName);
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
                        DownloadProgressChanged?.Invoke(this, new DownloadProgressEventArgs
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
    public async Task<bool> DownloadAndInstallPlugin(string url, bool autoLoad = true, CancellationToken cancellationToken = default)
    {
        try
        {
            var downloadedPath = await DownloadPluginFromWeb(url, null, cancellationToken);
            
            if (string.IsNullOrEmpty(downloadedPath))
                return false;

            if (autoLoad)
            {
                return LoadPluginFromFile(downloadedPath);
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
    public async Task<PluginRepository> LoadRepositoryFromUrl(string repositoryUrl, CancellationToken cancellationToken = default)
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
    ///     Gets the default RSBot plugin repository.
    /// </summary>
    /// <returns>The default repository.</returns>
    public static PluginRepository GetDefaultRepository()
    {
        return new PluginRepository
        {
            Name = "RSBot Official Repository",
            Url = "https://raw.githubusercontent.com/sdclowen/rsbot-plugins/main/repository.json",
            Plugins = []
        };
    }

    /// <summary>
    ///     Loads the assemblies.
    /// </summary>
    public bool LoadAssemblies()
    {
        if (Extensions != null)
            return false;

        Extensions = new Dictionary<string, IPlugin>();
        LoadedAssemblies = new Dictionary<string, Assembly>();
        PluginHandlers = new Dictionary<string, List<IPacketHandler>>();
        PluginHooks = new Dictionary<string, List<IPacketHook>>();

        try
        {
            // Load disabled plugins list from config
            var disabledPluginsStr = GlobalConfig.Get("RSBot.DisabledPlugins", "");
            var disabledPlugins = string.IsNullOrEmpty(disabledPluginsStr) 
                ? new HashSet<string>() 
                : new HashSet<string>(disabledPluginsStr.Split(','));

            foreach (
                var extension in from file in Directory.GetFiles(InitialDirectory)
                let fileInfo = new FileInfo(file)
                where fileInfo.Extension == ".dll"
                select GetExtensionsFromAssembly(file) into loadedExtensions
                from extension in loadedExtensions
                select extension
            )
            {
                Extensions.Add(extension.Key, extension.Value);
                
                // Set enabled state based on saved config
                extension.Value.Enabled = !disabledPlugins.Contains(extension.Value.InternalName);
                
                Log.Debug($"Loaded plugin [{extension.Value.InternalName}] - Enabled: {extension.Value.Enabled}");
            }

            //order by index, not alphabeticaly
            Extensions = Extensions.OrderBy(entry => entry.Value.Index).ToDictionary(x => x.Key, x => x.Value);

            EventManager.FireEvent("OnLoadPlugins");

            return true;
        }
        catch (Exception ex)
        {
            File.WriteAllText(
                Kernel.BasePath + "\\boot-error.log",
                $"The plugin manager encountered a problem: \n{ex.Message} at {ex.StackTrace}"
            );
            return false;
        }
    }

    /// <summary>
    ///     Saves the disabled plugins list to config.
    /// </summary>
    private void SaveDisabledPlugins()
    {
        var disabledPlugins = Extensions.Values
            .Where(p => !p.Enabled)
            .Select(p => p.InternalName)
            .ToArray();

        GlobalConfig.Set("RSBot.DisabledPlugins", string.Join(",", disabledPlugins));
        GlobalConfig.Save();
    }

    /// <summary>
    ///     Gets the extensions from assembly.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns></returns>
    private Dictionary<string, IPlugin> GetExtensionsFromAssembly(string file)
    {
        var result = new Dictionary<string, IPlugin>();

        var assembly = Assembly.LoadFrom(file);
        LoadedAssemblies[file] = assembly;

        try
        {
            var assemblyTypes = assembly.GetTypes();

            foreach (
                var extension in (
                    from type in assemblyTypes
                    where type.IsPublic && !type.IsAbstract && type.GetInterface("IPlugin") != null
                    select Activator.CreateInstance(type)
                ).OfType<IPlugin>()
            )
                result.Add(extension.InternalName, extension);

            if (result.Count == 0)
                return result;

            var handlerType = typeof(IPacketHandler);
            var hookType = typeof(IPacketHook);

            var types = assemblyTypes.Where(p => handlerType.IsAssignableFrom(p) && !p.IsInterface).ToArray();

            var handlers = new List<IPacketHandler>();
            foreach (var handler in types)
            {
                var instance = (IPacketHandler)Activator.CreateInstance(handler);
                PacketManager.RegisterHandler(instance);
                handlers.Add(instance);
            }

            types = assemblyTypes.Where(p => hookType.IsAssignableFrom(p) && !p.IsInterface).ToArray();

            var hooks = new List<IPacketHook>();
            foreach (var hook in types)
            {
                var instance = (IPacketHook)Activator.CreateInstance(hook);
                PacketManager.RegisterHook(instance);
                hooks.Add(instance);
            }

            // Store handlers and hooks for each plugin
            foreach (var plugin in result.Values)
            {
                PluginHandlers[plugin.InternalName] = handlers;
                PluginHooks[plugin.InternalName] = hooks;
            }
        }
        catch
        {
            /* ignore, it's an invalid extension */
        }

        return result;
    }

    /// <summary>
    ///     Enables a plugin.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully enabled, otherwise false.</returns>
    public bool EnablePlugin(string internalName)
    {
        if (!Extensions.ContainsKey(internalName))
            return false;

        var plugin = Extensions[internalName];
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
            Log.Notify($"Plugin [{plugin.DisplayName}] enabled!");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to enable plugin [{plugin.DisplayName}]: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Disables a plugin.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully disabled, otherwise false.</returns>
    public bool DisablePlugin(string internalName)
    {
        if (!Extensions.ContainsKey(internalName))
            return false;

        var plugin = Extensions[internalName];
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
            Log.Notify($"Plugin [{plugin.DisplayName}] disabled!");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to disable plugin [{plugin.DisplayName}]: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    ///     Toggles a plugin's enabled state.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>The new enabled state.</returns>
    public bool TogglePlugin(string internalName)
    {
        if (!Extensions.ContainsKey(internalName))
            return false;

        var plugin = Extensions[internalName];
        return plugin.Enabled ? DisablePlugin(internalName) : EnablePlugin(internalName);
    }

    /// <summary>
    ///     Reloads a plugin.
    /// </summary>
    /// <param name="internalName">The internal name of the plugin.</param>
    /// <returns>True if successfully reloaded, otherwise false.</returns>
    public bool ReloadPlugin(string internalName)
    {
        if (!Extensions.ContainsKey(internalName))
            return false;

        var wasEnabled = Extensions[internalName].Enabled;

        if (!DisablePlugin(internalName))
            return false;

        if (wasEnabled)
            return EnablePlugin(internalName);

        return true;
    }

    /// <summary>
    ///     Loads a plugin from a file at runtime.
    /// </summary>
    /// <param name="filePath">The path to the plugin DLL file.</param>
    /// <returns>True if successfully loaded, otherwise false.</returns>
    public bool LoadPluginFromFile(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Log.Error($"Plugin file not found: {filePath}");
                return false;
            }

            var newPlugins = GetExtensionsFromAssembly(filePath);

            if (newPlugins.Count == 0)
            {
                Log.Error($"No valid plugins found in: {filePath}");
                return false;
            }

            foreach (var plugin in newPlugins)
            {
                if (Extensions.ContainsKey(plugin.Key))
                {
                    Log.Warn($"Plugin '{plugin.Key}' is already loaded. Skipping.");
                    continue;
                }

                Extensions.Add(plugin.Key, plugin.Value);
                plugin.Value.Enabled = true;
                plugin.Value.Initialize();
                plugin.Value.Translate();

                Log.Notify($"Plugin '{plugin.Value.DisplayName}' loaded successfully!");
                EventManager.FireEvent("OnPluginLoaded", plugin.Value);
            }

            // Re-order extensions by index
            Extensions = Extensions.OrderBy(entry => entry.Value.Index).ToDictionary(x => x.Key, x => x.Value);

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
    public bool UnloadPlugin(string internalName)
    {
        if (!Extensions.ContainsKey(internalName))
            return false;

        try
        {
            var plugin = Extensions[internalName];

            // Disable first
            if (plugin.Enabled)
            {
                if (!DisablePlugin(internalName))
                    return false;
            }

            // Remove from extensions
            Extensions.Remove(internalName);

            // Remove handlers and hooks
            if (PluginHandlers.ContainsKey(internalName))
                PluginHandlers.Remove(internalName);

            if (PluginHooks.ContainsKey(internalName))
                PluginHooks.Remove(internalName);

            EventManager.FireEvent("OnPluginUnloaded", plugin);
            Log.Notify($"Plugin '{plugin.DisplayName}' unloaded successfully!");

            return true;
        }
        catch (Exception ex)
        {
            Log.Error($"Failed to unload plugin '{internalName}': {ex.Message}");
            return false;
        }
    }
}
