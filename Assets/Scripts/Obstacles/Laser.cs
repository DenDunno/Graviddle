using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Laser : Obstacle , IRestartableComponent
{    
    void IRestartableComponent.Restart()
    {
    }
}
