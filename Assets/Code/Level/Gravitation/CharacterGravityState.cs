
public class CharacterGravityState : ISubscriber, IGravityState
{
    private readonly SwipeHandler _swipeHandler;

    public CharacterGravityState(SwipeHandler swipeHandler)
    {
        _swipeHandler = swipeHandler;
    }

    public GravityDirection Direction { get; private set; } = GravityDirection.Down;

    void ISubscriber.Subscribe()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }

    void ISubscriber.Unsubscribe()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }

    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        Direction = gravityDirection;
    }
}