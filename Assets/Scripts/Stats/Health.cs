using UniRx;
using UnityEngine;

public sealed class Health : IStat
{
    public Health(int max, int current)
    {
        Max = new ReactiveProperty<int>(max);
        Current = new ReactiveProperty<int>(Mathf.Min(current, max));

        Max.Subscribe(m => 
        {
            if (Current.Value > m) Current.Value = m;
        });
    }

    public ReactiveProperty<int> Max { get; private set; }
    
    private ReactiveProperty<int> _current;
    public ReactiveProperty<int> Current
    {
        get => _current;
        private set
        {
            _current = new ReactiveProperty<int>(Mathf.Min(value.Value, Max.Value));
        }
    }

    // Метод для изменения Current
    public void SetCurrent(int value)
    {
        Current.Value = Mathf.Clamp(value, 0, Max.Value);
    }

    public void ChangeCurrent(int delta)
    {
        SetCurrent(Current.Value + delta);
    }
}
