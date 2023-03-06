using UnityEngine;

public class CharacterCapture : ILateUpdate
{
    private readonly CameraClamping _cameraClamping;
    private readonly Rigidbody2D _character;
    private readonly Transform _transform;
    private Vector3 _velocity;

    public CharacterCapture(Character character, Transform transform, CameraBordersWithOrientation borders)
    {
        _character = character.GetComponent<Rigidbody2D>();
        _cameraClamping = new CameraClamping(borders);
        _transform = transform;
    }

    void ILateUpdate.LateUpdate()
    {
        float captureTime = EvaluateCaptureTimeFunction(_character.velocity.magnitude);
        Vector3 clampedPosition = _cameraClamping.Clamp(_character.transform.position);

        _transform.position = Vector3.SmoothDamp(_transform.position, clampedPosition, ref _velocity, captureTime);
    }

    private float EvaluateCaptureTimeFunction(float x)
    {
        return 1 / (0.15f * x  + 3.33f);
    }
}