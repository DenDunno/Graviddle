﻿using System;


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


    public bool CheckIfTransitionHappened()
    {
        bool transitionHappened = CheckTransition();

        if (transitionHappened)
        {
            TransitionHappened?.Invoke();
        }

        return transitionHappened;
    }


    protected abstract bool CheckTransition();
}