using System;
using UnityEngine;

[Serializable]
public class TransitionsConditions
{
    [SerializeField] private Character _character;
    [SerializeField] private LevelBorders _levelBorders;
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private CollisionsList _allCollisions;
    [SerializeField] private CollisionsList _characterFeet;
    private CharacterMovementDirection _characterMovementDirection;
    private Func<bool> _restartCondition;

    public void Init(CharacterMovementDirection characterMovementDirection, Func<bool> restartCondition)
    {
        _characterMovementDirection = characterMovementDirection;
        _restartCondition = restartCondition;   
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