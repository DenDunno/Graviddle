using System;
using UnityEngine;


public class AnyState 
{
    public Action<CharacterState> StateChanged;
    private readonly CameraBorders _cameraBorders = null;


    private void TryChangeState(bool conditionIsMet, CharacterState newState)
    {
        if (conditionIsMet)
        {
            StateChanged?.Invoke(newState);
        }
    }


    public void TryDie(Collider2D collision)
    {
        TryChangeState(collision.GetComponent<IObstacle>() != null, CharacterStates.DieState);
    }


    public void TryDie(Transform transform)
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
