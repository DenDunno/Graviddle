using UnityEngine;


public class CharacterRotationImpulse
{
    private readonly Rigidbody2D _rigidbody;
    private const int _straightAngle = 180;
    private int _currentZRotation;


    public CharacterRotationImpulse(Rigidbody2D rigidbody2D)
    {
        _rigidbody = rigidbody2D;
    }


    public void TryImpulseCharacter(GravityDirection gravityDirection)
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