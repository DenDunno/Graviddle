using UnityEngine;


[RequireComponent(typeof(CameraClamping))]
[RequireComponent(typeof(CameraClamping))]
public class CameraPanning : MonoBehaviour
{
    private CameraClamping _cameraClamping;
    private Camera _mainCamera;
    private Vector3 _touchStartPosition;


    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _cameraClamping = GetComponent<CameraClamping>();
    }
    

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 worldTouchPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                _touchStartPosition = worldTouchPosition;
            }

            transform.position = _cameraClamping.Clamp(transform.position + (_touchStartPosition - worldTouchPosition));
        }
    }
}