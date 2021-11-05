using UnityEngine;
using Zenject;


public class CharacterCapture : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [SerializeField] private CameraBorders _cameraBorders = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    
    private float _captureSpeed = 2f;


    private void Start()
    {
        _characterStatesPresenter.FallState.CharacterFalling += OnCharacterFalling;
    }


    private void OnDestroy()
    {
        _characterStatesPresenter.FallState.CharacterFalling -= OnCharacterFalling;
    }

    
    private void OnCharacterFalling() 
    {
    }


    private void LateUpdate()
    {
        Vector3 newCameraPosition = _character.transform.position;
        newCameraPosition.z = transform.position.z;
        
        _cameraBorders.ClampCamera(ref newCameraPosition);

        transform.position = Vector3.Lerp(transform.position, newCameraPosition, _captureSpeed * Time.deltaTime);
    }
}