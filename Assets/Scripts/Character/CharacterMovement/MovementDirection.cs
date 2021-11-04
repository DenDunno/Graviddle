using UnityEngine;


[RequireComponent(typeof(CharacterGravity))]
public class MovementDirection : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    private CharacterGravity _characterGravity = null;
    private Movement _movement;

    public Vector2 MoveDirection { get; private set; }


    private void Start()
    {
        _characterGravity = GetComponent<CharacterGravity>();
    }


    private void Update()
    {
        // inversion when character upside
        int sign = (int)_movement * _characterGravity.MovementInversion;
        var actualMovement = (Movement)sign;
        
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