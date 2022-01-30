using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterRotationImpulse : MonoBehaviour
{
    [SerializeField] private GravityDirectionHandler _gravityDirectionHandler;
    private Rigidbody2D _rigidbody;
    private int _currentZRotation;
    private readonly int _straightAngle = 180;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        _gravityDirectionHandler.GravityChanged += TryImpulseCharacter;
    }


    private void OnDisable()
    {
        _gravityDirectionHandler.GravityChanged -= TryImpulseCharacter;
    }


    private void TryImpulseCharacter(GravityDirection gravityDirection)
    {
        int newZRotation = GravityDataPresenter.GravityData[gravityDirection].ZRotation;

        if (IsRightAngleRotation(newZRotation))
        {
            _rigidbody.AddForce(transform.up, ForceMode2D.Impulse);
        }

        _currentZRotation = newZRotation;
    }


    private bool IsRightAngleRotation(float zRotation)
    {
        return Mathf.Abs(zRotation - _currentZRotation) % _straightAngle != 0;
    }
}