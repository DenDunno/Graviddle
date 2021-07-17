using UnityEngine;


public class UISwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera = null;
    [SerializeField] private GameObject _touchPanel = null;
    [SerializeField] private GameObject _cameraPanel = null;

    private CameraTouchControlling _cameraTouchControlling;
    private CharacterCapture _cameraCapture;    


    private void Start()
    {
        _cameraTouchControlling = _mainCamera.GetComponent<CameraTouchControlling>();
        _cameraCapture = _mainCamera.GetComponent<CharacterCapture>();
    }


    public void SwitchCameraPanel(bool becomeActive)
    {
        _touchPanel.SetActive(!becomeActive);
        _cameraPanel.SetActive(becomeActive);

        _cameraCapture.enabled = !becomeActive;
        _cameraTouchControlling.enabled = becomeActive;
    }
}