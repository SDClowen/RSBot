
using System.Windows.Forms;
using RSBot.Core.Objects.Spawn;

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