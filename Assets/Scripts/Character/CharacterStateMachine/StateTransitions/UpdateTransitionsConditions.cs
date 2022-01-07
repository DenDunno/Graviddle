using UnityEngine;


public class UpdateTransitionsConditions
{
    private readonly Transform _transform;
    private readonly LevelBorders _levelBorders;
    private readonly MoveDirection _moveDirection;
    private readonly CollisionsList _collisionsList;
    private readonly CharacterFeet _characterFeet;


    public UpdateTransitionsConditions(Character character, LevelBorders levelBorders)
    {
        _transform = character.transform;
        _moveDirection = character.GetComponent<MoveDirection>();
        _collisionsList = character.GetComponent<CollisionsList>();
        _characterFeet = character.GetComponentInChildren<CharacterFeet>();

        _levelBorders = levelBorders;
    }


    public bool CheckDeathByLevelBorders() => _levelBorders.CheckIfPositionNotWithinTheLevel(_transform.position);

    public bool CheckDeathByObstacle() => _collisionsList.CheckComponent<Obstacle>();

    public bool CheckWin() => _collisionsList.CheckComponent<FinishPortal>();

    public bool CheckIfGrounded() => _characterFeet.CheckIfGrounded();

    public bool CheckIfRun() => _moveDirection.Direction != Vector2.zero;

    public bool CheckIfFall() => CheckIfGrounded() == false;

    public bool CheckIfIdle() => CheckIfRun() == false;
}