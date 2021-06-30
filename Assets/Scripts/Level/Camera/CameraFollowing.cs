using UnityEngine;


[RequireComponent(typeof(CameraBorders))]
public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private Character _character = null;
   
    private readonly float _movementSpeed = 2f;
    private CameraBorders _cameraBorders;
    

    private void Start()
    {
        _cameraBorders = GetComponent<CameraBorders>();
    }


    private void LateUpdate()
    {
        Vector3 cameraPosition = _character.transform.position;
        cameraPosition.z = transform.position.z;

        _cameraBorders.ClampCamera(ref cameraPosition);

        transform.position = Vector3.Lerp(transform.position, cameraPosition, _movementSpeed * Time.deltaTime);
    }
}
