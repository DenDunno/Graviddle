using UnityEngine;


public class TurretRotation : MonoBehaviour
{
    [SerializeField] private TurretRotationData _data;


    public void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _data.TransformToBeRotated.position - _data.Character.position);
        _data.TransformToBeRotated.rotation = Quaternion.Lerp(_data.TransformToBeRotated.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
}
