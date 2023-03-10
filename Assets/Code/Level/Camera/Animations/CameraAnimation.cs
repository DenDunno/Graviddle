using DG.Tweening;

public class CameraAnimation 
{
    private readonly CameraMovingToCentreAnimation _movingToCentreAnimation;
    private readonly CameraZoomAnimation _zoomAnimation;
    private Tween _animation;
    
    public CameraAnimation(CameraMovingToCentreAnimation movingToCentreAnimation, CameraZoomAnimation zoomAnimation)
    {
        _movingToCentreAnimation = movingToCentreAnimation;
        _zoomAnimation = zoomAnimation;
    }

    public void ZoomIn()
    {
        PlayAnimation(_zoomAnimation.ZoomIn());
    }

    public void ZoomOut()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_movingToCentreAnimation.Move());
        sequence.Join(_zoomAnimation.ZoomOut());
        
        PlayAnimation(sequence);
    }

    private void PlayAnimation(Tween animation)
    {
        Kill();
        _animation = animation;
    }

    public void Kill()
    {
        _animation?.Kill();
    }
}