using UnityEngine;


public class RotatingBlade : MonoBehaviour , IObstacle
{
    [SerializeField] private float _rotationSpeed = 2f;
    private Quaternion _rotationTo;


    private void Start()
    {
        _rotationTo = Quaternion.AngleAxis(_rotationSpeed, transform.forward);
    }


    private void FixedUpdate()
    {
        transform.rotation *= _rotationTo;
    }
}

