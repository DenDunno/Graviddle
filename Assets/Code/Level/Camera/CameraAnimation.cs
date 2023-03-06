using DG.Tweening;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    private CameraZoomAnimation _zoomAnimation;
    private CameraMovingToCentreAnimation _movingToCentreAnimation;

    public void Init(CameraZoomAnimation zoomAnimation, CameraMovingToCentreAnimation movingToCentreAnimation)
    {
        _zoomAnimation = zoomAnimation;
        _movingToCentreAnimation = movingToCentreAnimation;
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
