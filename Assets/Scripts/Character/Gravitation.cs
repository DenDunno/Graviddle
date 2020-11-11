using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Gravitation 
{
    public readonly static Dictionary<GravityDirection, Quaternion> DirectionToQuaternion;


    public readonly static Dictionary<Swipe, NewGravitation> SwipeToNewGravitaion =
        new Dictionary<Swipe, NewGravitation>()
        {
             {Swipe.UP    , new NewGravitation (GravityDirection.UP     ,  new Vector2(0  ,  1)) },
             {Swipe.DOWN  , new NewGravitation (GravityDirection.DOWN   ,  new Vector2(0  , -1)) },
             {Swipe.LEFT  , new NewGravitation (GravityDirection.LEFT   ,  new Vector2(-1 ,  0)) },
             {Swipe.RIGHT , new NewGravitation (GravityDirection.RIGHT  ,  new Vector2(1  ,  0)) }
        };


    public static void ChangeGravity(GravityDirection gravityDirection , Transform transform)
    {

    }
}





