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
    public static int NumOfRotations = 0;
    public GravityDirection Direction { get; private set; } = GravityDirection.DOWN;

    protected readonly Dictionary<Turn, NewGravitation> _turnToNewGravitaion =
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
    protected enum Turn { DOWN, LEFT, RIGHT, UP }
    protected Turn _turn;

    protected class NewGravitation
    {
        public GravityDirection Direction;
        public Vector2 GravitaionVector;

        public NewGravitation(GravityDirection direction, Vector2 gravityVector)
        {
            Direction = direction;
            GravitaionVector = gravityVector;
        }
    }


    public Quaternion GetRotation()
    {
        return _directionToRotation[Direction];
    }

    protected void ChangeGravitation(Turn turn)
    {
        NewGravitation newGravitation = _turnToNewGravitaion[turn];
        Physics2D.gravity = newGravitation.GravitaionVector;
        Direction = newGravitation.Direction;

        NumOfRotations++;
    }


    virtual public void LoadData() { }
}





