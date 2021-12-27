using UnityEngine;


public class CameraCapture : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _targetRigidbody = null;
    private readonly float _startCaptureTime = 0.3f;
    private CameraClamping _cameraClamping;
    private Transform _mainCamera;
    private Vector3 _velocity;


    private void Start()
    {
        _cameraClamping = Camera.main.GetComponent<CameraClamping>();
        _mainCamera = _cameraClamping.transform;
    }


    private void LateUpdate()
    {
        float captureTime = _startCaptureTime;

        if (_targetRigidbody != null)
        {
            captureTime = EvaluateCaptureTimeFunction(_targetRigidbody.velocity.magnitude);
        }

        _mainCamera.position = Vector3.SmoothDamp(_mainCamera.position, GetClampedPosition(), ref _velocity, captureTime);
    }


    private float EvaluateCaptureTimeFunction(float x)
    {
        return 1 / (0.15f * x  + 3.33f);
    }


    private Vector3 GetClampedPosition()
    {
        Vector3 clampedPosition = _cameraClamping.Clamp(transform.position);
        clampedPosition.z = _mainCamera.transform.position.z;
        
        return clampedPosition;
    }


    public void ResetCameraTransform()
    {
        _mainCamera.position = GetClampedPosition();
        _mainCamera.rotation = transform.rotation;
    }
}