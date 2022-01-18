using UnityEngine;


public class TurretRotation : MonoBehaviour
{
    [SerializeField] private TurretRotationData _data;


    public void Update()
    {
        Vector2 difference = _data.TransformToBeRotated.position - _data.Character.position; 
        _data.TransformToBeRotated.up = Vector2.Lerp(_data.TransformToBeRotated.up, difference, _data.RotationSpeed * Time.deltaTime);
    }
}
