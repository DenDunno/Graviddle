using UnityEngine;

public class GravityRotation : TogglingComponent
{
    private readonly float _rotationSpeed;
    private readonly IGravityState _state;
    private readonly Transform _transform;
    private readonly Quaternion _offset;
    
    public GravityRotation(IGravityState state, Transform transform, int offset = 0, float speed = 3)
    {
        _state = state;
        _rotationSpeed = speed;
        _transform = transform;
        _offset = Quaternion.Euler(0, 0, offset);
    }

    protected override void OnUpdate()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, _state.Data.Rotation * _offset, _rotationSpeed * Time.deltaTime);
    }
}