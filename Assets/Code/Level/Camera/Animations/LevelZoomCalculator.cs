using UnityEngine;

public class LevelZoomCalculator
{
    private GravityDirection _gravityDirection = GravityDirection.Down;
    private readonly LevelBorders _levelBorders;
    private readonly float _frameOffset = 1.5f;
    private readonly Camera _mainCamera;
    private bool _isLevelWithFrame;

    public LevelZoomCalculator(Camera mainCamera, LevelBorders levelBorders)
    {        
        _levelBorders = levelBorders;
        _mainCamera = mainCamera;
    }

    public void SetDirection(GravityDirection direction)
    {
        _gravityDirection = direction;
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
        return _gravityDirection is GravityDirection.Right or GravityDirection.Left;
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