using UnityEngine;


public class Axe : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private Rigidbody2D _rigidbody;
    

    void IRestartableComponent.Restart()
    { 
        _rigidbody.angularVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}