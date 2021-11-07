using UnityEngine;
using System;


[Serializable]
public class LevelSizeSettings
{
    [SerializeField] private float _topBorder = 0;
    [SerializeField] private float _downBorder = 0;
    [SerializeField] private float _leftBorder = 0;
    [SerializeField] private float _rightBorder = 0;

    private readonly CameraSizeSettings _cameraSizeSettings;
    private float _horizontalLevelCenter;
    private float _verticalLevelCenter;


    public LevelSizeSettings(CameraSizeSettings cameraSizeSettings)
    {
        _cameraSizeSettings = cameraSizeSettings;
        EvaluateLevelSettings();
    }


    private void EvaluateLevelSettings()
    {
        _topBorder -= _cameraSizeSettings.HeightOffset;
        _downBorder += _cameraSizeSettings.HeightOffset;
        _leftBorder += _cameraSizeSettings.WidthOffset;
        _rightBorder -= _cameraSizeSettings.WidthOffset;

        _horizontalLevelCenter = (_rightBorder + _leftBorder) / 2f;
        _verticalLevelCenter = (_topBorder + _downBorder) / 2f;
    }
}
