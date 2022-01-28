using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class EventTransitionsPresenterFactory : TransitionsPresenterFactory
{
    [SerializeField] private TransitionsEvents _transitionsEvents;


    protected override List<Transition> GetTransitions()
    {
        var eventTransitions = new List<Transition>();
        
        eventTransitions.AddRange(GetAllTransitionsWithState(States.DieState, _transitionsEvents.Restart));
        eventTransitions.AddRange(GetAllTransitionsWithState(States.DieState, _transitionsEvents.ObstacleEntered));
        eventTransitions.AddRange(GetAllTransitionsWithState(States.WinState, _transitionsEvents.FinishEntered));
        eventTransitions.Add(new EventTransition(States.DieState, States.IdleState, _transitionsEvents.CharacterResurrected));

        return eventTransitions;
    }


    private List<Transition> GetAllTransitionsWithState(CharacterState targetState, UnityEvent condition)
    {
        var transitions = new List<Transition>();

        foreach (CharacterState characterState in States.GameActiveStates)
        {
            transitions.Add(new EventTransition(characterState, targetState, condition));
        }

        return transitions;
    }
}