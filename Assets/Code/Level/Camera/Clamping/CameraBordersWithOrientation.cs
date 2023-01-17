using UnityEngine;

public class CameraBordersWithOrientation : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler;
    private CameraClampingSettings _cameraClampingSettings;
    private float _orientationOffset;

    public float Top => _cameraClampingSettings.CameraBorders.Top - _orientationOffset;
    public float Down => _cameraClampingSettings.CameraBorders.Down + _orientationOffset;
    public float Left => _cameraClampingSettings.CameraBorders.Left - _orientationOffset;
    public float Right => _cameraClampingSettings.CameraBorders.Right + _orientationOffset;

    public void Init(CameraClampingSettings clampingSettings)
    {
        _cameraClampingSettings = clampingSettings;
    }

    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }

    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }

    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        bool isHorizontalOrientation = gravityDirection == GravityDirection.Down || 
                                       gravityDirection == GravityDirection.Up;

        _orientationOffset = isHorizontalOrientation ? 0 : _cameraClampingSettings.OrientationOffset;
    }
}