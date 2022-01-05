using System.Collections.Generic;


public abstract class TransitionsPresenterBase
{
    private readonly Dictionary<CharacterState, List<Transition>> _transitionsForState;
    public IReadOnlyDictionary<CharacterState, List<Transition>> TransitionsForState => _transitionsForState;


    protected TransitionsPresenterBase()
    {
        _transitionsForState = new Dictionary<CharacterState, List<Transition>>();
    }


    public void AddTransition(CharacterState stateFrom, Transition transition)
    {
        if (_transitionsForState.ContainsKey(stateFrom) == false)
        {
            _transitionsForState[stateFrom] = new List<Transition>();
        }

        _transitionsForState[stateFrom].Add(transition);
    }
}