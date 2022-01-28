using UnityEngine;


public class UpdateTransitionsConditions
{
    private readonly Transform _transform;
    private readonly LevelBorders _levelBorders;
    private readonly MoveDirection _moveDirection;
    private readonly CharacterFeet _characterFeet;


    public UpdateTransitionsConditions(Character character, LevelBorders levelBorders)
    {
        _transform = character.transform;
        _moveDirection = character.GetComponent<MoveDirection>();
        _characterFeet = character.GetComponentInChildren<CharacterFeet>();

        _levelBorders = levelBorders;
    }


    public bool CheckDeathByLevelBorders() => _levelBorders.CheckIfPositionNotWithinTheLevel(_transform.position);

    public bool CheckIfGrounded() => _characterFeet.CheckIfGrounded();

    public bool CheckIfFall() => CheckIfGrounded() == false;
    
    public bool CheckIfRun() => _moveDirection.State != MovementState.Stop;
    
    public bool CheckIfRunLeft() => _moveDirection.State == MovementState.Left;

    public bool CheckIfRunRight() => _moveDirection.State == MovementState.Right;

    public bool CheckIfNotRun() => _moveDirection.State == MovementState.Stop;
}