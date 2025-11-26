using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RSBot.Core;

public class Config
{
    /// <summary>
    ///     The object that stores the configuration
    /// </summary>
    private readonly ConcurrentDictionary<string, string> _config;

    /// <summary>
    ///     Gets the path.
    /// </summary>
    private readonly string _path;

    /// <summary>
    ///     Loads the specified file.
    /// </summary>
    /// <param name="file">The file.</param>
    public Config(string file)
    {
        _path = file;

        CheckPath();

        _config = new ConcurrentDictionary<string, string>();
        foreach (var line in File.ReadAllLines(_path))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var key = line.Split('{')[0];
            var value = line.Split('{')[1].Split('}')[0];

            if (!_config.ContainsKey(key))
                _config.TryAdd(key, value);
        }
    }

    /// <summary>
    ///     gets is loaded
    /// </summary>
    private bool _isLoaded => _config != null;

    /// <summary>
    ///     Existses the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public bool Exists(string key)
    {
        if (!_isLoaded)
            return false;

        return _config.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Gets the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="defaultValue">The default value.</param>
    public T Get<T>(string key, T defaultValue = default)
    {
        if (!_isLoaded)
            return (T)Convert.ChangeType(false, typeof(T));

        if (!_config.ContainsKey(key))
        {
            Set(key, defaultValue);

            return defaultValue;
        }

        var value = _config[key];
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        return (T)Convert.ChangeType(value, typeof(T));
    }

    /// <summary>
    ///     Gets the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="defaultValue">The default value.</param>
    public TEnum GetEnum<TEnum>(string key, TEnum defaultValue)
        where TEnum : struct
    {
        if (!_isLoaded)
            return default;

        if (!_config.TryGetValue(key, out var value))
        {
            Set(key, defaultValue);
            value = defaultValue.ToString();
        }

        TEnum result;
        if (!Enum.TryParse(value, out result))
            return default;

        return result;
    }

    /// <summary>
    ///     Sets the specified key inside the config.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void Set<T>(string key, T value)
    {
        var setValue = value == null ? string.Empty : value.ToString();
        _config.AddOrUpdate(key, setValue, (k, v) => setValue);
    }

    /// <summary>
    ///     Check directories
    /// </summary>
    private void CheckPath()
    {
        var directory = Path.GetDirectoryName(_path);
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        if (!File.Exists(_path))
            File.Create(_path).Dispose();
    }

    /// <summary>
    ///     Saves the specified file.
    /// </summary>
    /// <param name="file">The file.</param>
    public void Save()
    {
        if (!_isLoaded || string.IsNullOrWhiteSpace(_path))
            return;

        CheckPath();

        var serializedConfig = new string[_config.Count];
        var index = 0;

        foreach (var element in _config.OrderBy(c => c.Key))
        {
            serializedConfig[index] = element.Key + "{" + element.Value + "}";
            index++;
        }

        File.WriteAllLines(_path, serializedConfig);
    }

    /// <summary>
    ///     Sets the array.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="values">The values.</param>
    /// <param name="delimiter">The delimiter.</param>
    public void SetArray<T>(string key, IEnumerable<T> values, string delimiter = ",")
    {
        if (values == null)
            return;

        Set(key, string.Join(delimiter, values));
    }

    /// <summary>
    ///     Gets the array.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns></returns>
    public T[] GetArray<T>(
        string key,
        char delimiter = ',',
        StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries
    )
    {
        if (!_isLoaded)
            return new T[] { };

        var data = Get<string>(key)?.Split(new[] { delimiter }, options);
        if (data == null || data.Length == 0)
            return new T[] { };

        return data?.Select(p => (T)Convert.ChangeType(p, typeof(T))).ToArray();
    }

    /// <summary>
    ///     Get array the specified key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="defaultValue">The default value.</param>
    public TEnum[] GetEnums<TEnum>(string key, char delimiter = ',')
        where TEnum : struct
    {
        if (!_isLoaded)
            return new TEnum[] { };

        var data = Get<string>(key)?.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        if (data == null || data.Length == 0)
            return new TEnum[] { };

        return data?.Select(p => Enum.Parse<TEnum>(p)).ToArray();
    }
}
