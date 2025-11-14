using System;
using System.Collections.Generic;
using System.IO;

namespace RSBot.Core;

public static class SystemConfig
{
    private static Config _config;

    public static void Load()
    {
        var path = Path.Combine(Kernel.BasePath, "User", "System.rs");
        _config = new Config(path);
    }

    public static T Get<T>(string key, T defaultValue = default)
    {
        if (_config == null)
            return defaultValue;

        return _config.Get(key, defaultValue);
    }

    public static void Set<T>(string key, T value)
    {
        if (_config != null)
        {
            _config.Set(key, value);
            _config.Save();
        }
    }
}