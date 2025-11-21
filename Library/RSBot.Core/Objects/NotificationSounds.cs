using System.IO;
using System.Media;
using System.Text.RegularExpressions;

namespace RSBot.Core.Objects
{
    /// <summary>
    /// Used for different sound notifications
    /// </summary>
    public class NotificationSounds
    {
        #region Unique in range

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayAlarmUniqueInRange = false;

        /// <summary>
        ///     Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathAlarmUniqueInRange = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerAlarmUniqueInRange;

        #endregion

        #region General unique appeared

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmGeneral = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmGeneral = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmGeneral;

        /// <summary>
        /// Regex for unique alarm
        /// </summary>
        public Regex RegexUniqueAlarmGeneral;

        #endregion

        #region Tiger Girl

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmTigerGirl = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmTigerGirl = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmTigerGirl;

        #endregion

        #region Cerberus

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmCerberus = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmCerberus = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmCerberus;

        #endregion

        #region Captain Ivy

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmCaptainIvy = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmCaptainIvy = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmIvy;

        #endregion

        #region Uruchi

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmUruchi = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmUruchi = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmUruchi;

        #endregion

        #region Isyutaru

        /// <summary>
        ///    Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmIsyutaru = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmIsyutaru = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmIsyutaru;

        #endregion

        #region Isyutaru

        /// <summary>
        ///     Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmLordYarkan = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmLordYarkan = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmLordYarkan;

        #endregion

        #region Demon Shaitan

        /// <summary>
        ///     Auxiliary variable to play sound if unique appeared.
        /// </summary>
        public bool PlayUniqueAlarmDemonShaitan = false;

        /// <summary>
        /// Auxiliary variable path to sound file (.wav)
        /// </summary>
        public string PathUniqueAlarmDemonShaitan = string.Empty;

        /// <summary>
        ///     Player to play sound if unqiue appeared
        /// </summary>
        private SoundPlayer _playerUniqueAlarmDemonShaitan;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationSounds() { }

        /// <summary>
        ///     Plays sound if unique spotted
        /// </summary>
        public void PlayUniqueInRange()
        {
            if (PlayAlarmUniqueInRange)
            {
                // Play sound
                _playerAlarmUniqueInRange?.Play();
            }
        }

        /// <summary>
        ///     Plays sound if unique appeared
        /// </summary>
        /// <param name="name">Name of unique</param>
        public void PlayUniqueAppeared(string name)
        {
            // Tiger Girl
            if (PlayUniqueAlarmTigerGirl)
            {
                if (Regex.IsMatch(name, "Tiger Girl", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmTigerGirl?.Play();
                    return;
                }
            }

            // Cerberus
            if (PlayUniqueAlarmCerberus)
            {
                if (Regex.IsMatch(name, "Cerberus", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmCerberus?.Play();
                    return;
                }
            }

            // Captain Ivy
            if (PlayUniqueAlarmCaptainIvy)
            {
                if (Regex.IsMatch(name, "Captain Ivy", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmIvy?.Play();
                    return;
                }
            }

            // Uruchi
            if (PlayUniqueAlarmUruchi)
            {
                if (Regex.IsMatch(name, "Uruchi", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmUruchi?.Play();
                    return;
                }
            }

            // Isyutaru
            if (PlayUniqueAlarmIsyutaru)
            {
                if (Regex.IsMatch(name, "Isyutaru", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmIsyutaru?.Play();
                    return;
                }
            }

            // Lord Yarkan
            if (PlayUniqueAlarmLordYarkan)
            {
                if (Regex.IsMatch(name, "Lord Yarkan", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmLordYarkan?.Play();
                    return;
                }
            }

            // Demon Shaitan
            if (PlayUniqueAlarmDemonShaitan)
            {
                if (Regex.IsMatch(name, "Demon Shaitan", RegexOptions.IgnoreCase))
                {
                    _playerUniqueAlarmDemonShaitan?.Play();
                    return;
                }
            }

            // General
            if (PlayUniqueAlarmGeneral)
            {
                if (RegexUniqueAlarmGeneral.IsMatch(name))
                {
                    _playerUniqueAlarmGeneral?.Play();
                }
            }
        }

        /// <summary>
        ///     Updates the player settings regarding notification sounds
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void UpdatePlayerSettings(string key, object value)
        {
            if (null == value)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            if (value is string stingValue)
            {
                PlayerConfig.Set(key, stingValue);
                UpdateSoundPlayerString(key, stingValue);
            }
            else if (value is bool boolValue)
            {
                PlayerConfig.Set(key, boolValue);
                UpdateSoundPlayerBool(key, boolValue);
            }
        }

        /// <summary>
        ///     Updates if player should play
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="play">Play</param>
        private void UpdateSoundPlayerBool(string key, bool play)
        {
            // Unique in range
            if (key.Equals("RSBot.Sounds.PlayAlarmUniqueInRange"))
            {
                PlayAlarmUniqueInRange = play;
            }

            // Tiger Girl
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmTigerGirl"))
            {
                PlayUniqueAlarmTigerGirl = play;
            }

            // Cerberus
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmCerberus"))
            {
                PlayUniqueAlarmCerberus = play;
            }

            // Captain Ivy
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmCaptainIvy"))
            {
                PlayUniqueAlarmCaptainIvy = play;
            }

            // Uruchi
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmUruchi"))
            {
                PlayUniqueAlarmUruchi = play;
            }

            // Isyutaru
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmIsyutaru"))
            {
                PlayUniqueAlarmIsyutaru = play;
            }

            // Lord Yarkan
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmLordYarkan"))
            {
                PlayUniqueAlarmLordYarkan = play;
            }

            // Demon Shaitan
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmDemonShaitan"))
            {
                PlayUniqueAlarmDemonShaitan = play;
            }

            // General
            if (key.Equals("RSBot.Sounds.PlayUniqueAlarmGeneral"))
            {
                PlayUniqueAlarmGeneral = play;
            }
        }

        /// <summary>
        ///     Updates path + player
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="path">Path</param>
        private void UpdateSoundPlayerString(string key, string path)
        {
            // Unique in range
            if (key.Equals("RSBot.Sounds.PathAlarmUniqueInRange"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathAlarmUniqueInRange = path;
                        _playerAlarmUniqueInRange ??= new();
                        _playerAlarmUniqueInRange.SoundLocation = path;
                    }
                }
            }

            // Tiger Girl
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmTigerGirl"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmTigerGirl = path;
                        _playerUniqueAlarmTigerGirl ??= new();
                        _playerUniqueAlarmTigerGirl.SoundLocation = path;
                    }
                }
            }

            // Cerberus
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmCerberus"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmCerberus = path;
                        _playerUniqueAlarmCerberus ??= new();
                        _playerUniqueAlarmCerberus.SoundLocation = path;
                    }
                }
            }

