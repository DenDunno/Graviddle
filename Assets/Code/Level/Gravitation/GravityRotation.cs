using System.Collections.Generic;
using UnityEngine;


public class GravityRotation : IUpdate
{
    private readonly CurrentGravityData _currentGravityData;
    private readonly IEnumerable<TransformWithGravityRotation> _transformsToBeRotated;
    private const float _rotationSpeed = 3f;


    public GravityRotation(CurrentGravityData currentGravityData, IEnumerable<TransformWithGravityRotation> transformsToBeRotated)
    {
        _currentGravityData = currentGravityData;
        _transformsToBeRotated = transformsToBeRotated;
    }


    void IUpdate.Update()
    {
        Quaternion targetRotation = _currentGravityData.Data.Rotation;

        foreach (TransformWithGravityRotation transformWithGravityRotation in _transformsToBeRotated)
        {
            Transform transform = transformWithGravityRotation.transform;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}