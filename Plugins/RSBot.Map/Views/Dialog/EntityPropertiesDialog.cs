using RSBot.Core.Objects.Spawn;
using System.Windows.Forms;


namespace RSBot.Map.Views.Dialog;

public partial class EntityDetailsDialog : Form
{
    public EntityDetailsDialog(SpawnedEntity entity)
    {
        InitializeComponent();

        propEntity.SelectedObject = entity;
    }
}

public class EntityDebugInformation : SpawnedEntity
{
}