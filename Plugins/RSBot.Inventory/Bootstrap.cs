using System.Windows.Forms;
using RSBot.Core;
using RSBot.Core.Components;
using RSBot.Core.Plugins;
using RSBot.Inventory.Subscriber;

namespace RSBot.Inventory;

public class Bootstrap : IPlugin
{
    /// <inheritdoc />
    public string InternalName => "RSBot.Inventory";

    /// <inheritdoc />
    public string DisplayName => "Inventory";

    /// <inheritdoc />
    public bool DisplayAsTab => true;

    /// <inheritdoc />
    public int Index => 4;

    /// <inheritdoc />
    public bool RequireIngame => true;

    /// <inheritdoc />
    public void Initialize()
    {
        BuyItemSubscriber.SubscribeEvents();
        InventoryUpdateSubscriber.SubscribeEvents();
        UseItemAtTrainplaceSubscriber.SubscribeEvents();
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
