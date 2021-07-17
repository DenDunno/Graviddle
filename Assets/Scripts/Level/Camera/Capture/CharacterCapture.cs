using UnityEngine;


[RequireComponent(typeof(CameraBorders))]
public class CharacterCapture : MonoBehaviour
{
    [SerializeField] private Character _character = null;        

    private readonly float _captureSpeed = 3f;
    private CameraBorders _cameraBorders;


    private void Start()
    {
        _cameraBorders = GetComponent<CameraBorders>();
    }


    private void LateUpdate()
    {
        Vector3 newCameraPosition = _character.transform.position;
        newCameraPosition.z = transform.position.z;
        
        _cameraBorders.ClampCamera(ref newCameraPosition);

        transform.position = Vector3.Lerp(transform.position, newCameraPosition, _captureSpeed * Time.deltaTime);
    }
}