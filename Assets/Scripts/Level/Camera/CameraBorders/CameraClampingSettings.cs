
public readonly struct CameraClampingSettings
{
    public readonly CameraBorders CameraBorders;
    public readonly bool CameraWidthGreaterLevelWidth;
    public readonly bool CameraHeightGreaterLevelHeight;


    public CameraClampingSettings(CameraBorders cameraBorders, bool cameraWidthGreaterLevelWidth, bool cameraHeightGreaterLevelHeight)
    {
        CameraBorders = cameraBorders;
        CameraWidthGreaterLevelWidth = cameraWidthGreaterLevelWidth;
        CameraHeightGreaterLevelHeight = cameraHeightGreaterLevelHeight;
    }
}