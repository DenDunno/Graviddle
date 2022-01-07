using UnityEngine.Events;
using Zenject;


public class EventTransition : Transition
{
    private bool _eventHappened;
    [Inject] private CharacterState _currentState;


    public EventTransition(CharacterState stateFrom, CharacterState stateTo, UnityEvent unityEvent) 
        : base(stateFrom, stateTo)
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
    

    protected override bool CheckTransition()
    {
        bool eventHappened = _eventHappened;

        _eventHappened = false;

        return eventHappened;
    }
}