using UnityEngine;


public static class CameraClampingSettingsFactory
{
    public static CameraClampingSettings CreateClampingSettings(LevelBorders levelBorders, Camera camera)
    {
        float cameraHalfHeight = camera.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * camera.aspect;

        CameraBorders cameraBorders = CreateCameraBorders(levelBorders, cameraHalfWidth, cameraHalfHeight);

        return new CameraClampingSettings(cameraBorders, cameraHalfWidth - cameraHalfHeight);
    }


    private static CameraBorders CreateCameraBorders(LevelBorders levelBorders, float cameraHalfWidth, float cameraHalfHeight)
    {
        const float tileOffset = 0.75f;
        float widthOffset = cameraHalfWidth - tileOffset;
        float heightOffset = cameraHalfHeight - tileOffset;

        float cameraTopBorder = levelBorders.Top - heightOffset;
        float cameraDownBorder = levelBorders.Down + heightOffset;
        float cameraLeftBorder = levelBorders.Left + widthOffset;
        float cameraRightBorder = levelBorders.Right - widthOffset;

        return new CameraBorders(cameraTopBorder, cameraDownBorder, cameraLeftBorder, cameraRightBorder);
    }
}