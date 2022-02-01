using UnityEngine;


public class GravityRotation : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private SwipeHandler _swipeHandler;

    private const float _rotationSpeed = 3f;
    private Quaternion _targetRotation;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        float targetZRotation = GravityDataPresenter.GravityData[gravityDirection].ZRotation;
        _targetRotation = Quaternion.Euler(0, 0, targetZRotation);
    }
    

    void IRestartableComponent.Restart()
    {
        _targetRotation = Quaternion.identity;
    }
}