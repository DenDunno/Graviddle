using System.Collections.Generic;
using UnityEngine;


public class GravityRotations : IUpdatable
{
    private readonly CurrentGravityData _currentGravityData;
    private readonly IEnumerable<Transform> _transformsToBeRotated;
    private const float _rotationSpeed = 3f;


    public GravityRotations(CurrentGravityData currentGravityData, IEnumerable<Transform> transformsToBeRotated)
    {
        _currentGravityData = currentGravityData;
        _transformsToBeRotated = transformsToBeRotated;
    }


    void IUpdatable.Update()
    {
        Quaternion targetRotation = _currentGravityData.Data.Rotation;

        foreach (Transform transform in _transformsToBeRotated)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}