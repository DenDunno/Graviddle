using UnityEngine;


public class RunState : CharacterState
{
    private readonly Transform _transform;
    private readonly MovementDirection _movementDirection;
    private readonly float _movementSpeed = 3f;


    public RunState(Character character) : base(character , AnimationsName.Run)
    {
        _transform = character.transform;
        _movementDirection = character.GetComponent<MovementDirection>();
    }


    public override void Update()
    {
        Vector2 direction = (Vector2)_transform.position + _movementDirection.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}
