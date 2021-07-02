using UnityEngine;


public class Character : MonoBehaviour , IRestartableObject
{
    private bool _isAlive = true;
    

    void IRestartableObject.Restart()
    {
    }
}



