using UnityEngine;


public class CameraPanning : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CameraClamping _cameraClamping;

    private Vector3 _touchStartPosition;
    private bool _isUserZooming;


    private void Update()
    {
        if (Input.touchCount > 1)
        {
            _isUserZooming = true;
            return;
        }

        if (Input.GetMouseButton(0))
        {
            MoveCamera();
        }
    }


    private void MoveCamera()
    {
        Vector3 worldTouchPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) || _isUserZooming)
        {
            _isUserZooming = false;
            _touchStartPosition = worldTouchPosition;
        }

        Vector3 targetPosition = _mainCamera.transform.position + (_touchStartPosition - worldTouchPosition);
        targetPosition.z = _mainCamera.transform.position.z;

        _mainCamera.transform.position = _cameraClamping.Clamp(targetPosition);
    }
}