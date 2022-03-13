﻿using UnityEngine;


public class RunState : CharacterState
{
    private readonly Rigidbody2D _rigidbody;
    private readonly CharacterMoveDirection _characterMoveDirection;
    private const float _movementSpeed = 4;
    

    public RunState(Animator character, CharacterMoveDirection characterMoveDirection) : base(character, AnimationsName.Run)
    {
        _rigidbody = character.GetComponent<Rigidbody2D>();
        _characterMoveDirection = characterMoveDirection;
    }


    public override void Update()
    {
        _rigidbody.velocity = _characterMoveDirection.Direction * _movementSpeed;
    }
}