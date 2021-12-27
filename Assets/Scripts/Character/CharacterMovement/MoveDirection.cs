using UnityEngine;


public class MoveDirection : MonoBehaviour, IAfterRestartComponent
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
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


    private void SetMoveDirection(Movement movement)
    {
        Direction = _gravityRotation * (Vector2.right * (int) movement);
    }


    public void MoveCharacter(Movement movement)
    {
        SetMoveDirection(movement);
    }


    public void StopCharacter() 
    {
        SetMoveDirection(Movement.Stop);
    }


    void IAfterRestartComponent.Restart()
    {
        StopCharacter();
    }
}