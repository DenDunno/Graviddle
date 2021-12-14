using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraSizeFitter : MonoBehaviour
{
    private Camera _camera;
    private readonly float _targetAspect = 1920 / 1080f;


    private void Start()
    {
        _camera = GetComponent<Camera>();
        FitCameraSize();
    }


    public void FitCameraSize()
    {
        float sizeFitter = _targetAspect / _camera.aspect;

        if (sizeFitter < 1)
        {
            _camera.orthographicSize *= sizeFitter;
        }
    }
}