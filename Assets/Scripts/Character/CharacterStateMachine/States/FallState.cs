using System;
using UnityEngine;


public class FallState : CharacterState
{
    private readonly Transform _transform;
    private readonly CharacterMovement _characterMovement;
    private readonly float _movementSpeed = 3f;

    public event Action<bool> CharacterGroundedChanged;


    public FallState(Character character) : base(character , AnimationsName.Fall)
    {
        _characterMovement = character.GetComponent<CharacterMovement>();
        _transform = character.transform;
    }


    protected override void OnEnterState()
    {
        CharacterGroundedChanged?.Invoke(false);
    }


    public override void Update()
    {
        Vector2 direction = (Vector2)_transform.position + _characterMovement.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}