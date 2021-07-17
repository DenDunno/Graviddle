using UnityEngine;


[RequireComponent(typeof(CharacterGravity))]
public class CharacterMovement : MonoBehaviour , IAfterRestartComponent
{
    public Vector2 MoveDirection { get; private set; }

    private Movement _movement; 
    private SpriteRenderer _spriteRenderer;
    private CharacterGravity _characterGravity;


    private void Start()
    {
        _characterGravity = GetComponent<CharacterGravity>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    private void Update()
    {
        //inversion when character upside
        int sign = (int)_movement * _characterGravity.MovementInversion;
        Movement actualMovement = (Movement)sign;
        
        MoveDirection = transform.right * sign;

        if (actualMovement != Movement.Stop)
        {
            _spriteRenderer.flipX = (actualMovement == Movement.Left);
        }
    }


    public void MoveCharacter(Movement movement) 
    {
        int movementInt = (int)movement * _characterGravity.MovementInversion;
        _movement = (Movement)movementInt;
    }


    public void StopCharacter() 
    {
        _movement = Movement.Stop;
    }


    void IAfterRestartComponent.Restart()
    {
        StopCharacter();
    }
}





