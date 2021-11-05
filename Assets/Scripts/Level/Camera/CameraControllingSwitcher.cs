using UnityEngine;


public class CameraControllingSwitcher : MonoBehaviour
{
    [SerializeField] private CameraControlling _cameraControlling = null;
    [SerializeField] private CameraCapturePresenter _characterCapture = null;    
    

    public void ToggleCameraControlling(bool cameraControllingEnabled)
    {
        _cameraControlling.enabled = cameraControllingEnabled;
        _characterCapture.enabled = !cameraControllingEnabled;
    }
}