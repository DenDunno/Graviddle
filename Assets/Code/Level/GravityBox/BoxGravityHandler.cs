
public class BoxGravityHandler : TogglingComponent, IRestart
{
    private readonly BoxGravitySelection _selection;
    private readonly BoxGravityState _state;
    private readonly Gravity _gravity;

    public BoxGravityHandler(Gravity gravity, BoxGravitySelection selection, BoxGravityState state)
    {
        _selection = selection;
        _gravity = gravity;
        _state = state;
        IsActive = false;
    }

    protected override void OnUpdate()
    {
        _state.Update();
        UpdateUI();
    }

    public void TryChangeDirection()
    {
        if (_state.DirectionChanged)
        {
            _state.UpdateDirection();
            _gravity.SetDirection(_state.TargetGlobalDirection);
        }
    }

    private void UpdateUI()
    {
        if (_state.DirectionChanged)
        {
            _selection.TrySelectDirection(_state.Direction, _state.TargetGlobalDirection);
        }
        else
        {
            _selection.DeselectAll();
        }
    }

    public void Restart()
    {
        _state.Reset();
    }
}