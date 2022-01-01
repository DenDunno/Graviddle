

public class LaserData
{
    private readonly float MaxDistortion = 1f;
    private readonly float MinDistortion = 0.25f;
    private readonly float MaxDistortionSpeed = 2f;
    private readonly float MinDistortionSpeed = 1f;


    public float GetNoiseDistortion(bool activate)
    {
        return activate ? MinDistortion : MaxDistortion;
    }


    public float GetDistortionSpeed(bool activate)
    {
        return activate ? MinDistortionSpeed : MaxDistortionSpeed;
    }
}