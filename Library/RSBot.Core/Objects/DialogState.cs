using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects;

public class DialogState
{
    private uint _dialogNpcId;
    internal uint RequestedCloseNpcId = 0;

    internal uint RequestedNpcId = 0;
    public bool IsInDialog => _dialogNpcId != 0;
    public TalkOption TalkOption { get; set; }

    //Special trader shops with Bargain goods has started.
    public bool IsSpecialityTime { get; set; }

    public SpawnedNpc Npc
    {
        get => _dialogNpcId == 0 ? null : SpawnManager.GetEntity<SpawnedNpc>(_dialogNpcId);
        set => _dialogNpcId = value?.UniqueId ?? 0;
    }
}
