using UnityEngine;


public class Axe : MonoBehaviour, IRestart
{
    [SerializeField] private Rigidbody2D _rigidbody;
    

    void IRestart.Restart()
    { 
        _rigidbody.angularVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}