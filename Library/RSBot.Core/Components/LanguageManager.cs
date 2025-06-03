using Avalonia.Controls;
using Avalonia.VisualTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace RSBot.Core.Components;

using LangDict = Dictionary<string, string>;

public class LanguageManager
{
    private static readonly string _path = Path.Combine(Kernel.BasePath, "Data", "Languages");

    /// <summary>
    ///     Parsed language values
    /// </summary>
    private static readonly Dictionary<string, LangDict> _values = new();

    /// <summary>
    ///     Get all menu items
    /// </summary>
    /// <param name="menuItem">The toolstrip menu item</param>
    /// <returns></returns>
    private static List<MenuItem> GetAllMenuItems(MenuItem menuItem)
    {
        var collection = new List<MenuItem> { menuItem };
        foreach (MenuItem item in menuItem.Items)
            collection.AddRange(GetAllMenuItems(item));

        return collection;
    }

    /// <summary>
    ///     Parse the language file
    /// </summary>
    /// <param name="file">The language file</param>
    /// <returns>Parsed language strings</returns>
    public static LangDict ParseLanguageFile(string file)
    {
        var languages = new LangDict();
        var lines = File.ReadAllLines(file);

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrEmpty(trimmedLine) || !trimmedLine.Contains("="))
                continue;

            var parts = trimmedLine.Split(new[] { '=' }, 2);
            if (parts.Length < 2)
                continue;

            var key = parts[0].Trim();
            var value = parts[1].Trim().Trim('"');

            value = value
                .Replace("\\r\\n", "\r\n") // CRLF
                .Replace("\\n", "\n")       // LF
                .Replace("\\r", "\r");      // CR

            if (!languages.ContainsKey(key))
            {
                languages[key] = value;
            }
        }

        return languages;
    }

    /// <summary>
    ///     Compare between controls ang languages strings if there have any missing complete and write to language file
    /// </summary>
    /// <param name="file">The language file path</param>
    /// <param name="controls">The controls</param>
    /// <param name="languages">the parsed languages list</param>
    private static void CheckMissings(string file, string header, Control main, LangDict languages)
    {
        var contents = new List<string>();

        foreach (Control control in main.GetVisualDescendants().OfType<Control>())
        {
            var headerEx = $"{header}.{control.Parent?.GetType().Name}";

            if (control is Menu menu)
            {
                var menuItems = new List<MenuItem>();
                foreach (var menuItem in menu.Items.OfType<MenuItem>())
                    menuItems.AddRange(GetAllMenuItems(menuItem));

                foreach (var item in menuItems)
                {
                    if (string.IsNullOrEmpty(item.Name) ||
                        string.IsNullOrEmpty(item.Header?.ToString()))
                        continue;

                    var menuItemCheckName = $"{headerEx}.{item.Name}";
                    if (!languages.ContainsKey(menuItemCheckName))
                    {
                        contents.Add($"{menuItemCheckName}=\"{item.Header}\"");
                        languages[item.Name] = item.Header.ToString();
                    }
                }
            }

            if (control is Menu)
                continue;

            if (!(control is TextBlock) &&
                !(control is Button) &&
                !(control is TabControl) &&
                !(control is TabItem))
                continue;

            if (string.IsNullOrEmpty(control.Name))
                continue;

            string controlText = null;
            if (control is TextBlock textBlock)
                controlText = textBlock.Text;
            else if (control is ContentControl contentControl)
                controlText = contentControl.Content?.ToString();

            if (string.IsNullOrEmpty(controlText))
                continue;

            var checkName = $"{headerEx}.{control.Name}";
            if (!languages.ContainsKey(checkName))
            {
                contents.Add($"{checkName}=\"{controlText}\"");
                languages[control.Name] = controlText;
            }
        }

        if (contents.Count > 0)
            File.AppendAllLines(file, contents);
    }

    /// <summary>
    ///     Get language value
    /// </summary>
    /// <param name="key">The key</param>
    public static string GetLang(string key)
    {
        var trace = new StackTrace();

        var parent = string.Empty;
        for (var i = 0; i < trace.FrameCount; i++)
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
    ///     Get language value
    /// </summary>
    /// <param name="key">The key</param>
    public static string GetLang(string key, params object[] args)
    {
        return string.Format(GetLang(key), args);
    }

    /// <summary>
    ///     Get language value
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
    ///     Translate the control
    /// </summary>
    /// <param name="view">The control view</param>
    /// <param name="file">The language file path</param>
    public static void Translate(Control view, string language = "en_US")
    {
        var type = view.GetType();
        var assembly = type.Assembly.GetName().Name;
        var path = Path.Combine(_path, assembly, language + ".rsl");
        var dir = Path.GetDirectoryName(path);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (!File.Exists(path))
            return;

        var values = ParseLanguageFile(path);
        _values[assembly] = values;

        TranslateControls(values, view, assembly);
    }

    private static void TranslateControls(LangDict values, Control view, string header)
    {
        foreach (Control control in view.GetVisualDescendants().OfType<Control>())
        {
            var headerEx = $"{header}.{control.Parent?.GetType().Name}";
            string translatedText;

            if (control is Menu menu)
            {
                foreach (var menuItem in menu.Items.OfType<MenuItem>())
                {
                    var subItems = GetAllMenuItems(menuItem);
                    foreach (var subMenuItem in subItems)
                        if (values.TryGetValue($"{headerEx}.{subMenuItem.Name}", out translatedText))
                            if (!string.IsNullOrWhiteSpace(translatedText))
                                subMenuItem.Header = translatedText;
                }
                continue;
            }

            if (values.TryGetValue($"{headerEx}.{control.Name}", out translatedText))
            {
                if (!string.IsNullOrWhiteSpace(translatedText))
                {
                    if (control is TextBlock textBlock)
                        textBlock.Text = translatedText;
                    else if (control is ContentControl contentControl)
                        contentControl.Content = translatedText;
                }
            }
        }
    }

    public static LangDict GetLanguages()
    {
        var filePath = Path.Combine(_path, "langs.rsl");
        if (!File.Exists(filePath))
        {
            //MessageBox.Show($"Language list file is missing! \n {filePath}");
            Environment.Exit(0);
        }

        return File.ReadAllLines(filePath)
            .ToDictionary(p => p.Split(':')[0], p => p.Split(':')[1]);
    }
}