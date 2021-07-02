using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Backstage))]
public class Restart : MonoBehaviour
{
    //[SerializeField] private UnityEvent AfterRestart = null;
    private IEnumerable<IRestartableObject> _restartableObjects = null;
    private readonly float _restartTime = 0.7f;
    private Backstage _backstage;


    private void Start()
    {
        _restartableObjects = FindObjectsOfType<MonoBehaviour>().OfType<IRestartableObject>();        
        _backstage = GetComponent<Backstage>();
    }


    public void ActivateRestart()
    {
        StartCoroutine(MakeRestart());
    }


    private IEnumerator MakeRestart()
    {
        yield return StartCoroutine(_backstage.MakeFade(RestartObjects()));
        //AfterRestart?.Invoke();
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
