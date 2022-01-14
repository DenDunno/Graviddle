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
            new EventTransition(_states.IdleState, _states.DieState, _transitionsEvents.Restart),
            new EventTransition(_states.RunState, _states.DieState, _transitionsEvents.Restart),
            new EventTransition(_states.FallState, _states.DieState, _transitionsEvents.Restart),

            new EventTransition(_states.IdleState, _states.DieState, _transitionsEvents.ObstacleEntered),
            new EventTransition(_states.RunState, _states.DieState, _transitionsEvents.ObstacleEntered),
            new EventTransition(_states.FallState, _states.DieState, _transitionsEvents.ObstacleEntered),

            new EventTransition(_states.IdleState, _states.WinState, _transitionsEvents.FinishEntered),
            new EventTransition(_states.RunState, _states.WinState, _transitionsEvents.FinishEntered),
            new EventTransition(_states.FallState, _states.WinState, _transitionsEvents.FinishEntered)
        };
    }
}