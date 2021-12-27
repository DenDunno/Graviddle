using UnityEngine;
using Zenject;


public abstract class CharacterFallingEventsHandler : MonoBehaviour
{
    [Inject] private readonly TransitionsPresenter _transitionsPresenter = null;
    [Inject] private readonly CharacterStatesPresenter _states = null;
    private Transition _transition;


    private void Awake()
    {
        _transition = _transitionsPresenter.GetTransition(_states.FallState, _states.IdleState);
    }


    private void OnEnable()
    {
        _states.FallState.CharacterFalling += OnCharacterStartFalling;
        _transition.TransitionHappened += OnCharacterEndFalling;
    }


    private void OnDisable()
    {
        _states.FallState.CharacterFalling -= OnCharacterStartFalling;
        _transition.TransitionHappened -= OnCharacterEndFalling;
    }


    protected abstract void OnCharacterStartFalling();
    protected abstract void OnCharacterEndFalling();
}