using DG.Tweening;
using UnityEngine;


public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private CameraZoomAnimation _zoomAnimation;
    [SerializeField] private CameraMovingToCentreAnimation _movingToCentreAnimation;
    
    
    public void Init()
    {
        _zoomAnimation.Init();
        _movingToCentreAnimation.Init();
    }


    public Tween ZoomIn()
    {
        return _zoomAnimation.ZoomIn();
    }
    
    
    public Tween ZoomOutAndMoveToCentre()
    {
        _movingToCentreAnimation.Move();
        return _zoomAnimation.ZoomOut();
    }
}
