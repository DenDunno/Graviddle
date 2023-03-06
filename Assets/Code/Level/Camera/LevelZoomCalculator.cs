using UnityEngine;

public class LevelZoomCalculator
{
    private readonly CurrentGravityData _currentGravityData;
    private readonly LevelBorders _levelBorders;
    private readonly float _frameOffset = 2;
    private readonly Camera _mainCamera;
    private bool _isLevelWithFrame;

    public LevelZoomCalculator(Camera mainCamera, LevelBorders levelBorders, CurrentGravityData currentGravityData)
    {
        _currentGravityData = currentGravityData;
        _levelBorders = levelBorders;
        _mainCamera = mainCamera;
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

        levelHeight += _frameOffset;
        levelWidth += _frameOffset;

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