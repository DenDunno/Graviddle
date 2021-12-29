using UnityEngine;


public class CameraZoomPoints : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    private Camera _mainCamera;
    private LevelBorders _levelBorders;
    private float _startZoom;
    private bool _isVerticalZoom;


    public void Init(Camera mainCamera, LevelBorders levelBorders)
    {
        _mainCamera = mainCamera;
        _levelBorders = levelBorders;
        _startZoom = _mainCamera.orthographicSize;
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
        _isVerticalZoom = gravityDirection == GravityDirection.Left || gravityDirection == GravityDirection.Right;
    }


    public float GetCharacterZoom()
    {
        return _startZoom;
    }


    public float GetLevelZoom()
    {
        float levelHeight = _levelBorders.Top - _levelBorders.Down;
        float levelWidth = _levelBorders.Right - _levelBorders.Left;

        if (_isVerticalZoom)
        {
            Algorithms.Swap(ref levelWidth, ref levelHeight);
        }

        return levelHeight / 2f;
    }
}