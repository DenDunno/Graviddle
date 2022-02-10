using UnityEngine;


public class CharacterStateMachine : MonoBehaviour
{
    private TransitionsPresenter _transitionsPresenter;
    private CharacterState _state;


    public void Init(CharacterState initialState, TransitionsPresenter transitionsPresenter)
    {
        _state = initialState;
        _transitionsPresenter = transitionsPresenter;
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
        _state = newState;
        _state.Enter();
    }
}