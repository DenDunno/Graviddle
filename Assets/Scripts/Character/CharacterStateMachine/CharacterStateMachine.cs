using UnityEngine;


public class CharacterStateMachine : MonoBehaviour , IRestartableComponent
{
    private CharacterState _state;


    private void Start()
    {
        _state = CharacterStates.IdleState;
    }
    

    private void SwitchState(CharacterState newState)
    {
        _state = newState;
        _state.Enter();
    }


    private void Update()
    {
        CharacterState newState = _state.Update();

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
