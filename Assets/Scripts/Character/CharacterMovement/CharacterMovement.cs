using UnityEngine;


public class CharacterMovement
{
    private readonly Transform _transform;
    private readonly MovementDirection _movementDirection;
    private readonly float _movementSpeed = 3f;


    public CharacterMovement(Character character)
    {
        _transform = character.transform;
        _movementDirection = character.GetComponent<MovementDirection>();
    }


    public void Update()
    {
        Vector2 direction = (Vector2)_transform.position + _movementDirection.MoveDirection;
        _transform.position = Vector3.MoveTowards(_transform.position, direction, _movementSpeed * Time.deltaTime);
    }
}
