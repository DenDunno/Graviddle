using System;


public class Transition
{
    public readonly CharacterState StateFrom;
    public readonly CharacterState StateTo;
    private readonly Func<bool> _transitionCondition;

    public event Action TransitionHappened;


    public Transition(CharacterState stateFrom, Func<bool> transitionCondition, CharacterState stateTo)
    {
        StateFrom = stateFrom;
        StateTo = stateTo;
        _transitionCondition = transitionCondition;
    }


    public bool CheckCondition()
    {
        bool transitionHappened = _transitionCondition();

        if (transitionHappened)
        {
            TransitionHappened?.Invoke();
        }

        return transitionHappened;
    }
}