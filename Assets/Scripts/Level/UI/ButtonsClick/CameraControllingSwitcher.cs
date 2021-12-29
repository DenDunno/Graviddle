using DG.Tweening;
using UnityEngine;


public class CameraControllingSwitcher : ButtonClick
{
    [SerializeField] private UIState _viewPanel = null;
    [SerializeField] private UIState _gameplayPanel = null;
    [SerializeField] private bool _activateCameraControlling = false;
    [SerializeField] private CameraZoomAnimation _zoomAnimation = null;
    

    protected override void OnButtonClick()
    {
        PlayZoomAnimation().OnComplete(ActivateUI);
    }


    private Tween PlayZoomAnimation()
    {
        return _activateCameraControlling ? _zoomAnimation.ZoomOutAndMoveToCentre() : _zoomAnimation.ZoomIn();
    }


    private void ActivateUI()
    {
        UIState uiState = _activateCameraControlling ? _viewPanel : _gameplayPanel;

        uiState.ActivateState();
    }
}