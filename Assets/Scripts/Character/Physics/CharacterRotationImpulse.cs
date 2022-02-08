using UnityEngine;


public class CharacterRotationImpulse
{
    private readonly SwipeHandler _swipeHandler;
    private readonly Rigidbody2D _rigidbody;
    private int _currentZRotation;
    private const int _straightAngle = 180;


    public CharacterRotationImpulse(SwipeHandler swipeHandler, Rigidbody2D rigidbody2D)
    {
        _swipeHandler = swipeHandler;
        _rigidbody = rigidbody2D;
        _swipeHandler.GravityChanged += TryImpulseCharacter;
    }

    
    ~CharacterRotationImpulse()
    {
        _swipeHandler.GravityChanged -= TryImpulseCharacter;
    }


    private void TryImpulseCharacter(GravityDirection gravityDirection)
    {
        int newZRotation = GravityDataPresenter.GravityData[gravityDirection].ZRotation;

        if (IsRightAngleRotation(newZRotation))
        {
            _rigidbody.AddForce(_rigidbody.transform.up, ForceMode2D.Impulse);
        }

        _currentZRotation = newZRotation;
    }


    private bool IsRightAngleRotation(float zRotation)
    {
        return Mathf.Abs(zRotation - _currentZRotation) % _straightAngle != 0;
    }
}