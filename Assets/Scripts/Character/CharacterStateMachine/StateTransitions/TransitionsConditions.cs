using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TransitionsConditions
{
    private readonly Transform _transform;
    private readonly CameraBorders _cameraBorders;
    private readonly MovementDirection _movementDirection;
    private readonly IReadOnlyList<Collider2D> _colliders;


    public TransitionsConditions(Character character, CameraBorders cameraBorders)
    {
        _transform = character.transform;
        _movementDirection = character.GetComponent<MovementDirection>();
        _colliders = character.GetComponent<CollisionsList>().Colliders;

        _cameraBorders = cameraBorders;
    }


    public bool CheckDeathByLevelBorders()
    {
        const float levelDeathDistance = 20;
        Vector3 position = _transform.position;
        Vector3 clampedPosition = position;

        _cameraBorders.ClampCamera(ref clampedPosition);

        return Vector3.Distance(position, clampedPosition) >= levelDeathDistance;
    }


    public bool CheckDeathByObstacle() => TryGetComponent<IObstacle>();

    public bool CheckWin() => TryGetComponent<FinishPortal>();

    public bool CheckIfFall() => Physics2D.OverlapCircleAll(_transform.position, 0.15f).Length < 2;

    public bool CheckIfRun() => _movementDirection.MoveDirection != Vector2.zero;

    public bool CheckIfGrounded() => CheckIfFall() == false;

    public bool CheckIfIdle() => CheckIfRun() == false;


    private bool TryGetComponent<T>()
    {
        return _colliders.Any(collider => collider.TryGetComponent(out T _));
    }
}