using UnityEngine;
using Zenject;


public class CharacterStateMachine : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    [Inject] private readonly CharacterStateTransitions _characterStateTransitions;
    private CharacterState _state;


    private void Start()
    {
        _state = _characterStatesPresenter.IdleState;
    }
    

    private void SwitchState(CharacterState newState)
    {
        _state = newState;
        _state.Enter();
    }


    private void Update()
    {
        _state.Update();
        TryTransit();
        EventTransition.SetCurrentState(_state);
    }


    private void TryTransit()
    {
        TransitionResult transitionResult = _characterStateTransitions.Transit(_state);

        if (transitionResult.TransitionHappened)
        {
            SwitchState(transitionResult.NewState);
        }
    }
}