

public class LaserDistortionData
{
    private readonly float _maxDistortion = 1f;
    private readonly float _minDistortion = 0.25f;
    private readonly float _switchingOffDuration = 4f;
    private readonly float _switchingOnDuration = 2f;


    public float GetDistortion(bool activate)
    {
        return activate ? _minDistortion : _maxDistortion;
    }


    public float GetDistortionDuration(bool activate)
    {
        return activate ? _switchingOnDuration : _switchingOffDuration;
    }
}