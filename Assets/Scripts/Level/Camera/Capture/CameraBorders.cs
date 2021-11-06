using UnityEngine;


public class CameraBorders : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    [SerializeField] private float _topBorder = 0;
    [SerializeField] private float _downBorder = 0;
    [SerializeField] private float _leftBorder = 0;
    [SerializeField] private float _rightBorder = 0;

    private float _widthHeightDifference;
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
        const float tileOffset = 0.75f;

        float heightOffset = Camera.main.orthographicSize;
        float widthOffset = heightOffset * Camera.main.aspect;

        heightOffset -= tileOffset;
        widthOffset -= tileOffset;

        _topBorder -= heightOffset;
        _downBorder += heightOffset;
        _leftBorder += widthOffset;
        _rightBorder -= widthOffset;

        _widthHeightDifference = widthOffset - heightOffset;
    }


    public void ClampCamera(ref Vector3 cameraPosition)
    {
        float orientationOffset = _isHorizontalClamping ? 0 : _widthHeightDifference;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, _leftBorder - orientationOffset, _rightBorder + orientationOffset);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, _downBorder + orientationOffset, _topBorder - orientationOffset);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _isHorizontalClamping = (int)gravityDirection % 2 == 0;
    }
}
