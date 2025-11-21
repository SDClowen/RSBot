using RSBot.Core.Objects.Spawn;
using SDUI.Controls;

namespace RSBot.Map.Views.Dialog;

public partial class EntityDetailsDialog : UIWindowBase
{
    public EntityDetailsDialog(SpawnedEntity entity)
    {
        InitializeComponent();

        propEntity.SelectedObject = entity;
    }
}

public class EntityDebugInformation : SpawnedEntity { }
