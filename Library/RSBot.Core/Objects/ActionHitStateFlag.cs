namespace RSBot.Core.Objects;

public enum ActionHitStateFlag : byte
{
    Damage = 1,
    Block = 2,
    KnockDown = 4,
    KnockBack = 5,
    Abort = 8,
    Dead = 128,
    KnockDownDead = KnockDown | Dead,
    KnockBackDead = KnockBack | Dead,
}
