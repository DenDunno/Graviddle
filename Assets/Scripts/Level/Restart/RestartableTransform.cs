using UnityEngine;


public class RestartableTransform : MonoBehaviour, IRestart
{
    private Transform _parent;
    private Vector3 _startPosition;
    private Quaternion _startRotation;


    private void Start()
    {
        _parent = transform.parent;
        _startPosition = transform.localPosition;
        _startRotation = transform.rotation;
    }

    
    void IRestart.Restart()
    {
        transform.SetParent(_parent);
        transform.localPosition = _startPosition;
        transform.rotation = _startRotation;
    }
}