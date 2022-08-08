using UnityEngine;


public class CharacterRotationImpulse : ISubscriber
{
    private readonly Rigidbody2D _rigidbody;
    private readonly SwipeHandler _swipeHandler;
    private const int _straightAngle = 180;
    private int _currentZRotation;


    public CharacterRotationImpulse(Rigidbody2D rigidbody2D, SwipeHandler swipeHandler)
    {
        _rigidbody = rigidbody2D;
        _swipeHandler = swipeHandler;
    }


    void ISubscriber.Subscribe()
    {
        _swipeHandler.GravityChanged += TryImpulseCharacter;
    }
    

    void ISubscriber.Unsubscribe()
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