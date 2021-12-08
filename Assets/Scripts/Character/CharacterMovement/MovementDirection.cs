using UnityEngine;


public class MovementDirection : MonoBehaviour , IAfterRestartComponent
{
    public Vector2 MoveDirection { get; private set; }


    private void SetMoveDirection(Movement movement)
    {
        MoveDirection = transform.right * (int)movement;
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