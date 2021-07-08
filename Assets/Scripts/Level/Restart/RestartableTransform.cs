using UnityEngine;


public class RestartableTransform : MonoBehaviour, IRestartableComponent
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;


    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }


    void IRestartableComponent.Restart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}