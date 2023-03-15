
public class CharacterGravity : ISubscriber
{
    private readonly SwipeHandler _swipeHandler;
    private readonly Gravity _gravity;

    public CharacterGravity(Gravity gravity, SwipeHandler swipeHandler)
    {
        _swipeHandler = swipeHandler;
        _gravity = gravity;
    }

    void ISubscriber.Subscribe()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }

    void ISubscriber.Unsubscribe()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }

    private void OnGravityChanged(GravityDirection direction)
    {
        _gravity.SetDirection(direction);
    }
}