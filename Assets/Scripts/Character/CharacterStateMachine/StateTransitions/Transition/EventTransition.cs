using UnityEngine.Events;


public class EventTransition : Transition
{
    private bool _eventHappened;


    public EventTransition(CharacterState stateFrom, CharacterState stateTo) : base(stateFrom, stateTo)
    {
    }


    public void AddEvent(UnityEvent unityEvent)
    {
        unityEvent.AddListener(TrySetEventFlag);
    }


    private void TrySetEventFlag()
    {
        _eventHappened = false;
    }
    

    protected override bool CheckTransition()
    {
        bool eventHappened = _eventHappened;

        _eventHappened = false;

        return eventHappened;
    }
}