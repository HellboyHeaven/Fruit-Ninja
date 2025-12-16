using UniRx;

public sealed class AttackSpeed : ReactiveProperty<int>, IStat
{
    public AttackSpeed(int value)
    {
        Value = value;
    }
}