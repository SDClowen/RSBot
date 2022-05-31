﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RSBot.Core
{
    using LangDict = Dictionary<string, string>;

    public class LanguageManager
    {
        private static string _path = Path.Combine(Environment.CurrentDirectory, "Languages");

        /// <summary>
        /// Parsed language values
        /// </summary>
        private static Dictionary<string, LangDict> _values = new Dictionary<string, LangDict>();

        /// <summary>
        /// Get all menu items
        /// </summary>
        /// <param name="menuItem">The toolstrip menu item</param>
        /// <returns></returns>
        private static List<ToolStripMenuItem> GetAllMenuItems(ToolStripMenuItem menuItem)
        {
            var collection = new List<ToolStripMenuItem>() { menuItem };
            foreach (ToolStripMenuItem item in menuItem.DropDownItems)
                collection.AddRange(GetAllMenuItems(item));

            return collection;

        }

        /// <summary>
        /// Parse the language file
        /// </summary>
        /// <param name="file">The language file</param>
        /// <returns>Parsed language strings</returns>
        public static LangDict ParseLanguageFile(string file)
        {
            var languages = new LangDict();

            var text = File.ReadAllText(file);

            var builder = new StringBuilder();

            var key = string.Empty;
            var value = string.Empty;

            var doubleQuotes = false;
            var skipDoubleQuotes = false;

            foreach (var c in text)
            {
                if (c == '=')
                {
                    key = builder.ToString().Trim();
                    builder = new StringBuilder();
                    value = string.Empty;

                    if (languages.ContainsKey(key))
                    {
                        key = string.Empty;
                        skipDoubleQuotes = true;
                    }

                    continue;
                }

                if (c == '"')
                {
                    doubleQuotes = !doubleQuotes;
                    if (skipDoubleQuotes)
                        continue;

                    value = builder.ToString();/*.Trim()*/
                    builder.Clear();

                    languages[key] = value;
                    value = string.Empty;

                    continue;
                }

                if (doubleQuotes && skipDoubleQuotes)
                    continue;

                if ((c == '\r' || c == '\n') && !doubleQuotes)
                    continue;

                builder.Append(c);
            }

            return languages;
        }

        /// <summary>
        /// Compare between controls ang languages strings if there have any missing complete and write to language file
        /// </summary>
        /// <param name="file">The language file path</param>
        /// <param name="controls">The controls</param>
        /// <param name="languages">the parsed languages list</param>
        private static void CheckMissings(string file, string header, Control main, LangDict languages)
        {
            var contents = new List<string>();

            foreach (Control control in main.Controls)
            {
                var headerEx = $"{header}.{control.Parent.GetType().Name}";
                if (control is ToolStrip toolStrip)
                {
                    var menuItems = new List<ToolStripItem>();
                    foreach (ToolStripMenuItem menuItem in toolStrip.Items.OfType<ToolStripMenuItem>())
                        menuItems.AddRange(GetAllMenuItems(menuItem));

                    foreach (var item in menuItems)
                    {
                        if (string.IsNullOrEmpty(item.Name) ||
                            string.IsNullOrEmpty(item.Text))
                            continue;

                        var menuItemCheckName = $"{headerEx}.{item.Name}";
                        if (!languages.ContainsKey(menuItemCheckName))
                        {
                            contents.Add($"{menuItemCheckName}=\"{item.Text}\"");

                            languages[item.Name] = item.Text;
                        }
                    }
                }

                if (control is ToolStrip)
                    continue;

                CheckMissings(file, headerEx, control, languages);

                if (!(control is Label) &&
                    !(control is GroupBox) &&
                    !(control is ButtonBase) &&
                    !(control is TabControl) &&
                    !(control is TabPage) &&
                    !(control is ToolStrip))
                    continue;

                if (string.IsNullOrEmpty(control.Name) ||
                    string.IsNullOrEmpty(control.Text))
                    continue;

                var checkName = $"{headerEx}.{control.Name}";
                if (!languages.ContainsKey(checkName))
                {
                    contents.Add($"{checkName}=\"{control.Text}\"");

                    languages[control.Name] = control.Text;
                }
            }

            if (contents.Count > 0)
                File.AppendAllLines(file, contents);
        }

        /// <summary>
        /// Get language value
        /// </summary>
        /// <param name="key">The key</param>
        public static string GetLang(string key)
        {
            var trace = new StackTrace();

            var parent = string.Empty;
            for (int i = 0; i < trace.FrameCount; i++)
            {
                parent = Path.GetFileNameWithoutExtension(trace.GetFrame(i).GetMethod().Module.Name);
                if (parent != "RSBot.Core")
                    break;
            }

            if (_values.ContainsKey(parent) && _values[parent].ContainsKey(key))
                return _values[parent][key];
            
            return string.Empty;
        }

        /// <summary>
        /// Get language value
        /// </summary>
        /// <param name="key">The key</param>
        public static string GetLang(string key, params object[] args)
        {
            return string.Format(GetLang(key), args);
        }

        /// <summary>
        /// Get language value
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="default">The default value that will be returned if the translation could not be found</param>
        public static string GetLangBySpecificKey(string parent, string key, string @default = "")
        {
            if (_values.ContainsKey(parent) && _values[parent].ContainsKey(key))
                return _values[parent][key];

            return @default;
        }

        /// <summary>
        /// Translate the control
        /// </summary>
        /// <param name="view">The control view</param>
        /// <param name="file">The language file path</param>
        public static void Translate(Control view, string language = "English")
        {
            var type = view.GetType();

            var controlName = type.FullName;
            var assembly = type.Assembly.GetName().Name;

            var path = Path.Combine(_path, assembly, language + ".rsl");
            var dir = Path.GetDirectoryName(path);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(Path.GetDirectoryName(dir));

            var stopwatch = Stopwatch.StartNew();

            if (!File.Exists(path))
                return;
                //File.CreateText(path).Dispose();

            //var instance = (Control)Activator.CreateInstance(type);

            var values = ParseLanguageFile(path);
            //CheckMissings(path, assembly, instance, values);


            _values[assembly] = values;

            TranslateControls(values, view, assembly);
        }

        private static void TranslateControls(LangDict values, Control view, string header)
        {
            foreach (Control control in view.Controls)
            {
                var headerEx = $"{header}.{control.Parent.GetType().Name}";

                string translatedText;

                if (control is ToolStrip strip)
                {
                    foreach (var toolStripItem in strip.Items.OfType<ToolStripMenuItem>())
                    {
                        var subItems = GetAllMenuItems(toolStripItem);
                        foreach (var subMenuItem in subItems)
                        {
                            if (values.TryGetValue($"{headerEx}.{subMenuItem.Name}", out translatedText))
                                subMenuItem.Text = translatedText;
                        }
                    }

                    continue;
                }

                if (values.TryGetValue($"{headerEx}.{control.Name}", out translatedText))
                    control.Text = translatedText;

                TranslateControls(values, control, headerEx);
            }
        }

        public static string[] GetLanguages()
        {
            var filePath = Path.Combine(_path, "langs.rsl");
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"Language list file is missing! \n {filePath}");
                Environment.Exit(0);
            }

            return File.ReadAllLines(filePath);
        }
    }
}
