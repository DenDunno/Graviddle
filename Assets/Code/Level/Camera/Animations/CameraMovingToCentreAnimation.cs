using DG.Tweening;
using UnityEngine;

public class CameraMovingToCentreAnimation
{
    private readonly float _horizontalLevelCentre;
    private readonly float _verticalLevelCentre;
    private readonly Camera _mainCamera;
    private const float _duration = 1f;

    public CameraMovingToCentreAnimation(LevelBorders levelBorders, Camera mainCamera)
    {
        _mainCamera = mainCamera;
        _horizontalLevelCentre = (levelBorders.Right + levelBorders.Left) / 2f;
        _verticalLevelCentre = (levelBorders.Top + levelBorders.Bottom) / 2f;
    }

    public Tween Move()
    {
        _mainCamera.transform.DOMoveX(_horizontalLevelCentre, _duration);
        return _mainCamera.transform.DOMoveY(_verticalLevelCentre, _duration);
    }
}