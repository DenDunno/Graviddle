using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Obstacle , IRestartableObject
{    
    void IRestartableObject.Restart()
    {
    }
}
