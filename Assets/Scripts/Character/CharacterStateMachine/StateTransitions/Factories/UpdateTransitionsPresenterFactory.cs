using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UpdateTransitionsPresenterFactory : TransitionsPresenterFactory
{
    [SerializeField] private LevelBorders _levelBorders;
    private UpdateTransitionsConditions _conditions;


    public void Init(Character character, CharacterStatesPresenter states)
    {
        SetStates(states);
        _conditions = new UpdateTransitionsConditions(character, _levelBorders);
    }


    protected override List<Transition> GetTransitions()
    {
        return new List<Transition>()
        {
            new UpdateTransition(States.IdleState, States.RunState, _conditions.CheckIfRun),
            new UpdateTransition(States.IdleState, States.FallState, _conditions.CheckIfFall),

            new UpdateTransition(States.RunState, States.FallState, _conditions.CheckIfFall),
            new UpdateTransition(States.RunState, States.IdleState, _conditions.CheckIfNotRun),

            new UpdateTransition(States.FallState, States.DieState, _conditions.CheckDeathByLevelBorders),
            new UpdateTransition(States.FallState, States.IdleState, _conditions.CheckIfGrounded),
            
            new UpdateTransition(States.BoxIdle, States.BoxPushingState, _conditions.CheckIfRunRight),
            new UpdateTransition(States.BoxIdle, States.BoxPullingState, _conditions.CheckIfRunLeft),
            
            new UpdateTransition(States.BoxPushingState, States.BoxIdle, _conditions.CheckIfNotRun),
            new UpdateTransition(States.BoxPullingState, States.BoxIdle, _conditions.CheckIfNotRun),
        };
    }
}