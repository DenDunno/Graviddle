using UnityEngine;


public class TransitionsConditions
{
    private readonly Transform _transform;
    private readonly CameraClamping _cameraClamping;
    private readonly MoveDirection _moveDirection;
    private readonly CollisionsList _collisionsList;


    public TransitionsConditions(Character character, CameraClamping cameraClamping)
    {
        _transform = character.transform;
        _moveDirection = character.GetComponent<MoveDirection>();
        _collisionsList = character.GetComponent<CollisionsList>();

        _cameraClamping = cameraClamping;
    }


    public bool CheckDeathByLevelBorders()
    {
        const float levelDeathDistance = 20;

        Vector3 currentPosition = _transform.position;
        Vector3 clampedPosition = _cameraClamping.Clamp(currentPosition);

        return Vector3.Distance(currentPosition, clampedPosition) >= levelDeathDistance;
    }


    public bool CheckDeathByObstacle() => _collisionsList.CheckComponent<IObstacle>();

    public bool CheckWin() => _collisionsList.CheckComponent<FinishPortal>();

    public bool CheckIfGrounded() => _collisionsList.CheckComponent<Ground>();

    public bool CheckIfRun() => _moveDirection.Direction != Vector2.zero;

    public bool CheckIfFall() => CheckIfGrounded() == false;

    public bool CheckIfIdle() => CheckIfRun() == false;
}