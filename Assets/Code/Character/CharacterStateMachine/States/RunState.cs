using UnityEngine;


public class RunState : CharacterState
{
    private readonly Rigidbody2D _rigidbody;
    private readonly CharacterMoveDirection _characterMoveDirection;
    private const float _movementSpeed = 3;


    public RunState(Animator character, CharacterMoveDirection characterMoveDirection) : base(character, AnimationsName.Run)
    {
        _rigidbody = character.GetComponent<Rigidbody2D>();
        _characterMoveDirection = characterMoveDirection;
    }


    public override void Update()
    {
        Vector2 direction = _rigidbody.position + _characterMoveDirection.Direction;
        Vector2 newPosition = Vector3.MoveTowards(_rigidbody.position, direction, _movementSpeed * Time.deltaTime);
        
        _rigidbody.MovePosition(newPosition);
    }
}