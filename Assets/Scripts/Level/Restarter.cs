using UnityEngine;


public class Restarter : MonoBehaviour
{
    [SerializeField] private IRestartableObject[] _objectsToBeRestarted = null;


    public void MakeRestart()
    {
        foreach (var restartableObject in _objectsToBeRestarted)
        {
            restartableObject.Restart();
        }
    }
}
