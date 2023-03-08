using UnityEngine;

public class BoxGravity : TogglingComponent
{
    private readonly OrientationHandler _orientation = new(0.75f);
    private readonly Transform _transform;
    private readonly BoxGravityView _view;
    private readonly Gravity _gravity;
    private readonly Camera _camera;
    private bool _directionChanged;
    
    public BoxGravity(Gravity gravity, Transform transform, BoxGravityView view)
    {
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
            Vector2 gravityVector = GravityDataPresenter.GravityData[_orientation.LocalDirection].GravityVector;

            _gravity.SetDirection(gravityVector);
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
            _view.SelectDirection(_orientation.LocalDirection);
        }
    }
}