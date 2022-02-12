

public abstract class CharacterFallingEventsHandler : IRestart, ISubscriber
{
    private readonly Transition _fallToIdleTransition;
    private readonly FallState _fallState;


    protected CharacterFallingEventsHandler(Transition fallToIdleTransition, FallState fallState)
    {
        _fallToIdleTransition = fallToIdleTransition;
        _fallState = fallState;
    }


    void ISubscriber.Subscribe()
    {
        _fallState.CharacterFalling += OnCharacterStartFalling;
        _fallToIdleTransition.TransitionHappened += OnCharacterEndFalling;
    }


    void ISubscriber.Unsubscribe()
    {
        _fallState.CharacterFalling -= OnCharacterStartFalling;
        _fallToIdleTransition.TransitionHappened -= OnCharacterEndFalling;
    }


    protected abstract void OnCharacterStartFalling();
    protected abstract void OnCharacterEndFalling();

    
    void IRestart.Restart()
    {
        OnCharacterEndFalling();
    }
}