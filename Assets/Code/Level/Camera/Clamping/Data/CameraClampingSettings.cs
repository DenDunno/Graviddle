
public class CameraClampingSettings
{
    public readonly CameraBorders CameraBorders;
    public readonly float OrientationOffset;

    public CameraClampingSettings(CameraBorders cameraBorders, float orientationOffset)
    {
        CameraBorders = cameraBorders;
        OrientationOffset = orientationOffset;
    }
}