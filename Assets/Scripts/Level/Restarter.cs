using System.Collections;
using UnityEngine;


public class Restarter : MonoBehaviour
{
    [SerializeField]
    private Obstacle[] _objectsToBeRestarted = null;
    private Character _character;


    private void Start()
    {
        _character = FindObjectOfType<Character>();
    }


    public  void MakeRestart()
    {
        _character.Restart();

        foreach (Obstacle obstacle in _objectsToBeRestarted)
            obstacle.transform.position = obstacle.RestartPosition;
    }
}
