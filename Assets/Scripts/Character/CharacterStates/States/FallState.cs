using UnityEngine;


public class FallState : CharacterState
{
    private readonly Transform _characterTransform;
    private readonly CharacterMovement _movement;


    public FallState(Character character) : base(character)
    {
        _movement = character.GetComponent<CharacterMovement>();
        _characterTransform = character.transform;
    }


    public override void EnterState()
    {
        _animator.Play("Fall");
    }


    public override CharacterState Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_characterTransform.position, 0.15f);

        if (colliders.Length > 1)
        {
            return CharacterStates.IdleState;
        }

        var direction = _characterTransform.position + Vector3.right * (int)_movement.СharacterMovement;
        _characterTransform.position = Vector3.MoveTowards(_characterTransform.position, direction, 2 * Time.deltaTime);

        return this;
    }
}