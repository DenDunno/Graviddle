using UnityEngine;


public class MoveDirection : MonoBehaviour
{
    [SerializeField] private CharacterSpriteFlipping _characterSpriteFlipping;
    [SerializeField] private InputButton[] _inputButtons;
    private CurrentGravityData _currentGravityData;

    public Vector2 Direction { get; private set; }


    public void Init(CurrentGravityData currentGravityData)
    {
        _currentGravityData = currentGravityData;
    }
    
    
    private void Update()
    {
        var state = MovementState.Stop;
        
        TryRun(0, ref state, MovementState.Left);
        TryRun(1, ref state, MovementState.Right);
        
        Direction = _currentGravityData.Data.Rotation * (Vector2.right * (int) state);
    }


    private void TryRun(int buttonIndex, ref MovementState state, MovementState targetState)
    {
        if (_inputButtons[buttonIndex].IsTouching)
        {
            state = targetState;
            _characterSpriteFlipping.FlipCharacter(state);
        }
    }
}