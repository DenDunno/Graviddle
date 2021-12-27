using UnityEngine;


public class CameraControllingSwitcher : ButtonClick
{
    [SerializeField] private bool _activateCameraControlling = false;
    [SerializeField] private CameraPanning _cameraPanning = null;
    [SerializeField] private CameraZoom _cameraZoom = null;


    protected override void OnButtonClick()
    {
        _cameraZoom.enabled = _activateCameraControlling;
        _cameraPanning.enabled = _activateCameraControlling;
    }
}
