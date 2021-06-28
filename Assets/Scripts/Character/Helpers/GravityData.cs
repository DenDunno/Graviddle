using UnityEngine;


public class GravityData
{
    public readonly Vector2 GravityVector;
    public readonly Quaternion Rotation;


    public GravityData(Vector2 gravityVector, int rotationAngle)
    {
        GravityVector = gravityVector;
        Rotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
