﻿using UnityEngine;


public class FallState : CharacterState
{
    private readonly Transform _transform;
    private readonly CharacterMovement _characterMovement;
    private readonly float _movementSpeed = 3f;


    public FallState(Character character) : base(character)
    {
        _characterMovement = character.GetComponent<CharacterMovement>();
        _transform = character.transform;
    }


    public override void EnterState()
    {
        _animator.Play("Fall");
    }


    public override CharacterState Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, 0.15f);

        if (colliders.Length > 1)
        {
            return CharacterStates.IdleState;
        }

        var direction = (Vector2)_transform.position + _characterMovement.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);

        return this;
    }
}