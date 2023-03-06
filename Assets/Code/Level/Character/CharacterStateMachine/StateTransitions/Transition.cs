using System;

public class Transition
{
    public readonly CharacterState StateFrom;
    public readonly CharacterState StateTo;
    private readonly Func<bool> _condition;

    public Transition(CharacterState stateFrom, CharacterState stateTo, Func<bool> condition)
    {
        StateFrom = stateFrom;
        StateTo = stateTo;
        _condition = condition;
    }

    public event Action TransitionHappened;

    public bool CheckCondition()
    {
        bool transitionHappened = _condition();

        if (transitionHappened)
        {
            TransitionHappened?.Invoke();
        }

        return transitionHappened;
    }
}