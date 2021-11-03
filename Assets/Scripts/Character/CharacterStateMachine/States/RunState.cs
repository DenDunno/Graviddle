using UnityEngine;


public class RunState : CharacterState
{
    private readonly Transform _transform;
    private readonly CharacterMovement _characterMovement;
    private readonly float _movementSpeed = 3f;


    public RunState(Character character) : base(character , AnimationsName.Run)
    {
        _characterMovement = character.GetComponent<CharacterMovement>();
        _transform = character.transform;
    }


    protected override void OnUpdateState()
    {
        Vector2 direction = (Vector2)_transform.position + _characterMovement.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}
