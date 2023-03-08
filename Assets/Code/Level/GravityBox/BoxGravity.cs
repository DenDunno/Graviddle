using UnityEngine;

public class BoxGravity : TogglingComponent
{
    private readonly OrientationHandler _orientation = new(0.75f);
    private readonly BoxGravityState _gravityState;
    private readonly Transform _transform;
    private readonly BoxGravityView _view;
    private readonly Gravity _gravity;
    private readonly Camera _camera;
    private bool _directionChanged;
    
    public BoxGravity(Gravity gravity, Transform transform, BoxGravityView view, BoxGravityState gravityState)
    {
        _gravityState = gravityState;
        _transform = transform;
        _camera = Camera.main;
        _gravity = gravity;
        IsActive = false;
        _view = view;
    }

    public void TryChangeDirection()
    {
        if (_directionChanged)
        {
            _gravityState.Direction = _orientation.LocalDirection;
            _gravity.SetDirection(_orientation.LocalDirection);
        }
    }

    protected override void OnUpdate()
    {
        Vector2 delta = GetDelta();
        _orientation.TryChangeDirection(delta);
        UpdateUI(delta);
    }

    private Vector2 GetDelta()
    {
        Vector2 worldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        return worldPoint - (Vector2)_transform.position;
    }

    private void UpdateUI(Vector2 localPoint)
    {
        _view.DeselectAll();
        _directionChanged = localPoint.magnitude > _orientation.Sensitivity;
        
        if (_directionChanged)
        {
            int start = (int)_gravityState.Direction;
            int target = (int)_orientation.LocalDirection;
            int result = target - start;

            if (result < 0)
            {
                result = 4 + result;
            }
            
            _view.SelectDirection((GravityDirection)result);
        }
    }
}