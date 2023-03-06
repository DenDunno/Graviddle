using DG.Tweening;
using UnityEngine;

public class CameraZoomAnimation
{
    private readonly float _characterZoom;
    private readonly Camera _mainCamera;
    private readonly LevelZoomCalculator _zoomCalculator;
    private readonly float _zoomOutDuration = 1f;
    private readonly float _zoomInDuration = 0.5f;

    public CameraZoomAnimation(Camera mainCamera, LevelZoomCalculator zoomCalculator)
    {
        _mainCamera = mainCamera;
        _zoomCalculator = zoomCalculator;
        _characterZoom = _mainCamera.orthographicSize;
    }

    public Tween ZoomOut()
    {
        return ZoomCamera(_characterZoom, _zoomCalculator.GetLevelZoom(), _zoomOutDuration);
    }

    public Tween ZoomIn()
    {
        return ZoomCamera(_mainCamera.orthographicSize, _characterZoom, _zoomInDuration);
    }

    private Tween ZoomCamera(float zoomFrom, float zoomTo, float duration)
    {
        return DOTween.To(x => _mainCamera.orthographicSize = x, zoomFrom, zoomTo, duration);
    }
} 