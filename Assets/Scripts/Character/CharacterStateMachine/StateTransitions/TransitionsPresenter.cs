using System;
using System.Collections.Generic;
using System.Linq;


public class TransitionsPresenter
{
    private readonly Dictionary<CharacterState, List<Transition>> _transitionsForState =
        new Dictionary<CharacterState, List<Transition>>();


    public void AddTransition(CharacterState from, Func<bool> condition, CharacterState to)
    {
        if (_transitionsForState.ContainsKey(from) == false)
        {
            _transitionsForState.Add(from, new List<Transition>());
        }

        _transitionsForState[from].Add(new Transition(from, condition, to));
    }


    public Transition GetTransition(CharacterState from, CharacterState to)
    {
        Transition answer = _transitionsForState[from].FirstOrDefault(transition => transition.StateTo == to);

        if (answer == null)
        {
            throw new ArgumentException();
        }

        return answer;
    }


    public bool TryTransit(CharacterState currentState, out CharacterState newState)
    {
        newState = currentState;

        if (_transitionsForState.ContainsKey(currentState))
        {
            foreach (Transition transition in _transitionsForState[currentState])
            {
                if (transition.CheckCondition())
                {
                    newState = transition.StateTo;
                    break;
                }
            }
        }

        return currentState != newState;
    }
}