using System;
using DG.Tweening;
using UnityEngine;


[Serializable]
public class CameraMovingToCentreAnimation
{
    [SerializeField] private LevelBorders _levelBorders;
    [SerializeField] private Camera _mainCamera;
    private float _horizontalLevelCentre;
    private float _verticalLevelCentre;
    private const float _duration = 1f;    
    

    public void Init()
    {
        _horizontalLevelCentre = (_levelBorders.Right + _levelBorders.Left) / 2f;
        _verticalLevelCentre = (_levelBorders.Top + _levelBorders.Down) / 2f;
    }
    
    
    public Tween Move()
    {
        _mainCamera.transform.DOMoveX(_horizontalLevelCentre, _duration);
        return _mainCamera.transform.DOMoveY(_verticalLevelCentre, _duration);
    }
}