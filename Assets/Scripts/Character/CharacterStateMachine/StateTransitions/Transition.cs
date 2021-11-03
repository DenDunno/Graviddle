using System;

public class Transition
{
    public readonly Func<bool> CheckTransition;
    public readonly CharacterState ResultState;

    public Transition(Func<bool> checkTransition, CharacterState resultState)
    {
        CheckTransition = checkTransition;
        ResultState = resultState;
    }
}
