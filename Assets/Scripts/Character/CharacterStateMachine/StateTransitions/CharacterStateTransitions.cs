using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


public class CharacterStateTransitions
{
    private readonly TransitionsPresenter[] _transitionPresenters;
    private readonly ReadOnlyDictionary<CharacterState, List<Transition>> _allTransitions;


    public CharacterStateTransitions(TransitionsPresenter eventTransitions, TransitionsPresenter updateTransitions)
    {
        _transitionPresenters = new[] { eventTransitions, updateTransitions };
        var allTransitions = eventTransitions.Transitions.Merge(updateTransitions.Transitions);
        _allTransitions = new ReadOnlyDictionary<CharacterState, List<Transition>>(allTransitions);
    }


    public Transition GetTransition(CharacterState stateFrom, CharacterState stateTo)
    {
        return _allTransitions[stateFrom].FirstOrDefault(transition => transition.StateTo == stateTo);
    }

    
    public TransitionResult Transit(CharacterState currentState)
    {
        var transitionResults = _transitionPresenters.Select(presenter => presenter.Transit(currentState));
        
        return transitionResults.FirstOrDefault(result => result.TransitionHappened);
    }
}