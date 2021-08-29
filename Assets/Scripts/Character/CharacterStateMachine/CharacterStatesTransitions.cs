using System;
using UnityEngine;


public class CharacterStatesTransitions
{
    private readonly CharacterState _characterState;
    private readonly Action<CharacterState> _switchState;
    private readonly CameraBorders _cameraBorders;


    public CharacterStatesTransitions(CharacterState state , Action<CharacterState> characterStateTransition 
        , CameraBorders cameraBorders)
    {
        _characterState = state;
        _switchState = characterStateTransition;
        _cameraBorders = cameraBorders;
    }


    private void TryChangeState(bool transitionConditionIsMet, CharacterState newState)
    {
        if (_characterState != newState && transitionConditionIsMet)
        {
            _switchState(newState);
        }
    }


    public void TryDieByObstacle(Collider2D collision)
    {
        TryChangeState(collision.GetComponent<IObstacle>() != null, CharacterStates.DieState);
    }


    public void TryDieByLevelBorders(Transform transform)
    {
        const float levelDeathDistance = 20;
        Vector3 position = transform.position;
        Vector3 clampedPosition = position;

        _cameraBorders.ClampCamera(ref clampedPosition);

        TryChangeState(Vector3.Distance(position, clampedPosition) >= levelDeathDistance, CharacterStates.DieState);
    }


    public void TryFall(Transform transform)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.15f);

        TryChangeState(colliders.Length < 2 , CharacterStates.FallState);
    }
}
