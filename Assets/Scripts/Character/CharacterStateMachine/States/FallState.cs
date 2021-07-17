using UnityEngine;


public class FallState : CharacterState
{
    private readonly SwipeHandler _swipeHandler;
    private readonly Transform _transform;
    private readonly CharacterMovement _characterMovement;
    private readonly float _movementSpeed = 3f;
    

    public FallState(Character character, SwipeHandler swipeHandler) : base(character)
    {
        _swipeHandler = swipeHandler;
        _characterMovement = character.GetComponent<CharacterMovement>();
        _transform = character.transform;
    }


    public override void EnterState()
    {
        _swipeHandler.enabled = false;
        _animator.Play(CharacterAnimations.Fall);
    }


    public override CharacterState Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, 0.15f);

        if (colliders.Length > 1)
        {
            _swipeHandler.enabled = true;
            return CharacterStates.IdleState;
        }

        Vector2 direction = (Vector2)_transform.position + _characterMovement.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);

        return this;
    }
}