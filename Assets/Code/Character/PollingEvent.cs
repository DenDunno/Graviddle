
public class PollingEvent
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
}