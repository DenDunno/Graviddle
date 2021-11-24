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

        HeightOffset -= _tileOffset;
        WidthOffset -= _tileOffset;
    }


    public bool CheckIfBorderGreaterLevelBorder(float firstBorder, float secondBorder)
    {
        return WidthOffset * 2f > (Mathf.Abs(firstBorder - secondBorder) + 2 * _tileOffset);
    }
}
