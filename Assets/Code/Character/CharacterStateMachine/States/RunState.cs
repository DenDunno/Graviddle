using UnityEngine;


public class RunState : CharacterState
{
    private readonly Transform _transform;
    private readonly CharacterMoveDirection _characterMoveDirection;
    private const float _movementSpeed = 3;


    public RunState(Animator character, CharacterMoveDirection characterMoveDirection) : base(character, AnimationsName.Run)
    {
        _transform = character.transform;
        _characterMoveDirection = characterMoveDirection;
    }


    public override void Update()
    {
        Vector2 direction = (Vector2)_transform.position + _characterMoveDirection.Direction;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}