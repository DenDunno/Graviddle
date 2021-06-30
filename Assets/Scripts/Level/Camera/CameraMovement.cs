using System;
using UnityEngine;


[RequireComponent(typeof(CameraBorders))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [SerializeField] private Character _character = null;

    private readonly float _rotationSpeed = 3f;
    private Quaternion _targetRotation;

    private float _movementSpeed = 2f;
    private CameraBorders _cameraClamping;
    

    private void Start()
    {
        _cameraClamping = GetComponent<CameraBorders>();
    }


    private void OnEnable()
    {
        CharacterStates.FallState.GroundedChanged += OnGroundedChanged;
        _swipeHandler.GravityChanged += OnGravityChanged;
    }

    
    private void OnDisable()
    {
        CharacterStates.FallState.GroundedChanged -= OnGroundedChanged;
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void LateUpdate()
    {
        Vector3 cameraPosition = _character.transform.position;

        _cameraClamping.ClampCamera(ref cameraPosition);

        cameraPosition += transform.up * 4.7f;
        cameraPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, _movementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
    }


    private void OnGroundedChanged(bool isGrounded)
    {
        _movementSpeed = isGrounded ? 2 : 6;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _targetRotation = GravityDataPresenter.GravityData[(int)gravityDirection].Rotation;
    }
}
