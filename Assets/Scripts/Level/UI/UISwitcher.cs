using UnityEngine;


public class UISwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera = null;
    [SerializeField] private GameObject _touchPanel = null;
    [SerializeField] private GameObject _cameraPanel = null;

    private CameraTouchControlling _cameraTouchControlling;
    private CameraCapture _cameraCapture;    
    private FinishPortalCapture _finishPortalCapture;


    private void Start()
    {
        _cameraTouchControlling = _mainCamera.GetComponent<CameraTouchControlling>();
        _cameraCapture = _mainCamera.GetComponent<CameraCapture>();
        _finishPortalCapture = _mainCamera.GetComponent<FinishPortalCapture>();
    }


    public void SwitchCameraPanel(bool becomeActive)
    {
        _touchPanel.SetActive(!becomeActive);
        _cameraPanel.SetActive(becomeActive);

        _cameraCapture.enabled = !becomeActive;
        _cameraTouchControlling.enabled = becomeActive;
    }


    public void TurnOnFinishCaptureUI()
    {
        _cameraCapture.CaptureFinishPortal();

        _touchPanel.SetActive(false);

        _finishPortalCapture.enabled = true;
    }
}