            // Captain Ivy
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmCaptainIvy"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmCaptainIvy = path;
                        _playerUniqueAlarmIvy ??= new();
                        _playerUniqueAlarmIvy.SoundLocation = path;
                    }
                }
            }

            // Uruchi
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmUruchi"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmUruchi = path;
                        _playerUniqueAlarmUruchi ??= new();
                        _playerUniqueAlarmUruchi.SoundLocation = path;
                    }
                }
            }

            // Isyutaru
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmIsyutaru"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmIsyutaru = path;
                        _playerUniqueAlarmIsyutaru ??= new();
                        _playerUniqueAlarmIsyutaru.SoundLocation = path;
                    }
                }
            }

            // Lord Yarkan
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmLordYarkan"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmLordYarkan = path;
                        _playerUniqueAlarmLordYarkan ??= new();
                        _playerUniqueAlarmLordYarkan.SoundLocation = path;
                    }
                }
            }

            // Demon Shaitan
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmDemonShaitan"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmDemonShaitan = path;
                        _playerUniqueAlarmDemonShaitan ??= new();
                        _playerUniqueAlarmDemonShaitan.SoundLocation = path;
                    }
                }
            }

            // General
            if (key.Equals("RSBot.Sounds.PathUniqueAlarmGeneral"))
            {
                if (false == string.IsNullOrWhiteSpace(path))
                {
                    if (File.Exists(path))
                    {
                        PathUniqueAlarmGeneral = path;
                        _playerUniqueAlarmGeneral ??= new();
                        _playerUniqueAlarmGeneral.SoundLocation = path;
                    }
                }
            }

            // Regex
            if (key.Equals("RSBot.Sounds.RegexUniqueAlarmGeneral"))
            {
                try
                {
                    RegexUniqueAlarmGeneral = new Regex(path);
                }
                catch
                {
                    RegexUniqueAlarmGeneral = new Regex("^.*$");
                }
            }
        }

        /// <summary>
        ///     Loads all player settings regarding notification sounds
        /// </summary>
        public void LoadPlayerSettings()
        {
            // Unique in range
            PlayAlarmUniqueInRange = PlayerConfig.Get("RSBot.Sounds.PlayAlarmUniqueInRange", false);
            PathAlarmUniqueInRange = PlayerConfig.Get("RSBot.Sounds.PathAlarmUniqueInRange", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathAlarmUniqueInRange))
            {
                if (File.Exists(PathAlarmUniqueInRange))
                {
                    _playerAlarmUniqueInRange ??= new();
                    _playerAlarmUniqueInRange.SoundLocation = PathAlarmUniqueInRange;
                }
            }

            // Tiger Girl
            PlayUniqueAlarmTigerGirl = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmTigerGirl", false);
            PathUniqueAlarmTigerGirl = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmTigerGirl", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmTigerGirl))
            {
                if (File.Exists(PathUniqueAlarmTigerGirl))
                {
                    _playerUniqueAlarmTigerGirl ??= new();
                    _playerUniqueAlarmTigerGirl.SoundLocation = PathUniqueAlarmTigerGirl;
                }
            }

            // Cerberus
            PlayUniqueAlarmCerberus = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmCerberus", false);
            PathUniqueAlarmCerberus = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmCerberus", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmCerberus))
            {
                if (File.Exists(PathUniqueAlarmCerberus))
                {
                    _playerUniqueAlarmCerberus ??= new();
                    _playerUniqueAlarmCerberus.SoundLocation = PathUniqueAlarmCerberus;
                }
            }

            // Captain Ivy
            PlayUniqueAlarmCaptainIvy = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmCaptainIvy", false);
            PathUniqueAlarmCaptainIvy = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmCaptainIvy", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmCaptainIvy))
            {
                if (File.Exists(PathUniqueAlarmCaptainIvy))
                {
                    _playerUniqueAlarmIvy ??= new();
                    _playerUniqueAlarmIvy.SoundLocation = PathUniqueAlarmCaptainIvy;
                }
            }

            // Uruchi
            PlayUniqueAlarmUruchi = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmUruchi", false);
            PathUniqueAlarmUruchi = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmUruchi", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmUruchi))
            {
                if (File.Exists(PathUniqueAlarmUruchi))
                {
                    _playerUniqueAlarmUruchi ??= new();
                    _playerUniqueAlarmUruchi.SoundLocation = PathUniqueAlarmUruchi;
                }
            }

            // Isyutaru
            PlayUniqueAlarmIsyutaru = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmIsyutaru", false);
            PathUniqueAlarmIsyutaru = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmIsyutaru", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmIsyutaru))
            {
                if (File.Exists(PathUniqueAlarmIsyutaru))
                {
                    _playerUniqueAlarmIsyutaru ??= new();
                    _playerUniqueAlarmIsyutaru.SoundLocation = PathUniqueAlarmIsyutaru;
                }
            }

            // Lord Yarkan
            PlayUniqueAlarmLordYarkan = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmLordYarkan", false);
            PathUniqueAlarmLordYarkan = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmLordYarkan", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmLordYarkan))
            {
                if (File.Exists(PathUniqueAlarmLordYarkan))
                {
                    _playerUniqueAlarmLordYarkan ??= new();
                    _playerUniqueAlarmLordYarkan.SoundLocation = PathUniqueAlarmLordYarkan;
                }
            }

            // Demon Shaitan
            PlayUniqueAlarmDemonShaitan = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmDemonShaitan", false);
            PathUniqueAlarmDemonShaitan = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmDemonShaitan", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmDemonShaitan))
            {
                if (File.Exists(PathUniqueAlarmDemonShaitan))
                {
                    _playerUniqueAlarmDemonShaitan ??= new();
                    _playerUniqueAlarmDemonShaitan.SoundLocation = PathUniqueAlarmDemonShaitan;
                }
            }

            // General unique alarm
            PlayUniqueAlarmGeneral = PlayerConfig.Get("RSBot.Sounds.PlayUniqueAlarmGeneral", false);
            PathUniqueAlarmGeneral = PlayerConfig.Get("RSBot.Sounds.PathUniqueAlarmGeneral", string.Empty);
            if (false == string.IsNullOrWhiteSpace(PathUniqueAlarmGeneral))
            {
                if (File.Exists(PathUniqueAlarmGeneral))
                {
                    _playerUniqueAlarmGeneral ??= new();
                    _playerUniqueAlarmGeneral.SoundLocation = PathUniqueAlarmGeneral;
                }
            }

            string regTmp = PlayerConfig.Get("RSBot.Sounds.RegexUniqueAlarmGeneral", string.Empty);
            try
            {
                if (false == string.IsNullOrWhiteSpace(regTmp))
                {
                    RegexUniqueAlarmGeneral = new Regex(regTmp);
                }
                else
                {
                    RegexUniqueAlarmGeneral = new Regex("^.*$");
                }
            }
            catch
            {
                RegexUniqueAlarmGeneral = new Regex("^.*$");
            }
        }
    }
}
