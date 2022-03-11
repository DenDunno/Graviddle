using UnityEngine;


public class ButtonLiftForce : MonoBehaviour, IRestart
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 0.05f;
    private readonly Vector2 _localForceDirection = new Vector2(0, 1);
    private Vector2 _forceDirection;


    private void Start()
    {
        _forceDirection = transform.TransformDirection(_localForceDirection);
    }
    

    private void Update()
    {
        _rigidbody.velocity += _forceDirection * (_speed * Time.deltaTime);
    }

    
    void IRestart.Restart()
    {
        enabled = false;
        _rigidbody.velocity = Vector2.zero;
    }
}
