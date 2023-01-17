using UnityEngine;

public class RestartableTransform : MonoBehaviour, IRestart
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Transform _parent;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _parent = transform.parent;
    }

    void IRestart.Restart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        transform.SetParent(_parent);
    }
}