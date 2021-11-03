using System.Collections.Generic;
using System.Linq;


public class TransitionsPresenter
{
    private readonly Dictionary<CharacterState, List<Transition>> _transitions = 
        new Dictionary<CharacterState, List<Transition>>();


    public void AddTransition(CharacterState from , Transition transition)
    {
        if (_transitions.ContainsKey(from) == false)
        {
            _transitions[from] = new List<Transition>();
        }

        _transitions[from].Add(transition);
    }


    public CharacterState TryTransit(CharacterState transitFrom)
    {
        CharacterState answer = transitFrom;

        IOrderedEnumerable<Transition> transitionsForState = _transitions[transitFrom].OrderBy(transition => transition.Priority);

        foreach (Transition transition in transitionsForState)
        {
            if (transition.TransitionCondition())
            {
                answer = transition.StateTo;
                break;
            }
        }

        return answer;
    }
}
