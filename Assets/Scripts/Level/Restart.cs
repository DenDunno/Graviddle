using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    private IEnumerable<IRestartableObject> _restartableObjects = null;
    private readonly float _restartTime = 0.7f;
    private Backstage _backstage;


    private void Start()
    {
        _restartableObjects = FindObjectsOfType<MonoBehaviour>().OfType<IRestartableObject>();        
        _backstage = GetComponent<Backstage>();
    }


    public void MakeRestart()
    {
        StartCoroutine(_backstage.MakeFade(RestartObjects()));
    }


    private IEnumerator RestartObjects()
    {
        foreach(IRestartableObject restartableObject in _restartableObjects)
        {
            restartableObject.Restart();
        }
        
        yield return new WaitForSeconds(_restartTime);
    }
}
