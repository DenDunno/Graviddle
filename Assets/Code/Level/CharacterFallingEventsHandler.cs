

public abstract class CharacterFallingEventsHandler : IRestart, ISubscriber
{
    private readonly Transition _fallToIdleTransition;
    private readonly FallState _fallState;
    protected bool IsFalling { get; private set; }


    protected CharacterFallingEventsHandler(Transition fallToIdleTransition, FallState fallState)
    {
        _fallToIdleTransition = fallToIdleTransition;
        _fallState = fallState;
    }


    void ISubscriber.Subscribe()
    {
        _fallState.CharacterFalling += OnCharacterFalling;
        _fallToIdleTransition.TransitionHappened += OnCharacterFell;
    }


    void ISubscriber.Unsubscribe()
    {
        _fallState.CharacterFalling -= OnCharacterFalling;
        _fallToIdleTransition.TransitionHappened -= OnCharacterFell;
    }


    private void OnCharacterFalling()
    {
        IsFalling = true;
        OnStartFalling();
    }


    private void OnCharacterFell()
    {
        IsFalling = false;
        OnEndFalling();
    }


    protected virtual void OnStartFalling() {}
    protected virtual void OnEndFalling() {}

    
    void IRestart.Restart()
    {
        OnEndFalling();
    }
}