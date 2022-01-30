using UnityEngine.Events;


public class EventTransition : Transition
{
    private bool _eventHappened;
    private static CharacterState _currentState;


    public EventTransition(CharacterState stateFrom, CharacterState stateTo, UnityEvent condition) 
        : base(stateFrom, stateTo)
    {
        condition.AddListener(TrySetEventFlag);
    }

    
    public static void SetCurrentState(CharacterState characterState)
    {
        _currentState = characterState;
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