using System;
using UnityEngine;

[Serializable]
public class TransitionsConditions
{
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private CollisionsList _allCollisions;
    [SerializeField] private CollisionsList _characterFeet;
    private CharacterMovementDirection _characterMovementDirection;
    private Func<bool> _restartCondition;
    private LevelBorders _levelBorders;
    private Character _character;

    public void Init(CharacterMovementDirection characterMovementDirection, Character character, LevelBorders borders, Func<bool> restartCondition)
    {
        _characterMovementDirection = characterMovementDirection;
        _restartCondition = restartCondition;
        _levelBorders = borders;
        _character = character;
    }
    
    public bool CheckDeathByLevelBorders() => _levelBorders.CheckIfPositionNotWithinTheLevel(_character.transform.position);

    public bool CheckDeathFromObstacle() => _allCollisions.CheckCollision<Obstacle>();

    public bool CheckIfGrounded() => _characterFeet.CheckCollision<Ground>();
    
    public bool CheckWin() => _allCollisions.CheckCollision<FinishPortal>();

    public bool CheckIfResurrected() => _restartCondition();
    
    public bool CheckIfRun() => _characterMovementDirection.Direction != Vector2.zero;

    public bool CheckIfRestart() => _restartButton.CheckIfPressed();

    public bool CheckIfFall() => CheckIfGrounded() == false;

    public bool CheckIfNotRun() => CheckIfRun() == false;
}