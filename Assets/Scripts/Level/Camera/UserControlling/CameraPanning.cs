using UnityEngine;


public class CameraPanning : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private CameraClamping _cameraClamping = null;

    private Vector3 _touchStartPosition;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldTouchPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                _touchStartPosition = worldTouchPosition;
            }

            Vector3 targetPosition = _mainCamera.transform.position + (_touchStartPosition - worldTouchPosition);
            targetPosition.z = _mainCamera.transform.position.z;

            _mainCamera.transform.position = _cameraClamping.Clamp(targetPosition);
        }
    }
}