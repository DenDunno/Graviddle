using UnityEngine;


public class TurretRotationData
{
    public readonly Transform Character;
    public readonly Transform TransformToBeRotated;
    public readonly float RotationSpeed;

    public TurretRotationData(CharacterHead character, Transform transformToBeRotated, float rotationSpeed)
    {
        Character = character.transform;
        TransformToBeRotated = transformToBeRotated;
        RotationSpeed = rotationSpeed;
    }
}