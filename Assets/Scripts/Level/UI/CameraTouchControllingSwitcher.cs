using UnityEngine;


public class CameraTouchControllingSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera = null;
    [SerializeField] private GameObject _touchPanel = null;
    [SerializeField] private GameObject _cameraPanel = null;

    private CameraTouchControlling _cameraTouchControlling;
    private CharacterCapture _characterCapture;    


    private void Start()
    {
        _cameraTouchControlling = _mainCamera.GetComponent<CameraTouchControlling>();
        _characterCapture = _mainCamera.GetComponent<CharacterCapture>();
    }


    public void ToggleCameraTouchControlling(bool cameraTouchControllingEnabled)
    {
        _touchPanel.SetActive(!cameraTouchControllingEnabled);
        _cameraPanel.SetActive(cameraTouchControllingEnabled);

        _characterCapture.enabled = !cameraTouchControllingEnabled;
        _cameraTouchControlling.enabled = cameraTouchControllingEnabled;
    }
}