using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Laser : MonoBehaviour , IRestartableComponent , IObstacle
{    
    void IRestartableComponent.Restart()
    {
    }
}
