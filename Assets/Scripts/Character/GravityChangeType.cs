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

abstract public class GravityChangeType : MonoBehaviour
{
    public static int NumOfRotations { get; private set; } = 0;
    public GravityDirection Direction { get; private set; } = GravityDirection.DOWN;

    private readonly Dictionary<Turn, NewGravitation> _turnToNewGravitaion =
        new Dictionary<Turn, NewGravitation>()
        {
             {Turn.UP    , new NewGravitation (GravityDirection.UP     ,  new Vector2(0  ,  1)) },
             {Turn.DOWN  , new NewGravitation (GravityDirection.DOWN   ,  new Vector2(0  , -1)) },
             {Turn.LEFT  , new NewGravitation (GravityDirection.LEFT   ,  new Vector2(-1 ,  0)) },
             {Turn.RIGHT , new NewGravitation (GravityDirection.RIGHT  ,  new Vector2(1  ,  0)) }
        };

    private readonly Dictionary<GravityDirection, Quaternion> _directionToRotation =
        new Dictionary<GravityDirection, Quaternion>()
        {
            {GravityDirection.DOWN  , Quaternion.AngleAxis(0   , new Vector3(0, 0, 1)) } ,
            {GravityDirection.RIGHT , Quaternion.AngleAxis(90  , new Vector3(0, 0, 1)) } ,
            {GravityDirection.UP    , Quaternion.AngleAxis(180 , new Vector3(0, 0, 1)) } ,
            {GravityDirection.LEFT  , Quaternion.AngleAxis(270 , new Vector3(0, 0, 1)) } ,
        };
    private enum Turn { LEFT , DOWN, RIGHT, UP }
    private Turn _turn;

    protected bool _gravityWasChanged = false;
    private class NewGravitation
    {
        public GravityDirection Direction;
        public Vector2 GravitaionVector;

        public NewGravitation(GravityDirection direction, Vector2 gravityVector)
        {
            Direction = direction;
            GravitaionVector = gravityVector;
        }
    }

    public void MakeStartTurn(GravityDirection startDirection)
    {
        Direction = startDirection;
        ChangeGravitation((Turn)startDirection);
        NumOfRotations = 0;
        _gravityWasChanged = false;
    }

    public Quaternion GetRotation()
    {
        return _directionToRotation[Direction];
    }


    private void ChangeGravitation(Turn turn)
    {
        NewGravitation newGravitation = _turnToNewGravitaion[turn];
        Physics2D.gravity = newGravitation.GravitaionVector;

        float rotationAngle = Math.Abs(Quaternion.Angle(_directionToRotation[Direction], _directionToRotation[newGravitation.Direction]));
        if ((int)rotationAngle == 90) // когда поворот на 90 градусов, персонаж цепляется за пол
            Character.TossingUp.Invoke();

        Direction = newGravitation.Direction;
        _gravityWasChanged = true;
        NumOfRotations++;
    }


    protected void DefineTurn(float sensitivity, float deltaX , float deltaY)
    {
        if (Mathf.Abs(deltaX) + Mathf.Abs(deltaY) > 2 * sensitivity) // достаточно длинное ли смещение
        {

            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY)) // определяем, в какую сторону смещение больше
            {
                _turn = deltaX < -sensitivity ? Turn.LEFT : Turn.RIGHT;
            }

            else
            {
                _turn = deltaY < -sensitivity ? Turn.DOWN : Turn.UP;
            }

            if (Character.IsAlive && Character.IsGrounded) // когда персонаж летит, не происходит смена гравитации
            {
                ChangeGravitation(_turn);
            }

        }
    }


    abstract public bool CheckTouch(Touch touch);
}





