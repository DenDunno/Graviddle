using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Axe : MonoBehaviour , IRestartableComponent, IObstacle
{
    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void IRestartableComponent.Restart()
    { 
        _rigidbody.angularVelocity = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}


