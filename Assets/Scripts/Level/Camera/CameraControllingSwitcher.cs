using UnityEngine;


public class CameraControllingSwitcher : MonoBehaviour
{
    private CameraControlling _cameraControlling = null;
    private CameraCapturePresenter _capturePresenter = null;


    private void Start()
    {
        Camera mainCamera = Camera.main;

        _cameraControlling = mainCamera.GetComponent<CameraControlling>();
        _capturePresenter = mainCamera.GetComponent<CameraCapturePresenter>();
    }


    public void ActivateCameraControlling()
    {
        _capturePresenter.UntieAll();
        _cameraControlling.enabled = true;
    }


    public void DeactivateCameraControlling()
    {
        _capturePresenter.ActivateLastCapture();
        _cameraControlling.enabled = false;
    }
}