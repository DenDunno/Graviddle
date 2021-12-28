using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    private Camera _mainCamera;
    private readonly float _zoomSpeed = 2f;


    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
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
        _mainCamera.orthographicSize += zoomCoefficient * _zoomSpeed * Time.deltaTime;
        _mainCamera.orthographicSize = Mathf.Max(_mainCamera.orthographicSize, 1);
    }
}