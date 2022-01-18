using System;
using UnityEngine;


[Serializable]
public class TurretRotationData
{
    [SerializeField] private Character _character;
    [SerializeField] private Transform _transformToBeRotated;

    public Transform Character => _character.transform;
    public Transform TransformToBeRotated => _transformToBeRotated;
    public readonly float RotationSpeed = 0.2f;
}