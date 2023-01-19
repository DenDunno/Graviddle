using System;
using System.Collections.Generic;

public class TransitionsPresenterFactory
{
    private readonly CharacterStatesPresenter _states;
    private readonly TransitionsConditions _transitionsConditions;

    public TransitionsPresenterFactory(CharacterStatesPresenter states, TransitionsConditions transitionsConditions)
    {
        _transitionsConditions = transitionsConditions;
        _states = states;
    }

    public TransitionsPresenter Create()
    {
        TransitionsPresenter transitionPresenter = new();

        foreach (Transition transition in GetTransitions())
        {
            transitionPresenter.AddTransition(transition);
        }

        return transitionPresenter;
    }

    private IEnumerable<Transition> GetTransitions()
    {
        List<Transition> allTransitions = new();

        allTransitions.AddRange(GetTransitionsWithState(_states.WinState, _transitionsConditions.CheckWin));
        
        allTransitions.AddRange(GetTransitionsWithState(_states.DieState, _transitionsConditions.CheckIfRestart));
        allTransitions.AddRange(GetTransitionsWithState(_states.DieState, _transitionsConditions.CheckDeathFromObstacle));
        allTransitions.Add(new Transition(_states.FallState, _states.DieState, _transitionsConditions.CheckDeathByLevelBorders));
        
        allTransitions.Add(new Transition(_states.DieState, _states.IdleState, _transitionsConditions.CheckIfResurrected));
        allTransitions.Add(new Transition(_states.FallState, _states.IdleState, _transitionsConditions.CheckIfGrounded));
        allTransitions.Add(new Transition(_states.RunState, _states.IdleState, _transitionsConditions.CheckIfNotRun));
        
        allTransitions.Add(new Transition(_states.IdleState, _states.RunState, _transitionsConditions.CheckIfRun));
        
        allTransitions.Add(new Transition(_states.RunState, _states.FallState, _transitionsConditions.CheckIfFall));
        allTransitions.Add(new Transition(_states.IdleState, _states.FallState, _transitionsConditions.CheckIfFall));

        return allTransitions;
    }

    private IEnumerable<Transition> GetTransitionsWithState(CharacterState targetState, Func<bool> condition)
    {
        List<Transition> transitionsWithState = new();

        foreach (CharacterState stateFrom in _states.GameActiveStates)
        {
            transitionsWithState.Add(new Transition(stateFrom, targetState, condition));
        }

        return transitionsWithState;
    }
}