using UnityEngine;


[System.Serializable]
public class CameraSizeSettings
{
    [SerializeField] private Camera _camera = null;
    private readonly float _tileOffset = 0.75f;
    private readonly float _targetAspect = 1920 / 1080f;

    public float WidthHeightDifference { get; private set; }
    public float HeightOffset { get; private set; }
    public float WidthOffset { get; private set; }
    public float Width { get; private set; }


    public void EvaluateCameraSizeSettings()
    {
        float sizeFitter = _targetAspect / _camera.aspect;

        if (sizeFitter < 1)
        {
            _camera.orthographicSize *= sizeFitter;
        }

        HeightOffset = _camera.orthographicSize;
        WidthOffset = HeightOffset * _camera.aspect;

        WidthHeightDifference = WidthOffset - HeightOffset;
        Width = WidthOffset * 2f;

        HeightOffset -= _tileOffset;
        WidthOffset -= _tileOffset;
    }
}
