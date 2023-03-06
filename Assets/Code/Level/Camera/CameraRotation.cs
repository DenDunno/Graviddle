using UnityEngine;

public class CameraRotation : ILateUpdate
{
    private readonly Transform _transform;
    private readonly Character _character;
    private readonly float _speed = 6f;

    public CameraRotation(Character character, Transform transform)
    {
        _character = character;
        _transform = transform;
    }

    void ILateUpdate.LateUpdate()
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation , _character.transform.rotation , _speed * Time.deltaTime);
    }
}