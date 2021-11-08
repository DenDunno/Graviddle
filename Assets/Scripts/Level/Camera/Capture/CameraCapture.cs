using UnityEngine;


public class CameraCapture : MonoBehaviour
{
    private CaptureUpdate _captureUpdate;
    private CameraCapturePresenter _capturePresenter;
    private CameraBorders _cameraBorders;
    private Transform _mainCamera;
    private Rigidbody2D _rigidbody;
    private readonly float _velocityToChangeUpdateMethod = 14f;


    private void Start()
    {
        _capturePresenter = Camera.main.GetComponent<CameraCapturePresenter>();
        _cameraBorders = _capturePresenter.GetComponent<CameraBorders>();
        _mainCamera = _capturePresenter.transform;
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        _captureUpdate = new CaptureUpdate(_mainCamera, transform, _cameraBorders);
    }
    

    private void LateUpdate()
    {
        TryMoveCamera(_rigidbody.velocity.magnitude < _velocityToChangeUpdateMethod);
    }


    public void FixedUpdate()
    {
        TryMoveCamera(_rigidbody.velocity.magnitude > _velocityToChangeUpdateMethod);
    }


    private void TryMoveCamera(bool cameraMovementCondition)
    {
        if (cameraMovementCondition)
        {
            _captureUpdate.MoveCamera();
        }
    }


    public void CaptureMe()
    {
        if (_capturePresenter == null)
        {
            Start();
        }
            
        _capturePresenter.CaptureObject(this);
    }


    public void ResetCameraTransform()
    {
        _mainCamera.position = _captureUpdate.GetNewPosition();
        _mainCamera.rotation = transform.rotation;
    }
}