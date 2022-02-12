

public class LaserDistortionData
{
    private const float _maxDistortion = 1f;
    private const float _minDistortion = 0.25f;
    private const float _switchingOffDuration = 4f;
    private const float _switchingOnDuration = 2f;


    public float GetDistortion(bool activate)
    {
        return activate ? _minDistortion : _maxDistortion;
    }


    public float GetDistortionDuration(bool activate)
    {
        return activate ? _switchingOnDuration : _switchingOffDuration;
    }
}