using UnityEngine;

public class CameraClampingSettingsFactory
{
    private readonly LevelBorders _levelBorders;
    private readonly Camera _camera;

    public CameraClampingSettingsFactory(LevelBorders levelBorders, Camera camera)
    {
        _levelBorders = levelBorders;
        _camera = camera;
    }
    
    public CameraClampingSettings Create()
    {
        float cameraHalfHeight = _camera.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * _camera.aspect;

        CameraBorders cameraBorders = CreateCameraBorders(cameraHalfWidth, cameraHalfHeight);

        return new CameraClampingSettings(cameraBorders, cameraHalfWidth - cameraHalfHeight);
    }

    private CameraBorders CreateCameraBorders(float cameraHalfWidth, float cameraHalfHeight)
    {
        const float tileOffset = 0.75f;
        float widthOffset = cameraHalfWidth - tileOffset;
        float heightOffset = cameraHalfHeight - tileOffset;

        float cameraTopBorder = _levelBorders.Top - heightOffset;
        float cameraDownBorder = _levelBorders.Bottom + heightOffset;
        float cameraLeftBorder = _levelBorders.Left + widthOffset;
        float cameraRightBorder = _levelBorders.Right - widthOffset;

        return new CameraBorders(cameraTopBorder, cameraDownBorder, cameraLeftBorder, cameraRightBorder);
    }
}