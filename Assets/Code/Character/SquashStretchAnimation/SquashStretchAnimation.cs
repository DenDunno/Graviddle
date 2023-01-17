using UnityEngine;

public class SquashStretchAnimation : CharacterFallingEventsHandler, IFixedUpdate 
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Squash _squash;
    private readonly Stretch _stretch;
    private float _velocity;

    public SquashStretchAnimation(Rigidbody2D rigidbody, SpriteRenderer sprite, Transition fallToIdleTransition, FallState fallState) 
        : base(fallToIdleTransition, fallState)
    {
        _rigidbody = rigidbody;
        _squash = new Squash(sprite.transform);
        _stretch = new Stretch(sprite.transform);
    }
    
    void IFixedUpdate.FixedUpdate()
    {
        if (IsFalling)
        {
            _velocity = _rigidbody.velocity.magnitude;
            _stretch.SetStretch(_velocity);
        }
    }

    protected override void OnEndFalling()
    {
        _squash.Play(_velocity);
    }
}