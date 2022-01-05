using DG.Tweening;
using UnityEngine;


public class ZoomClick : ButtonClick
{
    [SerializeField] private UIState _targetUI = null;
    [SerializeField] private bool _activateCameraControlling = false;
    [SerializeField] private CameraZoomAnimation _zoomAnimation = null;
    

    protected override void OnButtonClick()
    {
        PlayZoomAnimation().OnComplete(_targetUI.ActivateState);
    }


    private Tween PlayZoomAnimation()
    {
        return _activateCameraControlling ? _zoomAnimation.ZoomOutAndMoveToCentre() : _zoomAnimation.ZoomIn();
    }
}