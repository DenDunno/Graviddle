using UnityEngine;


public class TurretRotation : MonoBehaviour
{
    [SerializeField] private TurretRotationData _data;


    public void Update()
    {
        // Vector2 difference = _data.TransformToBeRotated.position - _data.Character.position; 
        // _data.TransformToBeRotated.up = Vector2.Lerp(_data.TransformToBeRotated.up, difference, _data.RotationSpeed * Time.deltaTime);
        
        // var neededRotation = Quaternion.LookRotation(Vector3.forward, _data.TransformToBeRotated.position - _data.Character.position);
        // _data.TransformToBeRotated.transform.rotation = Quaternion.Slerp(transform.rotation,neededRotation, _data.RotationSpeed * Time.deltaTime);
        
        // _data.TransformToBeRotated.rotation = Quaternion.LookRotation(Vector3.forward, _data.TransformToBeRotated.position - _data.Character.position);
        
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _data.TransformToBeRotated.position - _data.Character.position);
        _data.TransformToBeRotated.rotation = Quaternion.Lerp(_data.TransformToBeRotated.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
}
