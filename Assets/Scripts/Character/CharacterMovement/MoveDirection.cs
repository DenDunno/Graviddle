using UnityEngine;


public class MoveDirection : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private InputButton[] _inputButtons;
    [SerializeField] private CharacterSpriteFlipping _characterSpriteFlipping;
    private Quaternion _gravityRotation;
    
    public Vector2 Direction { get; private set; }
    

    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void Update()
    {
        var state = MovementState.Stop;
        TryRun(0, ref state, MovementState.Left);
        TryRun(1, ref state, MovementState.Right);
        
        Direction = _gravityRotation * (Vector2.right * (int) state);
    }


    private void TryRun(int buttonIndex, ref MovementState state, MovementState targetState)
    {
        if (_inputButtons[buttonIndex].IsTouching)
        {
            state = targetState;
            _characterSpriteFlipping.FlipCharacter(state);
        }
    }

    
    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        float zRotation = GravityDataPresenter.GravityData[gravityDirection].ZRotation;

        _gravityRotation = Quaternion.Euler(0, 0, zRotation);
    }
}