
public class CameraBordersWithOrientation : ISubscriber
{
    private readonly CameraClampingSettings _cameraClampingSettings;
    private readonly SwipeHandler _swipeHandler;
    private float _orientationOffset;

    public CameraBordersWithOrientation(CameraClampingSettings clampingSettings, SwipeHandler swipeHandler)
    {
        _cameraClampingSettings = clampingSettings;
        _swipeHandler = swipeHandler;
    }

    public float Top => _cameraClampingSettings.CameraBorders.Top - _orientationOffset;
    public float Down => _cameraClampingSettings.CameraBorders.Down + _orientationOffset;
    public float Left => _cameraClampingSettings.CameraBorders.Left - _orientationOffset;
    public float Right => _cameraClampingSettings.CameraBorders.Right + _orientationOffset;

    void ISubscriber.Subscribe()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }

    void ISubscriber.Unsubscribe()
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