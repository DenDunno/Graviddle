using UnityEngine;


public class RestartableTransform
{
    private readonly Transform _objectToBeRestarted;
    private readonly Vector3 _position;
    private readonly Quaternion _rotation;
    private readonly Transform _parent;

        
    public RestartableTransform(Transform transform)
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
        _objectToBeRestarted.parent = _parent;
    }
}