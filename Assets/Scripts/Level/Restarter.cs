using UnityEngine;


public class Restarter : MonoBehaviour
{
    [SerializeField] private IRestartableObject[] _objectsToBeRestarted = null;


    public void MakeRestart()
    {
        foreach (IRestartableObject restartableObject in _objectsToBeRestarted)
        {
            restartableObject.Restart();
        }
    }
}
