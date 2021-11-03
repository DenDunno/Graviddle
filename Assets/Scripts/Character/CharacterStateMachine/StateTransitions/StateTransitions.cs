using System.Collections.Generic;

public class StateTransitions
{
    private readonly List<Transition> _transitions;
    private CharacterState _currentState;


    public StateTransitions(CharacterState currentState , List<Transition> transitions)
    {
        _currentState = currentState;
        _transitions = transitions;
    }


    public CharacterState TryGetNewState()
    {
        CharacterState state = _currentState;

        foreach (Transition transition in _transitions)
        {
            if (transition.CheckTransition())
            {
                state = transition.ResultState;
                break;
            }
        }

        return state;
    }
}