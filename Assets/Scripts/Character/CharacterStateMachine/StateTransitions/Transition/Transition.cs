using System;


public abstract class Transition
{
    public readonly CharacterState StateFrom;
    public readonly CharacterState StateTo;

    public event Action TransitionHappened;


    protected Transition(CharacterState stateFrom, CharacterState stateTo)
    {
        StateFrom = stateFrom;
        StateTo = stateTo;
    }


    public virtual bool CheckIfTransitionHappened(CharacterState currentState)
    {
        bool transitionHappened = CheckTransition(currentState);

        if (transitionHappened)
        {
            TransitionHappened?.Invoke();
        }

        return transitionHappened;
    }


    protected abstract bool CheckTransition(CharacterState currentState);
}