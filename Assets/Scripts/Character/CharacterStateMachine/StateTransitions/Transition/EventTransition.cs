using UnityEngine.Events;


public class EventTransition : Transition
{
    private bool _eventHappened;
    private static CharacterState _currentState;


    public EventTransition(CharacterState stateFrom, CharacterState stateTo) : base(stateFrom, stateTo)
    {
    }


    public void AddEvent(UnityEvent unityEvent)
    {
        unityEvent.AddListener(TrySetEventFlag);
    }


    private void TrySetEventFlag()
    {
        if (_currentState == StateFrom)
        {
            _eventHappened = true;
        }
    }
    

    protected override bool CheckTransition(CharacterState currentState)
    {
        _currentState = currentState;
        bool eventHappened = _eventHappened;

        _eventHappened = false;

        return eventHappened;
    }
}