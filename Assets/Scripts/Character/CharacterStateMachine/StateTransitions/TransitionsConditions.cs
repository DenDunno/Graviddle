using UnityEngine;

public class TransitionsConditions
{
    private readonly Transform _characterTransform;
    private readonly CameraBorders _cameraBorders;
    private readonly MovementDirection _movementDirection;


    public TransitionsConditions(Character character, CameraBorders cameraBorders)
    {
        _characterTransform = character.transform;
        _movementDirection = character.GetComponent<MovementDirection>();
        _cameraBorders = cameraBorders;
    }


    public bool CheckDeathByLevelBorders()
    {
        const float levelDeathDistance = 20;
        Vector3 position = _characterTransform.position;
        Vector3 clampedPosition = position;

        _cameraBorders.ClampCamera(ref clampedPosition);

        return Vector3.Distance(position, clampedPosition) >= levelDeathDistance;
    }


    public bool CheckIfFall()
    {
        const float radius = 0.15f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_characterTransform.position, radius);

        return colliders.Length < 2;
    }


    public bool CheckIfRun() => _movementDirection.MoveDirection != Vector2.zero;

    public bool CheckIfIdle() => CheckIfRun() == false;

    public bool CheckIfGrounded() => CheckIfFall() == false;
}