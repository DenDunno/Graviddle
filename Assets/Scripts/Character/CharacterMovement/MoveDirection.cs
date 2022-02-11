using UnityEngine;


public class MoveDirection : MonoBehaviour, IRestart
{
    [SerializeField] private SwipeHandler _swipeHandler;
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


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        float zRotation = GravityDataPresenter.GravityData[gravityDirection].ZRotation;

        _gravityRotation = Quaternion.Euler(0, 0, zRotation);
    }


    public void SetMovementDirection(MovementState movementState)
    {
        Direction = _gravityRotation * (Vector2.right * (int) movementState);
    }


    void IRestart.Restart()
    {
        SetMovementDirection(MovementState.Stop);
    }
}