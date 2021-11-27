using System;
using System.Collections.Generic;


public class TransitionEventsPresenter
{
    private Dictionary<TransitionWithEvent, Action> _transitionsWithEvents;

    public event Action OnCharacterFell;


    public TransitionEventsPresenter(CharacterStatesPresenter states)
    {
        _transitionsWithEvents = new Dictionary<TransitionWithEvent, Action>()
        {
            { new TransitionWithEvent(states.FallState , states.IdleState) , OnCharacterFell }
        };
    }


    public void TryInvokeTransitionEvent(CharacterState from , CharacterState to)
    {
        _transitionsWithEvents[new TransitionWithEvent(from , to)]?.Invoke();
    }
}