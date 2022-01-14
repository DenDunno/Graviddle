using UnityEngine;


public class CharacterCapture : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _character;
    [SerializeField] private CameraClamping _cameraClamping;
    private Vector3 _velocity;


    private void LateUpdate()
    {
        float captureTime = EvaluateCaptureTimeFunction(_character.velocity.magnitude);
        Vector3 clampedPosition = _cameraClamping.Clamp(transform.position);
        
        transform.position = Vector3.SmoothDamp(transform.position, clampedPosition, ref _velocity, captureTime);
    }


    private float EvaluateCaptureTimeFunction(float x)
    {
        return 1 / (0.15f * x  + 3.33f);
    }
}