using UnityEngine;


public class Character : MonoBehaviour , IRestartableObject
{
    public bool IsAlive { get; private set; } = true;
    

    void IRestartableObject.Restart()
    {
    }
}



