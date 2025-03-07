using Avalonia.Controls;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RSBot.Core.Localization;

/*
 <TextBlock Tag="Welcome" 
          Text="{Binding Source={x:Static loc:LocalizationManager.Instance}, 
                 Path=Translate, 
                 ConverterParameter=Welcome}"/>

<Button Tag="SaveButton" 
        Content="{Binding Source={x:Static loc:LocalizationManager.Instance}, 
                 Path=Translate, 
                 ConverterParameter=SaveButton}"/>

 */
/// <summary>
/// Manages localization in an Avalonia application using modern patterns
/// </summary>
public sealed class LocalizationManager : ObservableObject
{
    private static readonly Lazy<LocalizationManager> _instance = new(() => new LocalizationManager());
    private readonly ConcurrentDictionary<string, Dictionary<string, string>> _translations = new();
    private readonly string _basePath;
    private CultureInfo _currentCulture;

    public static LocalizationManager Instance => _instance.Value;

    public CultureInfo CurrentCulture
    {
        get => _currentCulture;
        set
        {
            if (SetProperty(ref _currentCulture, value))
            {
                LoadTranslations(value.Name);
                OnCultureChanged();
            }
        }
    }

    private LocalizationManager()
    {
        _basePath = Path.Combine(AppContext.BaseDirectory, "Localization");
        _currentCulture = CultureInfo.CurrentUICulture;
        
        Directory.CreateDirectory(_basePath);
        LoadTranslations(_currentCulture.Name);
    }

    /// <summary>
    /// Gets available cultures from the localization directory
    /// </summary>
    public IEnumerable<CultureInfo> AvailableCultures
    {
        get
        {
            return Directory.GetFiles(_basePath, "*.json")
                .Select(f => Path.GetFileNameWithoutExtension(f))
                .Select(name => CultureInfo.GetCultureInfo(name));
        }
    }

    /// <summary>
    /// Translates a key to the current culture
    /// </summary>
    public string Translate(string key, string assembly = "Core")
    {
        if (_translations.TryGetValue(assembly, out var translations) &&
            translations.TryGetValue(key, out var translation))
        {
            return translation;
        }

        return key;
    }

    /// <summary>
    /// Translates a key with format parameters
    /// </summary>
    public string Translate(string key, string assembly, params object[] args)
    {
        return string.Format(Translate(key, assembly), args);
    }

    /// <summary>
    /// Applies translations to all controls in a visual tree
    /// </summary>
    public void TranslateView(Control view)
    {
        var assembly = view.GetType().Assembly.GetName().Name;

        foreach (var control in view.GetVisualDescendants().OfType<Control>())
        {
            if (control is ContentControl contentControl)
            {
                TranslateContentControl(contentControl, assembly);
            }
            else if (control is TextBlock textBlock)
            {
                TranslateTextBlock(textBlock, assembly);
            }
            // Add other control types as needed
        }
    }

    /// <summary>
    /// Loads translations for a specific culture
    /// </summary>
    private void LoadTranslations(string cultureName)
    {
        _translations.Clear();

        var files = Directory.GetFiles(_basePath, $"{cultureName}.json", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var assembly = Path.GetFileName(Path.GetDirectoryName(file)) ?? "Core";
            try
            {
                var json = File.ReadAllText(file);
                var translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                if (translations != null)
                {
                    _translations[assembly] = translations;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading translations: {ex.Message}");
            }
        }
    }

    private void TranslateContentControl(ContentControl control, string assembly)
    {
        if (control.Tag is string key)
        {
            control.Content = Translate(key, assembly);
        }
    }

    private void TranslateTextBlock(TextBlock control, string assembly)
    {
        if (control.Tag is string key)
        {
            control.Text = Translate(key, assembly);
        }
    }

    private void OnCultureChanged()
    {
        // Notify UI that culture has changed
        OnPropertyChanged(nameof(CurrentCulture));
    }

    /// <summary>
    /// Creates or updates translation files for a view
    /// </summary>
    public void ExtractTranslations(Control view, string cultureName)
    {
        var assembly = view.GetType().Assembly.GetName().Name;
        var translations = new Dictionary<string, string>();

        foreach (var control in view.GetVisualDescendants().OfType<Control>())
        {
            if (control.Tag is string key)
            {
                string defaultText = string.Empty;
                
                if (control is ContentControl contentControl)
                    defaultText = contentControl.Content?.ToString() ?? string.Empty;
                else if (control is TextBlock textBlock)
                    defaultText = textBlock.Text ?? string.Empty;

                if (!string.IsNullOrEmpty(defaultText))
                    translations[key] = defaultText;
            }
        }

        if (translations.Any())
        {
            var path = Path.Combine(_basePath, assembly!, $"{cultureName}.json");
            var json = JsonSerializer.Serialize(translations, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            File.WriteAllText(path, json);
        }
    }
}
