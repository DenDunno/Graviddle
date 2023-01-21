using UnityEngine;

public static class CharacterShaderID
{
    public static readonly int HSV = Shader.PropertyToID("_HsvShift");
    public static readonly int Rotation = Shader.PropertyToID("_RotateUvAmount");
    public static readonly int Twist = Shader.PropertyToID("_TwistUvAmount");
    public static readonly int Alpha = Shader.PropertyToID("_Alpha");
    public static readonly int WaveStrength = Shader.PropertyToID("_RoundWaveStrength");
    public static readonly int WaveSpeed = Shader.PropertyToID("_RoundWaveSpeed");
}