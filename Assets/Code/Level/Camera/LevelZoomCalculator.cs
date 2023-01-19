using UnityEngine;

public class LevelZoomCalculator : MonoBehaviour
{
    [SerializeField] private bool _isLevelWithFrame;
    private CurrentGravityData _currentGravityData;
    private Camera _mainCamera;
    private LevelBorders _levelBorders;
    private const float _frameOffset = 2;

    public void Init(Camera mainCamera, LevelBorders levelBorders)
    {
        _mainCamera = mainCamera;
        _levelBorders = levelBorders;
    }
    
    public void Init(CurrentGravityData currentGravityData)
    {
        _currentGravityData = currentGravityData;
    }

    public float GetLevelZoom()
    {
        (float levelWidth, float levelHeight) = GetLevelWidthAndHeight();
        return EvaluateLevelZoom(levelWidth, levelHeight) / 2f;
    }

    private (float, float) GetLevelWidthAndHeight()
    {
        float levelHeight = _levelBorders.Top - _levelBorders.Bottom;
        float levelWidth = _levelBorders.Right - _levelBorders.Left;

        if (_isLevelWithFrame)
        {
            levelHeight += _frameOffset;
            levelWidth += _frameOffset;
        }

        if (IsVerticalZoom())
        {
            Algorithms.Swap(ref levelWidth, ref levelHeight);
        }

        return (levelWidth, levelHeight);
    }

    private bool IsVerticalZoom()
    {
        GravityDirection direction = _currentGravityData.Data.GravityDirection;

        return direction == GravityDirection.Right || direction == GravityDirection.Left;
    }

    private float EvaluateLevelZoom(float levelWidth, float  levelHeight)
    {
        float levelZoom = levelHeight;
        float predictedCameraWidth = levelZoom * _mainCamera.aspect;

        if (levelWidth > predictedCameraWidth)
        {
            levelZoom = levelWidth / _mainCamera.aspect;
        }

        return levelZoom;
    }
}