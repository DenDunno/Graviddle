using UnityEngine;

public class RunState : CharacterState
{
    private readonly Rigidbody2D _rigidbody;
    private readonly CharacterMovementDirection _characterMovementDirection;
    private const float _movementSpeed = 3.75f;

    public RunState(Animator character, CharacterMovementDirection characterMovementDirection) : base(character, AnimationsName.Run)
    {
        _rigidbody = character.GetComponent<Rigidbody2D>();
        _characterMovementDirection = characterMovementDirection;
    }

    public override void Update()
    {
        _rigidbody.velocity = _characterMovementDirection.Direction * _movementSpeed;
    }
}