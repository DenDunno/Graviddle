using UnityEngine;


public class CameraSizeSettings
{
    public float WidthHeightDifference { get; private set; }
    public float HeightOffset { get; private set; }
    public float WidthOffset { get; private set; }
    public float Width { get; private set; }

    private readonly Camera _camera;
    private readonly float _tileOffset = 0.75f;


    public CameraSizeSettings(Camera camera)
    {
        _camera = camera;
        EvaluateCameraSizeSettings();
    }


    private void EvaluateCameraSizeSettings()
    {
        HeightOffset = _camera.orthographicSize;
        WidthOffset = HeightOffset * _camera.aspect;

        WidthHeightDifference = WidthOffset - HeightOffset;
        Width = WidthOffset * 2f;

        HeightOffset -= _tileOffset;
        WidthOffset -= _tileOffset;
    }


    public bool CheckIfGreaterLevelWidth(float rightBorder , float leftBorder)
    {
        return Width > (rightBorder - leftBorder + 2 * _tileOffset);
    }
}
