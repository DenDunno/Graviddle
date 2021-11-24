using UnityEngine;


public class GravityRotation : MonoBehaviour 
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private readonly float _rotationSpeed = 3f;
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
        _targetRotation = GravityDataPresenter.GravityData[(int)gravityDirection].Rotation;
    }
}