using DG.Tweening;
using UnityEngine;


public class ZoomClick : ButtonClick
{
    [SerializeField] private UIStatesSwitcher _uiSwitcher;
    [SerializeField] private UIState _targetUI;
    [SerializeField] private bool _activateCameraControlling;
    [SerializeField] private CameraAnimation _cameraAnimation;
    [SerializeField] private CharacterCapture _characterCapture;
    

    protected override void OnButtonClick()
    {
        _uiSwitcher.DeactivateStates();
        ToggleCharacterCapture();
        PlayAnimation().OnComplete(_targetUI.Activate);
    }
    

    private void ToggleCharacterCapture()
    {
        _characterCapture.enabled = _activateCameraControlling == false;
    }


    private Tween PlayAnimation()
    {
        return _activateCameraControlling ? _cameraAnimation.ZoomOutAndMoveToCentre() : _cameraAnimation.ZoomIn();
    }
}