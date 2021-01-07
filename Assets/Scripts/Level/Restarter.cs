using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Restarter : MonoBehaviour
{
    [SerializeField]
    private List<RestartableObject> _objectsToBeRestarted = null;


    private void Start()
    {
        Character character = FindObjectOfType<Character>();
        StartPortal startPortal = FindObjectOfType<StartPortal>();

        _objectsToBeRestarted.Add(character);
        _objectsToBeRestarted.Add(startPortal);
    }


    public  void MakeRestart()
    {
        foreach (RestartableObject restartableObject in _objectsToBeRestarted)
            restartableObject.Restart();
    }
}
