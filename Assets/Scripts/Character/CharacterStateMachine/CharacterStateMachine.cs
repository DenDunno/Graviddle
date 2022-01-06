using UnityEngine;
using Zenject;


public class CharacterStateMachine : MonoBehaviour, IRestartableComponent
{
    [Inject] private TransitionCheck _transitionCheck = null;
    [Inject] private CharacterStatesPresenter _characterStatesPresenter = null;
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
    }


    private void TryTransit()
    {
        TransitionResult transitionResult = _transitionCheck.Transit(_state);

        if (transitionResult.TransitionHappened)
        {
            SwitchState(transitionResult.NewState);
        }
    }


    void IRestartableComponent.Restart()
    {
        SwitchState(_characterStatesPresenter.IdleState);
    }
}