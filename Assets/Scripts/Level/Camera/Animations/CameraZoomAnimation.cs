using DG.Tweening;
using UnityEngine;


public class CameraZoomAnimation
{
    private const float _zoomOutDuration = 1f;
    private const float _zoomInDuration = 0.5f;

    private Camera _camera;
    private LevelZoomCalculator _zoomCalculator;
    private float _characterZoom;


    public void Init(Camera mainCamera, LevelZoomCalculator zoomCalculator)
    {
        _camera = mainCamera;
        _zoomCalculator = zoomCalculator;
        _characterZoom = mainCamera.orthographicSize;
    }


    public Tween ZoomOut()
    {
        return ZoomCamera(_characterZoom, _zoomCalculator.GetLevelZoom(), _zoomOutDuration);
    }


    public Tween ZoomIn()
    {
        return ZoomCamera(_camera.orthographicSize, _characterZoom, _zoomInDuration);
    }


    private Tween ZoomCamera(float zoomFrom, float zoomTo, float duration)
    {
        return DOTween.To(x => _camera.orthographicSize = x, zoomFrom, zoomTo, duration);
    }
} 