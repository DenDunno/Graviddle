using System;


public class Transition
{
    public readonly Func<bool> TransitionCondition;
    public readonly CharacterState StateTo;


    public Transition(Func<bool> transitionCondition, CharacterState stateTo)
    {
        TransitionCondition = transitionCondition;
        StateTo = stateTo;
    }
}