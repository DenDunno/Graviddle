
public class BoxMediator : ISubscriber
{
    private readonly BoxGravityHandler _boxGravityHandler;
    private readonly PhysicsInputTrigger _inputTrigger;
    private readonly SwipeHandler _swipeHandler;
    private readonly IToggleable[] _popUps;

    public BoxMediator(PhysicsInputTrigger inputTrigger, SwipeHandler swipeHandler, BoxGravityHandler boxGravityHandler, IToggleable[] popUps)
    {
        _boxGravityHandler = boxGravityHandler;
        _inputTrigger = inputTrigger;
        _swipeHandler = swipeHandler;
        _popUps = popUps;
    }

    void ISubscriber.Subscribe()
    {
        _inputTrigger.Entered += OnEnter;
        _inputTrigger.Exited += OnExit;
    }

    void ISubscriber.Unsubscribe()
    {
        _inputTrigger.Entered -= OnEnter;
        _inputTrigger.Exited -= OnExit;
    }

    private void OnEnter()
    {
        _popUps.ForEach(popUp => popUp.Show());
        _swipeHandler.IsActive = false;
        _boxGravityHandler.IsActive = true;
    }

    private void OnExit()
    {
        _boxGravityHandler.TryChangeDirection();
        
        _popUps.ForEach(popUp => popUp.Hide());
        _boxGravityHandler.IsActive = false;
        _swipeHandler.IsActive = true;
    }
}