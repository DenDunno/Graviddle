using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnimationHandler : ISubscriber, IDisposable
{
    private readonly LevelZoomCalculator _zoomCalculator;
    private readonly CameraAnimation _animation;
    private readonly SwipeHandler _swipeHandler;
    private readonly CharacterCapture _capture;
    private readonly Button _zoomOutButton;
    private readonly Button _zoomInButton;

    public CameraAnimationHandler(CameraData data, Camera camera, CharacterCapture capture)
    {
        CameraMovingToCentreAnimation movingToCentreAnimation = new(data.Borders, camera);
        _zoomCalculator = new LevelZoomCalculator(camera, data.Borders);
        CameraZoomAnimation zoomAnimation = new(camera, _zoomCalculator);
        
        _animation = new CameraAnimation(movingToCentreAnimation, zoomAnimation);
        _zoomOutButton = data.ZoomOutButton;
        _zoomInButton = data.ZoomInButton;
        _swipeHandler = data.SwipeHandler;
        _capture = capture;
    }

    void ISubscriber.Subscribe()
    {
        _zoomInButton.onClick.AddListener(ZoomIn);
        _zoomOutButton.onClick.AddListener(ZoomOut);
        _swipeHandler.GravityChanged += TryRecalculateZoom;
    }

    void ISubscriber.Unsubscribe()
    {
        _zoomInButton.onClick.RemoveListener(ZoomIn);
        _zoomOutButton.onClick.RemoveListener(ZoomOut);
        _swipeHandler.GravityChanged -= TryRecalculateZoom;
    }

    private void ZoomIn()
    {
        _animation.ZoomIn();
        _capture.IsActive = true;
    }

    private void ZoomOut()
    {
        _animation.ZoomOut();
        _capture.IsActive = false;
    }

    private void TryRecalculateZoom(GravityDirection direction)
    {
        if (_capture.IsActive == false)
        {
            _zoomCalculator.SetDirection(direction);
            ZoomOut();
        }
    }

    public void Dispose()
    {
        _animation.Kill();
    }
}