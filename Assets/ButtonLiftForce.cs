using UnityEngine;


public class ButtonLiftForce : MonoBehaviour, IRestart
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 0.05f;


    private void Update()
    {
        _rigidbody.velocity += (Vector2)transform.up * (_speed * Time.deltaTime);
    }

    
    void IRestart.Restart()
    {
        enabled = false;
        _rigidbody.velocity = Vector2.zero;
    }
}
