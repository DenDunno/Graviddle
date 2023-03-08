
public class BoxMediator : ISubscriber
{
    private readonly PhysicsInputTrigger _inputTrigger;
    private readonly SwipeHandler _swipeHandler;
    private readonly BoxGravity _boxGravity;
    private readonly IToggleable[] _popUps;

    public BoxMediator(PhysicsInputTrigger inputTrigger, SwipeHandler swipeHandler, BoxGravity boxGravity, IToggleable[] popUps)
    {
        _inputTrigger = inputTrigger;
        _swipeHandler = swipeHandler;
        _boxGravity = boxGravity;
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
        _boxGravity.IsActive = true;
    }

    private void OnExit()
    {
        _popUps.ForEach(popUp => popUp.Hide());
        _boxGravity.TryChangeDirection();
        _boxGravity.IsActive = false;
        _swipeHandler.IsActive = true;
    }
}