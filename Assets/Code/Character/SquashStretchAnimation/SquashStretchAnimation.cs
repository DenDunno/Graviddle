using UnityEngine;


public class SquashStretchAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private CollisionsList _characterFeet;
    private Squash _squash;
    private Stretch _stretch;
    private bool _isFalling;
    private float _velocity;


    private void Start()
    {
        _squash = new Squash(transform);
        _stretch = new Stretch(transform);
    }

    
    private void Update()
    {
        if (_characterFeet.CheckCollision<Ground>() == false)
        {
            _isFalling = true;
            _velocity = _rigidbody.velocity.magnitude;
            _stretch.SetStretch(_velocity);
        }
        else
        {
            if (_isFalling)
            {
                _isFalling = false;
                _squash.Play(_velocity);
            }
        }
    }
}