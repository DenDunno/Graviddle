using UnityEngine;


public class CameraCapture : MonoBehaviour
{
    private CameraCapturePresenter _capturePresenter;
    private CameraBorders _cameraBorders;
    private Transform _mainCamera;
    private float _captureSpeed = 2f;


    private void Start()
    {
        _capturePresenter = Camera.main.GetComponent<CameraCapturePresenter>();
        _cameraBorders = _capturePresenter.GetComponent<CameraBorders>();
        _mainCamera = _capturePresenter.transform;
    }


    public void CaptureMe()
    {
        _capturePresenter.CaptureObject(this);
    }


    private void LateUpdate()
    {
        _mainCamera.position = Vector3.Lerp(_mainCamera.position, GetNewPosition(), _captureSpeed * Time.deltaTime);
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