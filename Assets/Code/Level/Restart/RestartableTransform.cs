using UnityEngine;


public class RestartableTransform : MonoBehaviour
{
    private Transform _objectToBeRestarted;
    private Vector3 _position;
    private Quaternion _rotation;
    private Transform _parent;


    private void Start()
    {
        _objectToBeRestarted = transform;
        _position = transform.position;
        _rotation = transform.rotation;
        _parent = transform.parent;
    }


    public void Restart()
    {
        _objectToBeRestarted.position = _position;
        _objectToBeRestarted.rotation = _rotation;
        _objectToBeRestarted.SetParent(_parent);
    }
}