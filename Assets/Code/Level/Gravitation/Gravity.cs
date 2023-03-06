using UnityEngine;

public class Gravity : IInitializable, IRestart, IFixedUpdate
{    
    private readonly Rigidbody2D _rigidbody2D;
    private Vector2 _direction = Vector2.down;
    
    public Gravity(Rigidbody2D rigidbody2D)
    {        
        _rigidbody2D = rigidbody2D;
    }

    public void Initialize()
    {
        _rigidbody2D.gravityScale = 0;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }
    
    void IFixedUpdate.FixedUpdate()
    {
        _rigidbody2D.AddForce(_direction * _rigidbody2D.mass);
    }

    void IRestart.Restart()
    {
        SetDirection(Vector2.down);
    }
}