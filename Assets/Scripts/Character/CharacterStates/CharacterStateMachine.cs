using UnityEngine;


public class CharacterStateMachine : MonoBehaviour
{
    private CharacterState _state;


    private void Update()
    {
        var newState = _state.Update();

        if (newState != _state)
        {
            _state = newState;
            _state.EnterState();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Obstacle>(out var obstacle) == true)
        {
            _state = CharacterStates.DieState;
        }
    }
}
