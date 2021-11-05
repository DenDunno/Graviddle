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
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.z = _capturePresenter.transform.position.z;

        _cameraBorders.ClampCamera(ref newCameraPosition);

        _mainCamera.position = Vector3.Lerp(_mainCamera.position, newCameraPosition, _captureSpeed * Time.deltaTime);
    }
}