using System.Linq;


public class TransitionsPresenter : TransitionsPresenterBase
{
    private readonly UpdateTransitions _updateTransitions;
    private readonly EventTransitions _eventTransitions;


    public TransitionsPresenter(UpdateTransitions updateTransitions, EventTransitions eventTransitions)
    {
        _updateTransitions = updateTransitions;
        _eventTransitions = eventTransitions;
    }


    public Transition GetTransition(CharacterState from, CharacterState to)
    {
        return _transitionsForState[from].FirstOrDefault(transition => transition.StateTo == to);
    }


    public bool TryTransit(CharacterState currentState, out CharacterState newState)
    {
        if (_updateTransitions.TryTransit(currentState, out newState))
        {

        }

        return currentState != newState;
    }
}