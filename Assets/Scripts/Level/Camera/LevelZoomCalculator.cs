using UnityEngine;


public class LevelZoomCalculator : MonoBehaviour
{
    [SerializeField] private GravityDirectionPresenter _gravityDirectionPresenter = null;
    [SerializeField] private bool _isLevelWithFrame = false;
    private Camera _mainCamera;
    private LevelBorders _levelBorders;


    public void Init(Camera mainCamera, LevelBorders levelBorders)
    {
        _mainCamera = mainCamera;
        _levelBorders = levelBorders;
    }


    public float GetLevelZoom()
    {
        (float levelWidth, float levelHeight) = GetLevelWidthAndHeight();
        return EvaluateLevelZoom(levelWidth, levelHeight) / 2f;
    }


    private (float, float) GetLevelWidthAndHeight()
    {
        const int frameOffset = 2;
        float levelHeight = _levelBorders.Top - _levelBorders.Down;
        float levelWidth = _levelBorders.Right - _levelBorders.Left;

        if (_isLevelWithFrame)
        {
            levelHeight += frameOffset;
            levelWidth += frameOffset;
        }

        if (IsVerticalZoom())
        {
            Algorithms.Swap(ref levelWidth, ref levelHeight);
        }

        return (levelWidth, levelHeight);
    }


    private bool IsVerticalZoom()
    {
        GravityDirection direction = _gravityDirectionPresenter.GravityDirection;

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