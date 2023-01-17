using UnityEngine;

public class GravityRotation : MonoBehaviour
{
    private CurrentGravityData _currentGravityData;
    private const float _rotationSpeed = 3f;

    public void Init(CurrentGravityData currentGravityData)
    {
        _currentGravityData = currentGravityData;
    }
    
    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _currentGravityData.Data.Rotation, _rotationSpeed * Time.deltaTime);
    }
}