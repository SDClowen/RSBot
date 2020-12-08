using RSBot.Core.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RSBot.Core
{
    public static class GlobalConfig
    {
        /// <summary>
        /// The object that stores the configuration
        /// </summary>
        private static Dictionary<string, string> _config;

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        private static string _path;

        /// <summary>
        /// Existses the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (_config == null)
                return false;

            return _config.ContainsKey(key) && _config[key] != null && _config[key] != string.Empty;
        }

        /// <summary>
        /// Sets the specified key inside the config.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>

        public static void Set<T>(string key, T value)
        {
            _config = _config ?? new Dictionary<string, string>();

            string setValue = value == null ? string.Empty : value.ToString();
            if (!_config.ContainsKey(key))
                _config.Add(key, setValue);
            else
                _config[key] = setValue;
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        public static T Get<T>(string key, T defaultValue = default(T))
        {
            if (_config == null) return (T)Convert.ChangeType(false, typeof(T));

            if (!_config.ContainsKey(key))
                Set(key, defaultValue);

            return (T)Convert.ChangeType(_config[key], typeof(T));
        }

        /// <summary>
        /// Loads the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void Load(string file)
        {
            _path = Environment.CurrentDirectory + "\\" + file + ".rs";
            if (!File.Exists(_path))
            {
                Log.Notify($"Config file [{_path}] does not exists, creating a new one...");
                File.Create(_path).Dispose();
            }

            _config = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(_path))
            {
                if (string.IsNullOrWhiteSpace(line) || string.IsNullOrEmpty(line)) continue;

                var key = line.Split('{')[0];
                var value = line.Split('{')[1].Split('}')[0];

                if (!_config.ContainsKey(key))
                    _config.Add(key, value);
            }
            Log.Notify("[Global] Settings have been loaded!");
        }

        /// <summary>
        /// Saves the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void Save()
        {
            if (_config == null || string.IsNullOrWhiteSpace(_path)) return;

            if (!File.Exists(_path))
                File.Create(_path).Dispose();

            var serializedConfig = new string[_config.Count];
            var index = 0;

            foreach (var element in _config)
            {
                serializedConfig[index] = element.Key + "{" + element.Value + "}";
                index++;
            }

            File.WriteAllLines(_path, serializedConfig);

            EventManager.FireEvent("OnSaveGlobalConfig");
            Log.Notify("[Global] Settings have been saved!");
        }

        /// <summary>
        /// Sets the array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <param name="delimiter">The delimiter.</param>
        public static void SetArray<T>(string key, IList<T> values, string delimiter = ",")
        {
            if (values == null) return;

            Set(key, string.Join(delimiter, values));
        }

        /// <summary>
        /// Gets the array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static T[] GetArray<T>(string key, char delimiter = ',')
        {
            var data = Get<string>(key).Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (data.Length == 0)
            {
                return new T[] { };
            }

            return data?.Select(p => (T)Convert.ChangeType(p, typeof(T))).ToArray();
        }
    }
}