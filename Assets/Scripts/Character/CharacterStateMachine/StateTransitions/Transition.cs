using System;


public class Transition
{
    public readonly CharacterState StateFrom;
    public readonly CharacterState StateTo;
    private readonly Func<bool> TransitionCondition;

    public event Action TransitionHappened;


    public Transition(CharacterState stateFrom, Func<bool> transitionCondition, CharacterState stateTo)
    {
        StateFrom = stateFrom;
        TransitionCondition = transitionCondition;
        StateTo = stateTo;
    }


    public bool CheckCondition()
    {
        bool transitionHappened = TransitionCondition();

        if (transitionHappened)
        {
            TransitionHappened?.Invoke();
        }

        return transitionHappened;
    }
}