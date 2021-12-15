using UnityEngine;


public class CameraBordersWithOrientation : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    private CameraBorders _cameraBorders;
    private float _orientationOffset;
    private float _cameraWidthHeightDifference;

    public float Top => _cameraBorders.Top - _orientationOffset;
    public float Down => _cameraBorders.Down + _orientationOffset;
    public float Left => _cameraBorders.Left + _orientationOffset;
    public float Right => _cameraBorders.Right - _orientationOffset;


    public void Init(CameraClampingSettings clampingSettings)
    {
        _cameraBorders = clampingSettings.CameraBorders;
        _cameraWidthHeightDifference = clampingSettings.CameraWidthHeightDifference;
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

        _orientationOffset = isHorizontalOrientation ? _cameraWidthHeightDifference : 0;
    }
}