using UnityEngine;


public static class CameraClampingSettingsFactory
{
    private static readonly float _tileOffset = 0.75f;


    public static CameraClampingSettings CreateClampingSettings(LevelBorders levelBorders, Camera camera)
    {
        float cameraHeight = camera.orthographicSize - _tileOffset;
        float cameraWidth = cameraHeight * camera.aspect - _tileOffset;

        CameraBorders cameraBorders = CreateCameraBorders(levelBorders, cameraWidth, cameraHeight);

        return new CameraClampingSettings(cameraBorders, cameraWidth - cameraHeight);
    }


    private static CameraBorders CreateCameraBorders(LevelBorders levelBorders, float cameraWidth, float cameraHeight)
    {
        float cameraTopBorder = levelBorders.Top - cameraHeight;
        float cameraDownBorder = levelBorders.Down + cameraHeight;
        float cameraLeftBorder = levelBorders.Left + cameraWidth;
        float cameraRightBorder = levelBorders.Right - cameraWidth;

        return new CameraBorders(cameraTopBorder, cameraDownBorder, cameraLeftBorder, cameraRightBorder);
    }
}