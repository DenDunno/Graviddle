using UnityEngine;


public abstract class CharacterFallingEventsHandler : MonoBehaviour
{
    [LightweightInject] private readonly TransitionsPresenter _transitionsPresenter;
    [LightweightInject] private readonly CharacterStatesPresenter _states;
    private Transition _transition;


    private void Start()
    {
        _transition = _transitionsPresenter.GetTransition(_states.FallState, _states.IdleState);

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