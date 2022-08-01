﻿using System.Collections.Generic;

namespace RSBot.Core
{
    using Event;
    using RSBot.Core.Components;
    using System;
    using System.IO;

    public static class GlobalConfig
    {
        /// <summary>
        /// The config
        /// </summary>
        private static Config _config;

        /// <summary>
        /// Load config from file
        /// </summary>
        public static void Load()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "User", ProfileManager.SelectedProfile + ".rs");

            _config = new Config(path);

            Log.Notify("[Global] settings have been loaded!");
        }

        /// <summary>
        /// Returns a value indicating if the given config key exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if(_config == null)
                return false;

            return _config.Exists(key);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        public static T Get<T>(string key, T defaultValue = default(T))
        {
            if (_config == null)
                return defaultValue;

            return _config.Get(key, defaultValue);
        }

        /// <summary>
        /// Gets the enum value with specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        public static TEnum GetEnum<TEnum>(string key, TEnum defaultValue = default(TEnum))
            where TEnum : struct
        {
            if(_config == null)
                return defaultValue;

            return _config.GetEnum(key, defaultValue);
        }

        /// <summary>
        /// Sets the specified key inside the config.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set<T>(string key, T value)
        {
            if(_config != null)
                _config.Set(key, value);
        }

        /// <summary>
        /// Gets the array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static T[] GetArray<T>(string key, char delimiter = ',')
        {
            if (_config == null)
                return new T[] {};

            return _config.GetArray<T>(key, delimiter);
        }

        /// <summary>
        /// Sets the array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <param name="delimiter">The delimiter.</param>
        public static void SetArray<T>(string key, IEnumerable<T> values, string delimiter = ",")
        {
            if(_config != null)
                _config.SetArray(key, values, delimiter);
        }

        /// <summary>
        /// Saves the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void Save()
        {
            if (_config == null)
                return;

            _config.Save();

            Log.Notify("[Global] have been saved!");
            EventManager.FireEvent("OnSaveGlobalConfig");
        }
    }
}
