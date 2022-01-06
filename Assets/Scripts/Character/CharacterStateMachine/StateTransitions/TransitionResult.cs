

public readonly struct TransitionResult
{
    public readonly CharacterState NewState;
    public bool TransitionHappened => NewState != null;


    public TransitionResult(CharacterState newState)
    {
        NewState = newState;
    }
}