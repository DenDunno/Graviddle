using UnityEngine;


[RequireComponent(typeof(CameraBorders))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private CameraBorders _cameraBorders;
    private Quaternion _targetRotation;


    private void Start()
    {
        _cameraBorders = GetComponent<CameraBorders>();
    }


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
        var cameraPosition = _character.transform.position;
        _cameraBorders.ClampCamera(ref cameraPosition);

        cameraPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, 2 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, 2 * Time.deltaTime);
    }


    private void OnGravityChanged(GravityDirection gravityDirection, bool lift)
    {
        _targetRotation = GravityDataPresenter.GravityData[(int)gravityDirection].Rotation;
    }
}
