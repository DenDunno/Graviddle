using UnityEngine;

public class CharacterShaderID
{
    public static readonly int HSV = Shader.PropertyToID("_HsvShift");
    public static readonly int Rotation = Shader.PropertyToID("_RotateUvAmount");
    public static readonly int Twist = Shader.PropertyToID("_TwistUvAmount");
    public static readonly int Alpha = Shader.PropertyToID("_Alpha");
}