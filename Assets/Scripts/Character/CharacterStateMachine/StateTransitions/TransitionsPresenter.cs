using System;
using System.Collections.Generic;


public class TransitionsPresenter
{
    private readonly Dictionary<CharacterState, List<Transition>> _transitions = 
        new Dictionary<CharacterState, List<Transition>>();


    public void AddTransition(CharacterState from , Func<bool> condition , CharacterState to)
    {
        var transition = new Transition(condition, to);

        if (_transitions.ContainsKey(from) == false)
        {
            _transitions[from] = new List<Transition>();
        }

        _transitions[from].Add(transition);
    }


    public bool TryTransit(CharacterState currentState , out CharacterState newState)
    {
        newState = currentState;

        foreach (Transition transition in _transitions[currentState])
        {
            if (transition.TransitionCondition())
            {
                newState = transition.StateTo;
                break;
            }
        }

        return currentState != newState;
    }
}
