using UnityEngine;


public class CharacterGravityData
{
    public readonly Vector2 GravityVector;
    public readonly Quaternion CharacterRotation;

    public CharacterGravityData(Vector2 gravityVector, int rotationAngle)
    {
        GravityVector = gravityVector;
        CharacterRotation = Quaternion.Euler(0, 0, rotationAngle);
    }
}
