
public class CameraClampingSettings
{
    public readonly CameraBorders CameraBorders;
    public readonly float CameraWidthHeightDifference;


    public CameraClampingSettings(CameraBorders cameraBorders, float cameraWidthHeightDifference)
    {
        CameraBorders = cameraBorders;
        CameraWidthHeightDifference = cameraWidthHeightDifference;
    }
}