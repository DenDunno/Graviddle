using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UpdateTransitionsPresenterFactory : TransitionsPresenterFactory
{
    [SerializeField] private LevelBorders _levelBorders = null;
    private UpdateTransitionsConditions _conditions;


    public void CreateConditions(Character character)
    {
        _conditions = new UpdateTransitionsConditions(character, _levelBorders);
    }


    protected override List<Transition> GetTransitions()
    {
        return new List<Transition>()
        {
            new UpdateTransition(_states.IdleState, _states.RunState, _conditions.CheckIfRun),
            new UpdateTransition(_states.IdleState, _states.FallState, _conditions.CheckIfFall),

            new UpdateTransition(_states.RunState, _states.FallState, _conditions.CheckIfFall),
            new UpdateTransition(_states.RunState, _states.IdleState, _conditions.CheckIfNotRun),

            new UpdateTransition(_states.FallState, _states.DieState, _conditions.CheckDeathByLevelBorders),
            new UpdateTransition(_states.FallState, _states.IdleState, _conditions.CheckIfGrounded)
        };
    }
}