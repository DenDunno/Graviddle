using UnityEngine;


public class CharacterStateMachine : MonoBehaviour , IRestartableComponent
{
    private TransitionsPresenter _transitionsPresenter;
    private CharacterState _state;


    private void Start()
    {
        _transitionsPresenter = new TransitionsPresenter();
        _state = CharacterStates.IdleState;
    }
    

    private void SwitchState(CharacterState newState)
    {
        _state = newState;
        _state.Enter();
    }


    private void Update()
    {
        _state.Update();

        CharacterState newState = _transitionsPresenter.TryTransit(_state);

        if (newState != _state)
        {
            SwitchState(newState);
        }
    }
    

    void IRestartableComponent.Restart()
    {
        SwitchState(CharacterStates.IdleState);
    }
}
