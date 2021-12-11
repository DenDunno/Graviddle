using System;
using UnityEngine;


public class MoveDirection : MonoBehaviour , IAfterRestartComponent
{
    public Vector2 Direction { get; private set; }


    private void SetMoveDirection(Movement movement)
    {
        try
        {
            Direction = transform.right * (int)movement;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            throw;
        }
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