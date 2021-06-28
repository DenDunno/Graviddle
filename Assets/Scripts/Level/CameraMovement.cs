using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private Quaternion _targetRotation;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void LateUpdate()
    {
        var cameraPosition = Vector3.Lerp(transform.position, _character.transform.position, 2 * Time.deltaTime);

        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, 2 * Time.deltaTime);
    }


    private void OnGravityChanged(GravityDirection gravityDirection, bool lift)
    {
        _targetRotation = GravityDataPresenter.GravityData[(int)gravityDirection].Rotation;
    }
}
