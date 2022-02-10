

public class SwipeHandlerSwitcher : ICharacterFallingEventsHandler
{
    private readonly SwipeHandler _swipeHandler;
    

    public SwipeHandlerSwitcher(SwipeHandler swipeHandler)
    {
        _swipeHandler = swipeHandler;
    }

    
    void ICharacterFallingEventsHandler.OnCharacterStartFalling()
    {
        _swipeHandler.enabled = false;
    }


    void ICharacterFallingEventsHandler.OnCharacterEndFalling()
    {
        _swipeHandler.enabled = true;
    }
}