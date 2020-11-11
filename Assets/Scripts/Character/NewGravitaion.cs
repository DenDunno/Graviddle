using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGravitation
{
    public GravityDirection Direction;
    public Vector2 GravitaionVector;

    public NewGravitation(GravityDirection direction, Vector2 gravityVector)
    {
        Direction = direction;
        GravitaionVector = gravityVector;
    }
}
