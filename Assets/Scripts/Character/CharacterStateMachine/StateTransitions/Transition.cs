using System;


public class Transition
{
    public readonly int Priority;
    public readonly Func<bool> TransitionCondition;
    public readonly CharacterState StateTo;


    public Transition(Func<bool> transitionCondition, CharacterState to , int priority)
    {
        TransitionCondition = transitionCondition;
        StateTo = to;
        Priority = priority;
    }
}