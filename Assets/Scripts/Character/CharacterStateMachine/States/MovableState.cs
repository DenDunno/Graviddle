using UnityEngine;


public class MovableState : CharacterState
{
    private readonly Transform _transform;
    private readonly MoveDirection _moveDirection;
    private readonly float _movementSpeed;


    public MovableState(Character character, float speed, string animationName) : base(character, animationName)
    {
        _transform = character.transform;
        _moveDirection = character.GetComponent<MoveDirection>();
        _movementSpeed = speed;
    }


    public override void Update()
    {
        Vector2 direction = (Vector2)_transform.position + _moveDirection.Direction;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}