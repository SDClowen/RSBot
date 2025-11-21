using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using RSBot.Statistics.Stats;

namespace RSBot.Statistics;

public class Bootstrap : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.Statistics";

    /// <inheritdoc />
    public string DisplayName => "Statistics";

    /// <inheritdoc />
    public bool DisplayAsTab => true;

    /// <inheritdoc />
    public int Index => 97;

    /// <inheritdoc />
    public bool RequireIngame => true;

    /// <inheritdoc />
    public void Initialize()
    {
        CalculatorRegistry.Initialize();
    }

    /// <inheritdoc />
    public Control View => Views.View.Instance;

    /// <inheritdoc />
    public void Translate()
    {
        LanguageManager.Translate(View, Kernel.Language);
    }

    /// <inheritdoc />
    public void OnLoadCharacter()
    {
        // do nothing
    }
}
