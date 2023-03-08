using UnityEngine;

public class GravityRotation : TogglingComponent
{
    private readonly GravityState _state;
    private readonly Transform _transform;
    private readonly float _rotationSpeed = 3f;

    public GravityRotation(GravityState state, Transform transform)
    {
        _state = state;
        _transform = transform;
    }

    protected override void OnUpdate()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, _state.Data.Rotation, _rotationSpeed * Time.deltaTime);
    }
}