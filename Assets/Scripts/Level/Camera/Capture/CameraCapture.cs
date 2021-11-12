using UnityEngine;


public class CameraCapture : MonoBehaviour
{
    private readonly float _captureTime = 0.3f;
    private CameraCapturePresenter _capturePresenter;
    private CameraBorders _cameraBorders;
    private Transform _mainCamera;
    private Vector3 _velocity;


    private void Start()
    {
        _capturePresenter = Camera.main.GetComponent<CameraCapturePresenter>();
        _cameraBorders = _capturePresenter.GetComponent<CameraBorders>();
        _mainCamera = _capturePresenter.transform;
    }


    public void CaptureMe()
    {
        if (_capturePresenter == null)
        {
            Start();
        }

        _capturePresenter.CaptureObject(this);
    }


    private void LateUpdate()
    {
        _mainCamera.position = Vector3.SmoothDamp(_mainCamera.position, GetNewPosition(), ref _velocity ,_captureTime);
    }


    private Vector3 GetNewPosition()
    {
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.z = _mainCamera.transform.position.z;

        _cameraBorders.ClampCamera(ref newCameraPosition);

        return newCameraPosition;
    }


    public void ResetCameraTransform()
    {
        _mainCamera.position = GetNewPosition();
        _mainCamera.rotation = transform.rotation;
    }
}