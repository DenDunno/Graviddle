using UnityEngine;


public class CameraSizeFitter
{
    private readonly float _targetAspect = 1920 / 1080f;


    public void FitCameraSize(Camera camera)
    {
        float sizeFitter = _targetAspect / camera.aspect;

        if (sizeFitter < 1)
        {
            camera.orthographicSize *= sizeFitter;
        }
    }
}