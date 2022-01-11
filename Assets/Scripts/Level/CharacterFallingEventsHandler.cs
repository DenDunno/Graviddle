using UnityEngine;
using Zenject;


public abstract class CharacterFallingEventsHandler : MonoBehaviour
{
    [Inject] private readonly CharacterStateTransitions _statesTransitions;
    [Inject] private readonly CharacterStatesPresenter _states;
    private Transition _transition;


    private void Awake()
    {
        _transition = _statesTransitions.GetTransition(_states.FallState, _states.IdleState);

        _states.FallState.CharacterFalling += OnCharacterStartFalling;
        _transition.TransitionHappened += OnCharacterEndFalling;
    }


    private void OnDestroy()
    {
        _states.FallState.CharacterFalling -= OnCharacterStartFalling;
        _transition.TransitionHappened -= OnCharacterEndFalling;
    }


    protected abstract void OnCharacterStartFalling();
    protected abstract void OnCharacterEndFalling();
}