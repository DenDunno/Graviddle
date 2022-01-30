using UnityEngine;


public class MoveDirection : MonoBehaviour, IAfterRestartComponent
{
    [SerializeField] private GravityDirectionHandler _gravityDirectionHandler;
    private Quaternion _gravityRotation;
    public Vector2 Direction { get; private set; }
    public MovementState State { get; private set; }
        

    private void OnEnable()
    {
        _gravityDirectionHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _gravityDirectionHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        float zRotation = GravityDataPresenter.GravityData[gravityDirection].ZRotation;

        _gravityRotation = Quaternion.Euler(0, 0, zRotation);
    }


    public void SetMovementState(MovementState movementState)
    {
        Direction = _gravityRotation * (Vector2.right * (int) movementState);
        State = movementState;
    }


    void IAfterRestartComponent.Restart()
    {
        SetMovementState(MovementState.Stop);
    }
}