using UnityEngine;

public class TurretFasteningRotation : IUpdate
{
    private readonly TurretRotationData _data;
    private readonly CurrentGravityData _currentGravityData;
    private readonly Transform _transform;
    private const float _rightAngle = 90;

    public TurretFasteningRotation(TurretRotationData data, CurrentGravityData currentGravityData, Transform transform)
    {
        _data = data;
        _currentGravityData = currentGravityData;
        _transform = transform;
    }

    void IUpdate.Update()
    {
        Vector2 normal = _currentGravityData.Data.GravityVector;
        float zOffset = _currentGravityData.Data.ZRotation;
        
        Vector2 characterInLaserSpace = _transform.InverseTransformPoint(_data.Character.position);
        float crossProduct = normal.x * (normal.y - characterInLaserSpace.y) - normal.y * (normal.x - characterInLaserSpace.x);

        float targetZRotation = (_rightAngle - Vector3.SignedAngle(normal, characterInLaserSpace, Vector3.up)) * Mathf.Sign(crossProduct) + zOffset;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);

        _data.TransformToBeRotated.rotation = Quaternion.Lerp(_data.TransformToBeRotated.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
}