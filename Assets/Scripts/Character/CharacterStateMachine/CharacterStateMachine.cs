using UnityEngine;


public class CharacterStateMachine : MonoBehaviour
{
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    [LightweightInject] private readonly TransitionsPresenter _transitionsPresenter;
    private CharacterState _state;


    private void Start()
    {
        _state = _characterStatesPresenter.IdleState;
    }


    private void Update()
    {
        _state.Update();
        TryTransit();
    }

    
    private void TryTransit()
    {
        CharacterState newState = _transitionsPresenter.Transit(_state);

        if (newState != _state)
        {
            SwitchState(newState);
        }
    }


    private void SwitchState(CharacterState newState)
    {
        Debug.Log(newState);
        _state = newState;
        _state.Enter();
    }
}