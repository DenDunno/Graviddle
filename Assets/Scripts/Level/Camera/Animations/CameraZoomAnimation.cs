using System;
using DG.Tweening;
using UnityEngine;


[Serializable]
public class CameraZoomAnimation
{
    private const float _zoomOutDuration = 1f;
    private const float _zoomInDuration = 0.5f;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LevelZoomCalculator _zoomCalculator;
    private float _characterZoom;


    public void Init()
    {
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