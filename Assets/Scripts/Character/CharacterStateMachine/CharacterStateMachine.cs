using UnityEngine;
using Zenject;


public class CharacterStateMachine : MonoBehaviour , IRestartableComponent
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    [Inject] private readonly TransitionsPresenter _transitionsPresenter = null;
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

        if (_transitionsPresenter.TryTransit(_state, out CharacterState newState))
        {
            SwitchState(newState);
        }
    }
    

    void IRestartableComponent.Restart()
    {
        SwitchState(_characterStatesPresenter.IdleState);
    }
}
