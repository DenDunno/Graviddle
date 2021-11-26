using UnityEngine;


public class TransitionsConditions
{
    private readonly Transform _transform;
    private readonly CameraBorders _cameraBorders;
    private readonly MovementDirection _movementDirection;
    private readonly CollisionsList _collisionsList;


    public TransitionsConditions(Character character, CameraBorders cameraBorders)
    {
        _transform = character.transform;
        _movementDirection = character.GetComponent<MovementDirection>();
        _collisionsList = character.GetComponent<CollisionsList>();

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


    public bool CheckDeathByObstacle() => _collisionsList.CheckComponent<IObstacle>();

    public bool CheckWin() => _collisionsList.CheckComponent<FinishPortal>();

    public bool CheckIfGrounded() => _collisionsList.CheckComponent<Ground>();

    public bool CheckIfRun() => _movementDirection.MoveDirection != Vector2.zero;

    public bool CheckIfFall() => CheckIfGrounded() == false;

    public bool CheckIfIdle() => CheckIfRun() == false;
}