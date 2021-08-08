﻿using System;
using UnityEngine;


public class FallState : CharacterState
{
    public event Action<bool> CharacterGroundedChanged;
    
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
        CharacterGroundedChanged?.Invoke(false);
        _animator.Play(CharacterAnimations.Fall);
    }


    public override CharacterState Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, 0.15f);

        if (colliders.Length > 1)
        {
            CharacterGroundedChanged?.Invoke(true);
            return CharacterStates.IdleState;
        }

        Vector2 direction = (Vector2)_transform.position + _characterMovement.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);

        return this;
    }
}