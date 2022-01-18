using UnityEngine;


public class SphereLerpTurretRotation : MonoBehaviour
{
    [SerializeField] private TurretRotationData _data;
    [SerializeField] private GravityDirectionPresenter _gravityDirectionPresenter;
    private readonly Vector3 _rotationVector = new Vector3(0, 0, 30);


    public void Update()
    {
        Vector2 difference = _data.TransformToBeRotated.position - _data.Character.position;
        float sinus = difference.x / difference.y;
        sinus = Mathf.Pow(sinus, Mathf.Sign(1 - Mathf.Abs(sinus)));
        
        float targetZRotation = Mathf.Asin(sinus) * Mathf.Rad2Deg - 90 * Mathf.Sign(difference.y)  + 90* Mathf.Sign(difference.x);

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZRotation);
        
        _data.TransformToBeRotated.rotation = Quaternion.Lerp(_data.TransformToBeRotated.rotation, targetRotation, Time.deltaTime);
    }
}