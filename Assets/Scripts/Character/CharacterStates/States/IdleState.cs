

public class IdleState : CharacterState
{
    private readonly CharacterMovement _movement;
    private readonly SwipeHandler _swipeHandler;
    private bool _wasSwipe = false;


    public IdleState(Character character , SwipeHandler swipeHandler) : base(character)
    {
        _movement = character.GetComponent<CharacterMovement>();
        _swipeHandler = swipeHandler;
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    public override void EnterState()
    {
        _animator.Play("Idle");
    }


    public override CharacterState Update()
    {
        if (_wasSwipe == true)
        {
            _wasSwipe = false;
            return CharacterStates.FallState;
        }

        if (_movement.СharacterMovement != Movement.Stop)
        {
            return CharacterStates.RunningState;
        }

        return this;
    }


    public void OnGravityChanged(GravityDirection gravityDirection)
    {
        _wasSwipe = true;
    }


    ~IdleState()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }
}