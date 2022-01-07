using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class EventTransitionsPresenterFactory
{
    [SerializeField] private Button _restartButton = null;
    private CharacterStatesPresenter _states;


    public void Init(CharacterStatesPresenter states)
    {
        _states = states;
    }


    public TransitionPresenter Create()
    {
        var eventTransitionsForState = new TransitionPresenter();
        var eventTransitions = new List<EventTransition>()
        {
            new EventTransition(_states.IdleState, _states.DieState),
            new EventTransition(_states.RunState, _states.DieState),
            new EventTransition(_states.FallState, _states.DieState)
        };

        foreach (EventTransition eventTransition in eventTransitions)
        {
            eventTransition.AddEvent(_restartButton.onClick);
            eventTransitionsForState.AddTransition(eventTransition);
        }

        return eventTransitionsForState;
    }
}