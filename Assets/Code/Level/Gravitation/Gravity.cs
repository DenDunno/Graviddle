using UnityEngine;

public class Gravity : IRestart, ISubscriber
{
    private readonly SwipeHandler _swipeHandler;

    public Gravity(SwipeHandler swipeHandler)
    {
        _swipeHandler = swipeHandler;
        Physics2D.gravity = new Vector2(0, -1);
    }

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
        GravityData gravityData = GravityDataPresenter.GravityData[gravityDirection];

        Physics2D.gravity = gravityData.GravityVector;
    }

    void IRestart.Restart()
    {
        OnGravityChanged(GravityDirection.Down);
    }
}