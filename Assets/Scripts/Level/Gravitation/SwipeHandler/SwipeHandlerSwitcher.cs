

public class SwipeHandlerSwitcher : CharacterFallingEventsHandler
{
    private readonly SwipeHandler _swipeHandler;

    
    public SwipeHandlerSwitcher(SwipeHandler swipeHandler, Transition fallToIdleTransition, FallState fallState) 
        : base(fallToIdleTransition, fallState)
    {
        _swipeHandler = swipeHandler;
    }


    protected override void OnCharacterStartFalling()
    {
        _swipeHandler.enabled = false;
    }


    protected override void OnCharacterEndFalling()
    {
        _swipeHandler.enabled = true;
    }
}