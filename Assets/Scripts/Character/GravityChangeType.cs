using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GravityDirection
{
    LEFT,
    DOWN,
    RIGHT,
    UP
}


public class GravityEvent : UnityEvent<GravityDirection> { }


abstract public class GravityChangeType : MonoBehaviour
{
    public static int NumOfRotations { get; private set; } = 0;

    public GravityEvent GravityChanged = new GravityEvent();

    public GravityDirection Direction { get; private set; } = GravityDirection.DOWN;


    private readonly Dictionary<GravityDirection, int> DirectionToRotationAngle =
        new Dictionary<GravityDirection, int>()
        {
            {GravityDirection.DOWN  , 0  } ,
            {GravityDirection.RIGHT , 90 } ,
            {GravityDirection.UP    , 180} ,
            {GravityDirection.LEFT  , 270} ,
        };

    private readonly Dictionary<GravityDirection, Vector2> _directionToGravityVector =
        new Dictionary<GravityDirection, Vector2>()
        {
             {GravityDirection.UP    , new Vector2(0  ,  1)},
             {GravityDirection.DOWN  , new Vector2(0  , -1)},
             {GravityDirection.LEFT  , new Vector2(-1 ,  0)},
             {GravityDirection.RIGHT , new Vector2(1  ,  0)}
        };

    private GravityDirection _lastGravityDirection;
    protected bool _gravityWasChanged = false;



    public void MakeStartTurn(GravityDirection startDirection)
    {
        _lastGravityDirection = startDirection;

        ChangeGravitation(startDirection);

        NumOfRotations = 0;
        _gravityWasChanged = false;
    }


    public Quaternion GetRotation()
    {
        return Quaternion.AngleAxis(DirectionToRotationAngle[Direction], new Vector3(0, 0, 1));
    }


    private void ChangeGravitation(GravityDirection direction)
    {
        Direction = direction;

        GravityChanged.Invoke(_lastGravityDirection);

        Physics2D.gravity = _directionToGravityVector[Direction];

        _gravityWasChanged = true;
        _lastGravityDirection = Direction;
        NumOfRotations++;
    }


    protected void DefineTurn(float sensitivity, float deltaX , float deltaY)
    {
        if (Mathf.Abs(deltaX) + Mathf.Abs(deltaY) > 2 * sensitivity) // достаточно длинное ли смещение
        {

            GravityDirection temp;

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY)) // определяем, в какую сторону смещение больше
            {
                temp = deltaX < -sensitivity ? GravityDirection.LEFT : GravityDirection.RIGHT;
            }

            else
            {
                temp = deltaY < -sensitivity ? GravityDirection.DOWN : GravityDirection.UP;
            }

            if (Character.IsAlive && Character.IsGrounded && Direction != temp) // когда персонаж летит, не происходит смена гравитации
            {
                ChangeGravitation(temp);
            }

        }
    }


    abstract public bool CheckTouch(Touch touch);
}





