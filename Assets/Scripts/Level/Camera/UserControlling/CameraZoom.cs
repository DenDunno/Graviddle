using UnityEngine;


public class CameraZoom : MonoBehaviour, IRestart
{
    private Camera _camera;
    private LevelZoomCalculator _levelZoomCalculator;
    private float _characterZoom;
    private readonly float _zoomSpeed = 0.25f;


    public void Init(Camera mainCamera, LevelZoomCalculator zoomCalculator)
    {
        _camera = mainCamera;
        _levelZoomCalculator = zoomCalculator;
        _characterZoom = mainCamera.orthographicSize;
    }


    private void Update()
    {
        if (Input.touchCount == 2)
        {
            float zoomCoefficient = GetZoomCoefficient();
            ZoomCamera(zoomCoefficient);
        }
    }


    private float GetZoomCoefficient()
    {
        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        Vector2 previousFirstTouchPosition = firstTouch.GetPreviousTouchPosition();
        Vector2 previousSecondTouchPosition = secondTouch.GetPreviousTouchPosition();

        float previousDelta = GetDiffInMagnitude(previousFirstTouchPosition, previousSecondTouchPosition);
        float currentDelta = GetDiffInMagnitude(firstTouch.position, secondTouch.position);

        return previousDelta - currentDelta;
    }


    private float GetDiffInMagnitude(Vector2 first, Vector2 second)
    {
        return (first - second).magnitude;
    }


    private void ZoomCamera(float zoomCoefficient)
    {
        float levelZoom = _levelZoomCalculator.GetLevelZoom();

        _camera.orthographicSize += zoomCoefficient * _zoomSpeed * Time.deltaTime;
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _characterZoom, levelZoom);
    }


    void IRestart.Restart()
    {
        _camera.orthographicSize = _characterZoom;
    }
}