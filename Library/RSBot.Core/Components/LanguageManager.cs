using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
    private static List<ToolStripMenuItem> GetAllMenuItems(ToolStripMenuItem menuItem)
    {
        var collection = new List<ToolStripMenuItem> { menuItem };
        foreach (ToolStripMenuItem item in menuItem.DropDownItems)
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
                .Replace("\\n", "\n") // LF
                .Replace("\\r", "\r"); // CR

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

        foreach (Control control in main.Controls)
        {
            var headerEx = $"{header}.{control.Parent.GetType().Name}";
            if (control is ToolStrip toolStrip)
            {
                var menuItems = new List<ToolStripItem>();
                foreach (var menuItem in toolStrip.Items.OfType<ToolStripMenuItem>())
                    menuItems.AddRange(GetAllMenuItems(menuItem));

                foreach (var item in menuItems)
                {
                    if (string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Text))
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

            if (
                !(control is Label)
                && !(control is GroupBox)
                && !(control is ButtonBase)
                && !(control is TabControl)
                && !(control is TabPage)
                && !(control is ToolStrip)
            )
                continue;

            if (string.IsNullOrEmpty(control.Name) || string.IsNullOrEmpty(control.Text))
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

        var controlName = type.FullName;
        var assembly = type.Assembly.GetName().Name;

        var path = Path.Combine(_path, assembly, language + ".rsl");
        var dir = Path.GetDirectoryName(path);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        var stopwatch = Stopwatch.StartNew();

        if (!File.Exists(path))
            return;
        //File.CreateText(path).Dispose();

        //var instance = (Control)Activator.CreateInstance(type);

        var values = ParseLanguageFile(path);
        //CheckMissings(path, assembly, view, values);

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
                        if (values.TryGetValue($"{headerEx}.{subMenuItem.Name}", out translatedText))
                            if (!string.IsNullOrWhiteSpace(translatedText))
                                subMenuItem.Text = translatedText;
                }

                continue;
            }

            if (values.TryGetValue($"{headerEx}.{control.Name}", out translatedText))
                if (!string.IsNullOrWhiteSpace(translatedText))
                    control.Text = translatedText;

            TranslateControls(values, control, headerEx);
        }
    }

    public static Dictionary<string, string> GetLanguages()
    {
        var filePath = Path.Combine(_path, "langs.rsl");
        if (!File.Exists(filePath))
        {
            MessageBox.Show($"Language list file is missing! \n {filePath}");
            Environment.Exit(0);
        }

        return File.ReadAllLines(filePath).ToDictionary(p => p.Split(':')[0], p => p.Split(':')[1]);
    }
}
