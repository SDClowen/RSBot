using RSBot.Core.Components;
using RSBot.Core.Objects.Spawn;

namespace RSBot.Core.Objects;

public class DialogState
{
    public bool IsInDialog => _dialogNpcId != 0;

    internal uint RequestedNpcId = 0;
    internal uint RequestedCloseNpcId = 0;
    public TalkOption TalkOption { get; set; }

    //Special trader shops with Bargain goods has started.
    public bool IsSpecialityTime { get; set; }

    private uint _dialogNpcId;

    public SpawnedNpc Npc
    {
        get => _dialogNpcId == 0 ? null : SpawnManager.GetEntity<SpawnedNpc>(_dialogNpcId);
        set => _dialogNpcId = value?.UniqueId ?? 0;
    }
}