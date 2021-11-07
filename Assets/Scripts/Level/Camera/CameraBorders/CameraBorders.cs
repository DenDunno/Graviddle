using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraBorders : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private CameraSizeSettings _cameraSizeSettings;
    private LevelSizeSettings _levelSizeSettings;
    private bool _isHorizontalClamping = true;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void Start()
    {
        _cameraSizeSettings = new CameraSizeSettings(GetComponent<Camera>());
        _levelSizeSettings = new LevelSizeSettings(_cameraSizeSettings);
    }


    public void ClampCamera(ref Vector3 cameraPosition)
    {
        float orientationOffset = _isHorizontalClamping ? 0 : _cameraSizeSettings.WidthHeightDifference;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, _leftBorder - orientationOffset, _rightBorder + orientationOffset);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, _downBorder + orientationOffset, _topBorder - orientationOffset);

        if (_isHorizontalClamping)
        {
            if (_isCameraWidthGreaterLevelWidth)
            {
                cameraPosition.x = _horizontalLevelCenter;
            }
        }

        else
        {
            if (_isCameraWidthGreaterLevelWidth)
            {
                cameraPosition.y = _verticalLevelCenter;
            }
        }
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _isHorizontalClamping = (int)gravityDirection % 2 == 0;
    }
}
