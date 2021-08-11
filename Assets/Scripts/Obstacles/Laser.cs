using UnityEngine;


public class Laser : MonoBehaviour , IRestartableComponent , IObstacle
{    
    void IRestartableComponent.Restart()
    {
    }
}
