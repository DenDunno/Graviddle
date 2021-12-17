using UnityEngine;


public class GravityData
{
    public readonly Vector2 GravityVector;
    public readonly int ZRotation;


    public GravityData(Vector2 gravityVector, int rotationAngle)
    {
        GravityVector = gravityVector;
        ZRotation = rotationAngle;
    }
}
