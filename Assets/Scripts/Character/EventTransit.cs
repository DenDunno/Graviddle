
public class EventTransit
{
    private bool _eventHappened;

    
    public bool CheckIfEventHappened()
    {
        bool result = _eventHappened;

        _eventHappened = false;

        return result;
    }


    public void Invoke()
    {
        _eventHappened = true;
    }
    
    
    public void Cancel()
    {
        _eventHappened = false;
    }
}