using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class EventTransitionsPresenterFactory : TransitionsPresenterFactory
{
    [SerializeField] private TransitionsEvents _transitionsEvents;


    protected override List<Transition> GetTransitions()
    {
        return new List<Transition>()
        {
            new EventTransition(States.IdleState, States.DieState, _transitionsEvents.Restart),
            new EventTransition(States.RunState, States.DieState, _transitionsEvents.Restart),
            new EventTransition(States.FallState, States.DieState, _transitionsEvents.Restart),

            new EventTransition(States.IdleState, States.DieState, _transitionsEvents.ObstacleEntered),
            new EventTransition(States.RunState, States.DieState, _transitionsEvents.ObstacleEntered),
            new EventTransition(States.FallState, States.DieState, _transitionsEvents.ObstacleEntered),

            new EventTransition(States.IdleState, States.WinState, _transitionsEvents.FinishEntered),
            new EventTransition(States.RunState, States.WinState, _transitionsEvents.FinishEntered),
            new EventTransition(States.FallState, States.WinState, _transitionsEvents.FinishEntered),
            
            new EventTransition(States.DieState, States.IdleState, _transitionsEvents.CharacterRestarted)
        };
    }
}