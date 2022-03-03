using System.Collections.Generic;

namespace RSBot.Core
{
    using Event;

    public static class PlayerConfig
    {
        /// <summary>
        /// The config
        /// </summary>
        private static Config _config;

        /// <summary>
        /// Load config from file
        /// </summary>
        /// <param name="file">The config file path</param>
        public static void Load(string file)
        {
            _config = new Config(file);

            Log.Notify("[Player] settings have been loaded!");
        }

        /// <summary>
        /// Existses the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool Exists(string key)
            => _config.Exists(key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        public static T Get<T>(string key, T defaultValue = default(T))
            => _config.Get(key, defaultValue);

        /// <summary>
        /// Gets the enum value with specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        public static TEnum GetEnum<TEnum>(string key, TEnum defaultValue) 
            where TEnum : struct
            => _config.GetEnum(key, defaultValue);

        /// <summary>
        /// Sets the specified key inside the config.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Set<T>(string key, T value)
            => _config.Set(key, value);

        /// <summary>
        /// Gets the array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static T[] GetArray<T>(string key, char delimiter = ',')
            => _config.GetArray<T>(key, delimiter);

        /// <summary>
        /// Sets the array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <param name="delimiter">The delimiter.</param>
        public static void SetArray<T>(string key, IEnumerable<T> values, string delimiter = ",")
            => _config.SetArray(key, values, delimiter);

        /// <summary>
        /// Saves the specified file.
        /// </summary>
        /// <param name="file">The file.</param>
        public static void Save()
        {
            if (_config == null)
                return;

            _config.Save();

            Log.Notify("[Player] have been saved!");
            EventManager.FireEvent("OnSavePlayerConfig");
        }
    }
}
