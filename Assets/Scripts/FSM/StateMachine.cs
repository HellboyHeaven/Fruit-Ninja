using System;
using System.Collections.Generic;

public class StateMachine
{
    IState _current;

    readonly Dictionary<Type, IState> _states = new();
    readonly Dictionary<(Type, Type), Func<bool>> _transitions = new();

    public void AddState(IState state)
        => _states[state.GetType()] = state;

    public void AddTransition<TFrom, TTo>(Func<bool> condition)
        where TFrom : IState
        where TTo   : IState
    {
        _transitions[(typeof(TFrom), typeof(TTo))] = condition;
    }

    public void SetState<T>() where T : IState
    {
        var state = _states[typeof(T)];
        _current?.Exit();
        _current = state;
        _current.Enter();
    }

    public void Update()
    {
        TryTransition();
        _current?.Update();
    }

    public void FixedUpdate()
    {
        TryTransition();
        _current?.FixedUpdate();
    }

    private void TryTransition()
    {
        if (_current == null) return;

        foreach (var ((from, to), condition) in _transitions)
            if (_current.GetType() == from && condition())
            {
                SetState(to);
                return;
            }
    }

    private void SetState(Type type)
    {
        _current.Exit();
        _current = _states[type];
        _current.Enter();
    }
}
