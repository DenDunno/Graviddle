using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UpdateTransitionsPresenterFactory
{
    [SerializeField] private LevelBorders _levelBorders = null;
    private CharacterStatesPresenter _states;
    private UpdateTransitionsConditions _conditions;


    public void Init(Character character, CharacterStatesPresenter states)
    {
        _states = states;
        _conditions = new UpdateTransitionsConditions(character, _levelBorders);
    }


    public TransitionPresenter Create()
    {
        var updateTransitionsPresenter = new TransitionPresenter();
        List<UpdateTransition> updateTransitions = GetUpdateTransitions();

        updateTransitions.ForEach(transition => updateTransitionsPresenter.AddTransition(transition));

        return updateTransitionsPresenter;
    }


    private List<UpdateTransition> GetUpdateTransitions()
    {
        return new List<UpdateTransition>()
        {
            new UpdateTransition(_states.IdleState, _states.DieState, _conditions.CheckDeathByObstacle),
            new UpdateTransition(_states.IdleState, _states.RunState, _conditions.CheckIfRun),
            new UpdateTransition(_states.IdleState, _states.FallState, _conditions.CheckIfFall),
            new UpdateTransition(_states.IdleState, _states.WinState, _conditions.CheckWin),

            new UpdateTransition(_states.RunState, _states.DieState, _conditions.CheckDeathByObstacle),
            new UpdateTransition(_states.RunState, _states.FallState, _conditions.CheckIfFall),
            new UpdateTransition(_states.RunState, _states.IdleState, _conditions.CheckIfIdle),
            new UpdateTransition(_states.RunState, _states.WinState, _conditions.CheckWin),

            new UpdateTransition(_states.FallState, _states.DieState, _conditions.CheckDeathByObstacle),
            new UpdateTransition(_states.FallState, _states.DieState, _conditions.CheckDeathByLevelBorders),
            new UpdateTransition(_states.FallState, _states.IdleState, _conditions.CheckIfGrounded),
            new UpdateTransition(_states.FallState, _states.WinState, _conditions.CheckWin),
        };
    }
}