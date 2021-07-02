using UnityEngine;


public class CharacterStateMachine : MonoBehaviour , IRestartableObject
{
    private CharacterState _state;


    private void Start()
    {
        _state = CharacterStates.IdleState;
    }


    private void SwitchState(CharacterState newState)
    {
        _state = newState;
        _state.EnterState();
    }


    private void Update()
    {
        CharacterState newState = _state.Update();
        
        if (newState != _state)
        {
            SwitchState(newState);
        }
    }


    private void FixedUpdate()
    {
        if (_state != CharacterStates.FallState)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.15f);

            if (colliders.Length < 2)
            {
                SwitchState(CharacterStates.FallState);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Obstacle>(out var obstacle) == true)
        {
            if (_state != CharacterStates.DieState)
            {
                SwitchState(CharacterStates.DieState);
            }
        }
    }


    void IRestartableObject.Restart()
    {
        SwitchState(CharacterStates.IdleState);
    }
}
