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


    public virtual bool CheckIfTransitionHappened()
    {
        bool transitionHappened = OnCheckTransition();

        if (transitionHappened)
        {
            TransitionHappened?.Invoke();
        }

        return transitionHappened;
    }


    public virtual void Clear() {}
    protected abstract bool OnCheckTransition();
}