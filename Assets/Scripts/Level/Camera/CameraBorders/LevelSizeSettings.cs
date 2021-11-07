using UnityEngine;
using System;


[Serializable]
public class LevelSizeSettings
{
    [SerializeField] private float _topBorder = 0;
    [SerializeField] private float _downBorder = 0;
    [SerializeField] private float _leftBorder = 0;
    [SerializeField] private float _rightBorder = 0;
    [SerializeField] private CameraSizeSettings _cameraSizeSettings = null;

    private readonly float _tileOffset = 0.75f;
    private float _horizontalLevelCenter;
    private float _verticalLevelCenter;


    public void EvaluateLevelSettings()
    {
        _cameraSizeSettings.EvaluateCameraSizeSettings();

        _topBorder -= _cameraSizeSettings.HeightOffset;
        _downBorder += _cameraSizeSettings.HeightOffset;
        _leftBorder += _cameraSizeSettings.WidthOffset;
        _rightBorder -= _cameraSizeSettings.WidthOffset;

        _horizontalLevelCenter = (_rightBorder + _leftBorder) / 2f;
        _verticalLevelCenter = (_topBorder + _downBorder) / 2f;
    }


    public void ClampCamera(ref Vector3 cameraPosition, bool isHorizontalClamping)
    {
        float orientationOffset = isHorizontalClamping ? 0 : _cameraSizeSettings.WidthHeightDifference;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, _leftBorder - orientationOffset, _rightBorder + orientationOffset);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, _downBorder + orientationOffset, _topBorder - orientationOffset);
    }
}
