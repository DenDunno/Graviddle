using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;


public class CharacterStateTransitions
{
    private readonly TransitionPresenter[] _transitionPresenters;
    private ReadOnlyDictionary<CharacterState, List<Transition>> _allTransitions;


    public CharacterStateTransitions(TransitionPresenter eventTransitions, TransitionPresenter updateTransitions)
    {
        _transitionPresenters = new[] { eventTransitions, updateTransitions };
        var allTransitions = eventTransitions.Transitions.Merge(updateTransitions.Transitions);
        _allTransitions = new ReadOnlyDictionary<CharacterState, List<Transition>>(allTransitions);
    }

    public void Init(CharacterStateMachine characterStateMachine)
    {
        _characterStateMachine = characterStateMachine;
    }


    public Transition GetTransition(CharacterState stateFrom, CharacterState stateTo)
    {
        return _allTransitions[stateFrom].FirstOrDefault(transition => transition.StateTo == stateTo);
    }

    private CharacterStateMachine _characterStateMachine;
    public TransitionResult Transit(CharacterState currentState)
    {
        Debug.Log(_characterStateMachine.State);
        return _transitionPresenters.Select(transitionPresenter => transitionPresenter.Transit(currentState))
                                    .FirstOrDefault(result => result.TransitionHappened);
    }
}