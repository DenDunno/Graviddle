using UnityEngine;


public class CameraControllingSwitcher : ButtonClick
{
    [SerializeField] private bool _activateCameraControlling = false;
    [SerializeField] private CameraControlling _cameraControlling = null;


    protected override void OnButtonClick()
    {
        _cameraControlling.enabled = _activateCameraControlling;
    }
}
