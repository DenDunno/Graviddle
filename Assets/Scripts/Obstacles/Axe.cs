using UnityEngine;


public class Axe : MonoBehaviour, IRestartableComponent, IObstacle
{
    [SerializeField] private Rigidbody2D _rigidbody = null;
    

    void IRestartableComponent.Restart()
    { 
        _rigidbody.angularVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}