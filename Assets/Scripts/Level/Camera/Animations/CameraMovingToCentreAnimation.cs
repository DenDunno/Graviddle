using DG.Tweening;
using UnityEngine;

public class CameraMovingToCentreAnimation
{
    private const float _duration = 1f;
    private float _horizontalLevelCentre;
    private float _verticalLevelCentre;
    private Transform _mainCamera;
    

    public void Init(LevelBorders borders, Transform mainCamera)
    {
        _mainCamera = mainCamera;
        _horizontalLevelCentre = (borders.Right + borders.Left) / 2f;
        _verticalLevelCentre = (borders.Top + borders.Down) / 2f;
    }
    
    
    public Tween Move()
    {
        _mainCamera.DOMoveX(_horizontalLevelCentre, _duration);
        return _mainCamera.DOMoveY(_verticalLevelCentre, _duration);
    }
}