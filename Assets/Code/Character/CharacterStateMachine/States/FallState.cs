using System;
using UnityEngine;


public class FallState : CharacterState
{
    private readonly Rigidbody2D _rigidbody;
    private readonly CharacterMoveDirection _characterMoveDirection;
    private const float _movementSpeed = 8f;
    public event Action CharacterFalling;


    public FallState(Animator character, CharacterMoveDirection characterMoveDirection) : base(character, AnimationsName.Fall)
    {
        _rigidbody = character.GetComponent<Rigidbody2D>();
        _characterMoveDirection = characterMoveDirection;
    }

    
    protected override void OnEnterState()
    { 
        _rigidbody.velocity = Vector2.zero;;
        CharacterFalling?.Invoke();
    }
    

    public override void Update()
    {
        _rigidbody.velocity += _characterMoveDirection.Direction * (_movementSpeed * Time.deltaTime);
    }
}