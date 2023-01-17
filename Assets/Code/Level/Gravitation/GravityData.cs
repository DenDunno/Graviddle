using UnityEngine;

public class GravityData
{
    public readonly GravityDirection GravityDirection;
    public readonly Vector2 GravityVector;
    public readonly int ZRotation;
    public readonly Quaternion Rotation;

    public GravityData(Vector2 gravityVector, int rotationAngle, GravityDirection gravityDirection)
    {
        GravityDirection = gravityDirection;
        GravityVector = gravityVector;
        ZRotation = rotationAngle;
        Rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
