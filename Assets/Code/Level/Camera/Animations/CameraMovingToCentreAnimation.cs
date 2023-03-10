using DG.Tweening;
using UnityEngine;

public class CameraMovingToCentreAnimation
{
    private readonly float _horizontalLevelCentre;
    private readonly float _verticalLevelCentre;
    private readonly Transform _transform;
    private const float _duration = 1f;

    public CameraMovingToCentreAnimation(LevelBorders levelBorders, Camera mainCamera)
    {
        _transform = mainCamera.transform;
        _horizontalLevelCentre = (levelBorders.Right + levelBorders.Left) / 2f;
        _verticalLevelCentre = (levelBorders.Top + levelBorders.Bottom) / 2f;
    }

    public Tween Move()
    {
        Sequence animation = DOTween.Sequence();
        animation.Append(_transform.DOMoveX(_horizontalLevelCentre, _duration));
        animation.Join(_transform.DOMoveY(_verticalLevelCentre, _duration));
        animation.SetLink(_transform.gameObject);

        return animation;
    }
}