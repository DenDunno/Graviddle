using DG.Tweening;
using UnityEngine;


public class ZoomClick : ButtonClick
{
    [SerializeField] private UIState _targetUI;
    [SerializeField] private bool _activateCameraControlling;
    [SerializeField] private CameraZoomAnimation _zoomAnimation;
    

    protected override void OnButtonClick()
    {
        PlayZoomAnimation().OnComplete(_targetUI.ActivateState);
    }


    private Tween PlayZoomAnimation()
    {
        return _activateCameraControlling ? _zoomAnimation.ZoomOut() : _zoomAnimation.ZoomIn();
    }
}