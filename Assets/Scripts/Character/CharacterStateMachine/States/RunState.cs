using UnityEngine;


public class RunState : CharacterState
{
    private readonly Transform _transform;
    private readonly MoveDirection _moveDirection;
    private const float _movementSpeed = 3;


    public RunState(Character character) : base(character, AnimationsName.Run)
    {
        _transform = character.transform;
        _moveDirection = character.GetComponent<MoveDirection>();
    }


    public override void Update()
    {
        Vector2 direction = (Vector2)_transform.position + _moveDirection.Direction;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}