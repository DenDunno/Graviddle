using System;
using UnityEngine;


[Serializable]
public class TurretRotationData
{
    [SerializeField] private CharacterHead _character;
    [SerializeField] private Transform _transformToBeRotated;
    [SerializeField] private float _rotationSpeed = 2f;
    
    public Transform Character => _character.transform;
    public Transform TransformToBeRotated => _transformToBeRotated;
    public float RotationSpeed => _rotationSpeed;
}