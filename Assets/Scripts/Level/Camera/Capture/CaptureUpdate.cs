
using UnityEngine;

public class CaptureUpdate
{
    private readonly Transform _mainCamera;
    private readonly Transform _target;
    private readonly CameraBorders _cameraBorders;
    private readonly float _captureTime = 0.3f;
    private Vector3 _velocity;


    public CaptureUpdate(Transform camera, Transform target, CameraBorders cameraBorders)
    {
        _mainCamera = camera;
        _target = target;
        _cameraBorders = cameraBorders;
    }


    public void MoveCamera()
    {
        _mainCamera.position = Vector3.SmoothDamp(_mainCamera.position, GetNewPosition(), ref _velocity, _captureTime);
    }


    public Vector3 GetNewPosition()
    {
        Vector3 newCameraPosition = _target.position;
        newCameraPosition.z = _mainCamera.transform.position.z;

        _cameraBorders.ClampCamera(ref newCameraPosition);

        return newCameraPosition;
    }
}
