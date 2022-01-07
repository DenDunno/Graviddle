using System.Collections.Generic;


public class TransitionPresenter
{
    private readonly Dictionary<CharacterState, List<Transition>> _transitions =
        new Dictionary<CharacterState, List<Transition>>();

    public IReadOnlyDictionary<CharacterState, List<Transition>> Transitions => _transitions;


    public void Init(CharacterStateMachine characterStateMachine)
    {

    }


    public void AddTransition(Transition transition)
    {
        if (_transitions.ContainsKey(transition.StateFrom) == false)
        {
            _transitions.Add(transition.StateFrom, new List<Transition>());
        }

        _transitions[transition.StateFrom].Add(transition);
    }


    public TransitionResult Transit(CharacterState currentState)
    {
        var transitionResult = new TransitionResult();

        if (_transitions.ContainsKey(currentState))
        {
            foreach (Transition transition in _transitions[currentState])
            {
                if (transition.CheckIfTransitionHappened())
                {
                    transitionResult = new TransitionResult(transition.StateTo);
                    break;
                }
            }
        }

        return transitionResult;
    }
}