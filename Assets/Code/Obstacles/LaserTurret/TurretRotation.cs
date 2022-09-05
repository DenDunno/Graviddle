using UnityEngine;


public class TurretRotation : IUpdate
{
    private readonly TurretRotationData _data;

    
    public TurretRotation(TurretRotationData data)
    {
        _data = data;
    }


    void IUpdate.Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _data.TransformToBeRotated.position - _data.Character.position);
        _data.TransformToBeRotated.rotation = Quaternion.Lerp(_data.TransformToBeRotated.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
}
