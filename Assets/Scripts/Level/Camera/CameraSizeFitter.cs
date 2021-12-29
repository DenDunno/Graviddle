using UnityEngine;


public class CameraSizeFitter
{
    private readonly float _targetAspect = 1920 / 1080f;
    private readonly Camera _mainCamera;


    public CameraSizeFitter(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }


    public void FitCameraSize()
    {
        float sizeFitter = _targetAspect / _mainCamera.aspect;

        if (sizeFitter < 1)
        {
            _mainCamera.orthographicSize *= sizeFitter;
        }
    }
}