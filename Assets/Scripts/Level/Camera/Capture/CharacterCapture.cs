using UnityEngine;
using Zenject;


public class CharacterCapture : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [SerializeField] private CameraBorders _cameraBorders = null;
    [Inject] private readonly CharacterStates _characterStates = null;
    
    private float _captureSpeed = 2f;


    private void Start()
    {
        _characterStates.FallState.CharacterGroundedChanged += OnCharacterGroundedChanged;
    }


    private void OnDestroy()
    {
        _characterStates.FallState.CharacterGroundedChanged -= OnCharacterGroundedChanged;
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