using System;
using UnityEngine;


[Serializable]
public class TransitionsConditions
{
    [SerializeField] private Character _character;
    [SerializeField] private LevelBorders _levelBorders;
    [SerializeField] private MoveDirection _moveDirection;
    [SerializeField] private TransitButton _restartButton;
    [SerializeField] private CollisionsList _allCollisions;
    [SerializeField] private CollisionsList _characterFeet;
    private CharacterRestartEvent _characterRestartEvent;


    public void Init(CharacterRestartEvent characterRestartEvent)
    {
        _characterRestartEvent = characterRestartEvent;   
    }
    
    public bool CheckDeathByLevelBorders() => _levelBorders.CheckIfPositionNotWithinTheLevel(_character.transform.position);

    public bool CheckDeathFromObstacle() => _allCollisions.CheckCollision<Obstacle>();

    public bool CheckIfGrounded() => _characterFeet.CheckCollision<Ground>();
    
    public bool CheckWin() => _allCollisions.CheckCollision<FinishPortal>();

    public bool CheckIfResurrected() => _characterRestartEvent.CheckRestart();
    
    public bool CheckIfRun() => _moveDirection.Direction != Vector2.zero;

    public bool CheckIfRestart() => _restartButton.CheckIfPressed();

    public bool CheckIfFall() => CheckIfGrounded() == false;

    public bool CheckIfNotRun() => CheckIfRun() == false;
}