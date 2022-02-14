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
    private CharacterMoveDirection _characterMoveDirection;
    private Func<bool> _restartCondition;


    public void Init(CharacterMoveDirection characterMoveDirection, Func<bool> restartCondition)
    {
        _characterMoveDirection = characterMoveDirection;
        _restartCondition = restartCondition;   
    }
    
    public bool CheckDeathByLevelBorders() => _levelBorders.CheckIfPositionNotWithinTheLevel(_character.transform.position);

    public bool CheckDeathFromObstacle() => _allCollisions.CheckCollision<Obstacle>();

    public bool CheckIfGrounded() => _characterFeet.CheckCollision<Ground>();
    
    public bool CheckWin() => _allCollisions.CheckCollision<FinishPortal>();

    public bool CheckIfResurrected() => _restartCondition();
    
    public bool CheckIfRun() => _characterMoveDirection.Direction != Vector2.zero;

    public bool CheckIfRestart() => _restartButton.CheckIfPressed();

    public bool CheckIfFall() => CheckIfGrounded() == false;

    public bool CheckIfNotRun() => CheckIfRun() == false;
}