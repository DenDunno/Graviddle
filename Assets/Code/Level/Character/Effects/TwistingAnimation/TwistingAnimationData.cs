using UnityEngine;

public class TwistingAnimationData
{
    public readonly int HSV = Shader.PropertyToID("_HsvShift");
    public readonly int Rotation = Shader.PropertyToID("_RotateUvAmount");
    public readonly int Twist = Shader.PropertyToID("_TwistUvAmount");
    public readonly int Alpha = Shader.PropertyToID("_Alpha");
    public readonly int WaveStrength = Shader.PropertyToID("_RoundWaveStrength");
    public readonly int WaveSpeed = Shader.PropertyToID("_RoundWaveSpeed");

    public readonly float BrightenDuration = 2f;
    public readonly float FadeDuration = 5f;
    public readonly float WaitTime = 1f;
}