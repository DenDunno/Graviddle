using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class MovementButtons : MoveСontrolType
{
    public void MoveLeft()
    {
        Movement = Move.LEFT;
    }

    public void MoveRight()
    {
        Movement = Move.RIGHT;
    }

    public void Stop()
    {
        Movement = Move.STOP;
    }
}
