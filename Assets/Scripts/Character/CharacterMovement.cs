using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public Movement СharacterMovement { get; private set; }
    private SpriteRenderer _spriteRenderer;


    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    private void Update()
    {
        if (СharacterMovement != Movement.Stop)
        {
            _spriteRenderer.flipX = СharacterMovement == Movement.Left;
        }
    }


    public void MoveCharacter(Movement movement)
    {
        СharacterMovement = movement;
    }


    public void StopCharacter()
    {
        СharacterMovement = Movement.Stop;
    }
}





