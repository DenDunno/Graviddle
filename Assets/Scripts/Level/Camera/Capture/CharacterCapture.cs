using UnityEngine;


[RequireComponent(typeof(CameraBorders))]
public class CharacterCapture : MonoBehaviour 
{
    [SerializeField] private Character _character = null;        

    private float _captureSpeed = 2f;
    private CameraBorders _cameraBorders;


    private void Start()
    {
        _cameraBorders = GetComponent<CameraBorders>();
        CharacterStates.FallState.CharacterGroundedChanged += OnCharacterGroundedChanged;
    }


    private void OnDestroy()
    {
        CharacterStates.FallState.CharacterGroundedChanged -= OnCharacterGroundedChanged;
    }

    
    private void OnCharacterGroundedChanged(bool isGrounded) 
    {
        _captureSpeed = isGrounded ? 2f : 6f;
    }


    private void LateUpdate()
    {
        Vector3 newCameraPosition = _character.transform.position;
        newCameraPosition.z = transform.position.z;
        
        _cameraBorders.ClampCamera(ref newCameraPosition);

        transform.position = Vector3.Lerp(transform.position, newCameraPosition, _captureSpeed * Time.deltaTime);
    }
}