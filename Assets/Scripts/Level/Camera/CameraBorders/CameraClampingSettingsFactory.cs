using UnityEngine;


public class CameraClampingSettingsFactory
{
    private readonly float _tileOffset = 0.75f;
    private readonly float _cameraWidthOffset;
    private readonly float _cameraHeightOffset;


    public CameraClampingSettingsFactory(Camera camera)
    {
        _cameraHeightOffset = camera.orthographicSize - _tileOffset;
        _cameraWidthOffset = _cameraHeightOffset * camera.aspect - _tileOffset;
    }


    public CameraClampingSettings CreateClampingSettings(LevelBorders levelBorders)
    {
        CameraBorders cameraBorders = CreateCameraBorders(levelBorders);

        bool cameraWidthGreaterLevelWidth = CheckIfCameraBorderGreaterLevelBorder(cameraBorders.Left, cameraBorders.Right);
        bool cameraHeightGreaterLevelHeight = CheckIfCameraBorderGreaterLevelBorder(cameraBorders.Down, cameraBorders.Top);

        return new CameraClampingSettings(cameraBorders, cameraWidthGreaterLevelWidth, cameraHeightGreaterLevelHeight);
    }


    private bool CheckIfCameraBorderGreaterLevelBorder(float firstBorder, float secondBorder)
    {
        return _cameraWidthOffset * 2f > (Mathf.Abs(firstBorder - secondBorder) + 2 * _tileOffset);
    }


    private CameraBorders CreateCameraBorders(LevelBorders levelBorders)
    {
        float cameraTopBorder = levelBorders.TopBorder - _cameraHeightOffset;
        float cameraDownBorder = levelBorders.DownBorder + _cameraHeightOffset;
        float cameraLeftBorder = levelBorders.LeftBorder + _cameraWidthOffset;
        float cameraRightBorder = levelBorders.RightBorder - _cameraWidthOffset;

        return new CameraBorders(cameraTopBorder, cameraDownBorder, cameraLeftBorder, cameraRightBorder);
    }
}