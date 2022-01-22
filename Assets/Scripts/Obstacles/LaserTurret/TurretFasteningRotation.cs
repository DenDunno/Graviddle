using UnityEngine;


public class TurretFasteningRotation : MonoBehaviour
{
    [SerializeField] private TurretRotationData _data;
    [SerializeField] private GravityDirectionPresenter _gravityDirectionPresenter;
    private const float _rightAngle = 90;


    public void Update()
    {
        GravityData currentGravityData = _gravityDirectionPresenter.GravityData;
        Vector2 normal = currentGravityData.GravityVector;
        float zOffset = currentGravityData.ZRotation;
        
        Vector2 characterInLaserSpace = transform.InverseTransformPoint(_data.Character.position);
        float crossProduct = normal.x * (normal.y - characterInLaserSpace.y) - normal.y * (normal.x - characterInLaserSpace.x);

        float targetZRotation = (_rightAngle - Vector3.SignedAngle(normal, characterInLaserSpace, Vector3.up)) * Mathf.Sign(crossProduct) + zOffset;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);

        _data.TransformToBeRotated.rotation = Quaternion.Lerp(_data.TransformToBeRotated.rotation, targetRotation, _data.RotationSpeed * Time.deltaTime);
    }
}